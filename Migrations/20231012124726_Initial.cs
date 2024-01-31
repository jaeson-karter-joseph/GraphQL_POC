using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Superheroes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superheroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SuperheroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Superpowers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuperPower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperheroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superpowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Superpowers_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "Description", "Height", "Name" },
                values: new object[,]
                {
                    { new Guid("cc96a917-7538-4bc7-9136-a293f1512c0f"), "Black Widow, real name Natasha Romanoff, is a trained female secret agent and superhero that appears in Marvel Comics. Associated with the superhero teams S.H.I.E.L.D. and the Avengers, Black Widow makes up for her lack of superpowers with world class training as an athlete, acrobat, and expert martial artist and weapon specialist.", 1.7, "Black Widow" },
                    { new Guid("ddcba9df-62e9-42a3-9f10-bf635029c5dc"), "Luke Skywalker was a Tatooine farmboy who rose from humble beginnings to become one of the greatest Jedi the galaxy has ever known. Along with his friends Princess Leia and Han Solo, Luke battled the evil Empire, discovered the truth of his parentage, and ended the tyranny of the Sith.", 1.7, "Luke Skywalker" },
                    { new Guid("f6fe3acc-a335-4e40-9763-d30240978ae9"), "Batman was originally introduced as a ruthless vigilante who frequently killed or maimed criminals, but evolved into a character with a stringent moral code and strong sense of justice. Unlike most superheroes, Batman does not possess any superpowers, instead relying on his intellect, fighting skills, and wealth.", 1.9299999999999999, "Batman" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Instructor", "ReleaseDate", "SuperheroId", "Title" },
                values: new object[,]
                {
                    { new Guid("3a6db708-5e33-48dd-bb36-319b879a2ca3"), "The Dark Knight is a 2008 superhero film directed, produced, and co-written by Christopher Nolan. Based on the DC Comics character Batman, the film is the second installment of Nolan's The Dark Knight Trilogy and a sequel to 2005's Batman Begins, starring Christian Bale and supported by Michael Caine, Heath Ledger, Gary Oldman, Aaron Eckhart, Maggie Gyllenhaal, and Morgan Freeman.", "Christopher Nolan", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f6fe3acc-a335-4e40-9763-d30240978ae9"), "The Dark Knight" },
                    { new Guid("5d7bd131-751f-4c61-b50f-b47c0cc31c06"), "Batman Begins is a 2005 superhero film directed by Christopher Nolan and written by Nolan and David S. Goyer. Based on the DC Comics character Batman, it stars Christian Bale as Bruce Wayne / Batman, with Michael Caine, Liam Neeson, Katie Holmes, Gary Oldman,", "Christopher Nolan", new DateTime(2005, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f6fe3acc-a335-4e40-9763-d30240978ae9"), "Batman Begins" },
                    { new Guid("6c437c95-c7d3-434f-931c-6bf4116b3225"), "The Dark Knight Rises is a 2012 superhero film directed by Christopher Nolan, who co-wrote the screenplay with his brother Jonathan Nolan, and the story with David S. Goyer.", "Christopher Nolan", new DateTime(2012, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f6fe3acc-a335-4e40-9763-d30240978ae9"), "The Dark Knight Rises" },
                    { new Guid("8eeccc2d-b686-4a76-a3d7-6b8db6448766"), "Star Wars (retroactively titled Star Wars: Episode IV – A New Hope) is a 1977 American epic space opera film written and directed by George Lucas, produced by Lucasfilm and distributed by 20th Century Fox.", "George Lucas", new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ddcba9df-62e9-42a3-9f10-bf635029c5dc"), "Star Wars: Episode IV – A New Hope" },
                    { new Guid("949ae330-cf07-4d45-8c44-d326180c305d"), "Black Widow is a 2021 American superhero film based on Marvel Comics featuring the character of the same name. Produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures, it is the 24th film in the Marvel Cinematic Universe (MCU).", "Cate Shortland", new DateTime(2021, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc96a917-7538-4bc7-9136-a293f1512c0f"), "Black Widow" },
                    { new Guid("da245488-3ee7-4ac0-8533-ab04cde89489"), "Return of the Jedi (also known as Star Wars: Episode VI – Return of the Jedi) is a 1983 American epic space opera film directed by Richard Marquand. The screenplay is by Lawrence Kasdan and George Lucas from a story by Lucas, who was also the executive producer.", "Richard Marquand", new DateTime(1983, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ddcba9df-62e9-42a3-9f10-bf635029c5dc"), "Star Wars: Episode VI – Return of the Jedi" },
                    { new Guid("e0982562-9577-4812-a3a2-1918ffc92922"), "The Empire Strikes Back (also known as Star Wars: Episode V – The Empire Strikes Back) is a 1980 American epic space opera film directed by Irvin Kershner and written by Leigh Brackett and Lawrence Kasdan, based on a story by George Lucas.", "Irvin Kershner", new DateTime(1980, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ddcba9df-62e9-42a3-9f10-bf635029c5dc"), "Star Wars: Episode V – The Empire Strikes Back" }
                });

            migrationBuilder.InsertData(
                table: "Superpowers",
                columns: new[] { "Id", "Description", "SuperPower", "SuperheroId" },
                values: new object[,]
                {
                    { new Guid("225c6362-7951-4a4c-850d-f7ff0e470ec9"), "Sublime fighting skills.", "Fighting", new Guid("f6fe3acc-a335-4e40-9763-d30240978ae9") },
                    { new Guid("364240aa-aac2-4b38-a131-9aa810e13b3e"), "The knowledge of how to undermine others.", "Subterfuge", new Guid("cc96a917-7538-4bc7-9136-a293f1512c0f") },
                    { new Guid("3c60d957-21b8-4395-a64d-495fcc9d1017"), "He got a lot of money", "Wealth.", new Guid("f6fe3acc-a335-4e40-9763-d30240978ae9") },
                    { new Guid("424ec4e4-897c-41e2-bcac-b83176996fd0"), "She knows how to infiltrate the enemy.", "Infiltration", new Guid("cc96a917-7538-4bc7-9136-a293f1512c0f") },
                    { new Guid("8e3b3137-5e9e-4c96-b420-984929fc1d72"), "Skywalker is able to deflect fire from a blaster back at the opponent firing. This enables Luke to turn someone else's weapon against them.", "Deflect blaster power.", new Guid("ddcba9df-62e9-42a3-9f10-bf635029c5dc") },
                    { new Guid("d5ecefb4-4504-4e58-a75a-0b6702bf8ade"), "He's always a step ahead.", "Intellect.", new Guid("f6fe3acc-a335-4e40-9763-d30240978ae9") },
                    { new Guid("ff14aaaf-f589-4ba3-a7a3-840b17a7d432"), "She's good at spying at people.", "Espionage", new Guid("cc96a917-7538-4bc7-9136-a293f1512c0f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_SuperheroId",
                table: "Movies",
                column: "SuperheroId");

            migrationBuilder.CreateIndex(
                name: "IX_Superpowers_SuperheroId",
                table: "Superpowers",
                column: "SuperheroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Superpowers");

            migrationBuilder.DropTable(
                name: "Superheroes");
        }
    }
}
