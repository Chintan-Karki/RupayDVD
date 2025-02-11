<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="GroupCourseWork.signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Master/SignInStyles.css">
    <title></title>
</head>
<body>
    <div class="main">
        <form id="form1" runat="server">
            

            <div style="display: flex; justify-content: center; flex-direction: column; color: #1a074a; margin: 20px auto 10px auto;">

                    <svg style="height: 55px; margin-bottom: 10px;" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                        <path d="M11 17a1 1 0 001.447.894l4-2A1 1 0 0017 15V9.236a1 1 0 00-1.447-.894l-4 2a1 1 0 00-.553.894V17zM15.211 6.276a1 1 0 000-1.788l-4.764-2.382a1 1 0 00-.894 0L4.789 4.488a1 1 0 000 1.788l4.764 2.382a1 1 0 00.894 0l4.764-2.382zM4.447 8.342A1 1 0 003 9.236V15a1 1 0 00.553.894l4 2A1 1 0 009 17v-5.764a1 1 0 00-.553-.894l-4-2z" />
                    </svg>
                <div style="margin: 0px auto;">
                    <span style="font-weight: 700; font-size: 20px; ">Ropey DVDs</span>

                </div>
            </div>
            <div class="sign" align="center">Sign in to your account</div>
            <div>
                <asp:TextBox ID="Username" class="un" runat="server" placeholder="User name" style="font-family: 'Poppins', sans-serif; font-style:normal;"></asp:TextBox>
            </div>
            <div>
                <asp:TextBox ID="Password" class="pass" runat="server" placeholder="Password" type="password"  style="font-family: 'Poppins', sans-serif; font-style:normal;"></asp:TextBox>
            </div>
            <asp:label id="MessageLabel" runat="server" style=" color: red;  display: flex;justify-content: center; align-items: center;"/>
            <asp:Button ID="SigninButton" class="submit" runat="server" Text="Sign in" OnClick="SigninButton_Click" style="margin-top: 20px;" />

        </form>
    </div>

</body>
</html>
