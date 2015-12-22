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
        {
            get
            {
                return _context;
            }
        }

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
            return null;
        }

        public List<Tune> GetAllTunes()
        {
            return null;
        }
    }
}

