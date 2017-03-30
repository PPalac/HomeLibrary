using PGS_zadanie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace PGS_zadanie.Context
{
    public class Ctx : DbContext
    {
        public Ctx() : base("Library")
        {
           // Database.SetInitializer(new BooksDBInitializer());

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
    }

    

}