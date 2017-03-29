using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PGS_zadanie.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Nie możesz pozostawić pustego pola")]
        public string Title { get; set; }

        public int AuthorID { get; set; }
        public int GenreID { get; set; }

        [Required(ErrorMessage = "Nie możesz pozostawić pustego pola")]
        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; }

        [Required(ErrorMessage = "Nie możesz pozostawić pustego pola")]
        [ForeignKey("GenreID")]
        public virtual Genre Genre { get; set; }
    }
}