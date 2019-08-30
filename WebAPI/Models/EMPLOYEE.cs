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
    
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            this.USERS = new HashSet<USER>();
            this.AUDIT_TRAIL = new HashSet<AUDIT_TRAIL>();
            this.MAINTENANCEs = new HashSet<MAINTENANCE>();
        }
    
        public int EMPLOYEE_ID { get; set; }
        public Nullable<int> TITLE_ID { get; set; }
        public byte[] EMPLOYEE_IMAGE { get; set; }
        public string EMPLOYEE_IMAGE_NAME { get; set; }
        public string EMPLOYEE_NAMES { get; set; }
        public string EMPLOYEE_SURNAME { get; set; }
        public string EMPLOYEE_EMAIL_ADDRESS { get; set; }
        public string EMPLOYEE_CONTACT_NO { get; set; }
        public string IDENTITY_NO { get; set; }
        public string EMPLOYEE_CONTRACT_ID { get; set; }
        public Nullable<int> EMPLOYEE_TYPE_ID { get; set; }
    
        public virtual TITLE TITLE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER> USERS { get; set; }
        public virtual EMPLOYEE_CONTRACT EMPLOYEE_CONTRACT { get; set; }
        public virtual EMPLOYEE_TYPE EMPLOYEE_TYPE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUDIT_TRAIL> AUDIT_TRAIL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MAINTENANCE> MAINTENANCEs { get; set; }
    }
}
