using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgretmenSoruListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rp_SoruDoldur();
            }
        }

        private void Rp_SoruDoldur()
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                Sorular soru = new Sorular();
                rp_SoruListe.DataSource = (from k in db.Konulars
                                           join d in db.Derslers on k.DersId equals d.DersId
                                           join s in db.Sorulars on k.KonuId equals s.KonuId
                                           select new
                                           {
                                               s.SoruId,
                                               s.SoruMetni,
                                               s.ZorlukDerecesi,
                                               s.A,
                                               s.B,
                                               s.C,
                                               s.D,
                                               s.E,
                                               s.DogruCevap,
                                               s.SoruDurumu,
                                               d.DersAdi,
                                               k.KonuAdi

                                           }
                                           ).ToList();
                rp_SoruListe.DataBind();
            }
        }


        protected void rp_SoruListe_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            using (OnlineSinavEntities db=new OnlineSinavEntities())
            {
                
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName=="Edit")
                {
                    Response.Redirect("OgretmenSoruGuncelle.aspx?ID=" + id);
                }
                else if (e.CommandName=="Delete")
                {
                    Sorular soru = db.Sorulars.Where(s => s.SoruId == id).FirstOrDefault();
                    soru.SoruDurumu = false;
                    db.SaveChanges();
                    Rp_SoruDoldur();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("OgretmenSoruEkle.aspx");
        }
    }
}