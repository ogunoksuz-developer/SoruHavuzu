using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminOgrenciGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (OnlineSinavEntities db = new OnlineSinavEntities())
                {
                    if (Request.QueryString != null && !string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                    {
                        Kullanicilar kul = new Kullanicilar();
                        kul.KullaniciId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                        var mevcutOgr = db.Kullanicilars.Find(kul.KullaniciId);
                        txtOgrenciAdi.Text = mevcutOgr.Adi;
                        txtOgrenciSoyadi.Text = mevcutOgr.Soyadi;
                        txtOgrenciEmail.Text = mevcutOgr.Email;
                        txtOgrenciNo.Text = mevcutOgr.KulAdi;
                        if (mevcutOgr.KullaniciDurumu == true)
                        {
                            RadioButton1.Checked = true;
                        }
                        else if (mevcutOgr.KullaniciDurumu == false)
                        {
                            RadioButton2.Checked = true;
                        }

                    }
                }

            }

        }

        protected void bnt_Save_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                Kullanicilar kul = new Kullanicilar();
                kul.KullaniciId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                var mevcutOgr = db.Kullanicilars.Find(kul.KullaniciId);
                mevcutOgr.Adi = txtOgrenciAdi.Text;
                mevcutOgr.Soyadi = txtOgrenciSoyadi.Text;
                mevcutOgr.KulAdi = txtOgrenciNo.Text;
                mevcutOgr.Email = txtOgrenciEmail.Text;
                if (RadioButton1.Checked)
                {
                    mevcutOgr.KullaniciDurumu = true;
                }
                else if (RadioButton2.Checked)
                {
                    mevcutOgr.KullaniciDurumu = false;
                }
                db.SaveChanges();
                Response.Redirect("AdminOgrenciListesi.aspx");
            }
        }
    }
}