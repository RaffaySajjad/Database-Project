using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database_Project.Connection_Layer;

namespace Database_Project
{
    public partial class Login : System.Web.UI.Page
    {
        Data_Access_Layer myAccount;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.accountTypes.Attributes.Add("onchange", Page.ClientScript.GetPostBackEventReference(this.accountTypes, this.accountTypes.ID));
            hideExtraneousColumns("0");
            myAccount = new Data_Access_Layer();

            messageBox.InnerHtml = "Create an account today and avail the best deals on medics.";

        }
        protected void createAccount_Clicked(object sender, EventArgs e)
        {
            
            bool areCommonParametersValid = false;
            bool areSpecificParametersValid = false;

            string cnicText, emailText, passwordText, fNameText, lNameText;
            cnicText = cnic.Text;
            emailText = email.Text;
            passwordText = pass.Text;
            fNameText = firstname.Text;
            lNameText = lastname.Text;

            if (cnicText != "" && emailText != "" && passwordText != "" && fNameText != "" && lNameText != "")
            {
                areCommonParametersValid = true;
            }
            else
            {
                areCommonParametersValid = false;
            }


            int accountType = accountTypes.SelectedIndex;
            
            if(accountType == 0)
            {
                //Customer
                if(cAddress.Text != "")
                {
                    areSpecificParametersValid = true;
                }
                else
                {
                    areSpecificParametersValid = false;
                }
            }
            else if(accountType == 1)
            {
                //Pharmacy
                if (taxNo.Text != "" && pName.Text != "" && pAddress.Text != "")
                {
                    areSpecificParametersValid = true;
                }
                else
                {
                    areSpecificParametersValid = false;
                }
            }
            else
            {
                //Doctor
                if(docID.Text != "" && expertise.Text != "" && experience.Text != "" && chargesByDoc.Text != "")
                {
                    areSpecificParametersValid = true;
                }
                else
                {
                    areSpecificParametersValid = false;
                }
            }


            if(areCommonParametersValid && areSpecificParametersValid)
            {
                registerClient();
                messageBox.InnerHtml = "Account created. Use right hand side to login";

            }
            else
            {
                messageBox.InnerHtml = "Please check if you left any field(s) blank";
            }

            
        }

        public void registerClient()
        {

            string cnicText, emailText, passwordText, fNameText, lNameText;
            cnicText = cnic.Text;
            emailText = email.Text;
            passwordText = pass.Text;
            fNameText = firstname.Text;
            lNameText = lastname.Text;

            int accountType = accountTypes.SelectedIndex;


            myAccount.registerAccount(cnicText, emailText, passwordText, fNameText, lNameText);

            if(accountType == 0)
            {
                string cAddressText = cAddress.Text;
                myAccount.registerAsCustomer(cnicText, cAddressText);
            }
            else if(accountType == 1)
            {
                string taxNoText, pNameText, pAddressText;
                taxNoText = taxNo.Text;
                pNameText = pName.Text;
                pAddressText = pAddress.Text;
                myAccount.registerAsPharmacy(cnicText, taxNoText, pNameText, pAddressText);

            }
            else
            {
                string regNoText, specialization;
                int experienceVal = 0;
                float charges = 0;
                regNoText = docID.Text;
                specialization = expertise.Text;

                myAccount.registerAsDoctor(cnicText, experienceVal, regNoText, specialization, charges);
            }

        }

        protected void accountType_Changed(object sender, EventArgs e)
        {
            string value = accountTypes.SelectedIndex.ToString();
            hideExtraneousColumns(value);

        }
        public void hideExtraneousColumns(String accType)
        {
            if(accType == "0")
            {
                //Customer
                tNo.Visible = false;
                pN.Visible = false;
                pAd.Visible = false;

                exp.Visible = false;
                dId.Visible = false;
                expert.Visible = false;

                charge.Visible = false;
                cAd.Visible = true;
            }
            else if(accType == "1")
            {
                //Pharmacy
                cAd.Visible = false;

                exp.Visible = false;
                dId.Visible = false;
                expert.Visible = false;

                charge.Visible = false;
                tNo.Visible = true;
                pN.Visible = true;
                pAd.Visible = true;
}
            else
            {
                //Doctor
                cAd.Visible = false;

                tNo.Visible = false;
                pN.Visible = false;
                pAd.Visible = false;

                exp.Visible = true;
                dId.Visible = true;
                expert.Visible = true;
                charge.Visible = true;
            }

        }


        protected void login_Clicked(object sender, EventArgs e)
        {
            String usernameText = username.Text;
            String passwordText = password.Text;
            int loggedInStatus = myAccount.authenticateUser(usernameText, passwordText);

            if (loggedInStatus == 0)
            {
                loginTitle.InnerHtml = "Welcome!";

                String type = myAccount.getAccountType(usernameText);
                
                if (type == "Customer")
                {
                    Response.Redirect("index.aspx?user=" + usernameText);

                }
                else if(type == "Doctor")
                {
                    Response.Redirect("doctorAccount.aspx?user=" + usernameText);

                }
                else
                {
                    Response.Redirect("pharmacyAccount.aspx?user=" + usernameText);

                }
            }
            else
            {
                loginTitle.InnerHtml = "Login Failed. " + "\r\n" + "Please Try Again";
            }
        }
    }
}