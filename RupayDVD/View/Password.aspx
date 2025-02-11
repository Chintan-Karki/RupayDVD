<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="GroupCourseWork.View.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <span class="mainheading">Change Password</span>
    <form id="form1" runat="server">
        <asp:Label ID="Label1"  runat="server" Text="Change Password"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" style="margin-top:20px;"  class="forminput" runat="server" placeholder="New Password"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2"  class="forminput" runat="server" placeholder="Confirm Password"></asp:TextBox>
        </br>
         <asp:Label ID="ErrorChangePassword" runat="server" Style="color: red; display: flex; justify-content: start; align-items: center; margin: 10px 0px 5px;" />
         <asp:Label ID="SuccessChangePassword" runat="server" Style="color: green; display: flex; justify-content: start; align-items: center; margin: 0px 0px 10px;" />

        <asp:Button ID="Button1" runat="server" class="formbutton" OnClick="Button1_Click" Text="Change Password" />
    </form>
    <style>
    #passwordID{
        background-color: #d4dbef;
    }
</style>

</asp:Content>
