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
    
    public partial class Oyun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oyun()
        {
            this.Oyuncu = new HashSet<Oyuncu>();
            this.Seans = new HashSet<Seans>();
        }
    
        public int OyunId { get; set; }
        public string OyunAdi { get; set; }
        public Nullable<int> YonetmenId { get; set; }
        public Nullable<int> YazarId { get; set; }
        public Nullable<int> TurId { get; set; }
        public string OyunFoto { get; set; }
    
        public virtual Tur Tur { get; set; }
        public virtual Yazar Yazar { get; set; }
        public virtual Yonetmen Yonetmen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oyuncu> Oyuncu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seans> Seans { get; set; }
    }
}
