You are a senior enterprise solution architect and .NET engineer.

Build a production-quality Generic AI-Assisted Data Modeling Tool in .NET.

The application must be implemented as a command-line / console tool.

Do NOT build REST APIs.
Do NOT build ASP.NET Core controllers.
Do NOT require Swagger or an HTTP host.

The purpose of the tool is to accept a Business Specification document
from a file path, pass the extracted business specification together
with an AI instruction document to an AI Metadata Modeling Agent, and
generate metadata JSON files into a specified output folder.

The generated metadata represents the entities, relationships,
business objects, operations, profiling definitions, and data quality
rules required to support the business process described by the
Business Specification.

The tool must be generic and must NOT be limited to Master Data
Management.

====================================================
1. EXECUTION MODEL
====================================================

The tool shall be invoked from the command line.

Example:

dotnet run --project DataModelingTool.CLI -- \
  --business-spec "C:\Specs\OrderToCash.docx" \
  --instructions "C:\AIInstructions\metadata-generation-generic-data-modeling.md" \
  --output "C:\GeneratedMetadata\OrderToCash"

The tool should also work after publishing:

DataModelingTool.exe \
  --business-spec "C:\Specs\OrderToCash.docx" \
  --instructions "C:\AIInstructions\metadata-generation-generic-data-modeling.md" \
  --output "C:\GeneratedMetadata\OrderToCash"

Required command-line arguments:

--business-spec
    Full path of the Business Specification document.

--output
    Folder in which generated metadata must be written.

Optional command-line arguments:

--instructions
    Path of the AI instruction document.

    If omitted, use:
    ./AIInstructions/metadata-generation-generic-data-modeling.md

--generation-mode
    Allowed values:
    Create
    Regenerate
    Enhance
    Modify

    Default:
    Create

--existing-entity-metadata
    Optional path to an existing Entity Metadata JSON file.

--existing-business-object-metadata
    Optional path to an existing Business Object Metadata JSON file.

--comments
    Optional user instruction supplied to the AI agent.

--application-name
    Optional explicit application/business-process name.

====================================================
2. PRIMARY FLOW
====================================================

The execution flow must be:

1. Parse command-line arguments.
2. Validate input paths.
3. Validate output folder.
4. Read the Business Specification document.
5. Extract business specification text.
6. Load the AI instruction document.
7. Load existing metadata if supplied.
8. Construct MetadataGenerationRequest.
9. Pass request to IMetadataModelingAgent.
10. Receive strongly typed structured response.
11. Validate Entity Metadata.
12. Validate Business Object Metadata.
13. Cross-validate both metadata documents.
14. Report unresolved ambiguities and warnings.
15. Generate metadata JSON files.
16. Write files into the specified output directory.
17. Generate a generation-summary JSON file.
18. Return appropriate process exit code.

Conceptual flow:

Business Spec File
        |
        v
Document Extraction
        |
        +----------------------+
                               |
AI Instruction File           |
        |                      |
        +----------+-----------+
                   |
                   v
          Metadata Modeling Agent
                   |
          Structured AI Response
                   |
        +----------+-----------+
        |                      |
        v                      v
 Entity Metadata       Business Object Metadata
        |                      |
        +----------+-----------+
                   |
                   v
            Validation Engine
                   |
                   v
           Output File Writer
                   |
                   v
             Output Folder

====================================================
3. PROJECT STRUCTURE
====================================================

Use a Clean Architecture style solution.

DataModelingTool.sln

src/

DataModelingTool.CLI
DataModelingTool.Application
DataModelingTool.Domain
DataModelingTool.Infrastructure
DataModelingTool.AI

tests/

DataModelingTool.UnitTests
DataModelingTool.IntegrationTests

Responsibilities:

DataModelingTool.CLI
    Command-line entry point
    Argument parsing
    Console output
    Exit codes
    Application orchestration startup

