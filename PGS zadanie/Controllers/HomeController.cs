using PGS_zadanie.Context;
using PGS_zadanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PGS_zadanie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int id)
        {

            var BookList = new List<Book>();
            var DataMng = new DataManager();

            ViewBag.Section = "Katalog książek";

            if (id == 0)
            {
                BookList = DataMng.GetListOfBooksByTitle();
            }

            if (id == 1)
            {
                BookList = DataMng.GetListOfBooksByAuthor();
            }

            if (id == 2)
            {
                BookList = DataMng.GetListOfBooksByGenere();
            }


            return View(BookList);
        }



        public ActionResult Authors(int id)
        {
            var DataMng = new DataManager();
            var AuthorList = new List<Author>();

            ViewBag.Section = "Katalog autorów";

            if (id == 0)
            {
                AuthorList = DataMng.GetListOfAuthorsBySurname();
            }
            if (id == 1)
            {
                AuthorList = DataMng.GetListOfAuthorsByName();
            }

            return View(AuthorList);
        }
        
        public ActionResult Genres()
        {
            var DataMng = new DataManager();
            var GenreList = new List<Genre>();

            ViewBag.Section = "Katalog gatunków";

            GenreList = DataMng.GetListOfGenres();
            
            return View(GenreList);
        }

        public ActionResult BookDetails(int id)
        {
            Book bookInf = new Book();
            using (var db = new Ctx())
            {
                bookInf = db.Books.Include("Author").Include("Genre").Where(b => b.ID == id).FirstOrDefault();
            }
            return View(bookInf);
        }

        public ActionResult AuthorDetails(int id)
        {
            Author authorInf = new Author();
            using (var db = new Ctx())
            {
                authorInf = db.Authors.Include("Books").Where(b => b.ID == id).FirstOrDefault();
            }
            return View(authorInf);
        }

        public ActionResult GenreDetails(int id)
        {
            Genre genreInf = new Genre();
            using (var db = new Ctx())
            {
                genreInf = db.Genres.Include("Books").Where(b => b.ID == id).FirstOrDefault();
            }
            return View(genreInf);
        }

        public ActionResult Search()
        {
            CustomViewModel listContainer = new CustomViewModel();
            return View(listContainer);
        }

        [HttpPost]
        public ActionResult Search(string Search)
        {
            CustomViewModel listContainer = new CustomViewModel();
            DataManager DataMng = new DataManager();

            listContainer = DataMng.Search(Search);
            return View(listContainer);
        }






    }
}