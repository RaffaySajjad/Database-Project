using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database_Project.Connection_Layer;
using System.Data;

namespace Database_Project
{
    public partial class doctorAccount : System.Web.UI.Page
    {
        String cnic = "";
        DataTable dataTable;
        Data_Access_Layer myAccount;
        String user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];
            myAccount = new Data_Access_Layer();
            pNameTag.InnerHtml = myAccount.getDoctorName(user);
            cnic = myAccount.getCNIC(user);
            dataTable = new DataTable();

            loadServicesTable();

            specialization.Visible = false;
            reg_no.Visible = false;
            charges.Visible = false;
            exp.Visible = false;

            introText.InnerHtml = "Hello " + myAccount.getFirstName(cnic) + ". This is the service you are offering to your clients. If you want to update your details, please contact Technical Support";


        }

        public void loadServicesTable()
        {
            if (myAccount.fetchDoctorServices(cnic, ref dataTable) == 1)
            {
                stockDatabase.DataSource = dataTable;
                stockDatabase.DataBind();
            }
        }

        protected void stockDatabase_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gridViewRow = stockDatabase.Rows[e.RowIndex];
            Label specializationLabel = (Label)stockDatabase.Rows[e.RowIndex].FindControl("lblSpecialization");

            String specializationName = specializationLabel.Text.ToString();
            int result = myAccount.deleteFromDoctorService(cnic, specializationName);
            loadServicesTable();
        }


        protected void stockDatabase_RowEditing(object sender, GridViewEditEventArgs e)
        {
            stockDatabase.EditIndex = e.NewEditIndex;
            loadServicesTable();
        }

        protected void stockDatabase_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)stockDatabase.Rows[e.RowIndex];

            Label specialization = (Label)stockDatabase.Rows[e.RowIndex].FindControl("txtSpecialization");
            TextBox regNo = (TextBox)stockDatabase.Rows[e.RowIndex].FindControl("txtRegNo");
            TextBox experience = (TextBox)stockDatabase.Rows[e.RowIndex].FindControl("txtExperience");
            TextBox charges = (TextBox)stockDatabase.Rows[e.RowIndex].FindControl("txtCharges");


            string specializationVal = specialization.Text.ToString();
            string regNoVal = regNo.Text.ToString();
            int experienceVal = Convert.ToInt32(experience.Text.ToString());
            float chargesVal = float.Parse(charges.Text.ToString());
            //=====updating the newly entered values in database====

            myAccount.updateDoctorTable(cnic, specializationVal, experienceVal, regNoVal, chargesVal);
            //======================================================
            stockDatabase.EditIndex = -1;

            loadServicesTable();
        }

        protected void stockDatabase_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            stockDatabase.EditIndex = -1;
            loadServicesTable();
        }

    }
}