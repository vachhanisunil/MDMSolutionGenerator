# Business Specification Corpus for Generic Metadata Generation

## Purpose

This document is a reusable business specification corpus for an AI agent that must generate two metadata JSON files for `SolutionGeneratorService`:

1. Entity metadata JSON containing entities, properties, constraints, and relationships.
2. Business object metadata JSON containing business objects, associated entities, supported operations, profiling definitions, and data quality rules.

The generated metadata must support a **generic enterprise data-modeling platform**, not only master data management.

The platform must be capable of modeling any persisted business information required by an application or business process, including but not limited to:

- Master data
- Transactional data
- Reference data
- Configuration data
- Operational data
- Financial data
- Contractual data
- Pricing data
- Workflow and approval data
- Event/history data
- Relationship or associative data
- Snapshot / periodic data
- Analytical or calculated data when persisted
- Industry-specific business objects

Examples include Customer, Vendor, Product, Contract, Sales Order, Delivery, Invoice, Payment, Claim, Rebate Agreement, Promotion, Price List, Pricing Result, Inventory Position, Monthly Average Manufacturing Price, Compliance Submission, Workflow Request, Country, Currency, and Unit of Measure.

The AI agent must derive the appropriate model from the supplied business specification rather than assuming that the target domain is master data.

---

## Metadata Split Contract

The AI agent must never generate a single full metadata file containing both `entities` and `businessObjects`.

Generate two separate files.

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

The business object metadata file must not contain top-level `entities` or `relationships`.

A business object may reference entities defined in the entity metadata file.

---

# Core Modeling Definitions

## Entity

An entity represents a persisted data structure or logical record type that the generated solution must store or query. An entity may represent master data, a transaction header, transaction line, financial document, settlement record, relationship record, periodic snapshot, pricing result, configuration record, reference value, or workflow record.

Examples include:

- `Customer`
- `SalesOrder`
- `SalesOrderItem`
- `Invoice`
- `Payment`
- `PaymentAllocation`
- `Contract`
- `ContractItem`
- `InventorySnapshot`
- `MAMPResult`
- `ApprovalRequest`
- `Country`

An entity does **not** have to be master data.

Each entity should define, where applicable:

- Name
- Business description
- Primary key
- Properties
- Data types
- Required flags
- Length / precision / scale constraints
- Unique constraints
- Index hints
- Allowed values
- Default values
- Effective-date semantics
- Unit or currency semantics
- Whether values are stored, derived, or system-managed
- Query/search semantics when needed
- Audit behavior

Do not invent properties merely because they are common in enterprise systems. Generate properties only when supported by the business specification or required by the metadata contract.

## Relationship

A relationship describes how two entities are connected. Supported conceptual relationships may include `OneToOne`, `OneToMany`, `ManyToOne`, many-to-many represented through an associative entity, self-referencing hierarchy, optional reference, and required reference.

Example:

```json
{
  "name": "SalesOrder_SalesOrderItems",
  "type": "OneToMany",
  "from": "SalesOrderItem",
  "to": "SalesOrder",
  "foreignKey": "SalesOrderId"
}
```

In this convention, `from` is the dependent entity, `to` is the principal entity, and `foreignKey` is the property on the dependent entity.

When a relationship itself has business attributes, introduce an associative entity. For example, when a Payment can settle multiple Invoices and an Invoice can be settled by multiple Payments, and the relationship carries `AllocatedAmount`, infer `PaymentAllocation` rather than only a direct many-to-many link.

## Business Object

A business object is a **business-manageable or business-queryable unit of information** used by an application or business process.

A business object may be:

1. An aggregate with a root and dependent entities.
2. A single standalone entity.
3. A transactional document with header and line entities.
4. A relationship-centric object.
5. A periodic or snapshot object.
6. A persisted analytical/calculation object.
7. A configuration object.
8. A reference-data object when it has its own lifecycle or management operations.

Examples:

- `Customer`: Customer + CustomerAddress + CustomerContact
- `SalesOrder`: SalesOrder + SalesOrderItem + SalesOrderCharge
- `Invoice`: Invoice + InvoiceItem + InvoiceTax
- `Payment`: Payment + PaymentAllocation
- `Contract`: Contract + ContractItem + ContractCondition
- `MonthlyAverageManufacturingPrice`: MAMPResult + MAMPCalculationDetail + MAMPRevision
- `InventoryPosition`: InventoryPosition only

A business object therefore does **not** always require multiple entities, and the AI agent must not force every entity into a root-child master-data pattern.

