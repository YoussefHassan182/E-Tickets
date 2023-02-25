using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Tickets.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 2, 18, 31, 651, DateTimeKind.Utc).AddTicks(9777),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 19, 21, 19, 34, 10, DateTimeKind.Utc).AddTicks(4264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 27, 2, 18, 31, 652, DateTimeKind.Utc).AddTicks(357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 24, 21, 19, 34, 10, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "Bio", "FullName", "ProfilePicUrl" },
                values: new object[] { 1, "This is A Bio for lio", "Leonardo Decaprio", "https://www.themoviedb.org/t/p/w500/wo2hJpn04vbtmh0B9utCFdsQhxM.jpg" });

            migrationBuilder.InsertData(
                table: "Cinema",
                columns: new[] { "Id", "Description", "LogoUrl", "Name" },
                values: new object[] { 1, "This is a description", "https://i1.sndcdn.com/avatars-000006124431-8cxru4-t500x500.jpg", "Prince Charles Cinema" });

            migrationBuilder.InsertData(
                table: "Producer",
                columns: new[] { "Id", "Bio", "FullName", "ProfilePicUrl" },
                values: new object[] { 1, "THis is a bio", "Christopher Nolan", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSL7HtY5CubP3o0orL-3WmKeS1geED7RUTciHKN2UY&s" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CinemaId", "Description", "EndDate", "ImageUrl", "MovieCategory", "Name", "Price", "ProducerId", "StartDate" },
                values: new object[] { 1, 1, "This is a description", new DateTime(2023, 2, 24, 4, 18, 31, 657, DateTimeKind.Local).AddTicks(1276), "https://flxt.tmsimg.com/assets/p7825626_p_v8_af.jpg", 7, "Inception", 200.0, 1, new DateTime(2023, 2, 17, 4, 18, 31, 657, DateTimeKind.Local).AddTicks(1260) });

            migrationBuilder.InsertData(
                table: "ActorMovie",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorMovie",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cinema",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 19, 21, 19, 34, 10, DateTimeKind.Utc).AddTicks(4264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 2, 18, 31, 651, DateTimeKind.Utc).AddTicks(9777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 21, 19, 34, 10, DateTimeKind.Utc).AddTicks(5109),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 27, 2, 18, 31, 652, DateTimeKind.Utc).AddTicks(357));
        }
    }
}
