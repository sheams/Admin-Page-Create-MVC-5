using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminPageCreate.Models;
using Microsoft.AspNet.Identity;
using System.Text;

namespace AdminPageCreate.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Pages
        public async Task<ActionResult> Index()
        {
            return View(await db.Pages.ToListAsync());
        }

        // GET: Admin/Pages/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = await db.Pages.FindAsync(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,MetaKeyword,MetaDescription,ShortDescription,Body,Status")] Page page, string bodyText)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                page.CreateBy = userId;
                page.ModifyBy = userId;
                page.CreationDate = DateTime.Now;
                page.ModificationDate = DateTime.Now;
                var htmBody = Encoding.UTF8.GetBytes(bodyText);
                page.Body = htmBody;

                db.Pages.Add(page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = await db.Pages.FindAsync(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,MetaKeyword,MetaDescription,ShortDescription,Body,CreationDate,ModificationDate,CreateBy,ModifyBy,Status")] Page page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(page).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = await db.Pages.FindAsync(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Page page = await db.Pages.FindAsync(id);
            db.Pages.Remove(page);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
