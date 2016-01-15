using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.BusinessGateway.Logic.Services.Question;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Question;

namespace WIPCream.Presentation.WUI.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private QuestionUIDTO questionModel;
        private IQuestionBusinessService questionService = new QuestionBusinessService();

        //private WIPCream2 db = new WIPCream2();

        // GET: Questions
        [Authorize]
        public ActionResult Index()
        {
            return View(QuestionMapper.GetQuestionUIDTOList(questionService.RetrieveAll()));
        }

        // GET: Questions/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Questions questions = db.Questions.Find(id);
            QuestionDTO questions = questionService.FindById(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(QuestionMapper.GetQuestionUIDTO(questions));
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.TestId = new SelectList(questionService.getDB().Tests, "TestID", "Name");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionId,TestId,CorrectAnswer,CreatedAt")] QuestionUIDTO questions)
        {
            if (ModelState.IsValid)
            {
                //db.Questions.Add(questions);
                //db.SaveChanges();
                questionService.RegisterQuestion(QuestionMapper.GetQuestionDTO(questions));
                return RedirectToAction("Index");
            }

            ViewBag.TestId = new SelectList(questionService.getDB().Tests, "TestId", "Name", questions.TestId);
            return View(questions);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Questions questions = db.Questions.Find(id);
            QuestionDTO questions = questionService.FindById(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestId = new SelectList(questionService.getDB().Tests, "TestId", "Name", questions.TestId);
            return View(QuestionMapper.GetQuestionUIDTO(questions));
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionId,TestId,CorrectAnswer,CreatedAt")] QuestionUIDTO questions)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(questions).State = EntityState.Modified;
                //db.SaveChanges();
                questionService.Update(QuestionMapper.GetQuestionDTO(questions));
                return RedirectToAction("Index");
            }
            ViewBag.TestId = new SelectList(questionService.getDB().Tests, "TestId", "Name", questions.TestId);
            return View(questions);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Questions questions = db.Questions.Find(id);
            QuestionDTO questions = questionService.FindById(id);
            if (questions == null)
            {
                return HttpNotFound();
            }
            return View(QuestionMapper.GetQuestionUIDTO(questions));
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Questions questions = db.Questions.Find(id);
            //db.Questions.Remove(questions);
            //db.SaveChanges();
            questionService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                questionService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
