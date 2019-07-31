/*
 * =============================================
 * Title : CourtDto Model
 * Author : Osama Tarek
 * Date : 7/2019 
 * Training in the Ministry of Justice
 * =============================================
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using SupportSystemMOJ.Models;

namespace SupportSystemMOJ.dbModels
{
    public class CourtDto
    {
        public int CourtID { get; set; }
        [DisplayName("اسم المحكمة")]
        public string CourtName { get; set; }
        [DisplayName("الفئة")]
        public Nullable<int> CategoryID { get; set; }
        [DisplayName("السماح بموعد")]
        public Nullable<bool> AllowAppointment { get; set; }
        [DisplayName("أقصى عدد للمواعيد")]
        public Nullable<int> AppointmentLimit { get; set; }
        [DisplayName("كود المحكمة")]
        public Nullable<int> CourtCode { get; set; }
        [DisplayName("كود المدينة")]
        public string CityCode { get; set; }
        [DisplayName("كود المنطقة")]
        public string RegionCode { get; set; }
        [DisplayName("رقم المدينة")]
        public Nullable<int> CityID { get; set; }
        [DisplayName("رقم المنطقة")]
        public Nullable<int> RegionID { get; set; }
        [DisplayName("مفعلة")]
        public Nullable<bool> IsActive { get; set; }
        [DisplayName("رقم المحكمة السابق")]
        public Nullable<int> OldCourtId { get; set; }
    }
}