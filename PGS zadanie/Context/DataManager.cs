using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PGS_zadanie.Models;

namespace PGS_zadanie.Context
{
    public class DataManager
    {
        public List<Genre> GetListOfGenres()
        {
            List<Genre> GenreList = new List<Genre>();
            using (var db = new Ctx())
            {

                GenreList = db.Genres.ToList();
            }
            return GenreList;
        }


        public List<Author> GetListOfAuthors()
        {
            List<Author> AuthorList = new List<Author>();
            using (var db = new Ctx())
            {

                //AuthorList = db.Authors.Include("Book").ToList();
            }
            return AuthorList;
        }


        public List<Book> GetListOfBooks()
        {
            List<Book> BookList = new List<Book>();

            using (var db = new Ctx())
            {

                BookList = db.Books.Include("Author").Include("Genre").ToList();
            }
            return BookList;
        }


        public void AddBook(Book newBook)
        {
            using (var db = new Ctx())
            {
                var author = (from a in db.Authors where (a.Name == newBook.Author.Name && a.Surname == newBook.Author.Surname) select a).SingleOrDefault();

                var genre = (from g in db.Genres where (g.Name == newBook.Genre.Name) select g).SingleOrDefault();



                if (author != null)
                {
                    newBook.Author = author;
                }

                if (genre != null)
                {
                    newBook.Genre = genre;
                }


                db.Books.Add(newBook);

                db.SaveChanges();


            }
        }

        public void AddAuthor(Author newAuthor)
        {
            using (var db = new Ctx())
            {
                var author = (from a in db.Authors where (a.Name == newAuthor.Name && a.Surname == newAuthor.Surname) select a).SingleOrDefault();

                if (author == null)
                {
                    db.Authors.Add(newAuthor);
                }
                db.SaveChanges();
            }
        }


        public void AddGenre(Genre newGenre)
        {
            using (var db = new Ctx())
            {
                var author = (from g in db.Authors where g.Name == newGenre.Name select g).SingleOrDefault();

                if (author == null)
                {
                    db.Genres.Add(newGenre);

                }
                db.SaveChanges();

            }
        }

        public void RemoveBook(int id)
        {
            using (var db = new Ctx())
            {
                var book = (from b in db.Books where b.ID == id select b).First();
                if (book != null)
                    db.Books.Remove(book);
                db.SaveChanges();
            }
        }
    }
}