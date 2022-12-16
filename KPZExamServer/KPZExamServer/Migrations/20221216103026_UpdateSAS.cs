using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPZExamServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSAS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentStates_Assignments_AssignmentID",
                table: "AssignmentStates");

            migrationBuilder.RenameColumn(
                name: "mark",
                table: "AssignmentStates",
                newName: "Mark");

            migrationBuilder.RenameColumn(
                name: "isPresent",
                table: "AssignmentStates",
                newName: "IsPresent");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "AssignmentStates",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "AssignmentID",
                table: "AssignmentStates",
                newName: "AssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentStates_AssignmentID",
                table: "AssignmentStates",
                newName: "IX_AssignmentStates_AssignmentId");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "AssignmentStates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentStates_Assignments_AssignmentId",
                table: "AssignmentStates",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentStates_Assignments_AssignmentId",
                table: "AssignmentStates");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "AssignmentStates",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "AssignmentStates",
                newName: "mark");

            migrationBuilder.RenameColumn(
                name: "IsPresent",
                table: "AssignmentStates",
                newName: "isPresent");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "AssignmentStates",
                newName: "AssignmentID");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentStates_AssignmentId",
                table: "AssignmentStates",
                newName: "IX_AssignmentStates_AssignmentID");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentID",
                table: "AssignmentStates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentStates_Assignments_AssignmentID",
                table: "AssignmentStates",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "ID");
        }
    }
}
