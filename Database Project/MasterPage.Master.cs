using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database_Project;
using Database_Project.Connection_Layer;

namespace Database_Project
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        Data_Access_Layer myAccount;
        String user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            myAccount = new Data_Access_Layer();
            user = Request.QueryString["user"];

            loadAccount(user);
        }

        public void loadAccount(String user)
        {
            if (user == null || user == "")
            {

                test_cart.Visible = false;
                servicesTab.Visible = true;
                
                pharmacyTab.Visible = false;
                doctorTab.Visible = false;

                loginTab.Visible = true;


                logOutButton.Visible = false;

            }
            else
            {
                string accountType = myAccount.getAccountType(user);

                if (accountType == "Customer")
                {
                    test_cart.Visible = true;
                    servicesTab.Visible = true;
                    pharmacyTab.Visible = false;
                    doctorTab.Visible = false;
                    loginTab.Visible = false;
                    logOutButton.Visible = true;
                }
                else if (accountType == "Pharmacy")
                {
                    servicesTab.Visible = false;
                    test_cart.Visible = false;
                    pharmacyTab.Visible = true;
                    doctorTab.Visible = false;
                    loginTab.Visible = false;

                    logOutButton.Visible = true;
                }
                else
                {
                    test_cart.Visible = false;
                    servicesTab.Visible = false;
                    pharmacyTab.Visible = false;
                    doctorTab.Visible = true;
                    loginTab.Visible = false;

                    doctorTab.Visible = true;

                    logOutButton.Visible = true;
                }
            }

        }
        protected void HomeTabClick(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("index.aspx?user=" + user);

        }
        protected void AboutUsTabClick(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("index.aspx?user=" + user + "#about");
        }
        protected void ServicesTabClick(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("index.aspx?user=" + user + "#services");
        }
        protected void GalleryTabClick(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("index.aspx?user=" + user + "#gallery");
        }
        protected void CustomerReviewsTabClick(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("index.aspx?user=" + user + "#blog");
        }
        protected void ContactTabClick(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("index.aspx?user=" + user + "#contact");
        }
        protected void LoginTabClick(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("login.aspx");
        }
        
        protected void PharmacyTabClick(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("pharmacyAccount.aspx?user=" + user);
        }
        protected void DoctorTabClick(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("doctorAccount.aspx?user=" + user);
        }

        protected void LogOutTabClick(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }


        protected void subscribeFunction(object sender, EventArgs e)
        {

            myAccount.addToSubscribersList(emailAddress.Text);
            emailAddress.Text = "";
        }

        protected void medicineTab_Click(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("medicine.aspx?user=" + user);
        }

        protected void doctorHireTab_Click(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("doctorServices.aspx?user=" + user);
        }
        protected void cartTabClick(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];

            Response.Redirect("myCart.aspx?user=" + user);
        }
    }
}