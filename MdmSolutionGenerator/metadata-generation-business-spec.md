# Business Specification Corpus for MDM Metadata Generation

## Purpose

This document is a reusable business specification corpus for an AI agent that must generate two metadata JSON files for `SolutionGeneratorService`:

1. Entity metadata JSON containing only entities and relationships.
2. Business object metadata JSON containing only business objects, associated entities, profiling definitions, and data quality rules.

The generated metadata must support enterprise master data management use cases such as Customer, Vendor, Material, Finance, Location, and Reference Data.

## Metadata Split Contract

The AI agent must never generate a single full metadata file containing both `entities` and `businessObjects`.

Generate two separate files:

### Entity Metadata File

The entity metadata file may contain:

- `application`
- `audit`
- `entities`
- `relationships`

The entity metadata file must not contain:

- `businessObjects`
- `profiling`
- `dataQualityRules`

### Business Object Metadata File

The business object metadata file may contain:

- `application`
- `audit`
- `analysisGenerationMode`
- `businessObjects`

The business object metadata file must not contain:

- `entities`
- `relationships`

## Core Definitions

### Entity

An entity represents one database table or persisted data object.

Examples:

- Customer
- CustomerAddress
- CustomerContact
- Vendor
- VendorBankAccount
- Material
- MaterialPlant
- Country
- Currency

Each entity should define:

- Name
- Primary key
- Properties
- Data types
- Required flags
- Length constraints
- Unique constraints
- Index hints
- Allowed values where meaningful

### Relationship

A relationship describes how two entities are connected.

Use `OneToMany` for root-to-child relationships.

Example:

```json
{
  "name": "Customer_CustomerAddresses",
  "type": "OneToMany",
  "from": "CustomerAddress",
  "to": "Customer",
  "foreignKey": "CustomerId"
}
```

In this convention:

- `from` is the child/dependent entity.
- `to` is the parent/principal entity.
- `foreignKey` is the property on the child entity.

### Business Object

A business object is a business-managed aggregate composed of one root entity and one or more child entities.

Examples:

- Customer business object
- Vendor business object
- Material business object

Business users create, update, search, validate, approve, and analyze business objects. They do not usually think in terms of one isolated table.

## Enterprise Master Data Domains

### Customer Master

Customer master data represents organizations or individuals buying products or services.

Common entities:

- Customer
- CustomerAddress
- CustomerContact
- CustomerBankAccount
- CustomerSalesArea
- CustomerTax
- CustomerClassification
- CustomerCreditProfile
- CustomerPartnerFunction
- CustomerAttachment

Important Customer root fields:

- CustomerNumber
- CustomerName
- CustomerType
- Email
- Phone
- CountryId
- CurrencyId
- IndustryCode
- RiskCategory
- RegistrationNumber
- OnboardingDate
- IsActive
- Status

Common Customer child fields:

- AddressType
- AddressLine1
- City
- State
- PostalCode
- CountryId
- IsDefault
- FirstName
- LastName
- Email
- Phone
- BankName
- AccountNumber
- IFSCCode
- TaxType
- TaxNumber
- ValidFrom
- ValidTo
- CreditLimit
- CreditExposure
- CreditRiskClass

### Vendor Master

Vendor master data represents suppliers, service providers, and trading partners.

Common entities:

- Vendor
- VendorAddress
- VendorContact
- VendorBankAccount
- VendorTax
- VendorPurchasingOrganization
- VendorClassification
- VendorAttachment

Important Vendor root fields:

- VendorNumber
- VendorName
- VendorType
- Email
- Phone
- CountryId
- CurrencyId
- TaxRegistrationNumber
- RiskCategory
- OnboardingDate
- IsActive
- Status

Common Vendor child fields:

- AddressType
- AddressLine1
- City
- PostalCode
- CountryId
- ContactName
- Email
- Phone
- BankName
- AccountNumber
- BankCountryId
- PurchasingOrganizationId
- PaymentTermId
- Incoterms
- TaxNumber
- ValidFrom
- ValidTo

### Material Master

Material master data represents products, raw materials, finished goods, spare parts, packaging, and services.

Common entities:

- Material
- MaterialPlant
- MaterialPrice
- MaterialStorage
- MaterialClassification
- MaterialVendor
- MaterialUOM
- MaterialBarcode
- MaterialAttachment

Important Material root fields:

- MaterialNumber
- MaterialName
- MaterialType
- BaseUOM
- MaterialGroup
- Division
- GrossWeight
- NetWeight
- WeightUnit
- Status
- IsActive

Common Material child fields:

- PlantId
- ProcurementType
- MRPType
- StandardPrice
- CurrencyId
- StorageLocation
- BatchManaged
- ClassificationType
- ClassificationValue
- VendorId
- VendorMaterialNumber
- UOM
- ConversionNumerator
- ConversionDenominator
- Barcode

