using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database_Project.Connection_Layer;

namespace Database_Project
{
    public partial class index : System.Web.UI.Page
    {
        Data_Access_Layer myAccount;
        String user = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];
            myAccount = new Data_Access_Layer();


            if (myAccount.getAccountType(user) != "Customer")
            {
                services.Visible = false;
            }
            else if(user == "" || user == null)
            {
                services.Visible = true;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            String nameTxt, emailTxt, numberTxt, messageTxt;
            nameTxt = name.Text;
            emailTxt = email.Text;
            numberTxt = number.Text;
            messageTxt = message.Text;

            if(nameTxt != "" || emailTxt != "" || numberTxt != "" || messageTxt != "")
            {
                myAccount.registerInquiry(nameTxt, emailTxt, numberTxt, messageTxt);
            }

        }

        protected void medicineTag_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("medicine.aspx?user=" + user);
        }

        protected void labTag_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("medicine.aspx?user=" + user);
        }

        protected void radiologyTab_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("medicine.aspx?user=" + user);
        }

        protected void serviceTab_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("doctorServices.aspx?user=" + user);
        }
    }
}