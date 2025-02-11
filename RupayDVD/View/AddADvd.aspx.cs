using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using static GroupCourseWork.Models.DatabaseController;

namespace GroupCourseWork.View
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        DB db = new DB();
        protected void jpt()
        {
            DropDownList1.DataSource = db.AddToDropDown("select * from [dbo].[DVDCategory]");
            DropDownList1.DataTextField = "CategoryDescription";
            DropDownList1.DataValueField = "CategoryNumber";
            DropDownList1.DataBind();

            DropDownList2.DataSource = db.AddToDropDown("select * from [dbo].[Producer]");
            DropDownList2.DataTextField = "ProducerName";
            DropDownList2.DataValueField = "ProducerNumber";
            DropDownList2.DataBind();

            DropDownList3.DataSource = db.AddToDropDown("select * from [dbo].[Studio]");
            DropDownList3.DataTextField = "StudioName";
            DropDownList3.DataValueField = "StudioNumber";
            DropDownList3.DataBind();

            DropDownList4.DataSource = db.AddToDropDown("select * from [dbo].[Actor]");
            DropDownList4.DataTextField = "ActorFirstName";
            DropDownList4.DataValueField = "ActorNumber";
            DropDownList4.DataBind();
        }
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
            if (!IsPostBack)
            {
                this.jpt();
            }
        }

        protected bool checkExistence(string param)
        {
            DataTable prdcer = new DataTable();
            prdcer = db.Get(param);
            if (prdcer.Rows.Count > 0)
            {
                return true;
            }
            return false;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string title;
            int standardCharge, penalty;
            DateTime dateReleased;

            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                ErrorAddADVD.Text = ("Oops!!! DVD Title is required 😐");
                TextBox1.Focus();
            }
            else if (string.IsNullOrEmpty(TextBox2.Text))
            {
                ErrorAddADVD.Text = ("Oops!!! DVD Released Date is required 😐");
                TextBox2.Focus();
            }
            else if (string.IsNullOrEmpty(TextBox4.Text))
            {
                ErrorAddADVD.Text = ("Oops!!! DVD standard Charge is required 😐");
                TextBox4.Focus();
            }
            else if (string.IsNullOrEmpty(TextBox5.Text))
            {
                ErrorAddADVD.Text = ("Oops!!! DVD Penalty Charge is required 😐");
                TextBox5.Focus();
            }
            else if (!DateTime.TryParse(TextBox2.Text, out dateReleased))
            {
                ErrorAddADVD.Text = ("Oops!!! Invalid release date 😐");
                TextBox2.Focus();
            }
            else if (!int.TryParse(TextBox4.Text, out standardCharge))
            {
                ErrorAddADVD.Text = ("Oops!!! Standard charge is not a number 😐");
                TextBox4.Focus();
            }
            else if (!int.TryParse(TextBox5.Text, out penalty))
            {
                ErrorAddADVD.Text = ("Oops!!! Penalty Charge is not a number 😐");
                TextBox5.Focus();
            }
            else if (!string.IsNullOrEmpty(TextBox6.Text) && checkExistence("select * from [dbo].[Producer] WHERE ProducerName='" + TextBox6.Text + "'") == true)
            {
                ErrorAddADVD.Text = ("Oops!!! Producer Name Already Exists 😐");
                TextBox6.Focus();
            }
            else if (!string.IsNullOrEmpty(TextBox7.Text) && checkExistence("select * from [dbo].[Studio] WHERE StudioName='" + TextBox7.Text + "'") == true)
            {

                ErrorAddADVD.Text = ("Oops!!! Studio Name Already Exists 😐");
                TextBox7.Focus();
            }
            else if (!string.IsNullOrEmpty(TextBox8.Text) && checkExistence("select * from [dbo].[Actor] WHERE ActorFirstName='" + TextBox8.Text + "'") == true)
            {

                ErrorAddADVD.Text = ("Oops!!! Actor Name Already Exists 😐");
                TextBox8.Focus();
            }
            else
            {
                int producerId, studioId, actorId;
                if (string.IsNullOrEmpty(TextBox6.Text))
                {
                    producerId = int.Parse(DropDownList2.SelectedValue);
                }
                else
                {
                    string name = TextBox6.Text;
                    producerId = db.InsertedID("insert into [dbo].[Producer] (ProducerName) values('"+name+"') SELECT SCOPE_IDENTITY()");
                }


                if (string.IsNullOrEmpty(TextBox7.Text))
                {
                    studioId = int.Parse(DropDownList3.SelectedValue);
                }
                else
                {
                    studioId = db.InsertedID("insert into [dbo].[Studio] (StudioName) values('" + TextBox7.Text + "') SELECT SCOPE_IDENTITY()");
                }

                if (string.IsNullOrEmpty(TextBox8.Text))
                {
                    actorId = int.Parse(DropDownList4.SelectedValue);
                }
                else
                {
                    actorId= db.InsertedID("insert into [dbo].[Actor] (ActorFirstName,ActorSurname) values('" + TextBox8.Text + "','" + TextBox8.Text + "') SELECT SCOPE_IDENTITY()");
                }

                title = TextBox1.Text;
                int categoryId = int.Parse(DropDownList1.SelectedValue);
                
                

                int dvdNumber = db.InsertedID("insert into [dbo].[DVDTitle] (ProducerNumber,CategoryNumber,StudioNumber,DateReleased,StandardCharge,PenaltyCharge,DVDTitle) " +
                    "values("+producerId+","+categoryId+","+studioId+",'"+dateReleased+"',"+standardCharge+","+penalty+",'"+title+ "') SELECT SCOPE_IDENTITY()");

              
               db.ExecuteSqlQuery("insert into [dbo].[CastMember] (DVDNumber,ActorNumber) values("+dvdNumber+","+actorId+")");

                ErrorAddADVD.Text = "";
                SuccessAddADVD.Text = ("Congratulations! DVD Added Success ✅");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                this.jpt();
            }
        }
    }
}