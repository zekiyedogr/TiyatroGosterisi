﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiyatroGosterisi.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TiyatroGosterisiEntities : DbContext
    {
        public TiyatroGosterisiEntities()
            : base("name=TiyatroGosterisiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Oyun> Oyun { get; set; }
        public virtual DbSet<Oyuncu> Oyuncu { get; set; }
        public virtual DbSet<Salon> Salon { get; set; }
        public virtual DbSet<Seans> Seans { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tur> Tur { get; set; }
        public virtual DbSet<Uye> Uye { get; set; }
        public virtual DbSet<Yazar> Yazar { get; set; }
        public virtual DbSet<Yonetmen> Yonetmen { get; set; }
        public virtual DbSet<Mesajlar> Mesajlar { get; set; }
        public virtual DbSet<Iletisim> Iletisim { get; set; }
    }
}