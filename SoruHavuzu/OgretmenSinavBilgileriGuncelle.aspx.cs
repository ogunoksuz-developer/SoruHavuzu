using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgretmenSinavBilgileriGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString != null && !string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                {
                    using (OnlineSinavEntities db = new OnlineSinavEntities())
                    {
                        Sinavlar sinav = new Sinavlar();
                        sinav.SinavId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                        var mevcut = db.Sinavlars.Find(sinav.SinavId);

                        txtSinavAdi.Text = mevcut.SinavAdi;
                        txtBaslangicTarihi.Text = mevcut.SinavBaslamaTarihi.ToString();
                        txtBitisTarihi.Text = mevcut.SinavBitisTarihi.ToString();
                        txtSinavSuresi.Text = mevcut.SinavSuresi.ToString();
                        txtSoruSayisi.Text = mevcut.SoruSayisi.ToString();
                        if (mevcut.SinavDurumu==true)
                        {
                            rbAktif.Checked=true;
                        }
                        else if (mevcut.SinavDurumu==false)
                        {
                            rbPasif.Checked = true;
                        }

                    }
                }
            }
        }

        protected void bnt_Save_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                Sinavlar sinav = new Sinavlar();
                sinav.SinavId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                var mevcut = db.Sinavlars.Find(sinav.SinavId);
                mevcut.SinavAdi = txtSinavAdi.Text;
                mevcut.SinavBaslamaTarihi = Convert.ToDateTime(txtBaslangicTarihi.Text);
                mevcut.SinavBitisTarihi = Convert.ToDateTime(txtBitisTarihi.Text);
                mevcut.SinavSuresi = Convert.ToInt32(txtSinavSuresi.Text);
                mevcut.SoruSayisi = Convert.ToInt32(txtSoruSayisi.Text);
                if (rbAktif.Checked)
                {
                    mevcut.SinavDurumu = true; 
                }
                else if (rbPasif.Checked)
                {
                    mevcut.SinavDurumu = false;
                }
                db.SaveChanges();
                Response.Redirect("OgretmenSinavListesi.aspx");
            
            }
        }
    }
}