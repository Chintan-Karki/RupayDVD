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
    public partial class WebForm5 : System.Web.UI.Page
    {
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
                this.LoadData();
            }
        }

        protected void LoadData(string filter = "")
        {
            DB db = new DB();
            DataTable dt;

            if (string.IsNullOrEmpty(filter))
            {
                dt = db.Get("select dt.DVDTitle,CONCAT(m.MemberFirstName,' ', m.MemberLastName) AS \"Borrower Name\",loan.DateOut,loan.DateDue from [dbo].[DVDTitle] dt join [dbo].[DVDCopy] dc on dt.DVDNumber=dc.DVDNumber "+
"join[dbo].[Loan] loan on loan.CopyNumber = dc.CopyNumber "+
"join[dbo].[Member] m on m.MemberNumber = loan.MemberNumber");
            }
            else
            {
             
               string Query = "select dt.DVDTitle,CONCAT(m.MemberFirstName,' ', m.MemberLastName) AS \"Borrower Name\",loan.DateOut,loan.DateDue from [dbo].[DVDTitle] dt join [dbo].[DVDCopy] dc on dt.DVDNumber=dc.DVDNumber " +
"join[dbo].[Loan] loan on loan.CopyNumber = dc.CopyNumber " +
"join[dbo].[Member] m on m.MemberNumber = loan.MemberNumber WHERE dc.CopyNumber=" + int.Parse(filter);
                dt = db.Get(Query);
            }


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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filter = Search.Text;
            if (!string.IsNullOrEmpty(filter))
            {
                this.LoadData(filter);
                MessageLabelSearchDvd.Text = "";

            }
            else
            {
                MessageLabelSearchDvd.Text = ("Copy Number cannot be empty ! 😐");
                this.LoadData();
                return;
            }
        }
    }
}