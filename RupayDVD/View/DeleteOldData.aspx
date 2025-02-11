<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="DeleteOldData.aspx.cs" Inherits="GroupCourseWork.View.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <span class="mainheading">Delete DVDs</span>

    <form id="form1" runat="server">
        <asp:Button  runat="server" Text="DELETE" class="formbutton" style="background-color: #b10e0e;" OnClick="Unnamed1_Click" />
    </form>
    <div><asp:Panel ID="Panel1" runat="server"></asp:Panel></div>
    <style>
    #deleteolddataID{
        background-color: #d4dbef;
    }
</style>
</asp:Content>
