using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminOgrenciListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rp_OgrenciDoldur();
            }
        }

        private void Rp_OgrenciDoldur()
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {               
                rp_OgrenciListesi.DataSource = (from k in db.Kullanicilars
                                                where k.KullaniciTurId==3
                                                select new
                                                {
                                                    k.KullaniciId,
                                                    k.Adi,
                                                    k.Soyadi,
                                                    k.KulAdi,
                                                    k.Email,
                                                    k.KullaniciDurumu
                                                }).ToList();
                rp_OgrenciListesi.DataBind();
            }
        }

        protected void rp_OgrenciListesi_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName=="Edit")
                {
                    Response.Redirect("AdminOgrenciGuncelle.aspx?ID=" + id);
                }
                else if (e.CommandName=="Delete")
                {
                    Kullanicilar kul = db.Kullanicilars.Where(k => k.KullaniciId == id).FirstOrDefault();
                    kul.KullaniciDurumu = false;
                    db.SaveChanges();
                    Rp_OgrenciDoldur();
                }
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminOgrenciKayit.aspx");
        }

    }
}