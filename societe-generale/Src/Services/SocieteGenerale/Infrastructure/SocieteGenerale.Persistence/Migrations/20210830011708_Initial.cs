using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocieteGenerale.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "DateOfBirth", "Email", "FirstName", "IsActive", "LastModifiedDate", "LastName", "MobileNumber" },
                values: new object[] { new Guid("5dc6d320-aed8-415c-b4c7-870626fe2c2c"), new DateTime(2021, 8, 30, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new DateTime(1989, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "parthi@parthibank.com", "Parthiban", true, null, "K", "9677377505" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "DateOfBirth", "Email", "FirstName", "IsActive", "LastModifiedDate", "LastName", "MobileNumber" },
                values: new object[] { new Guid("d06497be-1f09-47a8-8773-05d2fea15e51"), new DateTime(2021, 8, 30, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new DateTime(1991, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "rmathimsc@gmail.com", "Mathiyalagan", true, null, "R", "9677377506" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CreatedDate", "CustomerId", "Description", "IsPaid", "LastModifiedDate" },
                values: new object[,]
                {
                    { new Guid("c6c14e39-1a2d-40d1-a4c6-d6d1cd08d166"), 0m, new DateTime(2021, 8, 30, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("5dc6d320-aed8-415c-b4c7-870626fe2c2c"), "Account Opened!", true, null },
                    { new Guid("aa079193-be82-4065-bd75-2eb6c07479ee"), 100m, new DateTime(2021, 8, 28, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("5dc6d320-aed8-415c-b4c7-870626fe2c2c"), "Online shopping!", false, null },
                    { new Guid("ab31f299-80e6-45c5-96dc-de4d8e2f77e7"), 200m, new DateTime(2021, 8, 16, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("5dc6d320-aed8-415c-b4c7-870626fe2c2c"), "Online shopping!", false, null },
                    { new Guid("35da2efe-f5b8-45de-a36d-4e7ca8e9fa3d"), 300m, new DateTime(2021, 7, 31, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("5dc6d320-aed8-415c-b4c7-870626fe2c2c"), "Online shopping!", false, null },
                    { new Guid("e0e784a5-4e6d-40fe-a60c-f61b8a377348"), 400m, new DateTime(2021, 7, 1, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("5dc6d320-aed8-415c-b4c7-870626fe2c2c"), "Online shopping!", false, null },
                    { new Guid("de49ec74-cffa-4bcb-9cb9-0808bdca256b"), 500m, new DateTime(2021, 3, 3, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("5dc6d320-aed8-415c-b4c7-870626fe2c2c"), "Online shopping!", false, null },
                    { new Guid("c08c08b5-b220-46c5-ae9f-b3a342ee31f5"), 0m, new DateTime(2021, 8, 30, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("d06497be-1f09-47a8-8773-05d2fea15e51"), "Account Opened!", true, null },
                    { new Guid("4bf7abba-c881-419c-9e13-f7d03729a826"), 100m, new DateTime(2021, 8, 28, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("d06497be-1f09-47a8-8773-05d2fea15e51"), "Online shopping!", false, null },
                    { new Guid("653a0c85-dcfd-43c2-a826-c4d1fd10d7b0"), 200m, new DateTime(2021, 8, 16, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("d06497be-1f09-47a8-8773-05d2fea15e51"), "Online shopping!", false, null },
                    { new Guid("aea91988-9453-49f5-b5c4-a200d8682dea"), 300m, new DateTime(2021, 7, 31, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("d06497be-1f09-47a8-8773-05d2fea15e51"), "Account Opened!", false, null },
                    { new Guid("d9d45749-61e6-4c0b-a1a9-68582e231417"), 400m, new DateTime(2021, 7, 1, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("d06497be-1f09-47a8-8773-05d2fea15e51"), "Online shopping!", false, null },
                    { new Guid("623f67d4-1619-47bd-92a7-043811cc3c3c"), 500m, new DateTime(2021, 3, 3, 6, 47, 7, 684, DateTimeKind.Local).AddTicks(6608), new Guid("d06497be-1f09-47a8-8773-05d2fea15e51"), "Online shopping!", false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
