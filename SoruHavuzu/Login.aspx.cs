using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                try
                {
                    var kullanici = db.Kullanicilars.Where(m => m.KulAdi == txt_UserName.Text && m.Sifre == txt_Password.Text).FirstOrDefault();
                    if (kullanici != null)
                    {
                        Session.Add("Kullanicilar", kullanici);
                        if (kullanici.KullaniciTurId == 1)
                        {
                            Response.Redirect("AdminFirstPage.aspx");
                        }
                        else if (kullanici.KullaniciTurId==2)
                        {
                            Response.Redirect("OgretmenFirstPage.aspx");
                        }
                        else if (kullanici.KullaniciTurId==3)
                        {
                            Response.Redirect("OgrenciFirstPage.aspx");
                        }
                    }

                    else
                    {
                        Response.Write("<script>alert('Yanlış Kullanıcı Adı veya Şifre Girdiniz')</script>");
                        txt_UserName.Text = string.Empty;
                        txt_Password.Text = string.Empty;
                    }                    
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                   
                }
            }
        }
    }
}