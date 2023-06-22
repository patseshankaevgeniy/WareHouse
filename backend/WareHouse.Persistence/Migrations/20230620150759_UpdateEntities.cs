using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkerDepartments",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "DepartmentWorker",
                schema: "dbo",
                columns: table => new
                {
                    DepartmentsId = table.Column<int>(type: "int", nullable: false),
                    WorkersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentWorker", x => new { x.DepartmentsId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_DepartmentWorker_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentWorker_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalSchema: "dbo",
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentWorker_WorkersId",
                schema: "dbo",
                table: "DepartmentWorker",
                column: "WorkersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentWorker",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "WorkerDepartments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerDepartments_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalSchema: "dbo",
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkerDepartments_DepartmentId",
                schema: "dbo",
                table: "WorkerDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerDepartments_WorkerId",
                schema: "dbo",
                table: "WorkerDepartments",
                column: "WorkerId");
        }
    }
}
