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
    
    public partial class AUDIT_TRAIL_TYPE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUDIT_TRAIL_TYPE()
        {
            this.AUDIT_TRAIL = new HashSet<AUDIT_TRAIL>();
        }
    
        public int AUDIT_TRAIL_TYPE_ID { get; set; }
        public string AUDIT_TRAIL_TYPE_NAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUDIT_TRAIL> AUDIT_TRAIL { get; set; }
    }
}
