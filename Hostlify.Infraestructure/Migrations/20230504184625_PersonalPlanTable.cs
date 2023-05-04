using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostlify.Infraestructure.Migrations
{
    public partial class PersonalPlanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(2883),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 10, 4, 47, 903, DateTimeKind.Local).AddTicks(5378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(5541),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 10, 4, 47, 903, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(6573),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 10, 4, 47, 903, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(7512),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 10, 4, 47, 903, DateTimeKind.Local).AddTicks(9227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CleaningServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(8192),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 10, 4, 47, 903, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.CreateTable(
                name: "PersonalPlans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    managerId = table.Column<int>(type: "int", nullable: false),
                    roomsLimit = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalPlans", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalPlans");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 10, 4, 47, 903, DateTimeKind.Local).AddTicks(5378),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 10, 4, 47, 903, DateTimeKind.Local).AddTicks(7373),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 10, 4, 47, 903, DateTimeKind.Local).AddTicks(8266),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 10, 4, 47, 903, DateTimeKind.Local).AddTicks(9227),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CleaningServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 10, 4, 47, 903, DateTimeKind.Local).AddTicks(9860),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(8192));
        }
    }
}
