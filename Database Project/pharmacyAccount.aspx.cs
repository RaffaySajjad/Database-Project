using Database_Project.Connection_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Database_Project
{
    public partial class pharmacyAccount : System.Web.UI.Page
    {
        String cnic = "";
        DataTable dataTable;
        Data_Access_Layer myAccount;
        String user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];
            myAccount = new Data_Access_Layer();
            pNameTag.InnerHtml = myAccount.getPharmacyName(user);
            cnic = myAccount.getCNIC(user);
            dataTable = new DataTable();

            loadStockTable();

            introText.InnerHtml = "Hello " + myAccount.getFirstName(cnic) + ". Here you can manage the stock that you've presented to the audience at PHS " ;
        }

        public void loadStockTable()
        {
            if (myAccount.fetchStock(cnic, ref dataTable) == 1)
            {
                stockDatabase.DataSource = dataTable;
                stockDatabase.DataBind();
            }
        }

        protected void addToStock_Click(object sender, EventArgs e)
        {
            if(medicineName.Text != "" && qty.Text!="" && price.Text != "")
            {
                String medicineNameTxt = medicineName.Text;
                int qtyInt = int.Parse(qty.Text);
                float priceFloat = float.Parse(price.Text);
                myAccount.insertToStock(cnic, medicineNameTxt, qtyInt, priceFloat);
                loadStockTable();
            }


            clearText();
        }

        public void clearText()
        {
            medicineName.Text = "";
            qty.Text = "";
            price.Text = "";
        }

        protected void stockGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Action 1";
                e.Row.Cells[1].Text = "Action 2";

                e.Row.Cells[2].Text = "Medicine";

                e.Row.Cells[3].Text = "Quantity";
                e.Row.Cells[4].Text = "Price (Rs)";
            }
        }

        protected void stockDatabase_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gridViewRow = stockDatabase.Rows[e.RowIndex];
            Label medicineLabel = (Label) stockDatabase.Rows[e.RowIndex].FindControl("lblMedicine");

            String medicineName = medicineLabel.Text.ToString();
            int result = myAccount.deleteFromStock(cnic, medicineName);
            loadStockTable();
        }

        
        protected void stockDatabase_RowEditing(object sender, GridViewEditEventArgs e)
        {
            stockDatabase.EditIndex = e.NewEditIndex;
            loadStockTable();
        }

        protected void stockDatabase_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow) stockDatabase.Rows[e.RowIndex];
           
            Label medicine = (Label) stockDatabase.Rows[e.RowIndex].FindControl("txtMedicine");
            TextBox quantity = (TextBox) stockDatabase.Rows[e.RowIndex].FindControl("txtQty");
            TextBox price = (TextBox) stockDatabase.Rows[e.RowIndex].FindControl("txtPrice");
            
            string medicineVal = medicine.Text.ToString();
            int qtyVal = Convert.ToInt32(quantity.Text.ToString()); 
            float priceVal = float.Parse(price.Text.ToString());
            //=====updating the newly entered values in database====
            myAccount.updateStockTable(cnic, medicineVal, qtyVal, priceVal);
            //======================================================
            stockDatabase.EditIndex = -1;

            loadStockTable();
        }

        protected void stockDatabase_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            stockDatabase.EditIndex = -1;
            loadStockTable();
        }
    }
    
}