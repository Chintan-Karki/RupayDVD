<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="SearchADvd.aspx.cs" Inherits="GroupCourseWork.View.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <span class="mainheading">Search for a DVD Copy</span>

    <form id="form1" runat="server">
        <asp:TextBox ID="Search" class="input" runat="server" placeholder="Search By Copy Number"></asp:TextBox>
        <asp:Button ID="Button1" class="formbutton" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>
    <asp:label id="MessageLabelSearchDvd" runat="server" style=" color: red;  display: flex;justify-content: start; align-items: center; margin: 0px 0px 10px;"/>

     <div><asp:Panel ID="Panel1" runat="server"></asp:Panel></div>
    <style>
    #searchdvdID{
        background-color: #d4dbef;
    }
</style>
</asp:Content>