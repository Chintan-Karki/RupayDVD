using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using static GroupCourseWork.Models.DatabaseController;

namespace GroupCourseWork
{
    public partial class signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GroupCourseWork.User.IsLoggedIn() == true)
            {
                Response.Redirect("dashboard.aspx");
            }
        }

        protected void SigninButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            if(string.IsNullOrEmpty(username) == true)
            {
                MessageLabel.Text = "Incorrect Username 😐";
                //Response.Write("");

                return;
            } 
            else if(string.IsNullOrEmpty(password) == true)
            {
                //Response.Write("Incorrect Password");
                MessageLabel.Text = "Incorrect Password 😐";

                return;
            }
            else
            {
                DB db = new DB();
                DataTable dt = db.Get("select * from [dbo].[User] WHERE UserName='"+username+"' AND UserPassword='"+password+"'");
                if (dt.Rows.Count > 0)
                {
                 if(GroupCourseWork.User.CreateLogin( dt.Rows[0]["UserNumber"].ToString(), dt.Rows[0]["UserType"].ToString()) == true)
                   {
                        Response.Redirect("dashboard.aspx");
                   }   
                }
                else
                {
                    //Response.Write("Bad Login");
                    MessageLabel.Text = "Incorrect Username and Password 🙂";

                }
            }
        }
    }
}