using DataModelingTool.Application;
using DataModelingTool.Domain;
using DataModelingTool.Infrastructure;

var tests = new List<(string Name, Action Test)>
{
    ("Filename generation normalizes names", FilenameGenerationNormalizesNames),
    ("Reader resolver selects markdown reader", ReaderResolverSelectsMarkdown),
    ("Validation catches missing relationship entity", ValidationCatchesMissingRelationshipEntity),
    ("Validation accepts coherent metadata", ValidationAcceptsCoherentMetadata)
};

var failures = 0;
foreach (var (name, test) in tests)
{
    try
    {
        test();
        Console.WriteLine($"PASS {name}");
    }
    catch (Exception ex)
    {
        failures++;
        Console.WriteLine($"FAIL {name}: {ex.Message}");
    }
}

return failures == 0 ? 0 : 1;

static void FilenameGenerationNormalizesNames()
{
    var generator = new MetadataFileNameGenerator();
    AssertEqual("order-to-cash.entity-metadata.json", generator.GetEntityMetadataFileName("Order to Cash"));
    AssertEqual("customer-onboarding.business-object-metadata.json", generator.GetBusinessObjectMetadataFileName("Customer/Onboarding"));
}

static void ReaderResolverSelectsMarkdown()
{
    var resolver = new BusinessSpecificationReaderResolver(
    [
        new PlainTextBusinessSpecificationReader(),
        new MarkdownBusinessSpecificationReader()
    ]);

    var reader = resolver.Resolve("sample.md");
    AssertTrue(reader is MarkdownBusinessSpecificationReader, "Expected markdown reader.");
}

static void ValidationCatchesMissingRelationshipEntity()
{
    var validation = new MetadataValidationService();
    var result = validation.Validate(
        new EntityMetadataDocument
        {
            Application = new ApplicationMetadata { Name = "Test" },
            Entities = [new EntityDefinition { Name = "Order", Properties = [new PropertyDefinition { Name = "Id", IsKey = true }] }],
            Relationships = [new RelationshipDefinition { Name = "Bad", From = "OrderItem", To = "Order", ForeignKey = "OrderId" }]
        },
        new BusinessObjectMetadataDocument
        {
            Application = new ApplicationMetadata { Name = "Test" },
            BusinessObjects = [new BusinessObjectDefinition { Name = "Order", Entity = "Order", RootEntity = "Order", Entities = ["Order"] }]
        });

    AssertTrue(!result.IsValid, "Expected validation failure.");
}

static void ValidationAcceptsCoherentMetadata()
{
    var validation = new MetadataValidationService();
    var result = validation.Validate(
        new EntityMetadataDocument
        {
            Application = new ApplicationMetadata { Name = "Test" },
            Entities =
            [
                new EntityDefinition { Name = "Order", Properties = [new PropertyDefinition { Name = "Id", IsKey = true }] },
                new EntityDefinition { Name = "OrderItem", Properties = [new PropertyDefinition { Name = "Id", IsKey = true }, new PropertyDefinition { Name = "OrderId" }] }
            ],
            Relationships = [new RelationshipDefinition { Name = "Order_OrderItem", From = "OrderItem", To = "Order", ForeignKey = "OrderId" }]
        },
        new BusinessObjectMetadataDocument
        {
            Application = new ApplicationMetadata { Name = "Test" },
            BusinessObjects = [new BusinessObjectDefinition { Name = "Order", Entity = "Order", RootEntity = "Order", Entities = ["Order", "OrderItem"] }]
        });

    AssertTrue(result.IsValid, string.Join(", ", result.Issues.Select(i => i.Message)));
}

static void AssertEqual(string expected, string actual)
{
    if (!string.Equals(expected, actual, StringComparison.Ordinal))
    {
        throw new InvalidOperationException($"Expected '{expected}', got '{actual}'.");
    }
}

static void AssertTrue(bool value, string message)
{
    if (!value)
    {
        throw new InvalidOperationException(message);
    }
}
