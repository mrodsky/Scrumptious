using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scrumptious.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Project_Name = table.Column<string>(maxLength: 250, nullable: false),
                    Project_Requirements = table.Column<string>(type: "text", nullable: false),
                    Project_Description = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    FirstName = table.Column<string>(maxLength: 200, nullable: false),
                    LastName = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    Role = table.Column<string>(maxLength: 20, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    Sprint_Description = table.Column<string>(type: "text", nullable: false),
                    SprintId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Completed = table.Column<bool>(nullable: false),
                    fk_ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.SprintId);
                    table.ForeignKey(
                        name: "fk_ProjectId",
                        column: x => x.fk_ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Backlog",
                columns: table => new
                {
                    BacklogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_SprintId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backlog", x => x.BacklogId);
                    table.ForeignKey(
                        name: "fk_SprintId",
                        column: x => x.fk_SprintId,
                        principalTable: "Sprint",
                        principalColumn: "SprintId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Completed = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Task_Description = table.Column<string>(type: "text", nullable: false),
                    Requirements = table.Column<string>(type: "text", nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fk_UserId = table.Column<int>(nullable: true),
                    fk_BacklogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "fk_BacklogId",
                        column: x => x.fk_BacklogId,
                        principalTable: "Backlog",
                        principalColumn: "BacklogId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_UserId",
                        column: x => x.fk_UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Step_Description = table.Column<string>(type: "text", nullable: false),
                    StepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Completed = table.Column<bool>(nullable: false),
                    fk_TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.StepId);
                    table.ForeignKey(
                        name: "fk_Step_TaskId",
                        column: x => x.fk_TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backlog_fk_SprintId",
                table: "Backlog",
                column: "fk_SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_fk_ProjectId",
                table: "Sprint",
                column: "fk_ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Step_fk_TaskId",
                table: "Step",
                column: "fk_TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_fk_BacklogId",
                table: "Task",
                column: "fk_BacklogId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_fk_UserId",
                table: "Task",
                column: "fk_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Backlog");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
