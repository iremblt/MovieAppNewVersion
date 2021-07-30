using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAppNewVersion.Migrations
{
    public partial class OneToOneRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DirectorName",
                table: "Directors",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "DirectorImageUrl",
                table: "Directors",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Directors",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "DirectorId",
                table: "Directors",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imdb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Directors_UserId",
                        column: x => x.UserId,
                        principalTable: "Directors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_People_UserId",
                table: "People",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Directors");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Directors",
                newName: "DirectorName");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Directors",
                newName: "DirectorImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Directors",
                newName: "Biography");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Directors",
                newName: "DirectorId");
        }
    }
}
