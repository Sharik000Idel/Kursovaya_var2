﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Skyline_DBEntities : DbContext
    {

        protected static Skyline_DBEntities _context;

        public static Skyline_DBEntities GetContext() {
            return _context ?? (new Skyline_DBEntities());
        }
        public Skyline_DBEntities()
            : base("name=Skyline_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Buyer> Buyer { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Personnal> Personnal { get; set; }
        public virtual DbSet<Plane> Plane { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<Vacancy> Vacancy { get; set; }
    }
}