### Reference Data

Reference data supports business objects but is not usually managed as part of one business object aggregate.

Examples:

- Country
- Currency
- Plant
- SalesOrganization
- PurchasingOrganization
- PaymentTerm
- UnitOfMeasure
- MaterialGroup
- TaxCode

Reference entities should usually have:

- Id
- Code
- Name
- Description
- IsActive

Use unique constraints on business codes such as `Code`, `CountryCode`, `CurrencyCode`, or `PlantCode`.

## Entity Metadata Generation Rules

### Naming

Use PascalCase for entity and property names.

Good:

- CustomerNumber
- CustomerName
- CountryId
- ValidFrom

Avoid:

- customer_number
- customerName
- country_id

### Primary Keys

Use an integer identity key named `Id` unless the business specifically requires a different key.

Example:

```json
{
  "name": "Id",
  "type": "int",
  "isKey": true,
  "identity": true
}
```

### Foreign Keys

Foreign key fields should use the target entity name plus `Id`.

Examples:

- CustomerId
- VendorId
- MaterialId
- CountryId
- CurrencyId
- PaymentTermId

### Required Fields

Mark a field as required only when the business cannot create a valid record without it.

Usually required:

- Business number/code
- Business name/description
- Type/category
- Root foreign key on child entities
- Country or currency where legally or financially required

Usually optional:

- AddressLine2
- Phone
- Email, unless used as the primary communication channel
- Latitude
- Longitude
- Attachments
- Comments

### Unique Fields

Use unique constraints for stable business identifiers.

Examples:

- Customer.CustomerNumber
- Vendor.VendorNumber
- Material.MaterialNumber
- Country.Code
- Currency.Code
- Plant.PlantCode

Do not mark names as unique unless the business truly requires it.

### Allowed Values

Use allowed values for controlled business classifications.

Examples:

CustomerType:

- Individual
- Corporate
- Government

RiskCategory:

- Low
- Medium
- High

MaterialType:

- RawMaterial
- FinishedGood
- SemiFinished
- Service
- Packaging

Status:

- Draft
- Active
- Blocked
- Deleted

### Data Types

Use these common metadata types:

- `int`
- `long`
- `decimal`
- `bool`
- `string`
- `DateTime`
- `Guid`

Use `decimal` for currency, weight, percentage, and quantity values.

Use `DateTime` for dates such as onboarding date, valid-from, valid-to, review date, and uploaded-on.

## Business Object Metadata Generation Rules

Each business object must include:

- `name`
- `entity`
- `rootEntity`
- `entities`
- `operations`
- `profiling`
- `dataQualityRules`

Example structure:

```json
{
  "name": "Customer",
  "entity": "Customer",
  "rootEntity": "Customer",
  "entities": [
    "Customer",
    "CustomerAddress",
    "CustomerContact",
    "CustomerBankAccount"
  ],
  "operations": [
    { "name": "Create", "type": "Create" },
    { "name": "Update", "type": "Update" },
    { "name": "Delete", "type": "Delete" },
    { "name": "Search", "type": "Search" },
    { "name": "BulkCreate", "type": "BulkCreate" },
    { "name": "BulkUpsert", "type": "BulkUpsert" },
    { "name": "BulkDelete", "type": "BulkDelete" },
    { "name": "RunAnalysis", "type": "RunAnalysis" }
  ],
  "profiling": {
    "enabled": true,
    "summaries": []
  },
  "dataQualityRules": []
}
```

## Profiling Guidance

Profiling describes the data as it exists. It does not necessarily decide whether data is valid or invalid.

Generate profiling only for meaningful fields. Do not blindly profile every property.

Good profiling candidates:

- Business number fields
- Name fields
- Email fields
- Phone fields
- Country and currency references
- Status fields
- Risk category fields
- Postal code
- Tax number
- Bank account number
- Material weight
- Price
- UOM
- Plant assignment

Avoid profiling:

- Internal identity keys unless total count is required
- Audit fields such as CreatedOn, CreatedBy, ModifiedOn, ModifiedBy
- Large text notes unless explicitly requested
- Attachment storage paths unless document completeness is important

### Supported Profiling Summary Types

Use these where meaningful:

- TotalCount
- NullCount
- DistinctCount
- Duplicate
- MinValue
- MaxValue
- AverageValue
- AllowedValues
- LookupExists
- ChildCount

### Profiling Examples

Customer email missing count:

```json
{
  "summaryCode": "CUSTOMER_EMAIL_NULL_COUNT",
  "summaryType": "NullCount",
  "entity": "Customer",
  "column": "Email",
  "condition": {
    "type": "IsNullOrEmpty",
    "field": "Email"
  },
  "storeDrilldown": true,
  "label": "Customer email missing count",
  "severity": "Medium"
}
```

