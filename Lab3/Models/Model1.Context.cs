﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebshopEntities : DbContext
    {
        public WebshopEntities()
            : base("name=WebshopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Customer> Tbl_Customer { get; set; }
        public virtual DbSet<Tbl_Order> Tbl_Order { get; set; }
        public virtual DbSet<Tbl_Order_Product> Tbl_Order_Product { get; set; }
        public virtual DbSet<Tbl_Payment_Method> Tbl_Payment_Method { get; set; }
        public virtual DbSet<Tbl_Product> Tbl_Product { get; set; }
    }
}
