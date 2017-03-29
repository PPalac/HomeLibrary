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
        public ActionResult Index()
        {

            ViewBag.Title = "PGS zadanie";
            ViewBag.Section = "Katalog książek";

            var DataMng = new DataManager();
            var BookList = DataMng.GetListOfBooks();
            return View(BookList);
        }

        public ActionResult Authors()
        {
            ViewBag.Title = "PGS zadanie";
            ViewBag.Section = "Katalog autorów";

            var DataMng = new DataManager();
            var AuthorList = DataMng.GetListOfAuthors();
            return View(AuthorList);
        }

        public ActionResult Genres()
        {
            ViewBag.Title = "PGS zadanie";
            ViewBag.Section = "Katalog gatunków";

            var DataMng = new DataManager();
            var GenreList = DataMng.GetListOfGenres(); 
            return View(GenreList);
        }

        
        


    }
}