using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCASPDOTNETCODEFIRST.Repository;
using MVCASPDOTNETCODEFIRST.Models;
using System.Threading;
using MVCASPDOTNETCODEFIRST.SignalR;

namespace MVCASPDOTNETCODEFIRST.Controllers
{
    public class DefaultController : Controller
    {

        private IUnitOfWork _repository = null;

        public DefaultController()
        {
            this._repository = new UnitOfWork();
        }

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DevTest dev)
        {
            if (ModelState.IsValid)
            {
                var DevRepo = _repository.RepositoryFor<DevTest>();
                DevRepo.Add(dev);
                _repository.SaveChanges();
                BroadCastData.NotifyToAllClients();

            }
            return View();
        }

        public ActionResult BroadCastDBChanges()
        {

            return View();
        }


        public JsonResult SaveRecord(DevTest dev)
        {
            var DevRepo = _repository.RepositoryFor<DevTest>();

            var entity = DevRepo.Find(e => e.ID == dev.ID).FirstOrDefault();
            if (entity == null)
                DevRepo.Add(dev);
            else
            {
                entity.CampaignName = dev.CampaignName;
                entity.AffiliateName = dev.AffiliateName;
                entity.Clicks = dev.Clicks;
                entity.Conversions = dev.Conversions;
                entity.Date = dev.Date;
                entity.Impressions = dev.Impressions;
            }

            _repository.SaveChanges();
            BroadCastData.NotifyToAllClients();

            return Json("Record Saved", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteRecord(int Id)
        {
            var DevRepo = _repository.RepositoryFor<DevTest>();

            var entity = DevRepo.Find(e => e.ID == Id).FirstOrDefault();
            if (entity != null)
                DevRepo.Delete(entity);

            _repository.SaveChanges();
            BroadCastData.NotifyToAllClients();
            return Json("Record Deleted", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetData()
        {
            var reporef = _repository.RepositoryFor<DevTest>();
            var data = reporef.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}