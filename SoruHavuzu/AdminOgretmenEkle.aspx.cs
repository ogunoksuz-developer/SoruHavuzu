using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminOgretmenEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                if (!IsPostBack)
                {

                }
            }
        }

        protected void bnt_Save_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                try
                {
                    Kullanicilar kul = new Kullanicilar();
                    kul.Adi = txtOgretmenAdi.Text;
                    kul.Soyadi = txtOgretmenSoyadi.Text;
                    kul.KulAdi = txtOgretmenNo.Text;
                    kul.Sifre = txtOgretmenSifre.Text;
                    kul.Email = txtOgretmenEmail.Text;
                    kul.KullaniciTurId = 2;
                    db.Kullanicilars.Add(kul);

                    db.SaveChanges();
                    Response.Write("<script>alert('Öğretmen Kaydı Başarıyla Gerçekleştirilmiştir.')</script>");

                    txtOgretmenAdi.Text = string.Empty;
                    txtOgretmenSoyadi.Text = string.Empty;
                    txtOgretmenNo.Text = string.Empty;
                    txtOgretmenSifre.Text = string.Empty;
                    txtOgretmenEmail.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
    }
}