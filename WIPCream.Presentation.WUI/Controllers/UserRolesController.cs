using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.BusinessGateway.Logic.Services.UserRoles;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.UserRole;

namespace WIPCream.Presentation.WUI.Controllers
{
    [Authorize]
    public class UserRolesController : Controller
    {
        private UserRoleUIDTO roleModel;
        private IUserRoleBusinessService roleService=new UserRoleBusinessService();
        // GET: UserRoles
        [Authorize]
        public ActionResult Index()
        {
            var userRoleList = roleService.RetrieveAll();
            return View(UserRoleMapper.GetUserRoleUIDTOList(userRoleList));
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoleDTO userRole = roleService.FindById(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(UserRoleMapper.GetUserRoleUIDTO(userRole));
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(roleService.RetrieveUnassigned(), "UserId", "UserName");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,UserId")] UserRoleUIDTO roles)
        {
            if (ModelState.IsValid)
            {
                roleService.ResgisterRole(UserRoleMapper.GetUserRoleDTO(roles));
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(roleService.getDB().Users, "UserId", "UserName", roles.UserId);
            return View(roles);
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoleDTO userRole = roleService.FindById(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(roleService.getDB().Users, "UserId", "UserName", userRole.UserId);
            return View(UserRoleMapper.GetUserRoleUIDTO(userRole));
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,UserId")] UserRoleUIDTO userRole)
        {
            if (ModelState.IsValid)
            {
                roleService.Update(UserRoleMapper.GetUserRoleDTO(userRole));
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(roleService.getDB().Users, "UserId", "UserName", userRole.UserId);
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRoleDTO userRole = roleService.FindById(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(UserRoleMapper.GetUserRoleUIDTO(userRole));
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            roleService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                roleService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
