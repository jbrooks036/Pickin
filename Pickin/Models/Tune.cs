using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pickin.Models
{
    public class Tune
    {
        [Key]
        public int TuneId
        {
            get; set;
        }
        public string Artist
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        public int Year
        {
            get; set;
        }
    }
}
