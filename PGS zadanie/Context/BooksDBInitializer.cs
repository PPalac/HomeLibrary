using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PGS_zadanie.Models;

namespace PGS_zadanie.Context
{
    public class BooksDBInitializer : DropCreateDatabaseAlways<Ctx>
    {
        protected override void Seed(Ctx context)
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { Title = "Wiedźmin", Author = new Author { Name = "Andrzej", Surname = "Sapkowski"}, Genre = new Genre { Name = "Fantasy" } });
            books.Add(new Book { Title = "Tożsamość Bourne'a", Author = new Author { Name = "Robert", Surname = "Ludlum"}, Genre = new Genre { Name = "Akcja"} });
            books.Add(new Book { Title = "Quo vadis", Author = new Author { Name = "Henryk", Surname = "Sienkiewicz"}, Genre = new Genre { Name = "Powieść"} });
            books.Add(new Book { Title = "Kamienie na szaniec", Author = new Author { Name = "Aleksander", Surname = "Kamiński"}, Genre = new Genre { Name = "Dramat"} });


            foreach (var book in books)
            {
                context.Books.Add(book);
            }
            base.Seed(context);
        }
    }
}