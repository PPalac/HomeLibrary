using PGS_zadanie.Context;
using PGS_zadanie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PGS_zadanie.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        [HttpGet]
        public ActionResult AddBook()
        {
            ViewBag.Title = "PGS zadanie";
            return View();
        }

        // Dodaj nową książkę
        [HttpPost]
        public ActionResult AddBook(Book newBook)
        {

            if (ModelState.IsValid)
            {
                DataManager dataMng = new DataManager();
                dataMng.AddBook(newBook);
                return RedirectToAction("Genres", "Home");

            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            ViewBag.Title = "PGS zadanie";

            return View();
        }

        //Dodaj nowego autora
        [HttpPost]
        public ActionResult AddAuthor(Author newAuthor)
        {
            if (newAuthor.Name != null)
            {
                DataManager dataMng = new DataManager();
                dataMng.AddAuthor(newAuthor);
                return RedirectToAction("Authors", "Home");

            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult AddGenre()
        {
            ViewBag.Title = "PGS zadanie";
            Genre newGenre = new Genre();
            return View(newGenre);
        }



        [HttpPost]
        public ActionResult AddGenre(Genre newGenre)
        {
            if (newGenre.Name != null)
            {
                DataManager dataMng = new DataManager();
                dataMng.AddGenre(newGenre);
                return RedirectToAction("Genres", "Home");

            }
            else
                return View();

        }
    }
}