Business operations may include create, update, submit, approve, post, release, cancel, calculate, simulate, search, query, reconcile, allocate, close, archive, analyze, amend, reverse, or revise depending on the domain.


# Generic Enterprise Domain Examples

These examples are guidance only and are not a fixed catalog.

## Customer

Possible entities: Customer, CustomerAddress, CustomerContact, CustomerBankAccount, CustomerTax, CustomerCreditProfile.

Possible operations: Create, Update, Search, Activate, Block, Merge, RunAnalysis.

## Product / Material

Possible entities: Product, ProductPlant, ProductPrice, ProductUOM, ProductClassification.

Possible operations: Create, Update, ExtendToPlant, ChangeStatus, Search, RunAnalysis.

## Sales Order

Possible entities: SalesOrder, SalesOrderItem, SalesOrderCharge, SalesOrderApproval.

Possible root properties: OrderNumber, CustomerId, OrderDate, RequestedDeliveryDate, CurrencyId, Status, GrossAmount, DiscountAmount, NetAmount.

Possible line properties: ProductId, OrderedQuantity, ConfirmedQuantity, UnitOfMeasureId, UnitPrice, DiscountPercentage, NetAmount.

Possible operations: Create, Update, AddItem, RemoveItem, Submit, Confirm, PutOnHold, ReleaseHold, Cancel, Search.

## Contract

Possible entities: Contract, ContractItem, ContractCondition, ContractApproval.

Possible operations: Create, Update, SubmitForApproval, Approve, Activate, Amend, Terminate, Expire, Search.

## Invoice

Possible entities: Invoice, InvoiceItem, InvoiceTax.

Possible operations: Create, Post, Cancel, Credit, Search, MarkOverdue.

## Payment

Possible entities: Payment, PaymentAllocation.

Possible operations: Record, Allocate, Reallocate, Reverse, Reconcile, Search.

## Pricing / Periodic Calculation

Possible objects: PriceList, PriceCondition, PriceCalculation, MonthlyAverageManufacturingPrice.

Possible operations: Calculate, Recalculate, Simulate, Override, Submit, Approve, Post, Revise, ComparePeriods, Search.

## Workflow / Approval

Possible entities: ApprovalRequest, ApprovalStep, ApprovalDecision, ApprovalHistory.

Possible operations: Submit, Approve, Reject, SendBack, Escalate, Withdraw.

## Reference Data

Examples: Country, Currency, UnitOfMeasure, PaymentTerm, TaxCode, StatusCode, Organization.

Reference data may be standalone or managed through a dedicated business object.

---

# Entity Metadata Generation Rules

## Naming

Use PascalCase for entity and property names. Preserve established business abbreviations such as NDC, AMP, MAMP, or UOM when explicitly used by the specification.

## Primary Keys

Use an integer identity key named `Id` as a default only when the business specification does not require another key strategy.

Do not assume every business identifier is the primary key. CustomerNumber, ContractNumber, OrderNumber, InvoiceNumber, NDC9, or ClaimNumber may be unique alternate keys.

## Foreign Keys

Foreign key fields should normally use the target entity name plus `Id`, such as CustomerId, SalesOrderId, ProductId, ContractId, InvoiceId, PaymentId, or CurrencyId.

Use relationship semantics from the specification; do not infer ownership purely from naming.

## Required Fields

Mark a field as required only when the business cannot create or reach the relevant lifecycle state without it.

Requiredness may be always required, creation-required, posting-required, conditionally required, or subtype/status-specific.

Examples:

- SalesOrder.CustomerId may be required to create an order.
- Shipment.TrackingNumber may become required only when status is `Dispatched`.
- Customer.GSTNumber may be required only for an Indian corporate customer.
- Invoice.PostingDate may be required only when posting.

Do not flatten conditional requiredness into `required: true` when a validation rule is more accurate.

## Unique Fields

Use unique constraints only for true uniqueness requirements. Composite uniqueness is valid, for example CustomerId + CustomerPurchaseOrderNumber, ProductId + PlantId, or NDC9 + ReportingPeriod.

## Allowed Values

Use allowed values for controlled states, categories, classifications, and indicators. Values should come from the business specification when possible.

## Data Types

Common metadata types include `int`, `long`, `decimal`, `bool`, `string`, `DateTime`, `DateOnly`, and `Guid`.

Identifiers such as NDC, postal code, bank account number, or document number may be strings even if they contain only digits.

For decimal properties, capture precision, scale, semantic type, unit, and currency reference where supported and known.

---

# Semantic Field Description Guidance

Field descriptions are important for both generated applications and LLM/NLP query interpretation.

