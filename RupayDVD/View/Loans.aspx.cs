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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (GroupCourseWork.User.IsLoggedIn() == false)
            {
                Response.Redirect("signin.aspx");
            }

            if(GroupCourseWork.User.LoggedInUserType() == "user")
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
            int memberNumber;
            string data = "m.MemberLastName='" + filter + "'";
            DB db = new DB();
            DataTable dt;
            string DueDate = DateTime.Now.AddDays(-31).ToString("dd.MM.yy");

            if (string.IsNullOrEmpty(filter))
            {
                dt = db.Get("select dt.DVDTitle, l.CopyNumber from[dbo].[Loan] l join[dbo].[DVDCopy] dc on dc.CopyNumber = l.CopyNumber join[dbo].[DVDTitle] dt on dt.DVDNumber = dc.DVDNumber WHERE l.DateOut >= DATEADD(DAY, -31, GETDATE())");
            }
            else
            {
                if(int.TryParse(filter, out memberNumber))
                {
                    data = "m.MemberNumber=" + memberNumber;
                }

                string Query = "select dt.DVDTitle,l.CopyNumber from[dbo].[Loan] l join[dbo].[DVDCopy] dc on dc.CopyNumber = l.CopyNumber join[dbo].[DVDTitle] dt on dt.DVDNumber = dc.DVDNumber" +
                    "  join [dbo].[Member] m on l.MemberNumber=m.MemberNumber WHERE " + data + " AND l.DateOut >= DATEADD(DAY, -31, GETDATE())";
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
                MessageLabelLoans.Text = "";

            }
            else
            {
                MessageLabelLoans.Text = ("Member's LastName is Required 🙂");
                this.LoadData();
                return;
            }
        }
    }
}