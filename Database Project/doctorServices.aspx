<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="doctorServices.aspx.cs" Inherits="Database_Project.doctorServices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="about" class="about-box">
			<div class="container">
                <div class="title-box">
                    <h2 id="pNameTag" runat="server">Welcome</h2>
                    <p id="introText" runat="server"></p>

                    <h3 id="loginTitle" runat="server">You can use the search box to narrow down to options</h3>

                    <div class="col-md-12 form-group p_star">
                        <asp:TextBox AutoPostBack="true" ID="serviceName" placeholder="Service" class="form-control" runat="server" style="margin-left:265px" Width="50%">
                        </asp:TextBox>
                    </div>

                    <div class="col-md-12 form-group">
                        <asp:Button style="text-align:center" ID="searchBox" class="btn_3" runat="server" Width="15%" Height="30%" Text="Search" OnClick="Search_Button_Click"/>
                    </div>

                </div>
                <h3 style="text-align:center" id="H1" runat="server">Click on add corressponding to desired service to add it to cart.</h3>

                <asp:GridView ID="doctorDatabase" CssClass="myCenteredGrid table table-striped table-bordered table-sm" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  runat="server" Width="100%" AutoGenerateColumns="false" AutoGenerateSelectButton="True" OnSelectedIndexChanged="doctorDatabase_SelectedIndexChanged" OnSelectedIndexChanging="doctorDatabase_SelectedIndexChanging">
                    <Columns>

                        <asp:TemplateField HeaderText="First Name" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:Label ID="txtfName" runat="server" Text='<%# Bind("fName") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lblfName" runat="server" Text='<%# Bind("fName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Last Name" HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                        <asp:Label ID="txtlName" runat="server" Text='<%# Bind("lName") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                        <asp:Label ID="lbllName" runat="server" Text='<%# Bind("lName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>

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
                </asp:GridView>


                
   		 </div>
        
       </div>



</asp:Content>
