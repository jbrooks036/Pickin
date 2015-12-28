using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickin.Controllers
{
    public class PickinController : Controller
    {
        // GET: Pickin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pickin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pickin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pickin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pickin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pickin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pickin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pickin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
