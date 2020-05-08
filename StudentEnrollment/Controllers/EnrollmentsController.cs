using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentEnrollment.Models;

namespace StudentEnrollment.Controllers
{
    public class EnrollmentsController : Controller
    {
        private EnrollmentDB db = new EnrollmentDB();

        // GET: Enrollments
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Course).Include(e => e.Student);
            return View(enrollments.ToList());
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Title");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "LastName","FirstName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,CourseId,Grade,IsActive,AssingedCampus,EnrollmentSemester,EnrollmentYear,Notes")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Title", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "LastName","FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Title", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "LastName","FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,CourseId,Grade,IsActive,AssingedCampus,EnrollmentSemester,EnrollmentYear,Notes")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Title", enrollment.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "LastName","FirstName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }
        
        // video 3 14:50 
      //  public ActionResult CourseSearch(string q)
      //  {
            //var course = getCourse(q);
          //  return PartialView(course);
      // }

        // Add a ActionMethod in the Enrollment controller named “CourseSearch” which returns a list of Course objects. 
       // private List*<Course> getCourse(string searchString) {
        //    return db.CourseId
         //       where(a => a.Name.Contains(searchString)).toList();
            
        //    throw new NotImplementedException
        
            //    }
        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
            db.SaveChanges();
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

        [HttpGet]
        public ActionResult StudentSearch(string keyword)
        {
            List<Student> studentModel = db.Students.Where(student => student.FirstName.Contains(keyword) ||
            student.LastName.Contains(keyword)).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_StudentSearch", studentModel);
            }

            return PartialView(studentModel);
        }
        [HttpGet]
        public ActionResult CourseSearch(string keyword)
        {
            List<Course> courseModel = db.Courses.Where(course => course.Title.Contains(keyword) ||
            course.Description.Contains(keyword)).ToList();
            if (Request.IsAjaxRequest())
            {
                return PartialView("_CourseSearch", courseModel);
            }

            return PartialView(courseModel);
        }
    }
}

