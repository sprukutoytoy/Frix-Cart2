using Cart2.DAL;
using Cart2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Cart2.Controllers
{
    public class HomeController : Controller
    {
        private readonly CartContext context = new CartContext();

        public ActionResult Index()
        {
            return View(context.Persons.ToList());
        }

        public ActionResult Details(int personId)
        {
            //Item item = context.Items.Find(personId);
            //Item item = context.Items.FirstOrDefault(x => x.PersonID == personId);

            IQueryable<Item> items = context.Items;
            if (personId > 0)
            {
                items = items.Where(p => p.PersonID == personId);
            }


            if (items == null)
            {
                return HttpNotFound();
            }

            ViewBag.PersonId = personId;

            return View(items);
        }

        #region Create
        public ActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost, ActionName("CreatePerson")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePerson([Bind(Include = "Name,Number")] Person person)
        {
            if (ModelState.IsValid)
            {
                context.Persons.Add(person);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult CreateItem(int personId)
        {
            Item item = new Item() { PersonID = personId };
            return View(item);
        }

        [HttpPost, ActionName("CreateItem")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem([Bind(Include = "Title,Weight,PersonId")] Item item)
        {
            if (ModelState.IsValid)
            {
                context.Items.Add(item);
                context.SaveChanges();
                return RedirectToAction("Details", new { personId = item.PersonID });
            }

            return View(item);
        }
        #endregion

        #region Edit
        public ActionResult EditPerson(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = context.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            //ViewBag.PersonID = new SelectList(db.Persons, "Id", "Name", person.PersonID);
            return View(person);
        }

        [HttpPost, ActionName("EditPerson")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerson([Bind(Include = "Id,Name,Number")] Person person)
        {
            if (ModelState.IsValid)
            {
                context.Entry(person).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public ActionResult EditItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("EditItem")]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "Id,Title,Weight,PersonID")] Item item)
        {
            if (ModelState.IsValid)
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Details", new { personId = item.PersonID });
            }
            return View(item);
        }
        #endregion

        #region Delete
        public ActionResult DeletePerson(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = context.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost, ActionName("DeletePerson")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePersonConfirmed(int id)
        {
            Person person = context.Persons.Find(id);
            context.Persons.Remove(person);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = context.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteItem(int id)
        {
            Item item = context.Items.Find(id);
            context.Items.Remove(item);
            context.SaveChanges();
            return RedirectToAction("Details", new { personId = item.PersonID });
        }
        #endregion

        #region Close
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}