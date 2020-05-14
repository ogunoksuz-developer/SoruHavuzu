using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgrenciGirilenSinavlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rp_SinavDoldur();
            }
        }

        private void rp_SinavDoldur()
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                Kullanicilar kul = new Kullanicilar();
                kul = (Kullanicilar)Session["Kullanicilar"];
                int kulid = kul.KullaniciId;

                rp_SinavListe.DataSource = (from k in db.KullanicilarSinavlars
                                            join s in db.Sinavlars on k.SinavId equals s.SinavId
                                            join d in db.Derslers on s.DersId equals d.DersId
                                            where k.KullaniciId == kulid && k.SinavaGirdimi==true
                                            select new
                                            {
                                                k.KullaniciId,
                                                d.DersAdi,
                                                s.SinavAdi,
                                                k.SinavNotu
                                            }).ToList();
                rp_SinavListe.DataBind();
            }
        }

    }
}