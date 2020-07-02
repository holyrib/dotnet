using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz.Models
{
    public class MoviesViewModels
    {
        public int Id { get; set; }
        public int Id_unique { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
    }


}