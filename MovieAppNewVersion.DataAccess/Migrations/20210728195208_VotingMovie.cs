using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAppNewVersion.Migrations
{
    public partial class VotingMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Movies_MovieId",
                table: "Votes");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Votes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Movies_MovieId",
                table: "Votes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Movies_MovieId",
                table: "Votes");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Movies_MovieId",
                table: "Votes",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
