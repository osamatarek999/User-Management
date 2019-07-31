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
    public class Users_CourtsController : Controller
    {
        private MOJEntities db = new MOJEntities();

        // GET: Users_Courts
        public ActionResult Index()
        {
            var users_Courts = db.Users_Courts.Include(u => u.CourtsOffice).Include(u => u.Role).Include(u => u.SubRole).Include(u => u.User).Include(u => u.User1).Include(u => u.User2);
            users_Courts.ToList();
            List<Users_CourtsDto> users_courts = new List<Users_CourtsDto>();

            foreach (var item in users_Courts)
            {
                users_courts.Add(new Users_CourtsDto
                {
                    ID = item.ID,
                    CourtsOffice = item.CourtsOffice,
                    Role = item.Role,
                    SubRole = item.SubRole,
                    User = item.User,
                    User1 = item.User1,
                    User2 = item.User2
                });
            }
            return View(users_courts);
        }

        // GET: Users_Courts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users_Courts users_Courts = db.Users_Courts.Find(id);
            if (users_Courts == null)
            {
                return HttpNotFound();
            }

            Users_CourtsDto users_courts = new Users_CourtsDto();

            users_courts.ID = users_Courts.ID;
            users_courts.CourtsOffice = users_Courts.CourtsOffice;
            users_courts.Role = users_Courts.Role;
            users_courts.SubRole = users_Courts.SubRole;
            users_courts.User = users_Courts.User;
            users_courts.User1 = users_Courts.User1;
            users_courts.User2 = users_Courts.User2;

            return View(users_courts);
        }

        // GET: Users_Courts/Create
        public ActionResult Create()
        {
            ViewBag.CorutID = new SelectList(db.Courts, "CourtID", "CourtName");
            ViewBag.CorutOfficeID = new SelectList("");
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name");
            ViewBag.SupRoleID = new SelectList(db.SubRoles, "ID", "Name");


            MOJEntities dbC = new MOJEntities();
            List<object> newList = new List<object>();
            foreach (var item in dbC.Users)
                newList.Add(new
                {
                    Id = item.ID,
                    Name = item.FullName + " | " + item.SocialID
                });
            ViewBag.UserID = new SelectList(newList, "Id", "Name");



            //ViewBag.UserID = new SelectList(db.Users, "ID", "UserName");
            ViewBag.CreateAdminID = new SelectList(db.Users, "ID", "FullName");
            ViewBag.UpdateAdminID = new SelectList(db.Users, "ID", "UserName");
            return View();
        }

        // POST: Users_Courts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,CorutOfficeID,RoleID,SupRoleID,CreateAdminID,UpdateAdminID,isActive")] Users_Courts users_Courts)
        {
            if (ModelState.IsValid)
            {
                users_Courts.CreateAdminID = Convert.ToInt32(Session["UserID"]);
                users_Courts.UpdateAdminID = Convert.ToInt32(Session["UserID"]);
                db.Users_Courts.Add(users_Courts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", users_Courts.RoleID);
            ViewBag.SupRoleID = new SelectList(db.SubRoles, "ID", "Name", users_Courts.SupRoleID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", users_Courts.UserID);
            ViewBag.CreateAdminID = new SelectList(db.Users, "ID", "UserName", users_Courts.CreateAdminID);
            ViewBag.UpdateAdminID = new SelectList(db.Users, "ID", "UserName", users_Courts.UpdateAdminID);
            return View(users_Courts);
        }

        public JsonResult getCourtsOffices(int CourtId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CourtsOffice> OfficeCourt = db.CourtsOffices.Where(x => x.CourtId == CourtId).ToList();
            return Json(OfficeCourt, JsonRequestBehavior.AllowGet);
        }

        // GET: Users_Courts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users_Courts users_Courts = db.Users_Courts.Find(id);
            if (users_Courts == null)
            {
                return HttpNotFound();
            }

            ViewBag.CorutOfficeID = new SelectList(db.CourtsOffices, "Id", "OfficeName", users_Courts.CorutOfficeID);
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", users_Courts.RoleID);
            ViewBag.SupRoleID = new SelectList(db.SubRoles, "ID", "Name", users_Courts.SupRoleID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", users_Courts.UserID);
            ViewBag.CreateAdminID = new SelectList(db.Users, "ID", "UserName", users_Courts.CreateAdminID);
            ViewBag.UpdateAdminID = new SelectList(db.Users, "ID", "UserName", users_Courts.UpdateAdminID);

            Users_CourtsDto users_courts = new Users_CourtsDto();

            users_courts.ID = users_Courts.ID;
            users_courts.CourtsOffice = users_Courts.CourtsOffice;
            users_courts.Role = users_Courts.Role;
            users_courts.SubRole = users_Courts.SubRole;
            users_courts.User = users_Courts.User;
            users_courts.User1 = users_Courts.User1;
            users_courts.User2 = users_Courts.User2;

            return View(users_courts);
        }

        // POST: Users_Courts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,CorutOfficeID,RoleID,SupRoleID,UpdateAdminID,UpdateDate,isActive")] Users_Courts users_Courts)
        {
            if (ModelState.IsValid)
            {
                users_Courts.UpdateAdminID = Convert.ToInt32(Session["UserID"]);
                users_Courts.UpdateDate = DateTime.Now;

                db.Entry(users_Courts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CorutOfficeID = new SelectList(db.CourtsOffices, "Id", "OfficeName", users_Courts.CorutOfficeID);
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", users_Courts.RoleID);
            ViewBag.SupRoleID = new SelectList(db.SubRoles, "ID", "Name", users_Courts.SupRoleID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", users_Courts.UserID);
            ViewBag.CreateAdminID = new SelectList(db.Users, "ID", "UserName", users_Courts.CreateAdminID);
            ViewBag.UpdateAdminID = new SelectList(db.Users, "ID", "UserName", users_Courts.UpdateAdminID);
            return View(users_Courts);
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
