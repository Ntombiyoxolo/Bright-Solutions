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
    
    public partial class ORDERS_LINE
    {
        public int ORDERS_LINE_ID { get; set; }
        public Nullable<int> ORDERS_LINE_QUANTITY { get; set; }
        public string ORDERS_ID { get; set; }
        public Nullable<int> PRODUCT_ID { get; set; }
    
        public virtual ORDER ORDER { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}