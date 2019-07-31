/*
 * =============================================
 * Title : Users Controller
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
using System.Web.Security;

namespace SupportSystemMOJ.Controllers
{
    public class UsersController : Controller
    {
        private MOJEntities db = new MOJEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            UserDto c = new UserDto();

            using(MOJEntities dbC = new MOJEntities())
            {
                List<Role> roles = new List<Role>();
                List<SubRole> subroles = new List<SubRole>();


                foreach (var item in dbC.Roles)
                {
                    roles.Add( new Role
                    {
                        ID = item.ID,
                        Name = item.Name,
                    });
                }

                foreach (var item in dbC.SubRoles)
                {
                    subroles.Add(new SubRole
                    {
                        ID = item.ID,
                        Name = item.Name,
                    });
                }

                c.RoleCollection = roles;
                c.SubRoleCollection = subroles;

            }
            return View(c);
        }

        public JsonResult getCourtsOffices(int CourtId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CourtsOffice> OfficeCourt = db.CourtsOffices.Where(x => x.CourtId == CourtId).ToList();
            return Json(OfficeCourt, JsonRequestBehavior.AllowGet);
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Password,CourtID,FullName,RoleID,CreationDate,LastLoginDateTime,OfficeNumber,OfficeFloorNumber,OfficeName,IsActive,IsInworkToday,MaxQueueCount,Email,Phone,Mobile,LastUpdateDate,SocialID,ExtensionNumber,ActiveDirectoryUserName,olduserid,SubRoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Password,CourtID,FullName,RoleID,CreationDate,LastLoginDateTime,OfficeNumber,OfficeFloorNumber,OfficeName,IsActive,IsInworkToday,MaxQueueCount,Email,Phone,Mobile,LastUpdateDate,SocialID,ExtensionNumber,ActiveDirectoryUserName,olduserid,SubRoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult login()
        {
            if(Session["UserID"] != null){
                using (MOJEntities db = new MOJEntities())
                {
                    string UserID = Session["UserID"].ToString();
                    if (db.Users.Where(a => a.RoleID.ToString().Equals("10") && a.ID.ToString().Equals(UserID)).FirstOrDefault() != null)
                    {
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        return RedirectToAction("Index", "NormalUser");
                    }
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(User objUser)
        {
            if (ModelState.IsValid)
            {
                using (MOJEntities db = new MOJEntities())
                {
                    var obj = db.Users.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.ID.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        Session["FullName"] = obj.FullName.ToString();
                        Session["RoleID"] = obj.RoleID;
                        if (db.Users.Where(a => a.RoleID.ToString().Equals("10") && a.ID.Equals(obj.ID)).FirstOrDefault() != null)
                        {
                            return RedirectToAction("Index");

                        }
                        else
                        {
                            return RedirectToAction("Index","NormalUser");
                        }
                    }
                    else
                    {
                        ViewBag.Message = "البريد الإلكتروني أو كلمة المرور غير صحيحة";
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("login","Users");
        }
    }
}