DataModelingTool.Application
    Metadata generation use cases
    Commands / handlers if MediatR is used
    DTOs
    Interfaces
    Validators
    Orchestration

DataModelingTool.Domain
    Metadata domain models
    Entity models
    Business Object models
    Relationship models
    Validation rules
    Generation result models
    Ambiguity models

DataModelingTool.Infrastructure
    File-system access
    Document reading
    JSON writing
    Existing metadata loading
    Optional generation history storage

DataModelingTool.AI
    AI provider abstraction
    OpenAI implementation
    Agent instruction loading
    Prompt construction
    Structured response handling

====================================================
4. TECHNOLOGY
====================================================

Use:

.NET 8 or later
Microsoft.Extensions.Hosting
Dependency Injection
Options pattern
Microsoft.Extensions.Logging
FluentValidation
System.CommandLine or another appropriate .NET CLI parser
Official OpenAI .NET SDK

Document-processing libraries suitable for:
DOCX
PDF
TXT
Markdown

Use async programming and CancellationToken throughout.
Do NOT introduce ASP.NET Core Web API unless required internally by a library.

====================================================
5. CLI COMMAND
====================================================

Provide a command such as:

datamodel generate

Example:

datamodel generate \
  --business-spec ./specs/order-to-cash.docx \
  --output ./generated/order-to-cash

A richer command can be:

datamodel metadata generate \
  --business-spec ./specs/order-to-cash.docx \
  --instructions ./AIInstructions/metadata-generation-generic-data-modeling.md \
  --output ./generated/order-to-cash \
  --generation-mode Create

====================================================
6. COMMAND-LINE OPTIONS MODEL
====================================================

Create a strongly typed options model.

Example:

public sealed class GenerateMetadataOptions
{
    public required string BusinessSpecificationPath { get; init; }
    public required string OutputDirectory { get; init; }
    public string? AgentInstructionPath { get; init; }
    public GenerationMode GenerationMode { get; init; } = GenerationMode.Create;
    public string? ExistingEntityMetadataPath { get; init; }
    public string? ExistingBusinessObjectMetadataPath { get; init; }
    public string? ApplicationName { get; init; }
    public string? Comments { get; init; }
}

====================================================
7. BUSINESS SPECIFICATION READER
====================================================

Create:

public interface IBusinessSpecificationReader
{
    bool CanRead(string fileExtension);

    Task<BusinessSpecificationDocument> ReadAsync(
        string filePath,
        CancellationToken cancellationToken);
}

BusinessSpecificationDocument should contain:
FileName
FullPath
ContentType
ExtractedText
Sections if identifiable

Provide readers for:
.docx
.pdf
.txt
.md

Create IBusinessSpecificationReaderResolver to select the appropriate reader.

====================================================
8. AI INSTRUCTION PROVIDER
====================================================

Create:

public interface IAgentInstructionProvider
{
    Task<string> GetInstructionsAsync(
        string? instructionFilePath,
        CancellationToken cancellationToken);
}

Default instructions:
AIInstructions/metadata-generation-generic-data-modeling.md

Do NOT copy the contents of this instruction corpus into C# classes.
Use the supplied metadata-generation-generic-data-modeling.md as the initial AI agent instruction corpus.

====================================================
9. AI AGENT ABSTRACTION
====================================================

Create:

public interface IMetadataModelingAgent
{
    Task<MetadataGenerationResult> GenerateMetadataAsync(
        MetadataGenerationRequest request,
        CancellationToken cancellationToken);
}

MetadataGenerationRequest should contain:
ApplicationName
BusinessSpecification
AgentInstructions
GenerationMode
ExistingEntityMetadata
ExistingBusinessObjectMetadata
UserComments

MetadataGenerationResult should contain:
EntityMetadata
BusinessObjectMetadata
Ambiguities
Warnings
GenerationSummary

====================================================
10. OPENAI IMPLEMENTATION
====================================================

