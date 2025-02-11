<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="NonLoan.aspx.cs" Inherits="GroupCourseWork.View.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="mainheading">DVD Copies that have not been loaned</span>
    <div><asp:Panel ID="Panel1" runat="server"></asp:Panel></div>
    <style>
    #nonloanedID{
        background-color: #d4dbef;
    }
</style>
</asp:Content>
