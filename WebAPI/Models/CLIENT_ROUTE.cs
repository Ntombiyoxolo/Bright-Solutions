//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENT_ROUTE
    {
        public int CLIENT_ROUTE_ID { get; set; }
        public Nullable<int> CLIENT_MINE_ID { get; set; }
        public string LOCATIONS { get; set; }
        public string DESIGNATED_ROUTE { get; set; }
    
        public virtual CLIENT_MINE CLIENT_MINE { get; set; }
    }
}
