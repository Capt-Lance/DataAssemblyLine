using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAssemblyLine.Infrastructure.EFCore.Migrations
{
    public partial class AbstractClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProcesses_Steps_FirstStepId",
                table: "ItemProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_ItemProcesses_ItemProcessId",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Steps_ItemProcessId",
                table: "Steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemProcesses",
                table: "ItemProcesses");

            migrationBuilder.DropColumn(
                name: "ItemProcessId",
                table: "Steps");

            migrationBuilder.RenameTable(
                name: "ItemProcesses",
                newName: "Processes");

            migrationBuilder.RenameIndex(
                name: "IX_ItemProcesses_FirstStepId",
                table: "Processes",
                newName: "IX_Processes_FirstStepId");

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "Steps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Processes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processes",
                table: "Processes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ProcessId",
                table: "Steps",
                column: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Steps_FirstStepId",
                table: "Processes",
                column: "FirstStepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Processes_ProcessId",
                table: "Steps",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Steps_FirstStepId",
                table: "Processes");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Processes_ProcessId",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_Steps_ProcessId",
                table: "Steps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processes",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Processes");

            migrationBuilder.RenameTable(
                name: "Processes",
                newName: "ItemProcesses");

            migrationBuilder.RenameIndex(
                name: "IX_Processes_FirstStepId",
                table: "ItemProcesses",
                newName: "IX_ItemProcesses_FirstStepId");

            migrationBuilder.AddColumn<int>(
                name: "ItemProcessId",
                table: "Steps",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemProcesses",
                table: "ItemProcesses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ItemProcessId",
                table: "Steps",
                column: "ItemProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProcesses_Steps_FirstStepId",
                table: "ItemProcesses",
                column: "FirstStepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_ItemProcesses_ItemProcessId",
                table: "Steps",
                column: "ItemProcessId",
                principalTable: "ItemProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