Create OpenAiMetadataModelingAgent using the official OpenAI .NET SDK.

Responsibilities:
- Accept MetadataGenerationRequest
- Pass AgentInstructions as system/domain instructions
- Pass BusinessSpecification as the source business context
- Include existing metadata when generation mode requires it
- Request structured output
- Deserialize into MetadataGenerationResult
- Validate deserialization
- Handle retries for transient failures
- Handle cancellation
- Never expose API keys

Configuration example:

{
  "OpenAI": {
    "ApiKey": "",
    "Model": ""
  }
}

API key should preferably come from OPENAI_API_KEY.

====================================================
11. AI INSTRUCTION CONTRACT
====================================================

The AI request conceptually contains:

SYSTEM:
<contents of metadata-generation-generic-data-modeling.md>

USER:
Business Specification:
<business specification extracted text>

Generation Mode:
<Create / Regenerate / Enhance / Modify>

Existing Entity Metadata:
<optional>

Existing Business Object Metadata:
<optional>

Additional User Comments:
<optional>

TASK:
Analyze the supplied Business Specification and generate:
1. Entity Metadata
2. Business Object Metadata
according to the provided modeling instructions.

Do not silently invent undefined business semantics.
Return unresolved ambiguities separately.

====================================================
12. TWO-METADATA-FILE CONTRACT
====================================================

Generate two primary JSON documents.

Entity Metadata:
- application
- audit if required
- entities
- relationships

Must NOT contain:
- businessObjects
- profiling
- dataQualityRules

Business Object Metadata:
- application
- audit if required
- analysisGenerationMode if supported
- businessObjects

Must NOT contain:
- top-level entities
- top-level relationships

This split is mandatory.

====================================================
13. OUTPUT FILE NAMING CONVENTION
====================================================

Use a deterministic naming convention.

Example Business Specification: Order to Cash
Normalized name: order-to-cash

Generated files:
order-to-cash.entity-metadata.json
order-to-cash.business-object-metadata.json
order-to-cash.generation-summary.json

Optional:
order-to-cash.ambiguities.json
order-to-cash.warnings.json

====================================================
14. NORMALIZED FILE NAME GENERATOR
====================================================

Create IMetadataFileNameGenerator.

File naming rules:
- lowercase
- words separated with "-"
- remove illegal file-system characters
- collapse duplicate separators
- no timestamps in primary metadata file names
- stable naming across regenerations

====================================================
15. OUTPUT DIRECTORY STRUCTURE
====================================================

/generated/order-to-cash/
    order-to-cash.entity-metadata.json
    order-to-cash.business-object-metadata.json
    order-to-cash.generation-summary.json

If ambiguities exist:
    order-to-cash.ambiguities.json

If warnings exist:
    order-to-cash.warnings.json

====================================================
16. REVISION / HISTORY OPTION
====================================================

Primary generated files should always have stable names.

Optional history:
/generated/order-to-cash/history/revision-0001/
/generated/order-to-cash/history/revision-0002/

Do not require a database merely for version history.
The filesystem can be the initial persistence mechanism.

====================================================
17. METADATA OUTPUT WRITER
====================================================

Create IMetadataOutputWriter.

Responsibilities:
- Create output directory if missing
- Generate deterministic filenames
- Serialize JSON using indented formatting
- Preserve UTF-8
- Avoid partial/corrupt writes
- Write via temporary file and atomic replace where practical
- Optionally create history revision
- Return full paths of generated files

====================================================
18. OUTPUT EXAMPLE
====================================================

Command:

datamodel generate \
  --business-spec "./specs/order-to-cash.docx" \
  --output "./output"

Console:

Reading business specification...
Loaded: order-to-cash.docx

Loading AI agent instructions...
Loaded: metadata-generation-generic-data-modeling.md

Analyzing business process...

Discovered:
  Business Objects : 8
  Entities         : 14
  Relationships    : 17
  Data Quality Rules: 12
  Ambiguities      : 2

