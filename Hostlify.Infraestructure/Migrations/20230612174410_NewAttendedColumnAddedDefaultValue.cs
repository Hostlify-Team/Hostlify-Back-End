using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostlify.Infraestructure.Migrations
{
    public partial class NewAttendedColumnAddedDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(969),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 209, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(2401),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 209, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PersonalPlans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(5442),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(3164),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(263));

            migrationBuilder.AlterColumn<bool>(
                name: "attended",
                table: "FoodServices",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(4116),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.AlterColumn<bool>(
                name: "attended",
                table: "CleaningServices",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CleaningServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(4835),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(1856));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 209, DateTimeKind.Local).AddTicks(8032),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 209, DateTimeKind.Local).AddTicks(9492),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PersonalPlans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(2425),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(5442));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(263),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(3164));

            migrationBuilder.AlterColumn<bool>(
                name: "attended",
                table: "FoodServices",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(1197),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(4116));

            migrationBuilder.AlterColumn<bool>(
                name: "attended",
                table: "CleaningServices",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CleaningServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(1856),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 44, 10, 748, DateTimeKind.Local).AddTicks(4835));
        }
    }
}
