<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="myCart.aspx.cs" Inherits="Database_Project.myCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="about" class="about-box">
		<div class="about-a1">
			<div class="container">

                <div class="col-lg-12">
                        <div class="title-box">
                            <h2 id="pNameTag" runat="server">Customer Name</h2>
                            <p id="introText" runat="server"></p>

                            <h3 id="loginTitle" runat="server">All Good? Confirm your order now!</h3>

                        </div>
                    </div>

                <asp:GridView ID="myCartDatabase" CssClass="myCenteredGrid table table-striped table-bordered table-sm" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  runat="server" Width="100%" AutoGenerateColumns="False" OnRowCancelingEdit="myCartDatabase_RowCancelingEdit" OnRowDeleting="myCartDatabase_RowDeleting" OnRowEditing="myCartDatabase_RowEditing" OnRowUpdating="myCartDatabase_RowUpdating">

                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" />


                        <asp:TemplateField HeaderText="Medicine/Doctor" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:Label ID="txtServiceName" runat="server" Text='<%# Bind("serviceName") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblServiceName" runat="server" Text='<%# Bind("serviceName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Units/Hours" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtQty" runat="server" Text='<%# Bind("qty")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Base Price" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtCost" runat="server" Text='<%# Bind("cost")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblCost" runat="server" Text='<%# Bind("cost")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Total Price" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtTotal" runat="server" Text='<%# Bind("total")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("total")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Category" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtService" runat="server" Text='<%# Bind("service")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblService" runat="server" Text='<%# Bind("service")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fullfilled By" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtFullfilledBy" runat="server" Text='<%# Bind("fullfilledBy")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblFullfilledBy" runat="server" Text='<%# Bind("fullfilledBy")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>



                    </Columns>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                    <RowStyle HorizontalAlign="Center"></RowStyle>

                </asp:GridView>

                <br /><br />
          <div id="head1" runat="server" class="row">
          <div class="col-md-6">
            <div class="row mb-5">
                <h3 style="margin-left:17px" id="instructions" runat="server">If you have a coupon, add it to avail a discout and/or click Confirm Order to place your order.</h3>
            </div>
            <div class="row">
              <div class="col-md-12">
                <label class="text-black h4" for="coupon">Coupon</label>
                <p id="couponInfo" runat="server">Enter your coupon code if you have one.</p>
              </div>
              <div class="col-md-8 mb-3 mb-md-0">
                <asp:TextBox ID="coupon" placeholder="Coupon Code" runat="server" CssClass="form-control py-3"></asp:TextBox>
              </div>
              <div class="col-md-4">
                <asp:Button ID="applyCoupon" runat="server" Text="Apply Coupon" CssClass="btn btn-primary btn-md px-4" OnClick="applyCoupon_Click" />
              </div>
            </div>
          </div>
          <div class="col-md-6 pl-5">
            <div class="row justify-content-end">
              <div class="col-md-7">
                <div class="row">
                  <div class="col-md-12 text-right border-bottom mb-5">
                    <h3 class="text-black h4 text-uppercase">Cart Totals</h3>
                  </div>
                </div>
                <div class="row mb-3">
                  <div class="col-md-6">
                    <span class="text-black">Subtotal</span>
                  </div>
                  <div class="col-md-6 text-right">
                    <strong id="subtotal" runat="server" class="text-black">$230.00</strong>
                  </div>
                  <div class="col-md-6">
                    <span class="text-black">Tax</span>
                  </div>
                  <div class="col-md-6 text-right">
                    <strong id="tax" runat="server" class="text-black">$230.00</strong>
                  </div>
                  <div class="col-md-6">
                  <span class="text-black">Discount</span>
                </div>
                  <div class="col-md-6 text-right">
                    <strong id="discount" runat="server" class="text-black">$0.00</strong>
                  </div>
                </div>
                <div class="row mb-5">
                  <div class="col-md-6">
                    <span class="text-black">Total</span>
                  </div>
                  <div class="col-md-6 text-right">
                    <strong id="totalPayable" runat="server" class="text-black">$230.00</strong>
                  </div>
                </div>
    
                <div class="row">
                    <div class="col-md-12">
                    <asp:Button ID="checkOut" runat="server" Text="Confirm Order" CssClass="btn btn-primary btn-lg btn-block" OnClick="checkOut_Click" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>



             </div>
        </div>
    </div>
</asp:Content>
