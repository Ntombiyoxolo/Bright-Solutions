﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UTRANSPORTDATABASEEntities2 : DbContext
    {
        public UTRANSPORTDATABASEEntities2()
            : base("name=UTRANSPORTDATABASEEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EMPLOYEE> EMPLOYEEs { get; set; }
        public virtual DbSet<EMPLOYEE_CONTRACT> EMPLOYEE_CONTRACT { get; set; }
        public virtual DbSet<EMPLOYEE_TYPE> EMPLOYEE_TYPE { get; set; }
        public virtual DbSet<TITLE> TITLEs { get; set; }
    }
}
