using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminOgretmenDersEsle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (OnlineSinavEntities db = new OnlineSinavEntities())
                {
                    CheckBoxListDoldur(db);
                    DdlOgretmenDoldur(db);
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
        private void DdlOgretmenDoldur(OnlineSinavEntities db)
        {
            ddlOgretmen.Items.Clear();
            List<ListItem> items = new List<ListItem>();
            db.Kullanicilars.Where(i => i.KullaniciTurId == 2 && i.KullaniciDurumu == true).ToList().ForEach(f =>
            {
                items.Add(new ListItem
                {
                    Value = f.KullaniciId.ToString(),
                    Text = f.Adi + " " + f.Soyadi
                });
            });

            ddlOgretmen.Items.Add(new ListItem { Text = "Öğretmen Seçiniz", Value = "0" });
            ddlOgretmen.Items.AddRange(items.ToArray());
        }

        protected void bnt_Save_Click1(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                int sayac = 0;
                Kullanicilar kul = new Kullanicilar();
                int id = Convert.ToInt32(ddlOgretmen.SelectedValue);


                for (int i = 0; i < cblDersler.Items.Count; i++)
                {
                    if (!cblDersler.Items[i].Selected)
                    {
                        sayac++;
                    }
                }

                if (ddlOgretmen.SelectedItem.Value == "0")
                {
                    Response.Write("<script>alert('Öğretmen Seçiniz')</script>");
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
                    DdlOgretmenDoldur(db);
                }
            }

        }
    }
}