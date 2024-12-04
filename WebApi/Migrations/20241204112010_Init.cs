using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 15.99m, "Moby Dick" },
                    { 2, 9.49m, "Pride and Prejudice" },
                    { 3, 20.00m, "War and Peace" },
                    { 4, 10.99m, "The Great Gatsby" },
                    { 5, 14.99m, "1984" },
                    { 6, 12.49m, "To Kill a Mockingbird" },
                    { 7, 8.99m, "The Catcher in the Rye" },
                    { 8, 13.49m, "The Hobbit" },
                    { 9, 11.99m, "Fahrenheit 451" },
                    { 10, 15.00m, "Brave New World" },
                    { 11, 18.49m, "Crime and Punishment" },
                    { 12, 19.99m, "The Brothers Karamazov" },
                    { 13, 10.99m, "The Odyssey" },
                    { 14, 12.99m, "The Iliad" },
                    { 15, 9.99m, "Jane Eyre" },
                    { 16, 8.49m, "Wuthering Heights" },
                    { 17, 10.49m, "Great Expectations" },
                    { 18, 9.49m, "Oliver Twist" },
                    { 19, 22.00m, "Les Misérables" },
                    { 20, 17.99m, "Anna Karenina" },
                    { 21, 11.49m, "A Tale of Two Cities" },
                    { 22, 23.99m, "Don Quixote" },
                    { 23, 21.99m, "The Divine Comedy" },
                    { 24, 7.99m, "The Old Man and the Sea" },
                    { 25, 19.99m, "Ulysses" },
                    { 26, 14.49m, "The Sound and the Fury" },
                    { 27, 12.99m, "Beloved" },
                    { 28, 13.99m, "Slaughterhouse-Five" },
                    { 29, 11.99m, "The Sun Also Rises" },
                    { 30, 10.99m, "On the Road" },
                    { 31, 8.99m, "Of Mice and Men" },
                    { 32, 15.49m, "Catch-22" },
                    { 33, 16.99m, "Lolita" },
                    { 34, 14.99m, "Middlemarch" },
                    { 35, 9.49m, "Frankenstein" },
                    { 36, 10.49m, "Dracula" },
                    { 37, 11.49m, "Rebecca" },
                    { 38, 10.99m, "The Picture of Dorian Gray" },
                    { 39, 9.99m, "Sense and Sensibility" },
                    { 40, 8.99m, "Persuasion" },
                    { 41, 9.49m, "Emma" },
                    { 42, 7.49m, "A Christmas Carol" },
                    { 43, 12.99m, "David Copperfield" },
                    { 44, 8.99m, "The Scarlet Letter" },
                    { 45, 9.49m, "Mansfield Park" },
                    { 46, 8.49m, "Northanger Abbey" },
                    { 47, 14.99m, "Bleak House" },
                    { 48, 10.49m, "Hard Times" },
                    { 49, 12.49m, "Dombey and Son" },
                    { 50, 11.99m, "Little Women" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
