using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhatT1808A.Models;

namespace PhatT1808A.Controllers
{
    public class StudentsController : Controller
    {
        private Context db = new Context();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.Where(s=>s.Status!=StudentStatus.Deleted).ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RollNumber,FullName,Email,CreatedAt,UpdatedAt,DeletedAt,Status")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.CreatedAt = DateTime.Now;
                student.UpdatedAt = DateTime.Now;
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RollNumber,FullName,Email,Status")] Student student)
        {
            if (student==null||student.RollNumber==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exitstudent = db.Students.Find(student.RollNumber);
            if (exitstudent==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                exitstudent.FullName = student.FullName;
                exitstudent.Email = student.Email;
                exitstudent.Status = student.Status;
                db.Students.AddOrUpdate(exitstudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exitStudent = db.Students.Find(id);
            if (exitStudent==null||exitStudent.Status==StudentStatus.Deleted)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                exitStudent.Status = StudentStatus.Deleted;
                exitStudent.DeletedAt = DateTime.Now;
                db.Students.Remove(exitStudent);
                db.SaveChanges();
            }
           
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
