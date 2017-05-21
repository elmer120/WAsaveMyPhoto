using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WAsaveMyphoto
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"]!=null)
            {
                Response.Redirect("./Logout.aspx");
            }
        }

        public void btnAccedi_click (object sender,EventArgs a)
        {

            String username = txtUsername.Text;
            String password = Servizi.md5(txtPassword.Text);

            using (SaveMyPhotoEntities ctx = new SaveMyPhotoEntities())
            {
                try
                {
                    var utenti = (from u in ctx.Utenti
                                  where u.NomeUtente == username
                                  && u.Password == password
                                  select u).First();

                    Session["username"] = utenti.NomeUtente;
                    Response.Redirect("./WFfoto.aspx");

                }
                catch (Exception)
                {

                    lblError.Text = "Username o password errati!";
                }
                

            }
                    
                    
        }
    }
}