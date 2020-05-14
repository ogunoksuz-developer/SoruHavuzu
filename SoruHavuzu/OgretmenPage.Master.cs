using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class OgretmenPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Kullanicilar"] != null)
                {
                    Kullanicilar kul = new Kullanicilar();
                    kul = (Kullanicilar)Session["Kullanicilar"];
                    lbl_AdminAdSoyad.Text = kul.Adi + " " + kul.Soyadi;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}