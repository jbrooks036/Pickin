using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pickin.Models
{
    public class PickinUser : IComparable
    {
        [Key]
        public int PickinUserId { get; set; }

        public virtual ApplicationUser RealUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        // ICollection, IEnumerable, IQueryable
        public List<Tune> Tunes { get; set; }
        public List<PickinUser> AllPickinUsers { get; set; }

        public int CompareTo(object obj)
        {
            // sort user based on email because email is string AND...
            // .NET knows how to compare strings already.  ha!

            // first need to explicitly cast from boject type to PickinUser type
            PickinUser other_user = obj as PickinUser;
            int answer = this.RealUser.Email.CompareTo(other_user.RealUser.Email);
            return answer;
        }
    }
}