Validating metadata...
Metadata validation successful.

Generated:
./output/order-to-cash.entity-metadata.json
./output/order-to-cash.business-object-metadata.json
./output/order-to-cash.generation-summary.json

Generation completed successfully.

====================================================
19. APPLICATION NAME DISCOVERY
====================================================

Resolve application/process name in this order:
1. --application-name command-line option
2. Business-process/application name discovered from Business Specification
3. Business Specification file name

Do not allow the AI to generate a completely different application name on every run.

====================================================
20. ENTITY METADATA EXAMPLE
====================================================

order-to-cash.entity-metadata.json

{
  "application": {
    "name": "OrderToCash"
  },
  "entities": [
    {
      "name": "SalesOrder",
      "description": "Represents a customer's commercial request to purchase products or services.",
      "properties": [
        {
          "name": "Id",
          "type": "int",
          "isKey": true,
          "identity": true
        },
        {
          "name": "OrderNumber",
          "type": "string",
          "required": true
        },
        {
          "name": "CustomerId",
          "type": "int",
          "required": true
        }
      ]
    },
    {
      "name": "SalesOrderItem",
      "description": "Represents an individual product or service requested as part of a sales order.",
      "properties": []
    }
  ],
  "relationships": [
    {
      "name": "SalesOrder_SalesOrderItems",
      "type": "OneToMany",
      "from": "SalesOrderItem",
      "to": "SalesOrder",
      "foreignKey": "SalesOrderId"
    }
  ]
}

====================================================
21. BUSINESS OBJECT METADATA EXAMPLE
====================================================

order-to-cash.business-object-metadata.json

{
  "application": {
    "name": "OrderToCash"
  },
  "businessObjects": [
    {
      "name": "SalesOrder",
      "category": "Transaction",
      "description": "Represents the complete customer sales order transaction.",
      "entity": "SalesOrder",
      "rootEntity": "SalesOrder",
      "entities": [
        "SalesOrder",
        "SalesOrderItem"
      ],
      "operations": [
        { "name": "Create", "type": "Create" },
        { "name": "Submit", "type": "Submit" },
        { "name": "Confirm", "type": "Custom" },
        { "name": "Cancel", "type": "Custom" },
        { "name": "Search", "type": "Search" }
      ],
      "profiling": {
        "enabled": true,
        "summaries": []
      },
      "dataQualityRules": []
    }
  ]
}

====================================================
22. GENERATION SUMMARY
====================================================

Generate <application>.generation-summary.json containing:
- applicationName
- sourceFile
- generationMode
- generatedOn
- counts/statistics
- output file names

====================================================
23. METADATA VALIDATION
====================================================

Create IMetadataValidationService.

Validate before writing final files:
- Every relationship refers to valid entities.
- Every foreign key exists.
- Every Business Object entity exists.
- Every rootEntity exists.
- Every profiling field exists.
- Every DQ entity exists.
- Every DQ field exists.
- Every lookup entity exists.
- Entity names are unique.
- Property names are unique within entity.
- Relationship names are unique.
- Business Object names are unique.
- Rule codes are unique.
- Profiling summary codes are unique.
- Entity metadata contains no Business Objects.
- Business Object metadata contains no top-level Entities.

====================================================
24. VALIDATION FAILURE
====================================================

If structural validation fails:
- Do NOT write primary metadata files as successful output.
- Write <application>.generation-errors.json
- Return non-zero exit code.

====================================================
25. AMBIGUITY HANDLING
====================================================

Do not treat business ambiguities as technical failures.
Write unresolved ambiguities to <application>.ambiguities.json.
Metadata can still be generated when the ambiguity does not make the structural model invalid.

====================================================
26. GENERATION MODES
====================================================

Support:
Create
Regenerate
Enhance
Modify

