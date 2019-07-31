/*
 * =============================================
 * Title : CourtsOfficesDto Model
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
    public class CourtsOfficesDto
    {
        public int Id { get; set; }
        [DisplayName("اسم المكتب")]
        public string OfficeName { get; set; }
        [DisplayName("رقم المكتب")]
        public int OfficeNo { get; set; }
        [DisplayName("المحكمة")]
        public int CourtId { get; set; }
        [DisplayName("نسبة العمل")]
        public Nullable<int> WorkPercentage { get; set; }
        [DisplayName("مفعلة")]
        public Nullable<bool> IsActive { get; set; }
        [DisplayName("تعمل")]
        public Nullable<bool> IsWorking { get; set; }

        [DisplayName("المحكمة")]
        public virtual Court Court { get; set; }

    }
}