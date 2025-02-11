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
    public partial class WebForm11 : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                this.LoadData1();
                this.LoadData();
            }
        }
        protected void LoadData1(string filter = "")
        {


            DataTable dt;


            dt = db.Get("select COUNT(LoanNumber) AS \"Number OF Loan\",dl.DateOut from [dbo].[Loan] dl  WHERE DateReturned IS NULL group by dl.DateOut");


            StringBuilder sb = new StringBuilder();
            sb.Append("<center>");
            sb.Append("<table>");
            sb.Append("<tr>");

            foreach (DataColumn dc in dt.Columns)
            {
                sb.Append("<th>");
                sb.Append(dc.ColumnName.ToUpper());
                sb.Append("</th>");
            }

            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(dr[dc.ColumnName].ToString());
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</center>");
            sb.Append("</table>");

            Panel1.Controls.Add(new Label { Text = sb.ToString() });
        }

        protected void LoadData(string filter = "")
        {


            DataTable dt;


            dt = db.Get("select dt.DVDTitle,dc.CopyNumber,CONCAT(dm.MemberFirstName,' ', dm.MemberLastName) AS \"Member Name\" from [dbo].[DVDTitle] dt " +
                "join [dbo].[DVDCopy] dc on dt.DVDNumber=dc.DVDNumber "
                + "join [dbo].[Loan] dl on dl.CopyNumber=dc.CopyNumber"
                + " join [dbo].[Member] dm on dm.MemberNumber=dl.MemberNumber Order By dt.DVDTitle");

            StringBuilder sb = new StringBuilder();
            sb.Append("<center>");
            sb.Append("<table>");
            sb.Append("<tr>");

            foreach (DataColumn dc in dt.Columns)
            {
                sb.Append("<th>");
                sb.Append(dc.ColumnName.ToUpper());
                sb.Append("</th>");
            }

            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(dr[dc.ColumnName].ToString());
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</center>");
            sb.Append("</table>");

            Panel2.Controls.Add(new Label { Text = sb.ToString() });
        }
    }
}