using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.BusinessGateway.Logic.Services.Test;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Test;

namespace WIPCream.Presentation.WUI.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private TestUIDTO testModel;
        private ITestBusinessService testService = new TestBusinessService();

        // GET: Tests
        [Authorize]
        public ActionResult Index()
        {
            //var tests = db.Tests.Include(t => t.Discipline);
            return View(TestMapper.GetTestUIDTOList(testService.RetrieveAll()));
        }

        // GET: Tests/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Tests tests = db.Tests.Find(id);
            TestDTO tests = testService.FindById(id);
            if (tests == null)
            {
                return HttpNotFound();
            }
            return View(TestMapper.GetTestUIDTO(tests));
        }

        // GET: Tests/Create
        public ActionResult Create()
        {
            ViewBag.DisciplineId = new SelectList(testService.getDB().Disciplines, "DisciplineId", "Name");
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestId,DisciplineId,Name,CreatedAt,Image")] TestUIDTO tests)
        {
            if (ModelState.IsValid)
            {
                //db.Tests.Add(tests);
                //db.SaveChanges();
                testService.ResgisterTest(TestMapper.GetTestDTO(tests));
                return RedirectToAction("Index");
            }
            
            ViewBag.DisciplineId = new SelectList(testService.getDB().Disciplines, "DisciplineId", "Name", tests.DisciplineId);
            return View(tests);
        }

        // GET: Tests/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDTO tests = testService.FindById(id);
            if (tests == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisciplineId = new SelectList(testService.getDB().Disciplines, "DisciplineId", "Name", tests.DisciplineId);
            return View(TestMapper.GetTestUIDTO(tests));
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestId,DisciplineId,Name,CreatedAt")] TestUIDTO tests)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(tests).State = EntityState.Modified;
                //db.SaveChanges();
                testService.Update(TestMapper.GetTestDTO(tests));
                return RedirectToAction("Index");
            }
            ViewBag.DisciplineId = new SelectList(testService.getDB().Disciplines, "DisciplineId", "Name", tests.DisciplineId);
            return View(tests);
        }

        // GET: Tests/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDTO tests = testService.FindById(id);
            if (tests == null)
            {
                return HttpNotFound();
            }
            return View(TestMapper.GetTestUIDTO(tests));
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Tests tests = db.Tests.Find(id);
            //db.Tests.Remove(tests);
            //db.SaveChanges();
            testService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                testService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
