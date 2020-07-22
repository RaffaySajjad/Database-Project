using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Database_Project.Connection_Layer;

namespace Database_Project
{
    public partial class myCart : System.Web.UI.Page
    {
        Data_Access_Layer myAccount;
        DataTable dataTable;
        String user = "";
        String cnic = "";
        float cartTotal = 0;
        float discountVal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Request.QueryString["user"];
            myAccount = new Data_Access_Layer();
            cnic = myAccount.getCNIC(user);

            
            dataTable = new DataTable();

            loadMyCart();

            pNameTag.InnerHtml = "Hi " + myAccount.getFirstName(cnic) + "!";
            if (myCartDatabase.Rows.Count == 0)
            {
                loginTitle.InnerHtml = "Hmmm. You haven't added anything in here yet. Go to Services tab to order desired Services.";
                removeExtraTags();
            }
            else
            {
                discount.InnerText = "Rs:0";
                couponInfo.Style.Add("color", "black");
                couponInfo.InnerHtml = "Enter your coupon code if you have one.";
            }
            
        }

        public void removeExtraTags()
        {
            head1.Visible = false;
        }

        public void updateCartTotal()
        {
            cartTotal = myAccount.getCartTotal(cnic);
            subtotal.InnerHtml = "Rs:" + Math.Round(cartTotal, 2);
            tax.InnerHtml = "Rs:" + Math.Round(0.05 * cartTotal, 2);
            totalPayable.InnerHtml = "Rs:" + Math.Round((Math.Round(1.05 * cartTotal, 2) - discountVal), 2);
            
        }

        public void loadMyCart()
        {
            if (myAccount.getCart(cnic, ref dataTable) == 1)
            {
                myCartDatabase.DataSource = dataTable;
                myCartDatabase.DataBind();
                updateCartTotal();
            }
            else
            {
                myCartDatabase.Visible = false;
                loginTitle.InnerHtml = "Hmmm. You haven't added anything in here yet. Go to Services tab to order desired Services.";
                removeExtraTags();
            }

            float status = myAccount.isCouponValid(coupon.Text);
            if (status != 0)
            {
                //Coupon applicable
                discountVal = cartTotal * (status / 100);
                discount.InnerHtml = "Rs:" + Math.Round(discountVal, 2);

                couponInfo.InnerHtml = "Coupon code applied successfully";
                couponInfo.Style.Add("color", "green");

                updateCartTotal();

            }
            else
            {
                //Coupon not applicable
                discount.InnerHtml = "Rs:0";
                couponInfo.InnerHtml = "This code is either expired or invalid";

            }

        }

        protected void myCartDatabase_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void myCartDatabase_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gridViewRow = myCartDatabase.Rows[e.RowIndex];
            Label serviceLabel = (Label)myCartDatabase.Rows[e.RowIndex].FindControl("lblServiceName");
            Label fullfilledByLabel = (Label)myCartDatabase.Rows[e.RowIndex].FindControl("lblFullfilledBy");
            Label qtyLabel = (Label)myCartDatabase.Rows[e.RowIndex].FindControl("lblQty");


            String serviceNameTxt = serviceLabel.Text.ToString();
            String fullfilledByTxt = fullfilledByLabel.Text.ToString();
            String qtyTxt = qtyLabel.Text.ToString();


            int result = myAccount.deleteFromCart(cnic, serviceNameTxt, fullfilledByTxt);


            //Add deleted item back to stock
            myAccount.reclaimStock(serviceNameTxt, fullfilledByTxt, int.Parse(qtyTxt));

            loadMyCart();
        }

        protected void myCartDatabase_RowEditing(object sender, GridViewEditEventArgs e)
        {
            myCartDatabase.EditIndex = e.NewEditIndex;
            loadMyCart();
        }

        protected void myCartDatabase_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)myCartDatabase.Rows[e.RowIndex];

            Label serviceName = (Label)myCartDatabase.Rows[e.RowIndex].FindControl("txtServiceName");
            Label fullfilledByLabel = (Label)myCartDatabase.Rows[e.RowIndex].FindControl("lblFullfilledBy");

            TextBox quantity = (TextBox)myCartDatabase.Rows[e.RowIndex].FindControl("txtQty");
            TextBox price = (TextBox)myCartDatabase.Rows[e.RowIndex].FindControl("txtCost");

            string serviceNameVal = serviceName.Text.ToString();
            //String fullfilledByTxt = fullfilledByLabel.Text.ToString();

            int qtyVal = Convert.ToInt32(quantity.Text.ToString());
            float costVal = float.Parse(price.Text.ToString());
            //=====updating the newly entered values in database====
            myAccount.updateMyCart(cnic, serviceNameVal, "Nasrullah Arshad", costVal, qtyVal);
            //======================================================
            myCartDatabase.EditIndex = -1;

            loadMyCart();
        }

        protected void applyCoupon_Click(object sender, EventArgs e)
        {
            if(coupon.Text != "")
            {
                float status = myAccount.isCouponValid(coupon.Text);
                if(status != 0)
                {
                    //Coupon applicable
                    discountVal = cartTotal * (status / 100);
                    discount.InnerHtml = "Rs:" + Math.Round(discountVal, 2);

                    couponInfo.InnerHtml = "Coupon code applied successfully";
                    couponInfo.Style.Add("color", "#7CFC00");

                    updateCartTotal();           
                }
                else
                {
                    //Coupon not applicable
                    discount.InnerHtml = "Rs: 0";
                    couponInfo.InnerHtml = "This code is either expired or invalid";
                    couponInfo.Style.Add("color", "red");
                }
            }
            else
            {
                couponInfo.InnerHtml = "Enter your coupon code if you have one";
                couponInfo.Style.Add("color", "black");
                discount.InnerHtml = "Rs: 0";
                discountVal = 0;
            }
        }
        protected void checkOut_Click(object sender, EventArgs e)
        {
            //If coupon applied set status to Expired and add user who used it
            if(discountVal != 0)
            {
                myAccount.updateCouponStatus(coupon.Text, user);
            }
            //Change status of cart items from Active to Delivered
            myAccount.deliverCartItems(cnic);
            //Display Thank You page
            Response.Redirect("ThankYou.aspx?user=" + user);

        }
    }
}