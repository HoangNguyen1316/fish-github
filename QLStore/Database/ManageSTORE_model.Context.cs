﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLStore.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MANAGEMENT_STORE_Entities : DbContext
    {
        public MANAGEMENT_STORE_Entities()
            : base("name=MANAGEMENT_STORE_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Detail_Product> Detail_Product { get; set; }
        public virtual DbSet<Input_Form> Input_Form { get; set; }
        public virtual DbSet<Output_Form> Output_Form { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Type_product> Type_product { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Staff_Bill> Staff_Bill { get; set; }
        public virtual DbSet<LoginUser> LoginUsers { get; set; }
    }
}