using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgretmenSoruEkle : System.Web.UI.Page
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

        protected void ddlKonuAdi_DataBound(object sender, EventArgs e)
        {
            ddlKonuAdi.Items.Insert(0, "Konu Seçiniz");
        }

        protected void ddlDersAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlKonuAdi.Items.Clear();
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                int dersId = Convert.ToInt32(ddlDersAdi.SelectedItem.Value);
                if (dersId == 0)
                {
                    ddlKonuAdi.Items.Clear();
                }
                else
                {
                    var konular = (from konu in db.Konulars
                                   where konu.KonuDurumu == true && konu.DersId == dersId
                                   select konu).ToList();

                    ddlKonuAdi.DataSource = konular;
                    ddlKonuAdi.DataValueField = "KonuId";
                    ddlKonuAdi.DataTextField = "KonuAdi";
                    ddlKonuAdi.DataBind();
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                try
                {
                    if (ddlDersAdi.SelectedItem.Value == "0")
                    {
                        Response.Write("<script>alert('Ders Seçiniz')</script>");
                    }
                    else if (ddlKonuAdi.SelectedItem.Value == "Konu Seçiniz")
                    {
                        Response.Write("<script>alert('Konu Seçiniz')</script>");
                    }
                    else if (ddlZorlukDerecesi.SelectedItem.Value == "0")
                    {
                        Response.Write("<script>alert('Zorluk Derecesi Seçiniz')</script>");
                    }
                    else
                    {
                        Sorular soru = new Sorular();
                        soru.KonuId = Convert.ToInt32(ddlKonuAdi.SelectedValue);
                        soru.SoruMetni = txtSoru.Text;
                        soru.ZorlukDerecesi = ddlZorlukDerecesi.Text;
                        soru.A = txtA.Text;
                        soru.B = txtB.Text;
                        soru.C = txtC.Text;
                        soru.D = txtD.Text;
                        soru.E = txtE.Text;
                        soru.DogruCevap = txtDogruCevap.Text;
                        soru.SoruDurumu = true;

                        db.Sorulars.Add(soru);
                        db.SaveChanges();

                        Response.Write("<script>alert('Soru Kaydı Başarıyla Gerçekleşmiştir.')</script>");
                        ddDersDoldur(db);
                        ddlKonuAdi.Items.Clear();

                        txtSoru.Text = string.Empty;
                        txtA.Text = string.Empty;
                        txtB.Text = string.Empty;
                        txtC.Text = string.Empty;
                        txtD.Text = string.Empty;
                        txtE.Text = string.Empty;
                        txtDogruCevap.Text = string.Empty;

                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.ToString() + "')</script>");
                }
            }
        }
    }
}

