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
using WIPCream.BusinessGateway.Logic.Services.User;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models;
using WIPCream.Presentation.WUI.Models.User;

namespace WIPCream.Presentation.WUI.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        //private WIPCreamEntities db = new WIPCreamEntities();
        private UserUIDTO userModel;
        private IUsersBusinessService userService;

        // GET: Users
        [Authorize]
        public ActionResult Index()
        {
            userService = new UserBusinessService();

            return View(UserMapper.GetUserUIDTOList(userService.RetrieveAll()));
            //return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userService = new UserBusinessService();
            UsersDTO users = userService.FindById(id);
            Mapper.CreateMap<UsersDTO, UserUIDTO>();
            UserUIDTO model = Mapper.Map<UserUIDTO>(users);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,FirstName,Lastname,Email,StudentId,Password,Role")] UserUIDTO users)
        {
            if (ModelState.IsValid)
            {
                userService = new UserBusinessService();
                userService.ResgisterUser(UserMapper.GetUserDTO(users));
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userService = new UserBusinessService();
            UsersDTO users = userService.FindById(id);
            Mapper.CreateMap<UsersDTO, UserUIDTO>();
            UserUIDTO model = Mapper.Map<UserUIDTO>(users);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,FirstName,Lastname,Email,StudentId,Password")] UserUIDTO users)
        {
            userService = new UserBusinessService();
            if (ModelState.IsValid)
            {
                userService.Update(UserMapper.GetUserDTO(users));
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userService = new UserBusinessService();
            UsersDTO users = userService.FindById(id);
            Mapper.CreateMap<UsersDTO, UserUIDTO>();
            UserUIDTO model = Mapper.Map<UserUIDTO>(users);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userService = new UserBusinessService();
            UsersDTO users = userService.FindById(id);
            userService.Delete(users.UserId);
            //Users users = db.Users.Find(id);
            //db.Users.Remove(users);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userService = new UserBusinessService();
                userService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
