using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminKonuGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString != null && !string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                {
                    using (OnlineSinavEntities db = new OnlineSinavEntities())
                    {
                        ddDerslerDoldur(db);
                        Konular konu = new Konular();
                        konu.KonuId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                        var mevcut = db.Konulars.Find(konu.KonuId);

                        txtKonuAdi.Text = mevcut.KonuAdi;
                        if (mevcut.KonuDurumu == true)
                        {
                            rbAktif.Checked = true;
                        }
                        else
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
                Konular konu = new Konular();
                konu.KonuId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                var mevcut = db.Konulars.Find(konu.KonuId);
                mevcut.DersId = Convert.ToInt32(ddlDersAdi.SelectedValue);
                mevcut.KonuAdi = txtKonuAdi.Text;

                if (rbAktif.Checked)
                {
                    mevcut.KonuDurumu = true;
                }
                else if (rbPasif.Checked)
                {
                    mevcut.KonuDurumu = false;
                }
                db.SaveChanges();
                Response.Redirect("AdminKonuListesi.aspx");
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