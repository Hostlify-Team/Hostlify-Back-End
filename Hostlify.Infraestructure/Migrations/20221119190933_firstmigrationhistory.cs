using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostlify.Infraestructure.Migrations
{
    public partial class firstmigrationhistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Plans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 14, 9, 32, 910, DateTimeKind.Local).AddTicks(7943),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 8, 17, 6, 35, 864, DateTimeKind.Local).AddTicks(841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 19, 14, 9, 32, 910, DateTimeKind.Local).AddTicks(9062),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 8, 17, 6, 35, 864, DateTimeKind.Local).AddTicks(2001));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Plans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 8, 17, 6, 35, 864, DateTimeKind.Local).AddTicks(841),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 19, 14, 9, 32, 910, DateTimeKind.Local).AddTicks(7943));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 8, 17, 6, 35, 864, DateTimeKind.Local).AddTicks(2001),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 19, 14, 9, 32, 910, DateTimeKind.Local).AddTicks(9062));
        }
    }
}
