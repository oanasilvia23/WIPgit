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
using WIPCream.BusinessGateway.Logic.Services.Post;
using WIPCream.BusinessGateway.Logic.Services.Thread;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.Thread;

namespace WIPCream.Presentation.WUI.Controllers
{
    public class ThreadsController : Controller
    {
        private WIPCream2 db = new WIPCream2();
        private ThreadUIDTO threadModel;
        private IThreadBusinessService threadService = new ThreadBusinessService();

        // GET: Threads
        [Authorize]
        public ActionResult Index()
        {
            return View(ThreadMapper.GetThreadUIDTOList(threadService.RetrieveAll()));
        }

        // GET: Threads/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThreadDTO threads = threadService.FindById(id);
            if (threads == null)
            {
                return HttpNotFound();
            }
            return View(ThreadMapper.GetThreadUIDTO(threads));
        }

        // GET: Threads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Threads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "threadid,Email,title,date")] ThreadUIDTO threads)
        {
            threads.date = DateTime.Now;
            if (ModelState.IsValid)
            {
                threadService.ResgisterThread(ThreadMapper.GetThreadDTO(threads));
                return RedirectToAction("Index");
            }

            return View(threads);
        }

        // GET: Threads/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThreadDTO threads = threadService.FindById(id);
            if (threads == null)
            {
                return HttpNotFound();
            }
            return View(ThreadMapper.GetThreadUIDTO(threads));
        }

        // POST: Threads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "threadid,Email,title,date")] ThreadUIDTO threads)
        {
            if (ModelState.IsValid)
            {
                threadService.Update(ThreadMapper.GetThreadDTO(threads));
                return RedirectToAction("Index");
            }
            return View(threads);
        }

        // GET: Threads/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThreadDTO threads = threadService.FindById(id);
            if (threads == null)
            {
                return HttpNotFound();
            }
            return View(ThreadMapper.GetThreadUIDTO(threads));
        }

        // POST: Threads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            threadService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult LoadDetails(int id)
        {
            var thread = threadService.FindById(id);
            ThreadUIDTO threads = ThreadMapper.GetThreadUIDTO(thread);
            //ViewBag.Posts = new SelectList(threadService.getDB().Posts, "PostId", "Posts", id);
            ViewBag.Posts = thread.Posts;
            return View("ViewThread", threads);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddPost(Posts model)
        {
            model.date = DateTime.Now;
            model.Email = User.Identity.Name;
            if (ModelState.IsValid)
            {
                IPostBusinessService postService = new PostBusinessService();
                Mapper.CreateMap<Posts, PostDTO>();
                PostDTO postdto = Mapper.Map<PostDTO>(model);
                postService.ResgisterPost(postdto);
                if (Request.IsAjaxRequest())
                {
                    var allPosts = postService.FindPostByThreadId((int)model.threadid);
                    Mapper.CreateMap<List<PostDTO>, List<Posts>>();
                    var allCommentsUIDTO = Mapper.Map<List<Posts>>(allPosts);
                    return PartialView("Comments", allCommentsUIDTO);
                }
                return RedirectToAction("LoadDetails", "Threads", new { id = model.threadid });
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                threadService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
