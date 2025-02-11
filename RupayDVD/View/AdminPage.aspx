<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="GroupCourseWork.View.WebForm15" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /*a:nth-last-child(1){
            color: orange
        }*/
    </style>
    <span class="mainheading">Add a new user</span>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" placeholder="UserName"></asp:TextBox><br />
        <asp:TextBox ID="TextBox2" runat="server" placeholder="Password"></asp:TextBox><br />
        <asp:TextBox ID="TextBox3" runat="server" placeholder="User Type"></asp:TextBox><br />
         <asp:Label ID="ErrorAddUser" runat="server" Style="color: red; display: flex; justify-content: start; align-items: center; margin: 10px 0px 5px;" />
         <asp:Label ID="SuccessAddUser" runat="server" Style="color: green; display: flex; justify-content: start; align-items: center; margin: 0px 0px 10px;" />

        <asp:Button ID="Button1" class="formbutton" runat="server" Text="Add User" OnClick="Button1_Click" Style="margin-bottom: 2rem;" />

        <asp:GridView ID="GridView1" runat="server" DataKeyNames="UserNumber" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Sr.No" HeaderText="Sr.No" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="User">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" class="forminput" runat="server" Text='<%# Eval("UserName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Password">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" class="forminput" runat="server" Text='<%# Eval("UserPassword") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("UserPassword") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>


                <asp:TemplateField HeaderText="User Type">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" class="forminput" runat="server" Text='<%# Eval("UserType") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("UserType") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:CommandField CausesValidation="False" HeaderText="Action" ShowDeleteButton="true" ShowEditButton="True" />
            </Columns>
        </asp:GridView>

    </form>

    <style>
        #adminpageID {
            background-color: #d4dbef;
        }
    </style>

</asp:Content>