Customer risk category distribution:

```json
{
  "summaryCode": "CUSTOMER_RISK_CATEGORY_DISTINCT_COUNT",
  "summaryType": "DistinctCount",
  "entity": "Customer",
  "column": "RiskCategory",
  "condition": {
    "type": "DistinctCount",
    "field": "RiskCategory"
  },
  "storeDrilldown": false,
  "label": "Distinct customer risk categories",
  "severity": "Low"
}
```

Material negative or zero net weight:

```json
{
  "summaryCode": "MATERIAL_NET_WEIGHT_INVALID_COUNT",
  "summaryType": "LessThanOrEqual",
  "entity": "Material",
  "column": "NetWeight",
  "condition": {
    "type": "LessThanOrEqual",
    "field": "NetWeight",
    "value": 0
  },
  "storeDrilldown": true,
  "label": "Material records with invalid net weight",
  "severity": "High"
}
```

## Data Quality Rule Guidance

Data quality rules evaluate whether data satisfies business requirements.

Generate rules only for meaningful business expectations.

Good DQ rule categories:

- Completeness
- Validity
- Uniqueness
- Consistency
- ReferentialIntegrity
- Timeliness
- Compliance
- Duplication

### Rule Types

Use these rule types when possible:

- FieldRule
- LookupRule
- RelationshipRule
- UniquenessRule
- RangeRule
- AllowedValuesRule
- DateRangeValid
- Duplication
- CustomCodeRule

Use `CustomCodeRule` only when the logic cannot be safely generated from metadata.

### Condition Types

Use supported condition types:

- IsNullOrEmpty
- IsNull
- IsNotNull
- Duplicate
- DistinctCount
- MinLength
- MaxLength
- MinValue
- MaxValue
- AverageValue
- LessThan
- LessThanOrEqual
- GreaterThan
- GreaterThanOrEqual
- Equals
- NotEquals
- AllowedValues
- Regex
- LookupExists
- AtLeastOneChild
- NoDuplicateCombination
- DateRangeValid
- ChildCount

### Data Quality Rule Examples

Customer name required:

```json
{
  "ruleId": "CUSTOMER_NAME_REQUIRED",
  "ruleCode": "CUSTOMER_NAME_REQUIRED",
  "ruleName": "Customer name is mandatory",
  "ruleType": "FieldRule",
  "category": "Completeness",
  "severity": "High",
  "enabled": true,
  "businessObject": "Customer",
  "entity": "Customer",
  "field": "CustomerName",
  "condition": {
    "type": "IsNullOrEmpty",
    "field": "CustomerName"
  },
  "message": "Customer name is required."
}
```

Customer country must exist:

```json
{
  "ruleId": "CUSTOMER_COUNTRY_EXISTS",
  "ruleCode": "CUSTOMER_COUNTRY_EXISTS",
  "ruleName": "Customer country must exist",
  "ruleType": "LookupRule",
  "category": "ReferentialIntegrity",
  "severity": "High",
  "enabled": true,
  "businessObject": "Customer",
  "entity": "Customer",
  "field": "CountryId",
  "condition": {
    "type": "LookupExists",
    "field": "CountryId",
    "lookupEntity": "Country",
    "lookupField": "Id"
  },
  "message": "Customer country does not exist."
}
```

Active customer must have default address:

```json
{
  "ruleId": "CUSTOMER_ACTIVE_DEFAULT_ADDRESS_REQUIRED",
  "ruleCode": "CUSTOMER_ACTIVE_DEFAULT_ADDRESS_REQUIRED",
  "ruleName": "Active customer must have a default address",
  "ruleType": "RelationshipRule",
  "category": "Completeness",
  "severity": "High",
  "enabled": true,
  "businessObject": "Customer",
  "entity": "Customer",
  "condition": {
    "type": "AtLeastOneChild",
    "childEntity": "CustomerAddress",
    "childForeignKey": "CustomerId",
    "parentKey": "Id",
    "field": "IsDefault",
    "value": true
  },
  "message": "Active customer must have at least one default address."
}
```

Tax valid-to must be greater than valid-from:

```json
{
  "ruleId": "CUSTOMER_TAX_DATE_RANGE_VALID",
  "ruleCode": "CUSTOMER_TAX_DATE_RANGE_VALID",
  "ruleName": "Customer tax validity date range must be valid",
  "ruleType": "DateRangeValid",
  "category": "Validity",
  "severity": "Medium",
  "enabled": true,
  "businessObject": "Customer",
  "entity": "CustomerTax",
  "condition": {
    "type": "DateRangeValid",
    "fromField": "ValidFrom",
    "toField": "ValidTo"
  },
  "message": "Tax valid-to date cannot be earlier than valid-from date."
}
```

