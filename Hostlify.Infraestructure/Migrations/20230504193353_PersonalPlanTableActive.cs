using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostlify.Infraestructure.Migrations
{
    public partial class PersonalPlanTableActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(790),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(2883));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(5630),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "PersonalPlans",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PersonalPlans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(9099),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(6666),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(7896),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(7512));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CleaningServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(8528),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(8192));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(2883),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(5541),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "PersonalPlans",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "PersonalPlans",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(9099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(6573),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(6666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(7512),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(7896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "CleaningServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 46, 24, 868, DateTimeKind.Local).AddTicks(8192),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 5, 4, 14, 33, 53, 145, DateTimeKind.Local).AddTicks(8528));
        }
    }
}
