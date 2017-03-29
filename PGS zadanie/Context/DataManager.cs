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

                AuthorList = db.Authors.Include("Books").ToList();
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
                var author = (from a in db.Authors where (a.Name == newBook.Author.Name && a.Surname == newBook.Author.Surname) select a).FirstOrDefault();

                var genre = (from g in db.Genres where (g.Name == newBook.Genre.Name) select g).FirstOrDefault();

               

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
                var author = (from a in db.Authors where (a.Name == newAuthor.Name && a.Surname == newAuthor.Surname) select a).FirstOrDefault();

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
                var book = (from b in db.Books where b.ID == id select b).FirstOrDefault();
                if(book !=null)
                    db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public void RemoveAuthor(int id)
        {
            using (var db = new Ctx())
            {
                var author = (from b in db.Authors where b.ID == id select b).First();
                if (author != null)
                    db.Authors.Remove(author);
                db.SaveChanges();
            }
        }

        public void RemoveGenre(int id)
        {
            using (var db = new Ctx())
            {
                var genre = (from b in db.Genres where b.ID == id select b).First();
                if (genre != null)
                    db.Genres.Remove(genre);
                db.SaveChanges();
            }
        }

        public void EditBook(Book editedBook)
        {
            using (var db = new Ctx())
            {
                var book = db.Books.Include("Author").Include("Genre").Where(b => b.ID == editedBook.ID).FirstOrDefault();
                book.Title = editedBook.Title;
                book.Genre.ID = editedBook.GenreID;
                book.Author.ID = editedBook.AuthorID;
                book.Author.Name = editedBook.Author.Name;
                book.Author.Surname = editedBook.Author.Surname;
                book.Genre.Name = editedBook.Genre.Name;
                db.SaveChanges();
            }
        }
    }
}