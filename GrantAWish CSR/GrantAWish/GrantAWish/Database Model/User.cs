//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GrantAWish.Database_Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Wishes = new HashSet<Wishes>();
        }
    
        public long userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public System.DateTime signup_Date { get; set; }
        public string contact_Number { get; set; }
    
        public virtual ICollection<Wishes> Wishes { get; set; }
    }
}
