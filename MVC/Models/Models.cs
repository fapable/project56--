using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

// dotnet aspnet-codegenerator controller -name ProductsController -m Product -dc FutureDBContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --controllerNamespace Models
// dotnet aspnet-codegenerator controller -name BrandsCategoriesController -m Brands_Categories -dc FutureDBContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --controllerNamespace Models

namespace MVC.Models {
    public class FutureDBContext : DbContext {
            public DbSet<Gebruiker> gebruikers { get; set; }
            public DbSet<OngeregistreerdeGebruiker> OngeregistreerdeGebruikers { get; set; }
            public DbSet<Favorieten> Favorieten { get; set; }
            public DbSet<FavorietenLijsten> FavorietenLijsten { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Laptop> Laptops { get; set;}
            public DbSet<Category> Categories { get; set; }
            public DbSet<Brand> Brands { get; set; }
            public DbSet<Factuur> Facturen { get; set; }
            public DbSet<FactuurLijsten> FactuurLijsten { get; set; }
            public DbSet<OngeregistreerdeFactuur> OngeregistreerdeFacturen { get; set; }
            public DbSet<RecommendedSystem> RecommendedSystems {get; set;}
            public DbSet<Brand_Categories> Brands_Categories {get; set;}

        public FutureDBContext(DbContextOptions<FutureDBContext> options): base(options)
                { }
    }

    public class Gebruiker {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public string Geboortedatum {get; set;}
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Stad { get; set; }
        public int Telefoonnummer {get; set;}
    }

    public class OngeregistreerdeGebruiker {
        public int Id { get; set; }
        public string EMail { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Stad { get; set; }
        public int Telefoonnummer {get; set;}
    }

    public class OngeregistreerdeFactuur {
        public int Id {get; set;}
        public string FactuurBon {get; set;}
        public OngeregistreerdeGebruiker OngeregistreerdeGebruiker {get; set;}
        public int OngeregistreerdeGebruikerId {get; set;}
    }

    public class Factuur {
        public int Id {get; set;}
        public string FactuurBon {get; set;}
        public Gebruiker Gebruiker {get; set;}
        public int GebruikerId {get; set;}
    }

    public class FactuurLijsten {
        public int Id {get; set;}
        public Gebruiker Gebruiker {get; set;}
        public int GebruikerUsername {get; set;}
    }

    public class Product {
        public int Id { get; set; }
        public string Title {get; set;}
        public string Description {get; set;}
        public string Short_Description {get; set;}
        public string Specification {get; set;}
        public string Compatibility {get; set;}
        public int Stock {get; set;}
        public float Price {get; set;}
        public int Amount_Sold {get; set;}
        public Brand Brand {get; set;}
        public int BrandId {get; set;}
        public Category Category {get; set;}
        public int CategoryId {get; set;}

    }

    public class Brand {
        public int Id {get; set;}
        public string Name {get; set;}
    }

    public class Brand_Categories {
        public int Id {get; set;}
        public Brand Brand {get; set;}
        public int BrandId {get; set;}
        public Category Category {get; set;}
        public int CategoryId {get; set;}
    }

    public class Category {
        public int Id {get; set;}
        public string Name {get; set;}
    }

    public class Favorieten {
        public int Id {get; set;}
        public FavorietenLijsten FavorietenLijsten {get; set;}
        public int FavorietenLijstenId {get; set;}
        public Product Product {get; set;}
        public int ProductsId {get; set;}
        
    }

    public class FavorietenLijsten {
        public int Id {get; set;}
        public string Name {get; set;}
        public Gebruiker Gebruiker {get; set;}
        public string GebruikersUsername {get; set;}
    }
    
    public class Laptop { // CPU, GPU, RAM, Screen, HDD, SSD, Weight, Ports (HDMI, USB etc.), Operating System, Disc player, GPU memory.
        public int Id {get; set;}
        public float Price {get; set;}
        public int Stock {get; set;}
        public int Amount_Sold {get; set;}
        public string Description {get; set;}
        public string Short_Description {get; set;}
        public string Image_Path {get; set;}
    }
          
    public class RecommendedSystem {
        public int Id {get; set;}
        public string Gebruik {get; set;}
        public string Level {get; set;}
        public string Title {get; set;}
        public string Short_Description {get; set;}
        public string Long_Description {get; set;}
        public string Image_Path {get; set;}
        public Product Product {get; set;}
        public int ProductsId {get; set;}
    }
}