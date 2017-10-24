using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MVC.Migrations
{
    public partial class MVCInitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Achternaam = table.Column<string>(type: "text", nullable: true),
                    EMail = table.Column<string>(type: "text", nullable: true),
                    Geboortedatum = table.Column<string>(type: "text", nullable: true),
                    Huisnummer = table.Column<string>(type: "text", nullable: true),
                    Postcode = table.Column<string>(type: "text", nullable: true),
                    Stad = table.Column<string>(type: "text", nullable: true),
                    Straat = table.Column<string>(type: "text", nullable: true),
                    Telefoonnummer = table.Column<int>(type: "int4", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Voornaam = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Amount_Sold = table.Column<int>(type: "int4", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Image_Path = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "float4", nullable: false),
                    Short_Description = table.Column<string>(type: "text", nullable: true),
                    Stock = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OngeregistreerdeGebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Achternaam = table.Column<string>(type: "text", nullable: true),
                    EMail = table.Column<string>(type: "text", nullable: true),
                    Huisnummer = table.Column<string>(type: "text", nullable: true),
                    Postcode = table.Column<string>(type: "text", nullable: true),
                    Stad = table.Column<string>(type: "text", nullable: true),
                    Straat = table.Column<string>(type: "text", nullable: true),
                    Telefoonnummer = table.Column<int>(type: "int4", nullable: false),
                    Voornaam = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OngeregistreerdeGebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BrandId = table.Column<int>(type: "int4", nullable: false),
                    CategoryId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Categories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Brands_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Amount_Sold = table.Column<int>(type: "int4", nullable: false),
                    BrandId = table.Column<int>(type: "int4", nullable: false),
                    CategoryId = table.Column<int>(type: "int4", nullable: false),
                    Compatibility = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "float4", nullable: false),
                    Short_Description = table.Column<string>(type: "text", nullable: true),
                    Specification = table.Column<string>(type: "text", nullable: true),
                    Stock = table.Column<int>(type: "int4", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FactuurBon = table.Column<string>(type: "text", nullable: true),
                    GebruikerId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturen_gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FactuurLijsten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GebruikerId = table.Column<int>(type: "int4", nullable: true),
                    GebruikerUsername = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactuurLijsten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactuurLijsten_gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavorietenLijsten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GebruikerId = table.Column<int>(type: "int4", nullable: true),
                    GebruikersUsername = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavorietenLijsten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavorietenLijsten_gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OngeregistreerdeFacturen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FactuurBon = table.Column<string>(type: "text", nullable: true),
                    OngeregistreerdeGebruikerId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OngeregistreerdeFacturen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OngeregistreerdeFacturen_OngeregistreerdeGebruikers_OngeregistreerdeGebruikerId",
                        column: x => x.OngeregistreerdeGebruikerId,
                        principalTable: "OngeregistreerdeGebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommendedSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Gebruik = table.Column<string>(type: "text", nullable: true),
                    Image_Path = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<string>(type: "text", nullable: true),
                    Long_Description = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<int>(type: "int4", nullable: true),
                    ProductsId = table.Column<int>(type: "int4", nullable: false),
                    Short_Description = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendedSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendedSystems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favorieten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FavorietenLijstenId = table.Column<int>(type: "int4", nullable: false),
                    ProductId = table.Column<int>(type: "int4", nullable: true),
                    ProductsId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorieten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorieten_FavorietenLijsten_FavorietenLijstenId",
                        column: x => x.FavorietenLijstenId,
                        principalTable: "FavorietenLijsten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorieten_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Categories_BrandId",
                table: "Brands_Categories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Categories_CategoryId",
                table: "Brands_Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_GebruikerId",
                table: "Facturen",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_FactuurLijsten_GebruikerId",
                table: "FactuurLijsten",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorieten_FavorietenLijstenId",
                table: "Favorieten",
                column: "FavorietenLijstenId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorieten_ProductId",
                table: "Favorieten",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavorietenLijsten_GebruikerId",
                table: "FavorietenLijsten",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_OngeregistreerdeFacturen_OngeregistreerdeGebruikerId",
                table: "OngeregistreerdeFacturen",
                column: "OngeregistreerdeGebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendedSystems_ProductId",
                table: "RecommendedSystems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands_Categories");

            migrationBuilder.DropTable(
                name: "Facturen");

            migrationBuilder.DropTable(
                name: "FactuurLijsten");

            migrationBuilder.DropTable(
                name: "Favorieten");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "OngeregistreerdeFacturen");

            migrationBuilder.DropTable(
                name: "RecommendedSystems");

            migrationBuilder.DropTable(
                name: "FavorietenLijsten");

            migrationBuilder.DropTable(
                name: "OngeregistreerdeGebruikers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "gebruikers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
