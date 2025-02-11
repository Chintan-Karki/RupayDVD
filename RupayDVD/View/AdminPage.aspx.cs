using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using static GroupCourseWork.Models.DatabaseController;

namespace GroupCourseWork.View
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GroupCourseWork.User.IsLoggedIn() == false)
            {
                Response.Redirect("signin.aspx");
            }

            if (GroupCourseWork.User.LoggedInUserType() == "manager")
            {
                
            }
            else
            {
                Response.Redirect("signin.aspx");
            }

            if (!IsPostBack)
            {
                this.GetUser();
            }
        }

        protected void GetUser()
        {
            DataTable dt = db.Get("select ROW_NUMBER() over(Order by (select 1)) as [Sr.No],UserNumber,UserName,UserPassword, UserType from [dbo].[User]"); 
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = db.Get("SELECT * FROM [dbo].[User] WHERE UserName='" + TextBox1.Text + "'");
            if (dt.Rows.Count > 0)
            {
                ErrorAddUser.Text = ("Username with user exists 😐");
            }
            else if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text) || string.IsNullOrEmpty(TextBox3.Text))
            {
                ErrorAddUser.Text = ("All Fields Are Required 🙂");
            }
            else
            {
                if (TextBox3.Text == "user" || TextBox3.Text == "assistant" || TextBox3.Text == "manager")
                {
                    db.ExecuteSqlQuery("insert into [dbo].[User] (UserName,UserPassword,UserType) Values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "')");
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    SuccessAddUser.Text = ("New User added ✅");
                    ErrorAddUser.Text = "";
                    this.GetUser();

                }
                else
                {
                    ErrorAddUser.Text = ("Oops! Only 'manager', 'user' and 'assistant' user-types are supported 🙂");
                    SuccessAddUser.Text = "";
                }
            }
        }

            protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                GridView1.PageIndex = e.NewPageIndex;
                this.GetUser();
            }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetUser();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex= e.NewEditIndex;
            this.GetUser();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int uid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string UserName = (row.FindControl("TextBox4") as TextBox).Text;
            string UserPassword = (row.FindControl("TextBox5") as TextBox).Text;
            string UserType = (row.FindControl("TextBox6") as TextBox).Text;
            db.ExecuteSqlQuery("UPDATE [dbo].[User] SET UserName='" + UserName + "', UserPassword='"+UserPassword+"', UserType='"+UserType+"' WHERE UserNumber=" + uid);
            GridView1.EditIndex = -1;
            this.GetUser();
            SuccessAddUser.Text = ("User Updated ✅✅");
            ErrorAddUser.Text = "";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int uid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            db.ExecuteSqlQuery("delete from [dbo].[User] WHERE UserNumber=" + uid);
            GridView1.EditIndex = -1;
            this.GetUser();
            SuccessAddUser.Text = ("User Updated ✅✅");
            ErrorAddUser.Text = "";
        }
    }
}