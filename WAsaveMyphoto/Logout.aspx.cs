using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WAsaveMyphoto
{
    public partial class Logout : System.Web.
        UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            lblDisconesso.Text = "Logout avvenuto correttamente <br/> <br/> Redirect alla home tra pochi secondi...";
            Response.AddHeader("REFRESH", "4;URL=./Index.aspx");
        }
    }
}