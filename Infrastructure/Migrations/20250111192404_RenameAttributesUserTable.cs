using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameAttributesUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDesativacao",
                table: "Users",
                newName: "DeletionTime");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Users",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Users",
                newName: "Active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletionTime",
                table: "Users",
                newName: "DataDesativacao");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Users",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Users",
                newName: "Ativo");
        }
    }
}
