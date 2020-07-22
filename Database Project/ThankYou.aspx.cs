using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database_Project
{
    public partial class ThankYou : System.Web.UI.Page
    {
        String user = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];
        }
        protected void backToStore_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx?user=" + user);
        }
    }
}