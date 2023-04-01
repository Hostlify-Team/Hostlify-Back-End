using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostlify.Infraestructure.Migrations
{
    public partial class initialDateRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Initialdate",
                table: "Rooms",
                newName: "InitialDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 503, DateTimeKind.Local).AddTicks(8268),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(3962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(233),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(1700),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(6457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(2783),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(7409));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InitialDate",
                table: "Rooms",
                newName: "Initialdate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(3962),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 503, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(5570),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(6457),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 30, 11, 49, 50, 36, DateTimeKind.Local).AddTicks(7409),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(2783));
        }
    }
}