For ambiguous fields, generate an enriched business description that explains:

- What the field means
- The business context in which it is used
- Whether it is an identifier, amount, quantity, percentage, rate, status, date, indicator, or calculated value
- Whether it is current, historical, planned, calculated, final, active, overridden, or posted
- How it differs from similarly named fields
- Whether it is stored or derived
- Unit/currency semantics
- Period semantics
- Common business synonyms when known
- Default interpretation only when explicitly supported by the specification

Example:

```json
{
  "name": "FinalMAMP",
  "type": "decimal",
  "description": "Final Monthly Average Manufacturing Price for the NDC and reporting period after applicable system calculation and approved override processing. This is the authoritative MAMP value used when business users refer to MAMP without further qualification.",
  "semanticType": "Rate"
}
```

Example:

```json
{
  "name": "ManualOverride",
  "type": "bool",
  "description": "Indicates whether the MAMP result was manually overridden. This field is the override indicator; the actual numeric override value is stored separately."
}
```

Avoid generic descriptions such as `Status of record`, `Amount value`, `Date field`, or `Calculated value` when the source provides enough information for a more precise definition.

---

# Business Object Metadata Generation Rules

Each business object should include, where supported by the schema:

- `name`
- `category`
- `description`
- `entity`
- `rootEntity`
- `entities`
- `operations`
- `profiling`
- `dataQualityRules`

A single-entity business object is valid.

Example transactional object:

```json
{
  "name": "SalesOrder",
  "category": "Transaction",
  "entity": "SalesOrder",
  "rootEntity": "SalesOrder",
  "entities": ["SalesOrder", "SalesOrderItem"],
  "operations": [
    { "name": "Create", "type": "Create" },
    { "name": "Update", "type": "Update" },
    { "name": "Submit", "type": "Submit" },
    { "name": "Confirm", "type": "Custom" },
    { "name": "Cancel", "type": "Custom" },
    { "name": "Search", "type": "Search" }
  ],
  "profiling": { "enabled": true, "summaries": [] },
  "dataQualityRules": []
}
```

Example single-entity periodic object:

```json
{
  "name": "MonthlyAverageManufacturingPrice",
  "category": "Analytical",
  "entity": "MAMPResult",
  "rootEntity": "MAMPResult",
  "entities": ["MAMPResult"],
  "operations": [
    { "name": "Calculate", "type": "Custom" },
    { "name": "Override", "type": "Custom" },
    { "name": "Post", "type": "Custom" },
    { "name": "Revise", "type": "Custom" },
    { "name": "Search", "type": "Search" }
  ],
  "profiling": { "enabled": true, "summaries": [] },
  "dataQualityRules": []
}
```

Do not automatically add CRUD operations to every object. Operations must reflect the actual business lifecycle and use cases.

---



# Profiling Guidance

Profiling describes the data as it exists. It does not necessarily decide whether data is valid or invalid.

Profiling applies to **any meaningful business data**, not only master data.

Good profiling candidates include business identifiers, names/descriptions, statuses, categories, dates/periods, monetary amounts, quantities, rates, percentages, references, transaction counts, child counts, nulls, distinct values, duplicate identifiers, period-over-period measures, and revision counts.

Examples:

### Sales Order

- Total order count
- Orders by Status
- Orders by Customer
- Average NetAmount
- Orders on CreditHold
- Orders with no items
- Duplicate customer PO numbers

### Invoice

- Total invoice count
- Open invoice count
- Overdue invoice count
- Average invoice amount
- Missing CustomerId
- Invoices by Status

### MAMP

- Count by reporting period
- Count by Status
- Count of manual overrides
- Average FinalMAMP
- Min/Max FinalMAMP
- Count of missing calculated MAMP
- Count of revised records

Avoid profiling internal identity keys, audit fields, large free text, or technical storage paths unless specifically requested.

## Supported Profiling Summary Types

Use these where meaningful and supported:

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

---

# Data Quality Rule Guidance

Data quality rules evaluate whether data satisfies business expectations. DQ applies to all modeled data categories.

Good rule categories include:

- Completeness
- Validity
- Uniqueness
- Consistency
- ReferentialIntegrity
- Timeliness
- Compliance
- Duplication
- Reconciliation
- CrossEntityConsistency
- AggregateConstraint
- LifecycleGuardrail

Examples beyond master data:

- A Sales Order must contain at least one Sales Order Item.
- Sales Order Customer must equal Contract Customer.
- Total delivered quantity for an order item must not exceed confirmed quantity.
- Payment allocations must not exceed Payment amount.
- A cancelled Delivery cannot be shipped.
- ReportingPeriod is mandatory for a periodic MAMP result.
- When ManualOverride is true, OverrideReason must be supplied.

