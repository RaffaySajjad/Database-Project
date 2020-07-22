<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="medicine.aspx.cs" Inherits="Database_Project.medicine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div id="about" class="about-box">
			<div class="container">
                <div class="title-box">
                    <h2 id="pNameTag" runat="server">Welcome</h2>
                    <p id="introText" runat="server"></p>

                    <h3 id="loginTitle" runat="server">You can use the search box to narrow down the options</h3>

                    <div class="col-md-12 form-group p_star">
                        <asp:TextBox AutoPostBack="true" ID="medicineName" placeholder="Medicine" class="form-control" runat="server" style="margin-left:265px" Width="50%">
                        </asp:TextBox>
                    </div>

                    <div class="col-md-12 form-group">
                        <asp:Button style="text-align:center" ID="searchBox" class="btn_3" runat="server" Width="15%" Height="30%" Text="Search" OnClick="Search_Button_Click"/>
                    </div>

                </div>
                <h3 style="text-align:center" id="H1" runat="server">Click on add corressponding to desired medicine to add it to cart. You can modify it later in your cart.</h3>

                <asp:GridView ID="medicineDatabase" CssClass="myCenteredGrid table table-striped table-bordered table-sm" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  runat="server" Width="100%" AutoGenerateColumns="false" AutoGenerateSelectButton="True" OnSelectedIndexChanging="medicineDatabase_SelectedIndexChanging">
                    <Columns>

                        <asp:TemplateField HeaderText="Medicine" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:Label ID="txtMedicine" runat="server" Text='<%# Bind("medicine") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblMedicine" runat="server" Text='<%# Bind("medicine") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Vendor" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtVendor" runat="server" Text='<%# Bind("pName")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblVendor" runat="server" Text='<%# Bind("pName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtQty" runat="server" Text='<%# Bind("qty")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblQty" runat="server" Text='<%# Bind("qty") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Price (PKR)" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("price")%>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("price")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>


                    </Columns>
                </asp:GridView>

   		 </div>
        
       </div>

    

</asp:Content>
