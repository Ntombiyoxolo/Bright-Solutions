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
    
    public partial class SUPPLIER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUPPLIER()
        {
            this.ORDERS = new HashSet<ORDER>();
        }
    
        public int SUPPLIER_ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string SUPPLIER_REGISTRATION_NUMBER { get; set; }
        public string SUPPLIER_EMAIL { get; set; }
        public string SUPPLIER_CONTACT_NO { get; set; }
        public string SUPPLIER_ADDRESS_BOX { get; set; }
        public string SUPPLIER_ADDRESS_STREET { get; set; }
        public string SUPPLIER_ADDRESS_TOWN { get; set; }
        public string SUPPLIER_ADDRESS_CODE { get; set; }
        public string SUPPLIER_BANK_DETAILS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }
    }
}