using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPageCreate.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/AdminHome/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AdminHome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminHome/Create
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

        // GET: Admin/AdminHome/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/AdminHome/Edit/5
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

        // GET: Admin/AdminHome/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AdminHome/Delete/5
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
