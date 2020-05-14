using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgrenciTaleplerim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_TalepDoldur();
        }

        private void rp_TalepDoldur()
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                Kullanicilar kul = new Kullanicilar();
                kul = (Kullanicilar)Session["Kullanicilar"];
                Talepler talep = new Talepler();
                rp_TalepListe.DataSource = (from t in db.Taleplers
                                            where t.KullaniciId == kul.KullaniciId
                                            select new
                                            {
                                                t.TalepId,
                                                t.TalepTuru,
                                                t.Aciklama,
                                                t.Durum
                                            }).ToList();
                rp_TalepListe.DataBind();
            }
        }
    }
}