//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SupportSystemMOJ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users_Courts
    {
        public int ID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> CorutOfficeID { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> SupRoleID { get; set; }
        public Nullable<int> CreateAdminID { get; set; }
        public Nullable<int> UpdateAdminID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public bool isActive { get; set; }
    
        public virtual CourtsOffice CourtsOffice { get; set; }
        public virtual Role Role { get; set; }
        public virtual SubRole SubRole { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
    }
}
