<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="Loans.aspx.cs" Inherits="GroupCourseWork.View.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <span class="mainheading">View loans</span>

     <div class="box">
        <form id="form1" runat="server">
            <asp:TextBox ID="Search" runat="server" class="input"  placeholder="Search By Actor's LastName" style="padding:10px;"></asp:TextBox>
            <asp:Button ID="Button1"  class="formbutton" runat="server" OnClick="Button1_Click" Text="View Loan" />
        </form>
    </div>
    <asp:label id="MessageLabelLoans" runat="server" style=" color: red;  display: flex;justify-content: start; align-items: center; margin: 0px 0px 10px;"/>

    <div><asp:Panel ID="Panel1" runat="server"></asp:Panel></div>
    <style>
    #loansID{
        background-color: #d4dbef;
    }
</style>
</asp:Content>
