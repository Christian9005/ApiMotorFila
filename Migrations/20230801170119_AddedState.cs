using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMotorFila.Migrations
{
    /// <inheritdoc />
    public partial class AddedState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Motors",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Motors");
        }
    }
}
