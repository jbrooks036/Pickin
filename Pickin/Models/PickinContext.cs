using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Pickin.Models
{
    public class PickinContext : DbContext
    {
        // IDbSet, IQueryable
        public virtual DbSet<PickinUser> PickinUsers { get; set; }
        public virtual DbSet<Tune> Tunes { get; set; }
    }
}
