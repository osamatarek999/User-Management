/*
 * =============================================
 * Title : UsersDto Model
 * Author : Osama Tarek
 * Date : 7/2019 
 * Training in the Ministry of Justice
 * =============================================
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SupportSystemMOJ.dbModels;
using SupportSystemMOJ.Models;

namespace SupportSystemMOJ.dbModels
{
    public class UserDto
    {
        public int ID { get; set; }
        [DisplayName("اسم المستخدم")]
        public string UserName { get; set; }
        [DisplayName("كلمة المرور")]
        public string Password { get; set; }
        [DisplayName("الاسم بالكامل")]
        public string FullName { get; set; }
        [DisplayName("تاريخ الإنشاء")]
        public DateTime CreationDate { get; set; }
        [DisplayName("تاريخ اخر تسجيل دخول")]
        public DateTime LastLoginDateTime { get; set; }
        [DisplayName("رقم المكتب")]
        public int OfficeNumber { get; set; }
        [DisplayName("رقم دور المكتب")]
        public int OfficeFloorNumber { get; set; }
        [DisplayName("اسم المكتب")]
        public string OfficeName { get; set; }
        [DisplayName("خصائصي")]
        public int MyProperty { get; set; }
        [DisplayName("الحساب مفعل")]
        public bool IsActive { get; set; }
        [DisplayName("على قائمة العمل اليوم")]
        public bool IsInworkToday { get; set; }
        [DisplayName("اقصى استيعاب")]
        public int MaxQueueCount { get; set; }
        [DisplayName("البريد الإلكتروني")]
        public string Email { get; set; }
        [DisplayName("رقم الهاتف")]
        public string Phone { get; set; }
        [DisplayName("رقم الجوال")]
        public string Mobile { get; set; }
        [DisplayName("تاريخ اخر تعديل")]
        public DateTime LastUpdateDate { get; set; }
        [DisplayName("رقم الهوية")]
        public string SocialID { get; set; }
        [DisplayName("")]
        public string ExtensionNumber { get; set; }
        [DisplayName("")]
        public string ActiveDirectoryUserName { get; set; }
        [DisplayName("")]
        public int olduserid { get; set; }
        [DisplayName("")]
        public int SubRoleID { get; set; }
        [DisplayName("")]
        public int RoleID { get; set; }

  //      [NotMapped]
    //    [DisplayName("")]
      //  public List<CourtDto> CourtCollection { get; set; }

        [NotMapped]
        [DisplayName("نوع المستخدم")]
        public List<Role> RoleCollection { get; set; }

        [NotMapped]
        [DisplayName("صلاحية المستخدم")]
        public List<SubRole> SubRoleCollection { get; set; }

    }
}