<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="AddADvd.aspx.cs" Inherits="GroupCourseWork.View.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <span class="mainheading">Add a DVD title</span>

    <form id="form1" runat="server" style="margin: 30px auto">
        <p>Movie Details</p>  
         <div style="display: flex; flex-direction: row; flex-wrap: wrap; margin-bottom:14px;">
            <div style="margin-right: 20px;">
                <asp:TextBox ID="TextBox1" class="forminput" runat="server" placeholder="Title"></asp:TextBox>

            </div>
            <div >
                <asp:TextBox ID="TextBox2" class="forminput" runat="server" placeholder="Date Released"></asp:TextBox>
            </div>
        </div>
        <p>Charges</p>
        <div style="display: flex; flex-direction: row; flex-wrap: wrap; margin-bottom:14px;">
            <div style="margin-right: 20px;">
               <asp:TextBox ID="TextBox4" class="forminput" runat="server" placeholder="Standard Charge"></asp:TextBox>

            </div>
            <div>
                 <asp:TextBox ID="TextBox5" class="forminput" runat="server" placeholder="Penalty Charge"></asp:TextBox>
            </div>
        </div>

        <p>Select Category</p>
        <asp:DropDownList ID="DropDownList1" class="dropdownCss" runat="server">
        </asp:DropDownList>
        <br />
        <br />

        <div style="display: flex; flex-direction: row; flex-wrap: wrap;">
            <div>
                <p>Select Producer</p>
                <asp:DropDownList ID="DropDownList2" class="dropdownCss" runat="server">
                </asp:DropDownList>

            </div>
            <div style="margin-top: 4px; margin-left: 20px;">
                <span style="font-size: 13px; color: grey;">or you can also add one of your own</span><br />
                <asp:TextBox ID="TextBox6" class="forminput" runat="server" placeholder="Producer Name" style="border: 2px solid #a9cff8"></asp:TextBox>
            </div>
        </div>
        <br />
        <div style="display: flex; flex-direction: row; flex-wrap: wrap;">
            <div>
                <p>Select Studio</p>
                <asp:DropDownList ID="DropDownList3" class="dropdownCss" runat="server">
                </asp:DropDownList>

            </div>
            <div style="margin-top: 4px; margin-left: 20px;">
                <span style="font-size: 13px; color: grey;">or you can also add one of your own</span><br />
                <asp:TextBox ID="TextBox7" runat="server" class="forminput" placeholder="Studio Name" style="border: 2px solid #a9cff8"></asp:TextBox>
            </div>
        </div>
        <br />
        <div style="display: flex; flex-direction: row; flex-wrap: wrap;">
            <div>
                <p>Select Actor</p>
                <asp:DropDownList ID="DropDownList4" class="dropdownCss" runat="server">
                </asp:DropDownList>

            </div>
            <div style="margin-top: 4px; margin-left: 20px;">
                <span style="font-size: 13px; color: grey;">or you can also add one of your own</span><br />
                <asp:TextBox ID="TextBox8" class="forminput" runat="server" placeholder="Actor Name" style="border: 2px solid #a9cff8"></asp:TextBox>
            </div>
        </div>
       <asp:Label ID="ErrorAddADVD" runat="server" Style="color: red; display: flex; justify-content: start; align-items: center; margin: 10px 0px 5px;" />
       <asp:Label ID="SuccessAddADVD" runat="server" Style="color: green; display: flex; justify-content: start; align-items: center; margin: 0px 0px 10px;" />

                <asp:Button ID="Button1" runat="server" Text="ADD DVD" class="formbutton" style="width:350px;" OnClick="Button1_Click" />

        

    </form>
    <style>
    #addadvdID{
        background-color: #d4dbef;
    }
</style>
</asp:Content>
