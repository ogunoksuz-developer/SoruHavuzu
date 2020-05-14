using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgretmenSinavListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rp_SinavDoldur();
            }
            
        }

        private void Rp_SinavDoldur()
        {
            using (OnlineSinavEntities db= new OnlineSinavEntities())
            {
                Sinavlar sinav = new Sinavlar();
                rp_SinavListe.DataSource = (from d in db.Derslers
                                            join s in db.Sinavlars on d.DersId equals s.DersId
                                            select new
                                            {
                                                s.SinavId,
                                                d.DersAdi,
                                                s.SinavAdi,
                                                s.SinavSuresi,
                                                s.SoruSayisi,
                                                s.SinavBaslamaTarihi,
                                                s.SinavBitisTarihi,
                                                s.SinavDurumu
                                            }).ToList();
                rp_SinavListe.DataBind();
            }
        }

        protected void rp_SinavListe_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName=="Edit")
                {
                    Response.Redirect("OgretmenSinavBilgileriGuncelle.aspx?ID=" + id);
                }
                else if (e.CommandName=="Delete")
                {
                    Sinavlar sinav = db.Sinavlars.Where(s => s.SinavId == id).FirstOrDefault();
                    sinav.SinavDurumu = false;
                    db.SaveChanges();
                    Rp_SinavDoldur();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("OgretmenSinavEkle.aspx");
        }
    }
}