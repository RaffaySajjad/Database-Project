<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="doctorAccount.aspx.cs" Inherits="Database_Project.doctorAccount" %>
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
                            <br /><br /> <br />
                            <h2 id="pNameTag" runat="server">Doctor's Name</h2>
                            <p id="introText" runat="server"></p>

                            
                            <div class="col-md-12 form-group p_star">
                                <asp:TextBox ID="specialization" placeholder="Specialization" class="form-control" runat="server" style="margin-left:265px" Width="50%">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-12 form-group p_star">
                                <asp:TextBox ID="reg_no" placeholder="Registration Number" class="form-control" runat="server" style="margin-left:265px" Width="50%">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-12 form-group p_star">
                                <asp:TextBox ID="exp" placeholder="Experience" class="form-control" runat="server" style="margin-left:265px" Width="50%">
                                </asp:TextBox>
                            </div>

                            <div class="col-md-12 form-group p_star">
                                <asp:TextBox ID="charges" placeholder="Charges (PKR)" class="form-control" runat="server" style="margin-left:265px" Width="50%">
                                </asp:TextBox>
                            </div>

                            
                        </div>
                    </div>

                    <div>
                        <asp:GridView ID="stockDatabase"  CssClass="myCenteredGrid table table-striped table-bordered table-sm" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  runat="server"  width="75%" OnRowDeleting="stockDatabase_RowDeleting" AutoGenerateColumns="False" EnableViewState="False" OnRowCancelingEdit="stockDatabase_RowCancelingEdit" OnRowEditing="stockDatabase_RowEditing" OnRowUpdating="stockDatabase_RowUpdating">
                            <Columns>

                               
                                <asp:TemplateField HeaderText="Specialization" HeaderStyle-HorizontalAlign="Left">
                                <EditItemTemplate>
                                <asp:Label ID="txtSpecialization" runat="server" Text='<%# Bind("specialization") %>'></asp:Label>
                                </EditItemTemplate>
                                <ItemTemplate>
                                <asp:Label ID="lblSpecialization" runat="server" Text='<%# Bind("specialization") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Registration No" HeaderStyle-HorizontalAlign="Left">
                                <EditItemTemplate>
                                <asp:TextBox ID="txtRegNo" runat="server" Text='<%# Bind("regNo")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                <asp:Label ID="lblRegNo" runat="server" Text='<%# Bind("regNo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Experience" HeaderStyle-HorizontalAlign="Left">
                                <EditItemTemplate>
                                <asp:TextBox ID="txtExperience" runat="server" Text='<%# Bind("experience")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                <asp:Label ID="lblExperience" runat="server" Text='<%# Bind("experience")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Charges (PKR)" HeaderStyle-HorizontalAlign="Left">
                                <EditItemTemplate>
                                <asp:TextBox ID="txtCharges" runat="server" Text='<%# Bind("charges")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                <asp:Label ID="lblCharges" runat="server" Text='<%# Bind("charges")%>'></asp:Label>
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
