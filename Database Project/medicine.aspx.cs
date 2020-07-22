using Database_Project.Connection_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.ModelBinding;

namespace Database_Project
{
    public partial class medicine : System.Web.UI.Page
    {
        Data_Access_Layer myAccount;
        DataTable dataTable;
        IList<int> selectedList;
        String user = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            myAccount = new Data_Access_Layer();
            dataTable = new DataTable();

            if(medicineName.Text != "")
            {
                searchDatabaseForMedicine();
            }
            else
            {
                loadMedicineStock();

            }

        }
        public void loadMedicineStock()
        {
            if (myAccount.getMedicineStock(ref dataTable) == 1)
            {

                medicineDatabase.DataSource = dataTable;
                medicineDatabase.DataBind();
            }
        }

        protected void Search_Button_Click(object sender, EventArgs e)
        {
            searchDatabaseForMedicine();
        }

      
        public void searchDatabaseForMedicine()
        {
            String medicineNameTxt = medicineName.Text;

            int Found;

            if (medicineNameTxt != "" || medicineNameTxt != null)
            {
                Found = myAccount.SearchMedicineStock(medicineNameTxt, ref dataTable);

                if (Found > 0)
                {
                    medicineDatabase.DataSource = dataTable;
                    medicineDatabase.DataBind();

                }
                else
                {
                    medicineDatabase.DataSource = null;
                    medicineDatabase.DataBind();
                }
            }
        }

        protected void medicineDatabase_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            user = Request.QueryString["user"];
            
            if (user == "" || user == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                int index = e.NewSelectedIndex;
                for (int i = index; i < medicineDatabase.Rows.Count; i++)
                {
                    Label medicineNameLabel = (Label)medicineDatabase.Rows[i].FindControl("lblMedicine");
                    String medName = medicineNameLabel.Text;
                    if(medName == medicineName.Text)
                    {
                        index = i;
                        break;
                    }

                }

                Label medicineLabel = (Label)medicineDatabase.Rows[index].FindControl("lblMedicine");
                Label costLabel = (Label)medicineDatabase.Rows[index].FindControl("lblPrice");

                Label vendorLabel = (Label)medicineDatabase.Rows[index].FindControl("lblVendor");

                String medicineNameTxt = medicineLabel.Text;
                String fullfilledBy = vendorLabel.Text;

                float costFloat = float.Parse(costLabel.Text);

                user = Request.QueryString["user"];

                String cnic = myAccount.getCNIC(user);

                myAccount.addMedicineOrderItem(cnic, costFloat, medicineNameTxt, fullfilledBy);

                //Deduct that item's stock
                myAccount.deductFromStock(medicineNameTxt, fullfilledBy);

                //loadMedicineStock();

            }


        }
    }
}