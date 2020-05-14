using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminOgrenciDersEsle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (OnlineSinavEntities db = new OnlineSinavEntities())
                {
                    CheckBoxListDoldur(db);
                    DdlOgrenciDoldur(db);
                }
            }
        }

        private void CheckBoxListDoldur(OnlineSinavEntities db)
        {
            cblDersler.Items.Clear();
            List<ListItem> items = new List<ListItem>();
            db.Derslers.Where(i => i.DersDurumu == true).ToList().ForEach(f =>
                {
                    items.Add(new ListItem
                    {
                        Value = f.DersId.ToString(),
                        Text = f.DersAdi
                    });
                });

            cblDersler.Items.AddRange(items.ToArray());
        }

        private void DdlOgrenciDoldur(OnlineSinavEntities db)
        {
            ddlOgrenci.Items.Clear();
            List<ListItem> items = new List<ListItem>();
            db.Kullanicilars.Where(i => i.KullaniciTurId == 3 && i.KullaniciDurumu == true).ToList().ForEach(f =>
            {
                items.Add(new ListItem
                {
                    Value = f.KullaniciId.ToString(),
                    Text = f.Adi + " " + f.Soyadi
                });
            });

            ddlOgrenci.Items.Add(new ListItem { Text = "Öğrenci Seçiniz", Value = "0" });
            ddlOgrenci.Items.AddRange(items.ToArray());
        }

        protected void bnt_Save_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                int sayac = 0;
                Kullanicilar kul = new Kullanicilar();
                int id = Convert.ToInt32(ddlOgrenci.SelectedValue);
               
                for (int i = 0; i < cblDersler.Items.Count; i++)
                {
                    if (!cblDersler.Items[i].Selected)
                    {
                        sayac++;
                    }
                }

                if (ddlOgrenci.SelectedItem.Value == "0")
                {
                    Response.Write("<script>alert('Öğrenci Seçiniz')</script>");
                }
                
                else if (sayac == cblDersler.Items.Count)
                {
                    Response.Write("<script>alert('Ders veya Dersler Seçiniz')</script>");
                }
                
                else
                {
                    kul = db.Kullanicilars.Where(i => i.KullaniciId == id).First();

                    Dersler ders = new Dersler();
                    //int id2 = Convert.ToInt32(cblDersler.SelectedValue);
                    int seciliDers = cblDersler.Items.Count;
                    for (int i = 0; i < seciliDers; i++)
                    {
                        if (cblDersler.Items[i].Selected == true)
                        {
                            int id2 = Convert.ToInt32(cblDersler.Items[i].Value);
                            ders = db.Derslers.Where(m => m.DersId == id2).FirstOrDefault();
                            kul.Derslers.Add(ders);
                        }
                    }
                    db.SaveChanges();
                    DdlOgrenciDoldur(db);
                }
            }
        }
    }
}