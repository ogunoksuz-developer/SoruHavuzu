using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminTaleplerListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rp_TalepDoldur();
            }
            
        }

        private void rp_TalepDoldur()
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {                
                rp_TalepListe.DataSource = (from t in db.Taleplers
                                            join k in db.Kullanicilars on t.KullaniciId equals k.KullaniciId
                                            select new
                                            {
                                                t.TalepId,
                                                k.Adi,
                                                k.Soyadi,
                                                t.TalepTuru,
                                                t.Aciklama,
                                                t.Durum
                                            }).ToList();
                rp_TalepListe.DataBind();
            }
        }

        protected void rp_TalepListe_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName=="Onayla")
                {
                    Talepler talep = db.Taleplers.Where(t => t.TalepId == id).FirstOrDefault();
                    talep.Durum = "Mazeret Sınavına Girebilirsiniz";
                    db.SaveChanges();
                    rp_TalepDoldur();
                }

                else if (e.CommandName=="Reddet")
                {
                    Talepler talep = db.Taleplers.Where(t => t.TalepId == id).FirstOrDefault();
                    talep.Durum = "Mazeretiniz Geçersiz";
                    db.SaveChanges();
                    rp_TalepDoldur();
                }
            }
        }

    }
}