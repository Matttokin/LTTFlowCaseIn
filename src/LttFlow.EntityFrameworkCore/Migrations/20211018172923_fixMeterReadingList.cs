using Microsoft.EntityFrameworkCore.Migrations;

namespace LttFlow.Migrations
{
    public partial class fixMeterReadingList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "GroupId",
                table: "MeterReadingList",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadingList_GroupId",
                table: "MeterReadingList",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadingList_MeterReadingGroupList_GroupId",
                table: "MeterReadingList",
                column: "GroupId",
                principalTable: "MeterReadingGroupList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadingList_MeterReadingGroupList_GroupId",
                table: "MeterReadingList");

            migrationBuilder.DropIndex(
                name: "IX_MeterReadingList_GroupId",
                table: "MeterReadingList");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "MeterReadingList",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
