using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgretmenSinavEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (OnlineSinavEntities db = new OnlineSinavEntities())
                {
                    ddDersDoldur(db);
                }
            }
        }

        public void ddDersDoldur(OnlineSinavEntities db)
        {
            Kullanicilar kul = new Kullanicilar();
            kul = (Kullanicilar)Session["Kullanicilar"];

            ddlDersAdi.Items.Clear();
            //List<ListItem> items = new List<ListItem>();

            var dersler = (from d in db.Derslers
                           from k in d.Kullanicilars
                           where k.KullaniciId == kul.KullaniciId
                           select d).ToList();

            ddlDersAdi.DataSource = dersler;
            ddlDersAdi.DataValueField = "DersId";
            ddlDersAdi.DataTextField = "DersAdi";
            ddlDersAdi.DataBind();
        }

        protected void ddlDersAdi_DataBound(object sender, EventArgs e)
        {
            ddlDersAdi.Items.Insert(0, "Ders Seçiniz");
        }

        

        protected void btnSinavOlustur_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                try
                {
                    if (ddlDersAdi.SelectedItem.Value == "0")
                    {
                        Response.Write("<script>alert('Ders Seçiniz')</script>");
                    }

                    Sinavlar sinav = new Sinavlar();
                    sinav.DersId = Convert.ToInt32(ddlDersAdi.SelectedValue);
                    sinav.SinavAdi = txtSinavAdi.Text;
                    sinav.SinavSuresi = Convert.ToInt32(txtSinavSuresi.Text);
                    sinav.SoruSayisi = Convert.ToInt32(txtSoruSayisi.Text);
                    sinav.SinavBaslamaTarihi = Convert.ToDateTime(txtSinavBaslangicTarihi.Text);
                    if (sinav.SinavBaslamaTarihi < DateTime.Now)
                    {
                        Response.Write("<script>alert('Başlama Tarihi bugunun tarihinden önce olamaz!')</script>");
                    }
                    else
                    {
                        sinav.SinavBitisTarihi = Convert.ToDateTime(txtSinavBitisTarihi.Text);
                        if (sinav.SinavBitisTarihi < DateTime.Now && sinav.SinavBitisTarihi < sinav.SinavBaslamaTarihi)
                        {
                            Response.Write("<script>alert('Bitiş Tarihi bugunun tarihinden ve sinav başlama tarihinden önce olamaz!')</script>");
                        }
                        else
                        {
                            sinav.SinavDurumu = false;

                            db.Sinavlars.Add(sinav);
                            db.SaveChanges();
                            Response.Write("<script>alert('Sınav Bilgileri Başarıyla Kaydedilmiştir.Sınavınıza Soru Kaydı yapabilirsiniz...')</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    lbl_Error.Text = ex.Message;
                }
            }
        }
    }
}