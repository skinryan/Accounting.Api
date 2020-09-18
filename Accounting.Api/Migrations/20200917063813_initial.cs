using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrimaryCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Icon = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "secondaryCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Icon = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PrimaryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_secondaryCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_secondaryCategories_PrimaryCategories_PrimaryId",
                        column: x => x.PrimaryId,
                        principalTable: "PrimaryCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    SecondaryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_secondaryCategories_SecondaryId",
                        column: x => x.SecondaryId,
                        principalTable: "secondaryCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PrimaryCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 1, null, "衣服饰品" });

            migrationBuilder.InsertData(
                table: "PrimaryCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 2, null, "食品酒水" });

            migrationBuilder.InsertData(
                table: "PrimaryCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 3, null, "居家物业" });

            migrationBuilder.InsertData(
                table: "PrimaryCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 4, null, "行车交通" });

            migrationBuilder.InsertData(
                table: "PrimaryCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 5, null, "交流通讯" });

            migrationBuilder.InsertData(
                table: "PrimaryCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 6, null, "休闲娱乐" });

            migrationBuilder.InsertData(
                table: "PrimaryCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 7, null, "人情往来" });

            migrationBuilder.InsertData(
                table: "PrimaryCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 8, null, "医疗保健" });

            migrationBuilder.InsertData(
                table: "PrimaryCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 9, null, "金融保险" });

            migrationBuilder.InsertData(
                table: "PrimaryCategories",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { 10, null, "其他杂项" });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 1, null, "衣服裤子", 1 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 22, null, "投资", 9 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 21, null, "医疗器材", 8 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 20, null, "药品", 8 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 19, null, "问诊治疗", 8 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 18, null, "红包", 7 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 17, null, "送礼", 7 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 16, null, "旅游度假", 6 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 15, null, "休闲玩乐", 6 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 14, null, "腐败聚会", 6 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 13, null, "网络", 5 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 23, null, "按揭还款", 9 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 12, null, "手机", 5 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 10, null, "打车", 4 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 9, null, "公共交通", 4 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 8, null, "维修保养", 3 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 7, null, "水电煤气", 3 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 6, null, "日常用品", 3 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 5, null, "水果零食", 2 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 4, null, "烟酒茶", 2 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 3, null, "早午晚餐", 2 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 25, null, "化妆饰品", 1 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 2, null, "鞋帽包包", 1 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 11, null, "私家车", 4 });

            migrationBuilder.InsertData(
                table: "secondaryCategories",
                columns: new[] { "Id", "Icon", "Name", "PrimaryId" },
                values: new object[] { 24, null, "意外丢失", 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Records_SecondaryId",
                table: "Records",
                column: "SecondaryId");

            migrationBuilder.CreateIndex(
                name: "IX_secondaryCategories_PrimaryId",
                table: "secondaryCategories",
                column: "PrimaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "secondaryCategories");

            migrationBuilder.DropTable(
                name: "PrimaryCategories");
        }
    }
}
