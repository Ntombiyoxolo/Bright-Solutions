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
    
    public partial class DEALERSHIP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEALERSHIP()
        {
            this.VEHICLE_DEALERSHIP_SERVICE = new HashSet<VEHICLE_DEALERSHIP_SERVICE>();
        }
    
        public int DEALERSHIP_ID { get; set; }
        public string DEALERSHIP_NAME { get; set; }
        public string DEALERSHIP_REGISTRATION_NUMBER { get; set; }
        public string DEALERSHIP_CONTACT_NUMBER { get; set; }
        public string DEALERSHIP_LOCATION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEHICLE_DEALERSHIP_SERVICE> VEHICLE_DEALERSHIP_SERVICE { get; set; }
    }
}