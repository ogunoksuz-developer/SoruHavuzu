using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminDersListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rp_DersleriDoldur();
            }
        }

        private void Rp_DersleriDoldur()
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                Dersler ders = new Dersler();
                //if (Request.QueryString[ders.DersId] != null && !string.IsNullOrEmpty(Request.QueryString[ders.DersId].ToString())) ;
                //{
                //    ders = (from d in db.Derslers where d.DersId == ders.DersId select d).SingleOrDefault();
                //    db.Derslers.Remove(ders);
                //    db.SaveChanges();
                //}

                rp_DersListe.DataSource = (from d in db.Derslers
                                           select new
                                           {
                                               d.DersId,
                                               d.DersAdi,
                                               d.DersDurumu
                                           }).ToList();
                rp_DersListe.DataBind();
            }
        }

        protected void rp_DersListe_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                int Id=Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Edit")
                {
                    Response.Redirect("AdminDersGuncelle.aspx?ID=" + Id);
                }

                else if (e.CommandName == "Delete")
                {
                    Dersler ders = db.Derslers.Where(d => d.DersId == Id ).FirstOrDefault();
                    ders.DersDurumu = false;
                    db.SaveChanges();
                    Rp_DersleriDoldur();

                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDersEkle.aspx");
        }
    }
}