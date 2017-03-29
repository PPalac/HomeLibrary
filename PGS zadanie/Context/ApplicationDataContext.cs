using PGS_zadanie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace PGS_zadanie.Context
{
    class Ctx : DbContext
    {
        public Ctx() : base("Library")
        {


        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
    }

}