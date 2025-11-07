using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                schema: "dbo",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "dbo",
                table: "Workers");

            migrationBuilder.CreateTable(
                name: "WorkerDepartments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Products_DepartmentId",
                schema: "dbo",
                table: "Products",
                column: "DepartmentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Departments_DepartmentId",
                schema: "dbo",
                table: "Products",
                column: "DepartmentId",
                principalSchema: "dbo",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Departments_DepartmentId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropTable(
                name: "WorkerDepartments",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Products_DepartmentId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                schema: "dbo",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
