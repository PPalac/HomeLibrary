using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PGS_zadanie.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public virtual Author Author { get; set; }

        [Required]
        public virtual Genre Genre { get; set; }
    }
}