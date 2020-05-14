using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminOgretmenListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rp_OgretmenDoldur();
            }

           
        }

        private void Rp_OgretmenDoldur()
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                rp_OgretmenListesi.DataSource = (from o in db.Kullanicilars
                                                 where o.KullaniciTurId == 2
                                                 select new
                                                 {
                                                     o.KullaniciId,
                                                     o.Adi,
                                                     o.Soyadi,
                                                     o.KulAdi,
                                                     o.Email,
                                                     o.KullaniciDurumu
                                                 }).ToList();
                rp_OgretmenListesi.DataBind();
            }
        }

        protected void rp_OgretmenListesi_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            using (OnlineSinavEntities db=new OnlineSinavEntities())
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName=="Edit")
                {
                    Response.Redirect("AdminOgretmenGuncelle.aspx?ID=" + id);
                }
                else if(e.CommandName=="Delete")
                {
                    Kullanicilar kul = db.Kullanicilars.Where(k => k.KullaniciId == id).FirstOrDefault();
                    kul.KullaniciDurumu = false;
                    db.SaveChanges();
                    Rp_OgretmenDoldur();
                        
                }
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminOgretmenEkle.aspx");
        }
        
    }

}