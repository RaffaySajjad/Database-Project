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
    public partial class doctorServices : System.Web.UI.Page
    {
        Data_Access_Layer myAccount;
        DataTable dataTable;
        String user = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            myAccount = new Data_Access_Layer();
            dataTable = new DataTable();

            searchDatabaseForServices();
        }

        protected void Search_Button_Click(object sender, EventArgs e)
        {
            searchDatabaseForServices();

        }


        public void searchDatabaseForServices()
        {
            String serviceNameTxt = serviceName.Text;


            int Found;

            if (serviceNameTxt != "" || serviceNameTxt != null)
            {
                Found = myAccount.SearchDoctorServices(serviceNameTxt, ref dataTable);

                if (Found > 0)
                {
                    doctorDatabase.DataSource = dataTable;
                    doctorDatabase.DataBind();

                }
                else
                {
                    doctorDatabase.DataSource = null;
                    doctorDatabase.DataBind();
                }
            }
        }

        protected void doctorDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            



        }

        protected void doctorDatabase_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            user = Request.QueryString["user"];

            if (user == "" || user == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
             
                int index = e.NewSelectedIndex;
                for (int i = index; i < doctorDatabase.Rows.Count; i++)
                {
                    Label serviceNameLabel = (Label)doctorDatabase.Rows[i].FindControl("lblSpecialization");
                    String serviceNameTxt = serviceNameLabel.Text;
                    if (serviceNameTxt == serviceName.Text)
                    {
                        index = i;
                        break;
                    }

                }

                Label specializationLabel = (Label)doctorDatabase.Rows[index].FindControl("lblSpecialization");
                Label fNameLabel = (Label)doctorDatabase.Rows[index].FindControl("lblfName");
                Label lNameLabel = (Label)doctorDatabase.Rows[index].FindControl("lbllName");

                Label costLabel = (Label)doctorDatabase.Rows[index].FindControl("lblCharges");


                //int costVal = int.Parse(cost.Text);
                String medicineNameTxt = specializationLabel.Text;
                String fullfilledBy = fNameLabel.Text + ' ' + lNameLabel.Text;
                float costFloat = float.Parse(costLabel.Text);

                user = Request.QueryString["user"];

                String cnic = myAccount.getCNIC(user);


                myAccount.addServiceOrderItem(cnic, costFloat, medicineNameTxt, fullfilledBy);

            }
        }
    }
}