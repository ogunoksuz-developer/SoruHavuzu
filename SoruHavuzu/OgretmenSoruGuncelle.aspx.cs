using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgretmenSoruGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString != null && !string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                {
                    using (OnlineSinavEntities db = new OnlineSinavEntities())
                    {
                        Sorular soru = new Sorular();
                        soru.SoruId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                        var mevcut = db.Sorulars.Find(soru.SoruId);

                        txtSoruAdi.Text = mevcut.SoruMetni;
                        txtA.Text = mevcut.A;
                        txtB.Text = mevcut.B;
                        txtC.Text = mevcut.C;
                        txtD.Text = mevcut.D;
                        txtE.Text = mevcut.E;
                        txtDogruCevap.Text = mevcut.DogruCevap;
                        if (mevcut.SoruDurumu == true)
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
                Sorular soru = new Sorular();
                soru.SoruId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                var mevcut = db.Sorulars.Find(soru.SoruId);
                mevcut.SoruMetni = txtSoruAdi.Text;
                mevcut.A = txtA.Text;
                mevcut.B = txtB.Text;
                mevcut.C = txtC.Text;
                mevcut.D = txtD.Text;
                mevcut.E = txtE.Text;
                mevcut.DogruCevap = txtDogruCevap.Text;
                if (rbAktif.Checked)
                {
                    mevcut.SoruDurumu = true;
                }
                else if (rbPasif.Checked)
                {
                    mevcut.SoruDurumu = false;
                }
                db.SaveChanges();
                Response.Redirect("OgretmenSoruListesi.aspx");
            }
        }
    }
}