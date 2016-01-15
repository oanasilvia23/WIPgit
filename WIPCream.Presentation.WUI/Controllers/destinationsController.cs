using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIPCream.BusinessGateway.Logic.Model;
using WIPCream.BusinessGateway.Logic.Services.Destinations;
using WIPCream.DataGateway.DAL2.Models;
using WIPCream.Presentation.WUI.App_Helper;
using WIPCream.Presentation.WUI.App_Helper.AutoMapper;
using WIPCream.Presentation.WUI.Models.PW9;

namespace WIPCream.Presentation.WUI.Controllers
{
    public class destinationsController : Controller
    {
        private destinationUIDTO userDestinationModel;
        private IDestinationBusinessService destinationService = new DestinationBusinessService();

        // GET: destinations
        public ActionResult CommitSearch(destinationListUIDTO model)
        {
            if (model.Filter.LocationName != null && model.Filter.Cost != 0)
            {
                var locationName = model.Filter.LocationName;
                var cost = model.Filter.Cost;
                var all = destinationService.RetrieveAll();
                List<destinationUIDTO> res=new List<destinationUIDTO>();
                for (int i = 0; i < all.Count; i++)
                {
                    if (all[i].Cost == cost && all[i].LocationName.Equals(locationName))
                        res.Add(destinationMapper.GetDestinationUIDTO(all[i]));
                }
                //var test = destinationService.getDB().destinations.Where(i=>i.LocationName.Equals(model.Filter.LocationName) && i.Cost==model.Filter.Cost).AsEnumerable<destination>();
                var test = res.AsEnumerable<destinationUIDTO>();
                var viewModel = new destinationListUIDTO
                {
                    Destinations = test.ToPagedList<destinationUIDTO>(1, 20),
                    Filter = new destinationUIDTO()
                };

                return View("Index", viewModel);
            }
            if (model.Filter.LocationName != null)
            {
                var location = model.Filter.LocationName;
                    var all=destinationService.RetrieveAll();
                List<destinationUIDTO> res = new List<destinationUIDTO>();
                for (int i = 0; i < all.Count; i++)
                {
                    if (all[i].LocationName.Equals(location))
                        res.Add(destinationMapper.GetDestinationUIDTO(all[i]));
                }
                var test = res.AsEnumerable<destinationUIDTO>();

                var viewModel = new destinationListUIDTO
                {
                    Destinations = test.ToPagedList<destinationUIDTO>(1, 20),
                    Filter = new destinationUIDTO()
                };

                return View("Index", viewModel);
            }
            if (model.Filter.Cost != 0)
            {
                var cost = model.Filter.Cost;
                var all = destinationService.RetrieveAll();
                List<destinationUIDTO> res = new List<destinationUIDTO>();
                for (int i = 0; i < all.Count; i++)
                {
                    if (all[i].Cost==cost)
                        res.Add(destinationMapper.GetDestinationUIDTO(all[i]));
                }
                var test = res.AsEnumerable<destinationUIDTO>();

                var viewModel = new destinationListUIDTO
                {
                    Destinations = test.ToPagedList<destinationUIDTO>(1, 20),
                    Filter = new destinationUIDTO()
                };

                return View("Index", viewModel);
            }

            return RedirectToAction("SearchEntityByPage", "destinations");
        }
        // GET: destinations/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destinationDTO destination = destinationService.FindById(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destinationMapper.GetDestinationUIDTO(destination));
        }

        // GET: destinations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: destinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DestinationID,LocationName,Country,Description,TouristTarget,Cost")] destinationUIDTO destination)
        {
            if (ModelState.IsValid)
            {
                destinationService.ResgisterDestination(destinationMapper.GetDestinationDTO(destination));
                return RedirectToAction("SearchEntityByPage", "destinations");
            }

            return View(destination);
        }

        // GET: destinations/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destinationDTO destination = destinationService.FindById(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destinationMapper.GetDestinationUIDTO(destination));
        }
        
        [Authorize]
        public ActionResult SearchEntityByPage(destinationListUIDTO model, int page = 1)
        {
            destinationUIDTO destModel = new destinationUIDTO();
            if (model != null && model.Filter != null && model.Filter.LocationName != null)
            {
                destModel.DestinationID = model.Filter.DestinationID;
                destModel.Description = model.Filter.Description;
                destModel.Country = model.Filter.Country;
                destModel.Cost = model.Filter.Cost;
                destModel.LocationName = model.Filter.LocationName;
                destModel.TouristTarget = model.Filter.TouristTarget;
            }

            var entityModel = new destinaitonHelper().GetDestinations(destModel, page);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_DestinationList", entityModel);
            }
            return View("Index", entityModel);
        }

        // POST: destinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DestinationID,LocationName,Country,Description,TouristTarget,Cost")] destinationUIDTO destination)
        {
            if (ModelState.IsValid)
            {
                destinationService.Update(destinationMapper.GetDestinationDTO(destination));
                return RedirectToAction("SearchEntityByPage", "destinations");
            }
            return View(destination);
        }

        // GET: destinations/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            destinationDTO destination = destinationService.FindById(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destinationMapper.GetDestinationUIDTO(destination));
        }

        // POST: destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            destinationService.Delete(id);
            return RedirectToAction("SearchEntityByPage", "destinations");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                destinationService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
