using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PGS_zadanie.Models
{
    public class CustomViewModel
    {
        public List<Book> books = new List<Book>();
        public Book bookToEdit = new Book();
    }
}