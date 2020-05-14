using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminDersGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (OnlineSinavEntities db = new OnlineSinavEntities())
                {
                    if (Request.QueryString != null && !string.IsNullOrEmpty(Request.QueryString["ID"].ToString()))
                    {
                        Dersler ders = new Dersler();
                        ders.DersId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                        var mevcut = db.Derslers.Find(ders.DersId);
                        txtDersAdi.Text = mevcut.DersAdi;
                        if (mevcut.DersDurumu == true)
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
                Dersler ders = new Dersler();
                ders.DersId = Convert.ToInt32(Request.QueryString["ID"].ToString());
                var mevcut = db.Derslers.Find(ders.DersId);
                mevcut.DersAdi = txtDersAdi.Text;
                if (rbPasif.Checked)
                {
                    mevcut.DersDurumu = false;
                }
                else if (rbAktif.Checked)
                {
                    mevcut.DersDurumu = true;
                }
                db.SaveChanges();
                Response.Redirect("AdminDersListesi.aspx");

            }
        }
    }
}