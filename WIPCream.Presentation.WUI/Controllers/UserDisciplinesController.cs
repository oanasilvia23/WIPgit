using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.BusinessGateway.Logic.Services.UserDisciplines;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.UserDiscipline;

namespace WIPCream.Presentation.WUI.Controllers
{
    [Authorize]
    public class UserDisciplinesController : Controller
    {
        private UserDisciplineUIDTO userDisciplineModel;
        private IUserDisciplineBusinessService userService;

        // GET: UserDisciplines
        [Authorize]
        public ActionResult Index()
        {
            userService = new UserDisciplineBusinessService();
            return View(UserDisciplineMapper.GetUserDisciplineUIDTOList(userService.RetrieveAll()));
        }

        // GET: UserDisciplines/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userService = new UserDisciplineBusinessService();
            UserDisciplineDTO userDiscipline = userService.FindById(id);
            Mapper.CreateMap<UserDisciplineDTO, UserDisciplineUIDTO>();
            UserDisciplineUIDTO ud= Mapper.Map<UserDisciplineUIDTO>(userDiscipline);
            if (ud == null)
            {
                return HttpNotFound();
            }
            return View(ud);
        }

        // GET: UserDisciplines/Create
        public ActionResult Create()
        {
            userService = new UserDisciplineBusinessService();
            ViewBag.DisciplineId = new SelectList(userService.getDB().Disciplines, "DisciplineId", "Name");
            ViewBag.UsereId = new SelectList(userService.getDB().Users, "UserId", "UserName");
            return View();
        }

        // POST: UserDisciplines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserDisciplineId,UsereId,DisciplineId")] UserDisciplineUIDTO userDiscipline)
        {
            if (ModelState.IsValid)
            {
                userService = new UserDisciplineBusinessService();

                userService.ResgisterUserDiscipline(UserDisciplineMapper.GetUserDisciplineDTO(userDiscipline));
                return RedirectToAction("Index");
            }

            ViewBag.DisciplineId = new SelectList(userService.getDB().Disciplines, "DisciplineId", "Name", userDiscipline.DisciplineId);
            ViewBag.UsereId = new SelectList(userService.getDB().Users, "UserId", "UserName", userDiscipline.UsereId);
            return View(userDiscipline);
        }

        // GET: UserDisciplines/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userService = new UserDisciplineBusinessService();
            UserDisciplineDTO userDiscipline = userService.FindById(id);
            Mapper.CreateMap<UserDisciplineDTO, UserDisciplineUIDTO>();
            UserDisciplineUIDTO ud = Mapper.Map<UserDisciplineUIDTO>(userDiscipline);
            if (userDiscipline == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisciplineId = new SelectList(userService.getDB().Disciplines, "DisciplineId", "Name", userDiscipline.DisciplineId);
            ViewBag.UsereId = new SelectList(userService.getDB().Users, "UserId", "UserName", userDiscipline.UsereId);
            return View(ud);
        }

        // POST: UserDisciplines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserDisciplineId,UsereId,DisciplineId")] UserDisciplineUIDTO userDiscipline)
        {
            if (ModelState.IsValid)
            {
                userService = new UserDisciplineBusinessService();
                userService.Update(UserDisciplineMapper.GetUserDisciplineDTO(userDiscipline));
                return RedirectToAction("Index");
            }
            ViewBag.DisciplineId = new SelectList(userService.getDB().Disciplines, "DisciplineId", "Name", userDiscipline.DisciplineId);
            ViewBag.UsereId = new SelectList(userService.getDB().Users, "UserId", "UserName", userDiscipline.UsereId);
            return View(userDiscipline);
        }

        // GET: UserDisciplines/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userService = new UserDisciplineBusinessService();
            UserDisciplineDTO userDiscipline = userService.FindById(id);
            Mapper.CreateMap<UserDisciplineDTO, UserDisciplineUIDTO>();
            UserDisciplineUIDTO ud = Mapper.Map<UserDisciplineUIDTO>(userDiscipline);
            if (userDiscipline == null)
            {
                return HttpNotFound();
            }
            return View(ud);
        }

        // POST: UserDisciplines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userService = new UserDisciplineBusinessService();
            UserDisciplineDTO userDiscipline = userService.FindById(id);
            userService.Delete(userDiscipline.UserDisciplineId);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userService = new UserDisciplineBusinessService();
                userService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
