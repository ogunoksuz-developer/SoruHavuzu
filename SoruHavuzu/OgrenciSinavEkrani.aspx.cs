using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgrenciSinavEkrani : System.Web.UI.Page
    {
        public int Not;
        public int puan;
        public int dogruSayisi;
        public int soruSayisi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int sinavSuresi = 0;
                Sinavlar sinav = new Sinavlar();
                sinav = (Sinavlar)Session["Sinavlar"];
                sinavSuresi = sinav.SinavSuresi * 60;
                puan = 100 / sinav.SoruSayisi;

                int i = 0;
                Session.Add("deger", i);
                lblTimer.Text = "";
                if (!ScriptManager1.IsInAsyncPostBack)
                {
                    Session["timeout"] = DateTime.Now.AddSeconds(sinavSuresi).ToString();
                }
                SorulariGetir();
            }
        }

        private void SorulariGetir()
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                Sinavlar sinav = new Sinavlar();
                sinav = (Sinavlar)Session["Sinavlar"];
                soruSayisi = sinav.SoruSayisi;

                var sorular = (from s in db.Sinavlars
                               from soru in s.Sorulars
                               where s.SinavId == sinav.SinavId
                               select new
                               {
                                   soru.SoruId,
                                   soru.SoruMetni,
                                   soru.A,
                                   soru.B,
                                   soru.C,
                                   soru.D,
                                   soru.E,
                                   soru.DogruCevap
                               }).ToArray();
                if (Convert.ToInt32(Session["deger"]) >= soruSayisi)
                {
                    Response.Write("<script>alert('Son Soru Olduğundan İleri Geçemezsiniz!')</script>");
                }
                else if (Convert.ToInt32(Session["deger"]) < 0)
                {
                    Response.Write("<script>alert('İlk Soru olduğundan daha geriye gidemezsin!')</script>");
                }
                else
                {
                    Label1.Text = sorular[Convert.ToInt32(Session["deger"])].SoruMetni;
                    lblSoruNo.Text = (Convert.ToInt32(Session["deger"]) + 1).ToString();
                    rbA.Text = sorular[Convert.ToInt32(Session["deger"])].A;
                    rbB.Text = sorular[Convert.ToInt32(Session["deger"])].B;
                    rbC.Text = sorular[Convert.ToInt32(Session["deger"])].C;
                    rbD.Text = sorular[Convert.ToInt32(Session["deger"])].D;
                    rbE.Text = sorular[Convert.ToInt32(Session["deger"])].E;
                    rbDogruCevap.Text = sorular[Convert.ToInt32(Session["deger"])].DogruCevap;

                    if (rbA.Checked)
                    {
                        if (rbA.Text == sorular[Convert.ToInt32(Session["deger"])].DogruCevap)
                        {
                            dogruSayisi = dogruSayisi + 1;
                        }
                    }
                    else if (rbB.Checked)
                    {
                        if (rbB.Text == sorular[Convert.ToInt32(Session["deger"])].DogruCevap)
                        {
                            dogruSayisi = dogruSayisi + 1;
                        }

                    }

                    else if (rbC.Checked)
                    {
                        if (rbC.Text == sorular[Convert.ToInt32(Session["deger"])].DogruCevap)
                        {
                            dogruSayisi = dogruSayisi + 1;
                        }

                    }

                    else if (rbD.Checked)
                    {
                        if (rbD.Text == sorular[Convert.ToInt32(Session["deger"])].DogruCevap)
                        {
                            dogruSayisi = dogruSayisi + 1;
                        }
                    }

                    else if (rbE.Checked)
                    {
                        if (rbE.Text == sorular[Convert.ToInt32(Session["deger"])].DogruCevap)
                        {
                            dogruSayisi = dogruSayisi + 1;
                        }
                    }
                }
            }
        }

        protected void tmrKalanSure_Tick(object sender, EventArgs e)
        {
            if (0 > DateTime.Compare(DateTime.Now, DateTime.Parse(Session["timeout"].ToString())))
            {
                lblTimer.Text = ((Int32)DateTime.Parse(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalSeconds).ToString();
            }

            else
            {
                Session.Abandon();
                Response.Write("<script>alert('Sınav Oturum Süreniz Dolmuştur')</script>");
                Response.Redirect("OgrenciSinavOturumu.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(Session["deger"]) + 1;
            Session["deger"] = i;

            //rbA.Checked = false;
            //rbB.Checked = false;
            //rbC.Checked = false;
            //rbD.Checked = false;
            //rbE.Checked = false;
            SorulariGetir();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(Session["deger"]) - 1;
            Session["deger"] = i;

            //rbA.Checked = false;
            //rbB.Checked = false;
            //rbC.Checked = false;
            //rbD.Checked = false;
            //rbE.Checked = false;
            SorulariGetir();
        }

        protected void btnSinavBitir_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                Kullanicilar kul = new Kullanicilar();
                kul = (Kullanicilar)Session["Kullanicilar"];
                int kulid = Convert.ToInt32(kul.KullaniciId);

                Sinavlar sinav = new Sinavlar();
                sinav = (Sinavlar)Session["Sinavlar"];
                int sinid = Convert.ToInt32(sinav.SinavId);

                Not = dogruSayisi * puan;
                bool SinavaGirdimi = true;

                KullanicilarSinavlar ks = new KullanicilarSinavlar();
                ks.KullaniciId = kulid;
                ks.SinavId = sinid;
                ks.SinavNotu = Not;
                ks.SinavaGirdimi = SinavaGirdimi;

                db.KullanicilarSinavlars.Add(ks);                
                db.SaveChanges();
            }
            Response.Redirect("OgrenciSinavBitisEkrani.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                Kullanicilar kul = new Kullanicilar();
                kul = (Kullanicilar)Session["Kullanicilar"];
                int kulid = Convert.ToInt32(kul.KullaniciId);

                Sinavlar sinav = new Sinavlar();
                sinav = (Sinavlar)Session["Sinavlar"];
                int sinid = Convert.ToInt32(sinav.SinavId);

                Not = dogruSayisi * puan;
                bool SinavaGirdimi = false;

                KullanicilarSinavlar ks = new KullanicilarSinavlar();
                ks.KullaniciId = kulid;
                ks.SinavId = sinid;
                ks.SinavNotu = 0;
                ks.SinavaGirdimi = SinavaGirdimi;

                db.KullanicilarSinavlars.Add(ks);
                db.SaveChanges();
            }
            Response.Redirect("OgrenciTalepEkle.aspx");
        }
    }
}