Generate only rules clearly supported by business requirements.

Do not convert every lifecycle behavior into a DQ rule if the platform models that behavior elsewhere.

## Rule Types

Use supported rule types when possible:

- FieldRule
- LookupRule
- RelationshipRule
- UniquenessRule
- RangeRule
- AllowedValuesRule
- DateRangeValid
- Duplication
- CustomCodeRule

If the metadata contract is extended, additional useful generic types may include CrossEntityRule, AggregateRule, ConditionalRule, LifecycleRule, and ReconciliationRule.

Use `CustomCodeRule` only when the logic cannot be represented safely through structured metadata.

## Condition Types

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

Do not invent unsupported condition types in generated JSON.

---

# Generic Data Quality Examples

## Sales Order must contain at least one item

```json
{
  "ruleId": "SALES_ORDER_ITEM_REQUIRED",
  "ruleCode": "SALES_ORDER_ITEM_REQUIRED",
  "ruleName": "Sales order must contain at least one item",
  "ruleType": "RelationshipRule",
  "category": "Completeness",
  "severity": "High",
  "enabled": true,
  "businessObject": "SalesOrder",
  "entity": "SalesOrder",
  "condition": {
    "type": "AtLeastOneChild",
    "childEntity": "SalesOrderItem",
    "childForeignKey": "SalesOrderId",
    "parentKey": "Id"
  },
  "message": "Sales order must contain at least one sales order item."
}
```

## Sales Order Customer must match Contract Customer

Business logic:

`SalesOrder.CustomerId = Contract.CustomerId`

If the current schema cannot express a cross-entity comparison structurally, generate `CustomCodeRule` rather than inventing unsupported syntax.

## Payment allocation may not exceed payment amount

Business logic:

`SUM(PaymentAllocation.AllocatedAmount for Payment) <= Payment.PaymentAmount`

Use an aggregate-capable rule only if supported; otherwise use `CustomCodeRule`.

## Manual override reason required

Business logic:

`ManualOverride = true -> OverrideReason is required`

Use a structured conditional rule when supported; otherwise use `CustomCodeRule`.

---

# Generic Profiling Recommendations by Object Type

## Master Object

- Total count
- Missing business identifier
- Missing business name
- Duplicate business identifier
- Status distribution
- Classification distribution
- Missing key relationships
- Potential duplicates

## Transactional Document

- Total transaction count
- Transactions by status
- Average amount
- Min/max amount
- Missing child lines
- Missing party/account reference
- Duplicate external reference
- Count on hold
- Count cancelled
- Transaction volume by period

## Financial Object

- Total posted amount
- Open amount
- Overdue amount
- Count by status
- Unallocated amount
- Reconciliation exceptions
- Missing currency
- Invalid amount ranges

## Periodic / Snapshot Object

- Count by reporting period
- Missing period
- Duplicate business key + period
- Min/max/average calculated value
- Revision count distribution
- Manual override count
- Missing source/calculated values

## Relationship Object

- Orphan records
- Duplicate combinations
- Allocation coverage
- Invalid relationship status
- Invalid effective dates

## Reference Data

- Duplicate code
- Missing name
- Inactive values still referenced
- Missing descriptions
- Invalid hierarchy parent

---

# AI Agent Instructions

When generating metadata from business requirements:

1. **Determine the business process and business concepts before assuming a data category.**
2. Identify candidate business objects from business nouns, documents, records, calculations, agreements, transactions, events, snapshots, and managed concepts.
3. Classify each business object only when useful: Master, Transaction, Reference, Configuration, Contract, Financial, Operational, Workflow, Snapshot, Analytical, Relationship, or Other.
4. Identify entities and properties from the information the business says must be stored, displayed, queried, calculated, audited, or related.
5. Do **not** assume that every business object is a master-data aggregate.
6. Do **not** assume that every business object requires child entities.
7. Identify relationships from ownership, reference, fulfillment, settlement, allocation, composition, hierarchy, and dependency statements.
8. Introduce associative entities when a many-to-many business relationship carries its own attributes.
9. Identify business operations from verbs and lifecycle behavior such as create, submit, approve, post, cancel, calculate, override, allocate, reconcile, revise, close, and search.
10. Do not add generic CRUD operations automatically when they conflict with the business lifecycle.
11. Identify lifecycle states and transition guardrails when the specification describes them.
12. Generate the entity metadata file first.
13. Generate the business object metadata file second.
14. Include profiling only for fields and measures that are operationally or analytically useful.
15. Include data quality rules only where the business specification defines a meaningful quality, consistency, compliance, reconciliation, or integrity expectation.
16. Prefer explicit structured profiling summaries and explicit structured data-quality rules.
17. Use `CustomCodeRule` only when the current metadata schema cannot safely express the required logic.
18. Enrich ambiguous business fields with precise business descriptions, especially for status, amount, quantity, calculated, final, active, prior-period, override, ratio, identifier, and period-dependent fields.
19. Preserve domain-specific terminology and regulated abbreviations where the business specification uses them.
20. Keep entity names, property names, relationship names, rule names, rule codes, and profiling summary codes stable across regenerations whenever the underlying meaning has not changed.
21. Never generate a property, relationship, operation, profiling definition, or DQ rule solely because it is common in similar systems.
22. When the source is ambiguous, record the ambiguity or request clarification rather than silently inventing business semantics.

