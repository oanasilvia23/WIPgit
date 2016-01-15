using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.BusinessGateway.Logic.Services.Course;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Course;

namespace WIPCream.Presentation.WUI.Controllers
{
    public class CoursesController : Controller
    {
        private CourseUIDTO courseModel;
        private ICourseBusinessService courseService = new CourseBusinessService();

        // GET: Courses
        [Authorize]
        public ActionResult Index()
        {
            //var courses = db.Courses.Include(c => c.Discipline);
            return View(CourseMapper.GetCourseUIDTOList(courseService.RetrieveAll()));
        }

        // GET: Courses/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDTO courses = courseService.FindById(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(CourseMapper.GetCourseUIDTO(courses));
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.DisciplineId = new SelectList(courseService.getDB().Disciplines, "DisciplineId", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,DisciplineId,Name,Description,CreatedAt,Deadline,Image")] CourseUIDTO courses)
        {
            if (ModelState.IsValid)
            {
                courseService.ResgisterCourse(CourseMapper.GetCourseDTO(courses));
                return RedirectToAction("Index");
            }

            ViewBag.DisciplineId = new SelectList(courseService.getDB().Disciplines, "DisciplineId", "Name", courses.DisciplineId);
            return View(courses);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDTO courses = courseService.FindById(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisciplineId = new SelectList(courseService.getDB().Disciplines, "DisciplineId", "Name", courses.DisciplineId);
            return View(CourseMapper.GetCourseUIDTO(courses));
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,DisciplineId,Name,Description,CreatedAt,Deadline")] CourseUIDTO courses)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(courses).State = EntityState.Modified;
                //db.SaveChanges();
                courseService.Update(CourseMapper.GetCourseDTO(courses));
                return RedirectToAction("Index");
            }
            ViewBag.DisciplineId = new SelectList(courseService.getDB().Disciplines, "DisciplineId", "Name", courses.DisciplineId);
            return View(courses);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseDTO courses = courseService.FindById(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(CourseMapper.GetCourseUIDTO(courses));
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            courseService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                courseService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
