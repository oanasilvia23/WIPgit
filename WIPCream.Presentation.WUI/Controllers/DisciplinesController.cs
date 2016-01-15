using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.BusinessGateway.Logic.Services.Disciplines;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Discipline;

namespace WIPCream.Presentation.WUI.Controllers
{
    [Authorize]
    public class DisciplinesController : Controller
    {
        private DisciplineUIDTO userDisciplineModel;
        private IDisciplineBusinessService disciplineService=new DisciplineBusinessService();

        // GET: Disciplines
        [Authorize]
        public ActionResult Index()
        {

            return View(DisciplineMapper.GetDisciplineUIDTOList(disciplineService.RetrieveAll()));
        }

        // GET: Disciplines/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisciplineDTO discipline = disciplineService.FindById(id);
            if (discipline == null)
            {
                return HttpNotFound();
            }
            return View(DisciplineMapper.GetDisciplineUIDTO(discipline));
        }

        // GET: Disciplines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disciplines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DisciplineId,Name")] DisciplineUIDTO discipline)
        {
            if (ModelState.IsValid)
            {
                disciplineService.ResgisterDiscipline(DisciplineMapper.GetDisciplineDTO(discipline));
                return RedirectToAction("Index");
            }

            return View(discipline);
        }

        // GET: Disciplines/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DisciplineDTO discipline = disciplineService.FindById(id);
            if (discipline == null)
            {
                return HttpNotFound();
            }
            return View(DisciplineMapper.GetDisciplineUIDTO(discipline));
        }

        // POST: Disciplines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DisciplineId,Name")] DisciplineUIDTO discipline)
        {
            if (ModelState.IsValid)
            {
                disciplineService.Update(DisciplineMapper.GetDisciplineDTO(discipline));
                return RedirectToAction("Index");
            }
            return View(discipline);
        }

        // GET: Disciplines/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DisciplineDTO discipline = disciplineService.FindById(id);
            if (discipline == null)
            {
                return HttpNotFound();
            }
            return View(DisciplineMapper.GetDisciplineUIDTO(discipline));
        }

        // POST: Disciplines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DisciplineDTO discipline = disciplineService.FindById(id);
            disciplineService.Delete(discipline.DisciplineId);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                disciplineService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
