using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pickin.Models
{
    public class PickinUser
    {
        [Key]
        public int PickinUserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        // ICollection, IEnumerable, IQueryable
        public List<Tune> Tunes { get; set; }
        public List<PickinUser> AllPickinUsers { get; set; }
    }
}

