using PersonDetails.Database;
using PersonDetails.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PersonDetails.Controllers
{
    public class HomeController : Controller
    {
        PersonDbContext db = new PersonDbContext();


        //Http: GET

        public ActionResult Index()
        {
            var data = db.Persons.ToList();

            return View(data);
        }



        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Persons Person)
        {
            if (ModelState.IsValid)
            {

                db.Persons.Add(Person);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(Person);

        }



        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persons person = db.Persons.Find(Id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);

        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,Address,Occupation, Area, Email, ContactNo, Code, Description, IsActive ")]  Persons person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }





        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persons person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persons person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persons person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}