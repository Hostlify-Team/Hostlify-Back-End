using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostlify.Infraestructure.Migrations
{
    public partial class FoodServiceDeleteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "managerId",
                table: "FoodServices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 23, 8, 49, 777, DateTimeKind.Local).AddTicks(5611),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(5842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 23, 8, 49, 777, DateTimeKind.Local).AddTicks(7442),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 23, 8, 49, 777, DateTimeKind.Local).AddTicks(8224),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 23, 8, 49, 777, DateTimeKind.Local).AddTicks(9133),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(9303));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(5842),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 23, 8, 49, 777, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(7530),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 23, 8, 49, 777, DateTimeKind.Local).AddTicks(7442));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(8378),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 23, 8, 49, 777, DateTimeKind.Local).AddTicks(8224));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(9303),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 23, 8, 49, 777, DateTimeKind.Local).AddTicks(9133));

            migrationBuilder.AddColumn<int>(
                name: "managerId",
                table: "FoodServices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
