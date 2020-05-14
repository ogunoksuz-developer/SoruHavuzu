using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgretmenSinavaSoruEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                if (!IsPostBack)
                {
                    ddDerslerDoldur(db);
                }
            }
        }

        private void ddDerslerDoldur(OnlineSinavEntities db)
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

        protected void ddlDersAdi_SelectedIndexChanged1(object sender, EventArgs e)
        {

            ddlSinavAdi.Items.Clear();
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                int dersId;
                dersId = Convert.ToInt32(ddlDersAdi.SelectedItem.Value);
                if (dersId == 0)
                {
                    ddlSinavAdi.Items.Clear();
                }
                else
                {
                    var sinavlar = (from sinav in db.Sinavlars
                                    where sinav.DersId == dersId
                                    select sinav).ToList();

                    ddlSinavAdi.DataSource = sinavlar;
                    ddlSinavAdi.DataValueField = "SinavId";
                    ddlSinavAdi.DataTextField = "SinavAdi";
                    ddlSinavAdi.DataBind();
                }
            }
        }

        protected void ddlDersAdi_DataBound(object sender, EventArgs e)
        {
            ddlDersAdi.Items.Insert(0, "Ders Seçiniz");
        }

        protected void ddlSinavAdi_DataBound(object sender, EventArgs e)
        {
            ddlSinavAdi.Items.Insert(0, "Sinav Seçiniz");
        }

        protected void bnt_Save_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                try
                {
                    int sinavId;
                    Sinavlar sinav = new Sinavlar();
                    sinavId = Convert.ToInt32(ddlSinavAdi.SelectedItem.Value);
                    sinav = db.Sinavlars.Where(i => i.SinavId == sinavId).First();
                    int sinavSoruSayisi = sinav.SoruSayisi;

                    if (ddlSinavAdi.SelectedItem.Value == "0")
                    {
                        Response.Write("<script>alert('Sinav Seçiniz')</script>");
                    }

                    else
                    {
                        var sorular = (from d in db.Derslers
                                       join k in db.Konulars on d.DersId equals k.DersId
                                       join s in db.Sorulars on k.KonuId equals s.KonuId
                                       select new
                                       {
                                           s.SoruId,
                                           s.SoruMetni,
                                           s.A,
                                           s.B,
                                           s.C,
                                           s.D,
                                           s.E
                                       }).OrderBy(x => Guid.NewGuid()).Take(sinavSoruSayisi).ToArray();

                        
                        Sorular soru = new Sorular();
                        for (int i = 0; i < sorular.Length; i++)
                        {
                            int id = Convert.ToInt32(sorular[i].SoruId);
                            soru = db.Sorulars.Where(s=>s.SoruId==id).FirstOrDefault();
                            sinav.Sorulars.Add(soru);     
                        
                        }
                        sinav.SinavDurumu = true;
                        
                        db.SaveChanges();

                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}