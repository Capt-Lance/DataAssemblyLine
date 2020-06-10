using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAssemblyLine.Infrastructure.EFCore.Migrations
{
    public partial class PluralizeItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Steps_LastCompletedStepId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Processes_ProcessId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ProcessId",
                table: "Items",
                newName: "IX_Items_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_LastCompletedStepId",
                table: "Items",
                newName: "IX_Items_LastCompletedStepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Steps_LastCompletedStepId",
                table: "Items",
                column: "LastCompletedStepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Processes_ProcessId",
                table: "Items",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Steps_LastCompletedStepId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Processes_ProcessId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ProcessId",
                table: "Item",
                newName: "IX_Item_ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_LastCompletedStepId",
                table: "Item",
                newName: "IX_Item_LastCompletedStepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Steps_LastCompletedStepId",
                table: "Item",
                column: "LastCompletedStepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Processes_ProcessId",
                table: "Item",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
