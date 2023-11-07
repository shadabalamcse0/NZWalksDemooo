using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b117a07c-6b9c-4207-9720-ba5142c3c587"), "Hard" },
                    { new Guid("d228706e-d4ef-4d84-9e62-caf3a60178cb"), "Medium" },
                    { new Guid("f531e97a-4768-48d4-9fa7-e9efc6de70d7"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("4b5f3ebc-9101-4528-ada9-06fb9d410916"), "STL", "SouthLand", null },
                    { new Guid("4d382db1-36fe-41fe-b3f9-3b3290334080"), "BOP", "Boy of Plenty", null },
                    { new Guid("5f2cb01e-9a47-4753-b6c7-1d4025ab83a4"), "NTL", "Northland", null },
                    { new Guid("7b4b1dd9-3e7c-4038-8859-f0acf84350e4"), "WGN", "Wellington", "wellingtonimage.jpg" },
                    { new Guid("eb86604d-bb3a-4fab-a03a-80008de50949"), "NSN", "Nelson", "nelsonimage.jpg" },
                    { new Guid("f1c1bd1f-f7c0-4a8e-b3d2-ae03b71c5895"), "AKL", "Auckland", " aucklandseaimage.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b117a07c-6b9c-4207-9720-ba5142c3c587"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d228706e-d4ef-4d84-9e62-caf3a60178cb"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f531e97a-4768-48d4-9fa7-e9efc6de70d7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4b5f3ebc-9101-4528-ada9-06fb9d410916"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4d382db1-36fe-41fe-b3f9-3b3290334080"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5f2cb01e-9a47-4753-b6c7-1d4025ab83a4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7b4b1dd9-3e7c-4038-8859-f0acf84350e4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("eb86604d-bb3a-4fab-a03a-80008de50949"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f1c1bd1f-f7c0-4a8e-b3d2-ae03b71c5895"));
        }
    }
}
