using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.BusinessGateway.Logic.Services.Assignments;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Assignment;

namespace WIPCream.Presentation.WUI.Controllers
{
    public class AssignmentsController : Controller
    {
        private AssignmentUIDTO disciplineModel;
        private IAssignmentBusinessSerevice assignmentService = new AssignmentBusinessService();

        // GET: Assignments
        [Authorize]
        public ActionResult Index()
        {
            return View(AssignmentMapper.GetAssignmentUIDTOList(assignmentService.RetrieveAll()));
        }

        // GET: Assignments/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentDTO assignment = assignmentService.FindById(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(AssignmentMapper.GetAssignmentUIDTO(assignment));
        }

        // GET: Assignments/Create
        public ActionResult Create()
        {
            ViewBag.DisciplineId = new SelectList(assignmentService.getDB().Disciplines, "DisciplineId", "Name");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignmentId,DisciplineId,Name,Description,CreatedAt,Deadline,Image")] AssignmentUIDTO assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.ResgisterAssignment(AssignmentMapper.GetAssignmentDTO(assignment));
                return RedirectToAction("Index");
            }

            ViewBag.DisciplineId = new SelectList(assignmentService.getDB().Disciplines, "DisciplineId", "Name", assignment.DisciplineId);
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentDTO assignment = assignmentService.FindById(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisciplineId = new SelectList(assignmentService.getDB().Disciplines, "DisciplineId", "Name", assignment.DisciplineId);
            return View(AssignmentMapper.GetAssignmentUIDTO(assignment));
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignmentId,DisciplineId,Name,Description,CreatedAt,Deadline")] AssignmentUIDTO assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Update(AssignmentMapper.GetAssignmentDTO(assignment));
                return RedirectToAction("Index");
            }
            ViewBag.DisciplineId = new SelectList(assignmentService.getDB().Disciplines, "DisciplineId", "Name", assignment.DisciplineId);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignmentDTO assignment = assignmentService.FindById(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(AssignmentMapper.GetAssignmentUIDTO(assignment));
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignmentDTO assignment = assignmentService.FindById(id);
            assignmentService.Delete(assignment.AssignmentId);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                assignmentService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
