/*
 * =============================================
 * Title : Courts Controller
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
    public class CourtsController : Controller
    {
        private MOJEntities db = new MOJEntities();

        // GET: Courts
        public ActionResult Index()
        {
            var Courts = db.Courts.ToList();

            List<CourtDto> courts = new List<CourtDto>();

            foreach (var item in Courts)
            {
                courts.Add(new CourtDto
                {
                    AllowAppointment = item.AllowAppointment,
                    CategoryID = item.CategoryID,
                    CityCode = item.CityCode,
                    CityID = item.CityID,
                    CourtCode = item.CourtCode,
                    CourtID = item.CourtID,
                    CourtName = item.CourtName,
                    IsActive = item.IsActive,
                    OldCourtId = item.OldCourtId,
                    RegionCode = item.RegionCode,
                    RegionID = item.RegionID,
                    AppointmentLimit = item.AppointmentLimit
                });
            }

            return View(courts);
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
