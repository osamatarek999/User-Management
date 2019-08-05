/*
 * =============================================
 * Title : Users_CourtsDto Model
 * Author : Osama Tarek
 * Date : 7/2019 
 * Training in the Ministry of Justice
 * =============================================
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SupportSystemMOJ.Models;

namespace SupportSystemMOJ.dbModels
{
    public class Users_CourtsDto
    {
        public int ID { get; set; }
        [DisplayName("اسم المستخدم")]
        public int? UserID { get; set; }
        [Required]
        [DisplayName("المكتب")]
        public int? CorutOfficeID { get; set; }
        [DisplayName("نوع المستخدم")]
        public int? RoleID { get; set; }
        [DisplayName("صلاحيات المستخدم")]
        public int? SupRoleID { get; set; }
        [DisplayName("ربط بواسطة")]
        public int? CreateAdminID { get; set; }
        [DisplayName("أخر تعديل بواسطة")]
        public int? UpdateAdminID { get; set; }
        [DisplayName("تاريخ الإنشاء")]
        public System.DateTime CreateDate { get; set; }
        [DisplayName("آخر تاريخ تعديل")]
        public System.DateTime UpdateDate { get; set; }
        [DisplayName("الربط مفعل")]
        public bool isActive { get; set; }

        [Required]
        [DisplayName("المحكمة")]
        public virtual Court Court { get; set; }
        [Required]
        [DisplayName("المكتب")]
        public virtual CourtsOffice CourtsOffice { get; set; }
        [DisplayName("نوع المستخدم")]
        public virtual Role Role { get; set; }
        [DisplayName("صلاحيات المستخدم")]
        public virtual SubRole SubRole { get; set; }
        [DisplayName("اسم المستخدم")]
        public virtual User User { get; set; }
        [DisplayName("ربط بواسطة")]
        public virtual User User1 { get; set; }
        [DisplayName("أخر تعديل بواسطة")]
        public virtual User User2 { get; set; }

        /*
        public static Users_CourtsDto operator -(Users_Courts u)
        {
            return u;
        }
        */
    }
}