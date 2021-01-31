using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class MovieModel
    {
        public string category { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public bool edited { get; set; }
        public string lentTo { get; set; }
        public string notes { get; set; }

    }
}
