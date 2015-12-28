using Pickin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Pickin.Controllers
{
    public class PickinController : Controller
    {
        public PickinRepository Repo { get; set; }

        public PickinController() : base()
        {
            Repo = new PickinRepository();
        }

        // GET: Pickin
        public ActionResult Index()
        {
            string user_id = User.Identity.GetUserId();
            ApplicationUser real_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
            PickinUser me = null;
            try
            {
                me = Repo.GetAllUsers().Where(u => u.RealUser.Id == user_id).Single();
            } catch (Exception)
            {
                bool successful = Repo.CreatePickinUser(real_user);
                if (successful)
                {
                }
                else
                {
                }
            }
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
