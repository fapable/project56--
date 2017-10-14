using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MVCAppREACT.Migrations
{
    public partial class MVC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gebruiker",
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
                    table.PrimaryKey("PK_gebruiker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laptop",
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
                    table.PrimaryKey("PK_Laptop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OngeregistreerdeGebruiker",
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
                    table.PrimaryKey("PK_OngeregistreerdeGebruiker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands_Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BrandsId = table.Column<int>(type: "int4", nullable: false),
                    CategoriesId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Category_Brand_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Brands_Category_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Amount_Sold = table.Column<int>(type: "int4", nullable: false),
                    BrandsId = table.Column<int>(type: "int4", nullable: false),
                    CategoriesId = table.Column<int>(type: "int4", nullable: false),
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
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
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
                    GebruikerId = table.Column<int>(type: "int4", nullable: true),
                    GebruikersId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturen_gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactuurLijst",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GebruikerId = table.Column<int>(type: "int4", nullable: true),
                    GebruikersUsername = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactuurLijst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactuurLijst_gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "gebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavorietenLijst",
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
                    table.PrimaryKey("PK_FavorietenLijst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavorietenLijst_gebruiker_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "gebruiker",
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
                    OngeregistreerdeGebruikersId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OngeregistreerdeFacturen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OngeregistreerdeFacturen_OngeregistreerdeGebruiker_OngeregistreerdeGebruikersId",
                        column: x => x.OngeregistreerdeGebruikersId,
                        principalTable: "OngeregistreerdeGebruiker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecommendedSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Gebruik = table.Column<string>(type: "text", nullable: true),
                    Image_Path = table.Column<string>(type: "text", nullable: true),
                    Level = table.Column<string>(type: "text", nullable: true),
                    Long_Description = table.Column<string>(type: "text", nullable: true),
                    ProductsId = table.Column<int>(type: "int4", nullable: false),
                    Short_Description = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendedSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendedSystem_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favoriet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FavorietenLijstenId = table.Column<int>(type: "int4", nullable: false),
                    ProductsId = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoriet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favoriet_FavorietenLijst_FavorietenLijstenId",
                        column: x => x.FavorietenLijstenId,
                        principalTable: "FavorietenLijst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoriet_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Category_BrandsId",
                table: "Brands_Category",
                column: "BrandsId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Category_CategoriesId",
                table: "Brands_Category",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturen_GebruikerId",
                table: "Facturen",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_FactuurLijst_GebruikerId",
                table: "FactuurLijst",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoriet_FavorietenLijstenId",
                table: "Favoriet",
                column: "FavorietenLijstenId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoriet_ProductsId",
                table: "Favoriet",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_FavorietenLijst_GebruikerId",
                table: "FavorietenLijst",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_OngeregistreerdeFacturen_OngeregistreerdeGebruikersId",
                table: "OngeregistreerdeFacturen",
                column: "OngeregistreerdeGebruikersId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandsId",
                table: "Product",
                column: "BrandsId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoriesId",
                table: "Product",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendedSystem_ProductsId",
                table: "RecommendedSystem",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands_Category");

            migrationBuilder.DropTable(
                name: "Facturen");

            migrationBuilder.DropTable(
                name: "FactuurLijst");

            migrationBuilder.DropTable(
                name: "Favoriet");

            migrationBuilder.DropTable(
                name: "Laptop");

            migrationBuilder.DropTable(
                name: "OngeregistreerdeFacturen");

            migrationBuilder.DropTable(
                name: "RecommendedSystem");

            migrationBuilder.DropTable(
                name: "FavorietenLijst");

            migrationBuilder.DropTable(
                name: "OngeregistreerdeGebruiker");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "gebruiker");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
