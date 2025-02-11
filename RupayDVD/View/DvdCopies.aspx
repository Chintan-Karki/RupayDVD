<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="DvdCopies.aspx.cs" Inherits="GroupCourseWork.View.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <span class="mainheading">View DVD Copy</span>
    <div style="display:flex; width: full; height: 8vw; position:relative;">
            <img src="https://image.tmdb.org/t/p/original/zzXFM4FKDG7l1ufrAkwQYv2xvnh.jpg" alt="poster" style="width:100%; object-fit:cover; border-radius: 20px;" />
            <div style="position:absolute; top: 25%; left: 30%; "><span style="font-weight: 900; font-size: 2.8vw;  display:block; text-shadow: 1px 4px 20px black;color: #ffffff;" >Search for movie copies</span></div>
        </div>

    <form id="form1" runat="server" style="display:flex; justify-content: center; align-content: center; align-items:center; margin: 20px auto;">
        <asp:TextBox ID="Search" class="input"  runat="server" placeholder="Search By LastName" style="background-color:white; margin-bottom: 0px; width: 50%;"></asp:TextBox>
        <asp:Button ID="Button1" class="formbutton"  runat="server" OnClick="Button1_Click" Text="Search Copies" />
    </form>
        <asp:label id="MessageLabelCopies" runat="server" style=" color: red;  display: flex;justify-content: center; align-items: center; margin: -15px 0px 15px;"/>
    
    <div><asp:Panel ID="Panel1" runat="server"></asp:Panel></div>
    <style>
        #copiesID{
            background-color: #d4dbef;
        }
    </style>
</asp:Content>

