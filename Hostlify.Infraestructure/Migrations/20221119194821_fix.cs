using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostlify.Infraestructure.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Plans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 14, 48, 21, 157, DateTimeKind.Local).AddTicks(4927),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 19, 14, 9, 32, 910, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "History",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 14, 48, 21, 157, DateTimeKind.Local).AddTicks(6007),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 19, 14, 9, 32, 910, DateTimeKind.Local).AddTicks(9062));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Plans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 14, 9, 32, 910, DateTimeKind.Local).AddTicks(7943),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 19, 14, 48, 21, 157, DateTimeKind.Local).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "History",
                keyColumn: "description",
                keyValue: null,
                column: "description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "History",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 14, 9, 32, 910, DateTimeKind.Local).AddTicks(9062),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 19, 14, 48, 21, 157, DateTimeKind.Local).AddTicks(6007));
        }
    }
}
