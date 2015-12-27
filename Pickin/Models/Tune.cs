using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pickin.Models
{
    public class Tune : IComparable
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
        [Required]
        public string Title
        {
            get; set;
        }
        public int Year
        {
            get; set;
        }

        public int CompareTo(object obj)
        {
            Tune other_tune = obj as Tune;
            return this.Title.CompareTo(other_tune.Title);
        }
    }
}
