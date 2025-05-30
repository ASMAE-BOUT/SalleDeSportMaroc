using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalleDeSportMaroc.Data.Migrations
{
    /// <inheritdoc />
    public partial class CoachCRUD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Coachs");

            migrationBuilder.AlterColumn<string>(
                name: "Specialite",
                table: "Coachs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Coachs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Coachs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Coachs");

            migrationBuilder.AlterColumn<string>(
                name: "Specialite",
                table: "Coachs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Coachs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Coachs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
