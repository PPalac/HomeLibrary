using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PGS_zadanie.Models
{
    public class CustomViewModel
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
    }

}