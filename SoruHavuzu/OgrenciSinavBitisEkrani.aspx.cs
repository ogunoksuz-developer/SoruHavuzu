using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgrenciSinavBitisEkrani : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Kullanicilar kul = new Kullanicilar();
            kul = (Kullanicilar)Session["Kullanicilar"];
            lblAdSoyad.Text = kul.Adi + " " + kul.Soyadi;

            Sinavlar sinav = new Sinavlar();
            sinav = (Sinavlar)Session["Sinavlar"];
            lblSinavAdi.Text = sinav.SinavAdi;
        }

        protected void btnAnasayfayaDon_Click(object sender, EventArgs e)
        {
            Response.Redirect("OgrenciFirstPage.aspx");
        }
    }
}