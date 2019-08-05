/*
 * =============================================
 * Title : Courts Offices Controller
 * Author : Osama Tarek
 * Date : 7/2019 
 * Training in the Ministry of Justice
 * =============================================
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SupportSystemMOJ.Models;
using SupportSystemMOJ.dbModels;

namespace SupportSystemMOJ.Controllers
{
    public class CourtsOfficesController : Controller
    {
        private MOJEntities db = new MOJEntities();

        // GET: CourtsOffices
        public ActionResult Index()
        {
            var courtsOffices = db.CourtsOffices.Include(c => c.Court).ToList();

            List<CourtsOfficesDto> courtsoffices = new List<CourtsOfficesDto>();

            foreach (var item in courtsOffices)
            {
                courtsoffices.Add(new CourtsOfficesDto
                {
                    CourtId = item.CourtId,
                    Id = item.Id,
                    IsActive = item.IsActive,
                    IsWorking = item.IsWorking,
                    OfficeName = item.OfficeName,
                    OfficeNo = item.OfficeNo,
                    WorkPercentage = item.WorkPercentage,
                    Court = item.Court
                });
            }

            return View(courtsoffices);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
