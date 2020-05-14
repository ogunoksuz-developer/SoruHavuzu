using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Entity;

namespace SoruHavuzu
{
    public partial class AdminKonuEkle : System.Web.UI.Page
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

        protected void bnt_Save_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                try
                {
                    if (ddlDersAdi.SelectedItem.Value == "0")
                    {
                        Response.Write("<script>alert('Ders Seçiniz')</script>");
                    }

                    else
                    {
                        Konular konu = new Konular();
                        konu.DersId = Convert.ToInt32(ddlDersAdi.SelectedValue);
                        konu.KonuAdi = txtKonuAdi.Text;
                        konu.KonuDurumu = true;

                        db.Konulars.Add(konu);
                        db.SaveChanges();
                        Response.Write("<script>alert('Konu Kaydı Başarıyla Gerçekleşmiştir.')</script>");
                        ddDerslerDoldur(db);
                        txtKonuAdi.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.ToString() + "')</script>");
                }
            }

        }

        private void ddDerslerDoldur(OnlineSinavEntities db)
        {
            ddlDersAdi.Items.Clear();
            List<ListItem> items = new List<ListItem>();
            db.Derslers.ToList().ForEach(f =>
                {
                    items.Add(new ListItem
                    {
                        Value = f.DersId.ToString(),
                        Text = f.DersAdi
                    });
                });

            ddlDersAdi.Items.Add(new ListItem { Text = "Ders Seçiniz", Value = "0" });
            ddlDersAdi.Items.AddRange(items.ToArray());
        }
    }
}