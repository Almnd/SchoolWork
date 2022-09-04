using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib.Moviedata;

namespace WebService.Models
{
    public class CompareDto
    {
        public Movies TitleId { get; set; }
        public Movies PrimaryTitle { get; set; }

        public Genres Genre { get; set; }

        public Details Startyear { get; set; }
        public Details EndYear { get; set; }
        public Details RunTimeMinutes { get; set; } //int? used to fix that some values are null in the DB

        public Actors Nconst { get; set; }
        public Actors PrimaryName { get; set; }
    }
}
