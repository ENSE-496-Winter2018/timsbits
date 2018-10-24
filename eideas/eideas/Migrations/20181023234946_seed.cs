using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eideas.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "DivisionId", "CreatedDate", "DivisionName" },
                values: new object[,]
                {
                    { 1,DateTime.Now, "Finance" },
                    { 2, DateTime.Now, "Marketing" },
                    { 3, DateTime.Now, "Content" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "CreatedDate", "DivisionId", "UnitName" },
                values: new object[,]
                {

                    { 1,  DateTime.Now, 1, "Payroll" },
                    { 2, DateTime.Now, 1, "Economics" },                    
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "CreatedDate", "DivisionId", "UnitName" },
                values: new object[] { 3, DateTime.Now, 2, "Poster Makers" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitId", "CreatedDate", "DivisionId", "UnitName" },
                values: new object[] { 4, DateTime.Now, 3, "Coders" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "UnitId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "DivisionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Divisions",
                keyColumn: "DivisionId",
                keyValue: 3);
        }
    }
}
