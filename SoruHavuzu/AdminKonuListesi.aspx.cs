using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoruHavuzu
{
    public partial class AdminKonuListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Rp_KonuDoldur();
            }
        }

        private void Rp_KonuDoldur()
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

                rp_KonuListe.DataSource = (from d in db.Derslers
                                           join k in db.Konulars on d.DersId equals k.DersId
                                           select new
                                           {
                                               k.KonuId,
                                               k.KonuAdi,
                                               d.DersAdi,
                                               k.KonuDurumu
                                           }).ToList();
                rp_KonuListe.DataBind();
            }
        }

        protected void rp_KonuListe_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            using (OnlineSinavEntities db = new OnlineSinavEntities())
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "Edit")
                {
                    Response.Redirect("AdminKonuGuncelle.aspx?ID=" + id);
                }

                else if (e.CommandName == "Delete")
                {
                    Konular konu = db.Konulars.Where(k => k.KonuId == id).FirstOrDefault();
                    konu.KonuDurumu = false;
                    db.SaveChanges();
                    Rp_KonuDoldur();
                }
            }
        }

        protected void Button1_Click3(object sender, EventArgs e)
        {
            Response.Redirect("AdminKonuEkle.aspx");
        }
    }
}