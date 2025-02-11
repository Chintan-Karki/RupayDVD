<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="GroupCourseWork.View.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box">
         <span class="mainheading">Dashboard</span>
        <div style="display:flex; width: full; height: 8vw; position:relative;">
            <img src="https://image.tmdb.org/t/p/original/1g0dhYtq4irTY1GPXvft6k4YLjm.jpg" alt="poster" style="width:100%; object-fit:cover; border-radius: 20px;" />
            <div style="position:absolute; top: 25%; left: 20%; "><span style="font-weight: 900; font-size: 2.8vw;  display:block; text-shadow: 1px 4px 20px black;color: #ffffff;" >Search for your favourite movies</span></div>
        </div>
        <form id="form1" runat="server" style="display:flex; justify-content: center; align-content: center; align-items:center; margin: 10px auto;">
            <asp:TextBox ID="Search" runat="server" class="input"  placeholder="Search By LastName" style="background-color:white; margin-bottom: 0px; width: 50%;"></asp:TextBox>
            
            <asp:Button ID="Button1" runat="server" class="formbutton" OnClick="Button1_Click" Text="Search" />
        </form>
        <asp:label id="MessageLabelDashboard" runat="server" style=" color: red;  display: flex;justify-content: center; align-items: center; margin: -15px 0px 15px;"/>
   </div>
    <div><asp:Panel ID="Panel1" runat="server"></asp:Panel></div>
     <style>
        #dashboardID{
            background-color: #d4dbef;
        }
    </style>
</asp:Content>
