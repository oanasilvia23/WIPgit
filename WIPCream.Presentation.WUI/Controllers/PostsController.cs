using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.BusinessGateway.Logic.Services.Post;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Post;

namespace WIPCream.Presentation.WUI.Controllers
{
    public class PostsController : Controller
    {
        private PostUIDTO postModel;
        private IPostBusinessService postService = new PostBusinessService();

        // GET: Posts
        [Authorize]
        public ActionResult Index()
        {
            return View(PostMapper.GetPostUIDTOList(postService.RetrieveAll()));
        }

        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostDTO posts = postService.FindById(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(PostMapper.GetPostUIDTO(posts));
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.threadid = new SelectList(postService.getDB().Threads, "threadid", "title");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "postid,threadid,userid,title,date,message")] PostUIDTO posts)
        {
            if (ModelState.IsValid)
            {
                postService.ResgisterPost(PostMapper.GetPostDTO(posts));
                return RedirectToAction("Index");
            }

            ViewBag.threadid = new SelectList(postService.getDB().Threads, "threadid", "title", posts.threadid);
            return View(posts);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostDTO posts = postService.FindById(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            ViewBag.threadid = new SelectList(postService.getDB().Threads, "threadid", "title", posts.threadid);
            return View(posts);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "postid,threadid,userid,title,date,message")] PostUIDTO posts)
        {
            if (ModelState.IsValid)
            {
                postService.Update(PostMapper.GetPostDTO(posts));
                    return RedirectToAction("Index");
            }
            ViewBag.threadid = new SelectList(postService.getDB().Threads, "threadid", "title", posts.threadid);
            return View(posts);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostDTO posts = postService.FindById(id);
            if (posts == null)
            {
                return HttpNotFound();
            }
            return View(PostMapper.GetPostUIDTO(posts));
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            postService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                postService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
