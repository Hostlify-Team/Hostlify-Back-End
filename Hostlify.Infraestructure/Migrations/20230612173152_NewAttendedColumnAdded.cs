using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostlify.Infraestructure.Migrations
{
    public partial class NewAttendedColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 209, DateTimeKind.Local).AddTicks(8032),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(3989));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 209, DateTimeKind.Local).AddTicks(9492),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(5465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PersonalPlans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(2425),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(263),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(1197),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CleaningServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(1856),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(7706));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(3989),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 209, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(5465),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 209, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PersonalPlans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(8268),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(6207),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(7024),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(1197));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CleaningServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 12, 12, 29, 31, 731, DateTimeKind.Local).AddTicks(7706),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 6, 12, 12, 31, 52, 210, DateTimeKind.Local).AddTicks(1856));
        }
    }
}
