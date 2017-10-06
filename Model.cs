using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Models{
  public class FutureDBContext : DbContext {
        public DbSet<User> User { get; set; }
        public DbSet<BookmarkList> BookmarkList { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Bookmark> Bookmark { get; set; }
        public DbSet<Factuur> Factuur { get; set; }
        public DbSet<FactuurList> FactuurList { get; set; }
        public DbSet<UnregisteredUser> UnregisteredUser { get; set; }
        public DbSet<UnregisteredFactuur> UnregisteredFactuur { get; set; }
        public DbSet<RecommendedSystems> RecommendedSystems {get; set;}
        public DbSet<Brands_Categories> Brands_Categories {get; set;}

// We moeten nog een line toevoegen bij Startup.cs deze line te kunnen uncommenten.
//   public FutureDBContext(DbContextOptions<FutureDBContext> options): base(options)
//         { }
//     }

    public class User {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Stad { get; set; }
        public int Phonenumber {get; set;}
    }

    public class UnregisteredUser {
        public int Id { get; set; }
        public string EMail { get; set; }
        public string BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Stad { get; set; }
        public int Phonenumber {get; set;}
    }

    public class UnregisteredFactuur {
        public int Id {get; set;}
        public string FactuurBon {get; set;}
        public UnregisteredUser UnregisteredUser {get; set;}
        public int UnregisteredUserId {get; set;}
    }

    public class Factuur {
        public int Id {get; set;}
        public string FactuurBon {get; set;}
        public User User {get; set;}
        public int UserId {get; set;}
    }

    public class FactuurList {
        public int Id {get; set;}
        public User User {get; set;}
        public int UserUsername {get; set;}
    }

    public class Products {
        public int Id { get; set; }
        public string Name {get; set;}
        public string Description {get; set;}
        public string Short_Description {get; set;}
        public string Specs {get; set;}
        public int Aantal {get; set;}
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

    public class Bookmark {
        public int Id {get; set;}
        public BookmarkList BookmarkList {get; set;}
        public int BookmarkListId {get; set;}
        public Products Products {get; set;}
        public int ProductsId {get; set;}
        
    }

    public class BookmarkList {
        public int Id {get; set;}
        public string Name {get; set;}
        public User User {get; set;}
        public string UserUsername {get; set;}
    }

    public class RecommendedSystems {
        public int Id {get; set;}
        public string Gebruik {get; set;}
        public Products Products {get; set;}
        public int ProductsId {get; set;}
        // in progress nog, maakt dit af my boy
    }
}