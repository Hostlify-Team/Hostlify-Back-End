using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostlify.Infraestructure.Migrations
{
    public partial class FoodServiceRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomID",
                table: "FoodServices",
                newName: "roomId");

            migrationBuilder.RenameColumn(
                name: "ManagerID",
                table: "FoodServices",
                newName: "managerId");

            migrationBuilder.RenameColumn(
                name: "Instruction",
                table: "FoodServices",
                newName: "instruction");

            migrationBuilder.RenameColumn(
                name: "DrinkQuantity",
                table: "FoodServices",
                newName: "drinkQuantity");

            migrationBuilder.RenameColumn(
                name: "Drink",
                table: "FoodServices",
                newName: "drink");

            migrationBuilder.RenameColumn(
                name: "DishQuantity",
                table: "FoodServices",
                newName: "dishQuantity");

            migrationBuilder.RenameColumn(
                name: "Dish",
                table: "FoodServices",
                newName: "dish");

            migrationBuilder.RenameColumn(
                name: "CreamQuantity",
                table: "FoodServices",
                newName: "creamQuantity");

            migrationBuilder.RenameColumn(
                name: "Cream",
                table: "FoodServices",
                newName: "cream");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FoodServices",
                newName: "id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(5842),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 503, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(7530),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(8378),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(9303),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(2783));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "FoodServices",
                newName: "RoomID");

            migrationBuilder.RenameColumn(
                name: "managerId",
                table: "FoodServices",
                newName: "ManagerID");

            migrationBuilder.RenameColumn(
                name: "instruction",
                table: "FoodServices",
                newName: "Instruction");

            migrationBuilder.RenameColumn(
                name: "drinkQuantity",
                table: "FoodServices",
                newName: "DrinkQuantity");

            migrationBuilder.RenameColumn(
                name: "drink",
                table: "FoodServices",
                newName: "Drink");

            migrationBuilder.RenameColumn(
                name: "dishQuantity",
                table: "FoodServices",
                newName: "DishQuantity");

            migrationBuilder.RenameColumn(
                name: "dish",
                table: "FoodServices",
                newName: "Dish");

            migrationBuilder.RenameColumn(
                name: "creamQuantity",
                table: "FoodServices",
                newName: "CreamQuantity");

            migrationBuilder.RenameColumn(
                name: "cream",
                table: "FoodServices",
                newName: "Cream");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FoodServices",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 503, DateTimeKind.Local).AddTicks(8268),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(5842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Rooms",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(233),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(7530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "History",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(1700),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(8378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "FoodServices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 20, 5, 40, 504, DateTimeKind.Local).AddTicks(2783),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 3, 31, 22, 21, 34, 409, DateTimeKind.Local).AddTicks(9303));
        }
    }
}
