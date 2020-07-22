<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="pharmacyAccount.aspx.cs" Inherits="Database_Project.pharmacyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">  
        .myCenteredGrid  
        {  
            margin: 0 auto;  
        }  
    </style>

	<div id="about" class="about-box">
		<div class="about-a1">
			<div class="container">
                    <div class="col-lg-12">
                        <div class="title-box">
                            <h2 id="pNameTag" runat="server">Pharmacy Name</h2>
                            <p id="introText" runat="server"></p>

                            <h3 id="loginTitle" runat="server">Add/Manage your stock</h3>

                            <div class="col-md-12 form-group p_star">
                                <asp:TextBox ID="medicineName" placeholder="Medicine" class="form-control" runat="server" style="margin-left:265px" Width="50%">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-12 form-group p_star">
                                <asp:TextBox ID="qty" placeholder="Quantity" class="form-control" runat="server" style="margin-left:265px" Width="50%">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-12 form-group p_star">
                                <asp:TextBox ID="price" placeholder="Price (PKR)" class="form-control" runat="server" style="margin-left:265px" Width="50%">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-12 form-group">
                                <asp:Button ID="addToStock" class="btn_3" runat="server" Width="30%" Height="100%" Text="Add to stock" OnClick="addToStock_Click" />
                            </div>

                        </div>
                    </div>

                    <div>
                        <asp:GridView ID="stockDatabase"  CssClass="myCenteredGrid table table-striped table-bordered table-sm" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  runat="server" OnRowDataBound="stockGridView_RowDataBound" width="75%" OnRowDeleting="stockDatabase_RowDeleting" AutoGenerateColumns="False" EnableViewState="False" OnRowCancelingEdit="stockDatabase_RowCancelingEdit" OnRowEditing="stockDatabase_RowEditing" OnRowUpdating="stockDatabase_RowUpdating">
                            <Columns>

                                <asp:CommandField ShowDeleteButton="True" />
                                <asp:CommandField ShowEditButton="True" />

                                <asp:TemplateField HeaderText="Medicine" HeaderStyle-HorizontalAlign="Left">
                                <EditItemTemplate>
                                <asp:Label ID="txtMedicine" runat="server" Text='<%# Bind("medicine") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                <asp:Label ID="lblMedicine" runat="server" Text='<%# Bind("medicine") %>'></asp:Label>
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
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <RowStyle HorizontalAlign="Center"></RowStyle>
                        </asp:GridView>
                    </div>

			</div>

		</div>
        
        

    </div>

    
</asp:Content>