---

# Interpretation Examples for the AI Agent

## Example 1: Master Data

Business statement: A customer can have multiple billing and shipping addresses.

Infer Customer, CustomerAddress, Customer 1:N CustomerAddress, and AddressType.

## Example 2: Transaction

Business statement: A sales order contains one or more items. Each item references a product and records ordered quantity and unit price.

Infer SalesOrder, SalesOrderItem, SalesOrder 1:N SalesOrderItem, Product reference, OrderedQuantity, and UnitPrice. Category: Transaction.

## Example 3: Many-to-Many Settlement

Business statement: A payment may settle multiple invoices, and an invoice may be settled by multiple payments. The allocated amount must be captured for each settlement.

Infer Payment, Invoice, PaymentAllocation, Payment 1:N PaymentAllocation, Invoice 1:N PaymentAllocation, and PaymentAllocation.AllocatedAmount.

## Example 4: Periodic Calculated Object

Business statement: For each NDC and reporting month, the system calculates MAMP. A user may override the calculated value before posting, and revisions must be retained.

Infer possible concepts such as MonthlyAverageManufacturingPrice, MAMPResult, ReportingPeriod, NDC9, SystemCalculatedMAMP, FinalMAMP, ManualOverride, OverrideReason, Status, and RevisionCount.

Possible operations: Calculate, Override, Post, Revise, Search.

Do not classify this as master data merely because NDC identifies a product.

## Example 5: Workflow

Business statement: A contract change above the approval threshold must be submitted to a manager. The manager may approve, reject, or send it back.

Infer Contract, ApprovalRequest, ApprovalDecision/ApprovalHistory, and operations Submit, Approve, Reject, SendBack. Do not reduce this to a boolean Approved field if approval history is required.

---

# Output Checklist

Before returning generated metadata, verify:

- The entity file has no `businessObjects` property.
- The business object file has no top-level `entities` property.
- Every relationship references existing entity names.
- Every business object entity name exists in entity metadata.
- A single-entity business object is allowed.
- Transactional, financial, analytical, workflow, configuration, relationship, snapshot, and reference objects are not rejected merely because they are not master data.
- Every DQ rule entity exists in the business object's entity list.
- Every field referenced by profiling or DQ exists on the referenced entity.
- Every lookup entity exists in entity metadata.
- Every operation is supported by the business specification or explicitly required by the platform.
- No `Delete` operation is added automatically where the business uses cancel, reverse, expire, terminate, or archive.
- Lifecycle/status semantics are consistent with generated operations.
- Rule codes are unique.
- Profiling summary codes are unique.
- No audit fields are profiled unless explicitly requested.
- No profiling definition or DQ rule is generated only because a property exists.
- Ambiguous fields have sufficiently precise business descriptions when the source supports enrichment.
- Identifiers are not incorrectly modeled as numeric measures.
- Monetary, quantity, rate, percentage, period, and currency semantics are represented where known.
- Unsupported business logic is not represented using invented condition syntax; use an approved extension point such as `CustomCodeRule`.
- The generated model reflects the supplied business process rather than a preselected MDM template.

---

# Final Principle

The AI agent is a **business-to-metadata modeling agent**, not an MDM-only metadata generator.

Its responsibility is to interpret the supplied business specification and discover the minimum correct persistent model required to support that business domain and its operations.

The agent must be equally capable of modeling a Customer master, a Sales Order transaction, a Contract and its conditions, an Invoice and payment settlement, a Pricing calculation, a periodic regulatory measure, a Workflow approval, a Reference-data entity, or any other business object supported by the specification.

The business specification is the semantic source of truth. The generated metadata is the normalized machine-readable representation of that business meaning.
