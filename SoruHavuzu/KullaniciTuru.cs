//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoruHavuzu
{
    using System;
    using System.Collections.Generic;
    
    public partial class KullaniciTuru
    {
        public KullaniciTuru()
        {
            this.Kullanicilars = new HashSet<Kullanicilar>();
        }
    
        public int KullaniciTurId { get; set; }
        public string KullaniciTuruAdi { get; set; }
    
        public virtual ICollection<Kullanicilar> Kullanicilars { get; set; }
    }
}