Potential duplicate customer:

```json
{
  "ruleId": "CUSTOMER_DUP_002",
  "ruleCode": "CUSTOMER_DUP_002",
  "ruleName": "Potential Duplicate Customer by Name and Address",
  "ruleType": "Duplication",
  "executionType": "Complex",
  "businessObject": "Customer",
  "category": "Duplication",
  "severity": "Medium",
  "enabled": true,
  "filter": {
    "logicalOperator": "AND",
    "conditions": [
      {
        "propertyPath": "Customer.Status",
        "operator": "NotEquals",
        "value": "Deleted"
      }
    ]
  },
  "matchingCriteria": {
    "matchType": "WeightedFuzzy",
    "minimumMatchScore": 85,
    "properties": [
      {
        "propertyPath": "Customer.CustomerName",
        "comparison": "Fuzzy",
        "minimumPropertyScore": 85,
        "weight": 50
      },
      {
        "propertyPath": "CustomerAddress.AddressLine1",
        "comparison": "Fuzzy",
        "minimumPropertyScore": 75,
        "weight": 30
      },
      {
        "propertyPath": "CustomerAddress.PostalCode",
        "comparison": "Exact",
        "weight": 20
      }
    ]
  },
  "message": "Potential duplicate customer found."
}
```

## Recommended Profiling and DQ by Business Object

### Customer

Recommended profiling:

- Total customer count
- Missing CustomerNumber
- Missing CustomerName
- Missing Email
- Duplicate CustomerNumber
- Duplicate TaxNumber
- Invalid RiskCategory
- Customer count by Status
- Customer count by CustomerType
- Address missing PostalCode
- Contact missing Email or Phone
- Bank account missing AccountNumber
- Sales area missing PaymentTermId

Recommended DQ rules:

- CustomerNumber required
- CustomerName required
- CustomerType allowed values
- Email format valid when supplied
- CountryId lookup exists
- CurrencyId lookup exists
- CustomerNumber unique
- Active customer must have default address
- Active customer must have primary contact
- Bank country lookup exists
- Tax date range valid
- Credit exposure must not exceed credit limit
- Potential duplicate customer by name/address/postal code

### Vendor

Recommended profiling:

- Total vendor count
- Missing VendorNumber
- Missing VendorName
- Missing Email
- Duplicate VendorNumber
- Duplicate TaxRegistrationNumber
- Vendor count by Status
- Vendor count by VendorType
- Address missing PostalCode
- Bank account missing AccountNumber
- Purchasing organization coverage

Recommended DQ rules:

- VendorNumber required
- VendorName required
- VendorType allowed values
- CountryId lookup exists
- CurrencyId lookup exists
- VendorNumber unique
- Active vendor must have default address
- Active vendor must have primary contact
- Vendor bank account required for active vendor
- Purchasing organization required for active vendor
- Tax date range valid
- Potential duplicate vendor by name/address/postal code/tax number

### Material

Recommended profiling:

- Total material count
- Missing MaterialNumber
- Missing MaterialName
- Duplicate MaterialNumber
- Material count by MaterialType
- Material count by Status
- Missing BaseUOM
- Invalid or zero NetWeight
- Missing plant assignment
- Missing price
- Missing barcode

Recommended DQ rules:

- MaterialNumber required
- MaterialName required
- MaterialType allowed values
- BaseUOM required
- MaterialNumber unique
- NetWeight must be greater than zero when supplied
- GrossWeight must be greater than or equal to NetWeight
- Active material must have at least one plant assignment
- Active material must have base UOM
- Material price currency lookup exists
- Material vendor lookup exists
- Barcode unique when supplied

## AI Agent Instructions

When generating metadata from business requirements:

1. Identify business domains first, such as Customer, Vendor, Material, or Reference Data.
2. Identify entities and properties from nouns and data attributes.
3. Identify relationships from ownership phrases such as "customer has addresses" or "material is extended to plants".
4. Generate the entity metadata file first.
5. Generate the business object metadata file second.
6. Include profiling only for fields that are operationally useful for analysis.
7. Include DQ rules only for fields that have business quality expectations.
8. Prefer explicit profiling summaries and explicit data quality rules.
9. Do not auto-generate rules for every property.
10. Keep rule names and codes stable across regenerations.

## Output Checklist

Before returning generated metadata, verify:

- The entity file has no `businessObjects` property.
- The business object file has no `entities` property.
- Every relationship references existing entity names.
- Every business object entity name exists in the entity metadata.
- Every DQ rule entity exists in the business object entity list.
- Every field referenced by profiling or DQ exists on the referenced entity.
- Every lookup entity exists in the entity metadata.
- Rule codes are unique.
- Profiling summary codes are unique.
- No audit fields are profiled unless explicitly requested.
- No rule is generated only because a property exists.

