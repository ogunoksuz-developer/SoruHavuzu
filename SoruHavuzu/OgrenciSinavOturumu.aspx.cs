using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgrenciSinavOturumu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (OnlineSinavEntities db = new OnlineSinavEntities())
                {
                    ddDerslerDoldur(db);
                }
            }
        }

        public void ddDerslerDoldur(OnlineSinavEntities db)
        {
            Kullanicilar kul = new Kullanicilar();
            kul = (Kullanicilar)Session["Kullanicilar"];

            ddlDersAdi.Items.Clear();
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

        protected void ddlDersAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSinavAdi.Items.Clear();
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                int dersID = Convert.ToInt32(ddlDersAdi.SelectedItem.Value);
                if (dersID == 0)
                {
                    ddlSinavAdi.Items.Clear();
                }
                else
                {
                    var sinavlar = (from sinav in db.Sinavlars
                                    where sinav.SinavDurumu == true && sinav.DersId == dersID
                                    select sinav).ToList();
                    ddlSinavAdi.DataSource = sinavlar;
                    ddlSinavAdi.DataValueField = "SinavId";
                    ddlSinavAdi.DataTextField = "SinavAdi";
                    ddlSinavAdi.DataBind();
                }
            }
        }

        protected void ddlSinavAdi_DataBound(object sender, EventArgs e)
        {
            ddlSinavAdi.Items.Insert(0, "Sınav Seçiniz");
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                if (ddlDersAdi.SelectedItem.Value == "Ders Seçiniz")
                {
                    Response.Write("<script>alert('Ders Seçiniz!')</script>");
                }
                else if (ddlSinavAdi.SelectedItem.Value == "Sınav Seçiniz")
                {
                    Response.Write("<script>alert('Sinav Seçiniz')</script>");
                }
                else
                {
                    Sinavlar sinav = new Sinavlar();
                    sinav.SinavId = Convert.ToInt32(ddlSinavAdi.SelectedItem.Value);

                    var sinavlar = db.Sinavlars.Where(s => s.SinavId == sinav.SinavId).FirstOrDefault();
                    Session.Add("Sinavlar", sinavlar);

                    var mevcutSinav = db.Sinavlars.Find(sinav.SinavId);

                    if (mevcutSinav.SinavBaslamaTarihi > DateTime.Now)
                    {
                        Response.Write("<script>alert('Sinav Baslama Tarihini Bekleyiniz!')</script>");
                    }

                    else if (mevcutSinav.SinavBitisTarihi < DateTime.Now)
                    {
                        Response.Write("<script>alert('Sinav Tarihi Geçmiştir!')</script>");
                    }

                    else
                    {
                        Response.Redirect("OgrenciSinavBaslangicEkrani.aspx");
                    }
                }
            }

        }


    }
}