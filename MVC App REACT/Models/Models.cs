using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


// dotnet aspnet-codegenerator controller -name GebruikerController -m Gebruiker -dc FutureDBContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

namespace MVC_App_REACT.Models {
  public class FutureDBContext : DbContext {
        public DbSet<Gebruiker> gebruiker { get; set; }
        public DbSet<OngeregistreerdeGebruikers> OngeregistreerdeGebruiker { get; set; }
        public DbSet<Favorieten> Favoriet { get; set; }
        public DbSet<FavorietenLijsten> FavorietenLijst { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<Laptops> Laptop { get; set;}
        public DbSet<Categories> Category { get; set; }
        public DbSet<Brands> Brand { get; set; }
        public DbSet<Factuur> Facturen { get; set; }
        public DbSet<FactuurLijsten> FactuurLijst { get; set; }
        public DbSet<OngeregistreerdeFactuur> OngeregistreerdeFacturen { get; set; }
        public DbSet<RecommendedSystems> RecommendedSystem {get; set;}
        public DbSet<Brands_Categories> Brands_Category {get; set;}

    public FutureDBContext(DbContextOptions<FutureDBContext> options): base(options)
            { }

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

    public class OngeregistreerdeGebruikers {
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
        public OngeregistreerdeGebruikers OngeregistreerdeGebruikers {get; set;}
        public int OngeregistreerdeGebruikersId {get; set;}
    }

    public class Factuur {
        public int Id {get; set;}
        public string FactuurBon {get; set;}
        public Gebruiker Gebruiker {get; set;}
        public int GebruikersId {get; set;}
    }

    public class FactuurLijsten {
        public int Id {get; set;}
        public Gebruiker Gebruiker {get; set;}
        public int GebruikersUsername {get; set;}
    }

    public class Products {
        public int Id { get; set; }
        public string Title {get; set;}
        public string Description {get; set;}
        public string Short_Description {get; set;}
        public string Specification {get; set;}
        public string Compatibility {get; set;}
        public int Stock {get; set;}
        public float Price {get; set;}
        public int Amount_Sold {get; set;}
        public Brands Brands {get; set;}
        public int BrandsId {get; set;}
        public Categories Categories {get; set;}
        public int CategoriesId {get; set;}

    }

    public class Brands {
        public int Id {get; set;}
        public string Name {get; set;}
    }

    public class Brands_Categories {
        public int Id {get; set;}
        public Brands Brands {get; set;}
        public int BrandsId {get; set;}
        public Categories Categories {get; set;}
        public int CategoriesId {get; set;}
    }

    public class Categories {
        public int Id {get; set;}
        public string Name {get; set;}
    }

    public class Favorieten {
        public int Id {get; set;}
        public FavorietenLijsten FavorietenLijsten {get; set;}
        public int FavorietenLijstenId {get; set;}
        public Products Products {get; set;}
        public int ProductsId {get; set;}
        
    }

    public class FavorietenLijsten {
        public int Id {get; set;}
        public string Name {get; set;}
        public Gebruiker Gebruiker {get; set;}
        public string GebruikersUsername {get; set;}
    }
    
    public class Laptops { // CPU, GPU, RAM, Screen, HDD, SSD, Weight, Ports (HDMI, USB etc.), Operating System, Disc player, GPU memory.
        public int Id {get; set;}
        public float Price {get; set;}
        public int Stock {get; set;}
        public int Amount_Sold {get; set;}
        public string Description {get; set;}
        public string Short_Description {get; set;}
        public string Image_Path {get; set;}
    }
          
    public class RecommendedSystems {
        public int Id {get; set;}
        public string Gebruik {get; set;}
        public string Level {get; set;}
        public string Title {get; set;}
        public string Short_Description {get; set;}
        public string Long_Description {get; set;}
        public string Image_Path {get; set;}
        public Products Products {get; set;}
        public int ProductsId {get; set;}
    }
    }
  }