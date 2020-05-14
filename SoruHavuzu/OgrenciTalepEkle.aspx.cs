using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgrenciTalepEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                using (OnlineSinavEntities db = new OnlineSinavEntities())
                {
                    Kullanicilar kul = new Kullanicilar();
                    kul = (Kullanicilar)Session["Kullanicilar"];
                    int kulid = Convert.ToInt32(kul.KullaniciId);

                    Talepler talep = new Talepler();

                    talep.TalepTuru = txtTalepTuru.Text;
                    talep.Aciklama = txtAciklama.Text;
                    talep.KullaniciId = kulid;
                    talep.Durum = "Bekliyor";

                    db.Taleplers.Add(talep);
                    db.SaveChanges();
                    Response.Write("<script>alert('Talebiniz Başarıyla Gönderilmiştir.')</script>");

                }
            }
            catch (Exception )
            {

            }
        }
    }
}