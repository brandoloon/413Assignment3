using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class MovieModel
    {
        [DisplayName("Category"), Required]
        public string category { get; set; }

        [DisplayName("Title"), Required]
        public string title { get; set; }

        [DisplayName("Release Year"), Required]
        public int year { get; set; }

        [DisplayName("Director"), Required]
        public string director { get; set; }

        [DisplayName("Rating"), Required]
        public string rating { get; set; }

        [DisplayName("Edited")]
        public bool edited { get; set; }

        [DisplayName("Lent To")]
        public string lentTo { get; set; }

        [DisplayName("Notes"), MaxLength(25)]
        public string notes { get; set; }

    }
}
