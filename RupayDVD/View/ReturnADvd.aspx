<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="ReturnADvd.aspx.cs" Inherits="GroupCourseWork.View.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <span class="mainheading">Return a DVD </span>

    <form id="form1" runat="server">
    <span>Return DVD</span>
    <div>
        <asp:TextBox ID="TextBox1" runat="server" class="input"  placeholder="Loan Number"> </asp:TextBox>
        <asp:Button ID="Button3" runat="server" Class="formbutton" Text="Get Price To Pay" OnClick="Button3_Click" />
        </div>
       <asp:Label ID="ErrorReturnDVD" runat="server" Style="color: red; display: flex; justify-content: start; align-items: center; margin: 0px 0px 10px;" />

    <p style="color: black; opacity: 0.9;">
        <asp:Label ID="Label1" runat="server" Text="" style="font-weight: 500; font-size: 1.5rem; font-style: bold;"></asp:Label>
        </p>
    <p>
        <asp:Button ID="Button4" runat="server" Class="formbutton" Text="Return DVD" OnClick="Button4_Click" />
       <asp:Label ID="SuccessReturnMessage" runat="server" Style="color: green; display: flex; justify-content: start; align-items: center; margin: 0px 0px 10px;" />


        </p>

    </form>
     <style>
    #returnadvdID{
        background-color: #d4dbef;
    }
</style>

</asp:Content>
