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
            using (var db = new Ctx())
            {
                db.Books.Add(newBook);
                db.SaveChanges();
            }
            return RedirectToAction("Index","Home");
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
            using (var db = new Ctx())
            {
                db.Authors.Add(newAuthor);
                db.SaveChanges();
            }
            return RedirectToAction("Books", "Home");
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
            using (var db = new Ctx())
            {
                db.Genres.Add(newGenre);
                db.SaveChanges();
            }
            return RedirectToAction("Genres","Home");
        }
    }
}