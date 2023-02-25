using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Tickets.Migrations
{
    public partial class lastoflast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 2, 32, 0, 270, DateTimeKind.Utc).AddTicks(4293),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 2, 18, 31, 651, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 27, 2, 32, 0, 270, DateTimeKind.Utc).AddTicks(4660),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 27, 2, 18, 31, 652, DateTimeKind.Utc).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 24, 4, 32, 0, 273, DateTimeKind.Local).AddTicks(3256), new DateTime(2023, 2, 17, 4, 32, 0, 273, DateTimeKind.Local).AddTicks(3244) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 2, 18, 31, 651, DateTimeKind.Utc).AddTicks(9777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 2, 32, 0, 270, DateTimeKind.Utc).AddTicks(4293));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 27, 2, 18, 31, 652, DateTimeKind.Utc).AddTicks(357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 27, 2, 32, 0, 270, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 24, 4, 18, 31, 657, DateTimeKind.Local).AddTicks(1276), new DateTime(2023, 2, 17, 4, 18, 31, 657, DateTimeKind.Local).AddTicks(1260) });
        }
    }
}
