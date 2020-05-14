using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminDersEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bnt_Save_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                Dersler ders = new Dersler();
                ders.DersAdi = txtDersAdi.Text;

                db.Derslers.Add(ders);
                db.SaveChanges();

                Response.Write("<script>alert('Ders Kaydı Başarıyla Yapılmıştır.')</script>");
                txtDersAdi.Text = string.Empty;
            }
        }
    }
}