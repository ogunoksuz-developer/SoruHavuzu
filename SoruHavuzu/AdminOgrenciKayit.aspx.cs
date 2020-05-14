using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminOgrenciKayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bnt_Save_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                try
                {
                    Kullanicilar kul = new Kullanicilar();
                    kul.Adi = txtOgrenciAdi.Text;
                    kul.Soyadi = txtOgrenciSoyadi.Text;
                    kul.KulAdi = txtOgrenciNo.Text;
                    kul.Sifre = txtOgrenciSifre.Text;
                    kul.Email = txtOgrenciEmail.Text;
                    kul.KullaniciTurId = 3;

                    string sonuc1 = "";
                    string sonuc2 = "";
                    sonuc1 = txtOgrenciNo.Text.Substring(0, 1);
                    sonuc2 = txtOgrenciNo.Text.Substring(5, 1);

                    if (sonuc1.ToUpper() != "B" && sonuc1.ToUpper() != "G" && sonuc2.ToString() != ".")
                    {
                        Response.Write("<script>alert('Numaranın ilk değeri B veya G ile başlamalı ve 6. karakteri nokta olmalıdır')</script>");
                    }
                    else
                    {
                        db.Kullanicilars.Add(kul);
                        db.SaveChanges();
                        Response.Write("<script>alert('Öğrenci Kaydı Başarıyla Gerçekleştirilmiştir.')</script>");

                        txtOgrenciAdi.Text = string.Empty;
                        txtOgrenciSoyadi.Text = string.Empty;
                        txtOgrenciNo.Text = string.Empty;
                        txtOgrenciSifre.Text = string.Empty;
                        txtOgrenciEmail.Text = string.Empty;
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
    }
}