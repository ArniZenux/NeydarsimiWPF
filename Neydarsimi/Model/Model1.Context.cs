﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Neydarsimi.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Neydarsimi1_dbEntities : DbContext
    {
        public Neydarsimi1_dbEntities()
            : base("name=Neydarsimi1_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblNeydarsimi> tblNeydarsimis { get; set; }
        public virtual DbSet<Tulkur> Tulkurs { get; set; }
    }
}
