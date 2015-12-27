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
            // SQL:  select * from Tunes;
            var query = from tune in _context.Tunes select tune;
            List<Tune> found_tunes = query.ToList();
            // found_tunes.Sort();
            return found_tunes;
        }

        public bool CreateTune(string title)
        {
            Tune a_tune = new Tune { Title = title };
            bool is_added = true;
            try
            {
                Tune added_tune = _context.Tunes.Add(a_tune);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                is_added = false;
            }
            return is_added;
        }
    }
}

