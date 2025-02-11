using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GroupCourseWork.Models.DatabaseController;


namespace GroupCourseWork.View
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GroupCourseWork.User.IsLoggedIn() == false)
            {
                Response.Redirect("signin.aspx");
            }

            if (GroupCourseWork.User.LoggedInUserType() == "user")
            {
                Response.Redirect("signin.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text))
            {
                ErrorChangePassword.Text = ("Both The Password Field Is Required 😐");
                SuccessChangePassword.Text = "";
            }
            else if (TextBox1.Text != TextBox2.Text)
            {
                ErrorChangePassword.Text = ("Confirm Password Doesnot Match New Password 🤨");
                SuccessChangePassword.Text = "";

            }
            else
            {
                if(GroupCourseWork.User.LoggedInUserId() >0)
                {
                    db.ExecuteSqlQuery("UPDATE [dbo].[User] SET UserPassword='"+TextBox1.Text+"' WHERE UserNumber=" + GroupCourseWork.User.LoggedInUserId());
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    SuccessChangePassword.Text = ("Your Password Has Been Changed ✅✅");
                    ErrorChangePassword.Text = "";
                }
            }
        }
    }
}