Create: Generate new metadata.
Regenerate: Generate again from the Business Specification.
Enhance: Use existing metadata and enrich descriptions, profiling, DQ rules, operations, or other supported semantics while preserving stable names.
Modify: Use the Business Specification plus existing metadata to apply explicit business changes.

====================================================
27. STABILITY REQUIREMENT
====================================================

When existing metadata is supplied, preserve stable:
- Entity names
- Property names
- Business Object names
- Relationship names
- Rule codes
- Profiling summary codes

unless the underlying business meaning changed.

====================================================
28. FILESYSTEM SERVICE
====================================================

Create an IFileSystemService abstraction to make CLI behavior testable.

====================================================
29. ORCHESTRATOR
====================================================

Create IMetadataGenerationOrchestrator.

Execution steps:
ValidateArguments
ReadBusinessSpecification
LoadAgentInstructions
LoadExistingMetadata
GenerateMetadataUsingAI
ValidateMetadata
WriteMetadata
WriteDiagnostics
ReturnExecutionResult

Program.cs should remain thin.

====================================================
30. EXIT CODES
====================================================

Use predictable process exit codes:
0 Successful generation
1 Unexpected application failure
2 Invalid command-line arguments
3 Input file not found / unreadable
4 Document extraction failure
5 AI generation failure
6 AI response deserialization failure
7 Metadata validation failure
8 Output writing failure

====================================================
31. LOGGING
====================================================

Log source file name, generation mode, processing stage, duration,
counts of discovered artifacts, validation outcome, and generated paths.

Do not log the full Business Specification text, API keys, or full prompts by default.

====================================================
32. TESTING
====================================================

Create unit and integration tests for:
- CLI argument parsing
- Application-name normalization
- Filename generation
- Business Specification reader resolution
- AI response deserialization
- Metadata validation
- Output writer
- Ambiguity serialization
- End-to-end Business Spec -> Mock AI -> JSON files

====================================================
33. SAMPLE COMMANDS
====================================================

datamodel generate \
 --business-spec "./samples/customer.md" \
 --output "./output/customer"

datamodel generate \
 --business-spec "./samples/order-to-cash.docx" \
 --output "./output/order-to-cash"

datamodel generate \
 --business-spec "./samples/mamp-business-spec.pdf" \
 --output "./output/mamp"

====================================================
34. REQUIRED DELIVERABLES
====================================================

Generate working code for:
- Solution structure
- CLI project
- Command-line parser
- Domain metadata models
- Business Specification readers
- Instruction provider
- AI abstraction
- OpenAI implementation
- Structured AI output contracts
- Metadata validation service
- Metadata output writer
- Filename generation
- Generation orchestrator
- Dependency injection
- Configuration
- Logging
- Error handling
- Tests
- Sample Business Specification
- Sample generated Entity Metadata
- Sample generated Business Object Metadata
- README

====================================================
35. IMPORTANT IMPLEMENTATION PRINCIPLE
====================================================

This is a batch metadata-generation tool.

It should be possible to run it from:
- Developer workstation
- CI/CD pipeline
- Shell script
- PowerShell
- Scheduled batch job
- Other application process

The tool should have no dependency on a web server.

INPUT:
Business Specification file path
AI Agent instruction file path
Optional existing metadata
Generation options

OUTPUT:
Entity Metadata JSON
Business Object Metadata JSON
Generation Summary
Optional Ambiguities / Warnings

====================================================
36. FINAL EXPECTATION
====================================================

Do not merely provide an architecture document.
Generate a complete compilable .NET solution.
Build incrementally and make sure it compiles.

The most important end-to-end scenario is:

datamodel generate \
   --business-spec <path> \
   --output <folder>

which must result in:

<folder>/<business-name>.entity-metadata.json
<folder>/<business-name>.business-object-metadata.json
<folder>/<business-name>.generation-summary.json

using the supplied AI instruction corpus to determine how the Business Specification should be interpreted.
