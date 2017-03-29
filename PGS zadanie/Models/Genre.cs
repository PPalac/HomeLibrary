using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PGS_zadanie.Models
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Nie możesz pozostawić pustego pola")]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}