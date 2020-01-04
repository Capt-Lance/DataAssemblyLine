using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAssemblyLine.Infrastructure.EFCore.Migrations
{
    public partial class AddItemProcessAndSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true),
                    NextStepId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ItemProcessId = table.Column<int>(nullable: true),
                    BodyTemplate = table.Column<string>(nullable: true),
                    HttpMethod = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    TimeToWaitInSeconds = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Steps_NextStepId",
                        column: x => x.NextStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    FirstStepId = table.Column<int>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    MaxItemsToProcess = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemProcesses_Steps_FirstStepId",
                        column: x => x.FirstStepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemProcesses_FirstStepId",
                table: "ItemProcesses",
                column: "FirstStepId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_ItemProcessId",
                table: "Steps",
                column: "ItemProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_NextStepId",
                table: "Steps",
                column: "NextStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_ItemProcesses_ItemProcessId",
                table: "Steps",
                column: "ItemProcessId",
                principalTable: "ItemProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProcesses_Steps_FirstStepId",
                table: "ItemProcesses");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "ItemProcesses");
        }
    }
}
