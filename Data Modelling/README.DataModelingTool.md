# DataModelingTool

`DataModelingTool` is a .NET 8 command-line tool that reads a Business Specification document and generates two primary metadata files:

- `<business-name>.entity-metadata.json`
- `<business-name>.business-object-metadata.json`

It also writes `<business-name>.generation-summary.json`, plus ambiguity, warning, or validation error files when applicable.

## Build

```powershell
dotnet build DataModelingTool.sln
```

## Run

```powershell
dotnet run --project src\DataModelingTool.CLI -- generate `
  --business-spec .\samples\customer.md `
  --instructions .\AIInstructions\metadata-generation-generic-data-modeling.md `
  --output .\output\customer
```

The richer command form is also accepted:

```powershell
dotnet run --project src\DataModelingTool.CLI -- metadata generate `
  --business-spec .\samples\customer.md `
  --output .\output\customer `
  --generation-mode Create
```

## Projects

- `DataModelingTool.CLI`: command-line entry point, DI, logging, exit codes.
- `DataModelingTool.Application`: orchestration, interfaces, filename generation, validation.
- `DataModelingTool.Domain`: metadata contracts and result models.
- `DataModelingTool.Infrastructure`: filesystem, document readers, instruction provider, JSON writer.
- `DataModelingTool.AI`: `IMetadataModelingAgent` implementation boundary.

## Microsoft Agent Framework

The AI layer uses Microsoft Agent Framework through `Microsoft.Agents.AI`.

`DataModelingTool.AI` registers `MicrosoftAgentFrameworkMetadataModelingAgent`, which:

- creates an OpenAI-backed `IChatClient`
- wraps it as an `AIAgent` with `AsAIAgent(...)`
- runs the metadata-generation task with `RunAsync(...)`
- deserializes the agent JSON response into `MetadataGenerationResult`

Configure live model execution with:

```powershell
$env:OPENAI_API_KEY = "<your key>"
```

Optionally set the model in `src\DataModelingTool.CLI\appsettings.json`:

```json
{
  "OpenAI": {
    "ApiKey": "",
    "Model": "gpt-4o-mini"
  }
}
```

When no API key is configured, the tool uses deterministic local generation so builds, tests, and CI runs can still execute without calling a model.

## Tests

The tests are package-free console runners:

```powershell
dotnet run --project tests\DataModelingTool.UnitTests
dotnet run --project tests\DataModelingTool.IntegrationTests
```
