<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="IssueADvd.aspx.cs" Inherits="GroupCourseWork.View.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <span class="mainheading">Issue a DVD </span>

        <asp:TextBox ID="MemberId" class="forminput" runat="server" placeholder="Member ID"></asp:TextBox>
        <br />
        <asp:TextBox ID="DVDCopyNumber" class="forminput" runat="server" placeholder="DVD Copy Number"></asp:TextBox>
        <br />
        <asp:DropDownList ID="LoanType" class="dropdownCss" runat="server">
        </asp:DropDownList>
        <br />

        <asp:Label ID="SuccessIssueMessage" runat="server" Style="color: green; display: flex; justify-content: start; align-items: center; margin: 0px 0px 10px;" />
        
        <asp:Label ID="ErrorIssueMessage" runat="server" Style="color: red; display: flex; justify-content: start; align-items: center; margin: 0px 0px 10px;" />

        <asp:Button ID="Button1" runat="server" Text="Issue DVD" class="formbutton" OnClick="Button1_Click" Width="119px" />
    </form>
    <style>
        #issueadvdID {
            background-color: #d4dbef;
        }
    </style>
</asp:Content>
