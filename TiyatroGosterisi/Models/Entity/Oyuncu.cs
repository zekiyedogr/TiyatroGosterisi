//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Oyuncu
    {
        public int OyuncuId { get; set; }
        public string OyuncuAdi { get; set; }
        public Nullable<int> OyunId { get; set; }
        public string Rol { get; set; }
        public string OyuncuFoto { get; set; }
    
        public virtual Oyun Oyun { get; set; }
    }
}
