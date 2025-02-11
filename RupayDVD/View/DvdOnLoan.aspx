    <%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="DvdOnLoan.aspx.cs" Inherits="GroupCourseWork.View.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="mainheading">View DVDs on loan</span>
    <div><asp:Panel ID="Panel1" runat="server"></asp:Panel></div>
    <span class="mainheading" style="font-size:24px; margin-top:20px;">Loaned DVDs</span>

    <div><asp:Panel ID="Panel2" runat="server"></asp:Panel></div>
    <style>
    #dvdsonloanID{
        background-color: #d4dbef;
    }
</style>
</asp:Content>
