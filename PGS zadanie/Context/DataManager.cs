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
                
                    AuthorList = db.Authors.ToList();
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
    }
}