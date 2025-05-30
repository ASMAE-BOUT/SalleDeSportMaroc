using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalleDeSportMaroc.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateNaissance",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Abonnements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prix = table.Column<double>(type: "float", nullable: false),
                    DureeMois = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonnements_AspNetUsers_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coachs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coachs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Horaire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoachId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cours_Coachs_CoachId",
                        column: x => x.CoachId,
                        principalTable: "Coachs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonnements_UtilisateurId",
                table: "Abonnements",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Cours_CoachId",
                table: "Cours",
                column: "CoachId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonnements");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Coachs");

            migrationBuilder.DropColumn(
                name: "DateNaissance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "AspNetUsers");
        }
    }
}
