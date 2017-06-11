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
            if (Session["id"]!=null)
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
                    var utenteId = (from u in ctx.Utenti
                                  where u.NomeUtente == username
                                  && u.Password == password
                                  select u.ID).First();

                    Session["id"] = utenteId;
                    Response.Redirect("./WFfoto.aspx?id=-1");

                }
                catch (Exception ex)
                {

                    lblError.Text = "Username o password errati!";
                }
                

            }
                    
                    
        }
    }
}