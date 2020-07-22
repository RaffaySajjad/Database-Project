<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="Database_Project.ThankYou" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br />
    <div class="site-section">
      <div class="container">
        <div class="row">

          <div class="col-md-12 text-center">
            <span class="icon-check_circle display-3 text-success"></span>
              <br />
            <h2 class="display-3 text-black">Thank you!</h2>
            <p class="lead mb-5">You order was successfuly completed.</p>
            <asp:Button ID="backToStore" Width="20%" CssClass="btn btn-md height-auto px-4 py-3 btn-primary" runat="server" Text="Back to Store" OnClick="backToStore_Click" />
             <br /><br /><br />
          </div>
        </div>
      </div>
    </div>


</asp:Content>
