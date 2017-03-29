﻿using PGS_zadanie.Context;
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
                return RedirectToAction("Index", "Home");

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

        public ActionResult RemoveBook(int id)
        {

            var dataMng = new DataManager();
            dataMng.RemoveBook(id);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveAuthor(int id)
        {

            var dataMng = new DataManager();
            dataMng.RemoveAuthor(id);

            return RedirectToAction("Authors", "Home");
        }

        public ActionResult RemoveGenre(int id)
        {

            var dataMng = new DataManager();
            dataMng.RemoveGenre(id);

            return RedirectToAction("Genres", "Home");
        }

        public ActionResult Edit(int id)
        {
            Book bookToEdit = new Book();
            using (var db = new Ctx())
            {
                var books = db.Books.Include("Author").Include("Genre").ToList();
                bookToEdit = books.Where(b => b.ID == id).FirstOrDefault();
            }
            return View(bookToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Book editedBook)
        {
            var dataMng = new DataManager();
            dataMng.EditBook(editedBook);
            return RedirectToAction("Index", "Home");
        }
    }
}