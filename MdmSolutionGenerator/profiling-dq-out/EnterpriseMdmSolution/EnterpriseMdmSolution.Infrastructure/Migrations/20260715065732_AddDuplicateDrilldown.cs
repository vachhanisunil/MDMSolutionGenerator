using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseMdmSolution.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDuplicateDrilldown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataQualityDuplicateDrilldowns",
                columns: table => new
                {
                    DuplicateDrilldownId = table.Column<Guid>(type: "uuid", nullable: false),
                    RunId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResultId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessObjectName = table.Column<string>(type: "text", nullable: false),
                    RuleCode = table.Column<string>(type: "text", nullable: false),
                    RuleName = table.Column<string>(type: "text", nullable: false),
                    EntityName = table.Column<string>(type: "text", nullable: false),
                    SourceRootRecordId = table.Column<string>(type: "text", nullable: false),
                    SourceRecordId = table.Column<string>(type: "text", nullable: false),
                    SourceDisplayValue = table.Column<string>(type: "text", nullable: false),
                    DuplicateRootRecordId = table.Column<string>(type: "text", nullable: false),
                    DuplicateRecordId = table.Column<string>(type: "text", nullable: false),
                    DuplicateDisplayValue = table.Column<string>(type: "text", nullable: false),
                    MatchScore = table.Column<decimal>(type: "numeric", nullable: false),
                    MatchStatus = table.Column<string>(type: "text", nullable: false),
                    Severity = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    MatchedFieldJson = table.Column<string>(type: "text", nullable: false),
                    SourceRecordSnapshotJson = table.Column<string>(type: "text", nullable: false),
                    DuplicateRecordSnapshotJson = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataQualityDuplicateDrilldowns", x => x.DuplicateDrilldownId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataQualityDuplicateDrilldowns");
        }
    }
}
