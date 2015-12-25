using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pickin.Models
{
    public class PickinRepository
    {
        private PickinContext _context;
        public PickinContext Context
        { get { return _context; } }

        public PickinRepository()
        {
            _context = new PickinContext();
        }

        public PickinRepository(PickinContext a_context)
        {
            _context = a_context;
        }

        public List<PickinUser> GetAllUsers()
        {
            var query = from users in _context.PickinUsers select users;
            return query.ToList();
        }

        public List<Tune> GetAllTunes()
        {
            return null;
        }
    }
}

