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
    public partial class WebForm12 : System.Web.UI.Page
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
            }
        }
        protected void LoadData1(string filter = "")
        {


            DataTable dt;


            dt = db.Get("select distinct dl.MemberNumber,dt.DVDTitle,CONCAT(dm.MemberFirstName,' ',dm.MemberLastName) AS \"Member Name\",dm.MemberAddress, ABS(DATEDIFF(day,GETDATE(), dl.DateOut)) AS days from [dbo].[Loan] dl"+
" join[dbo].[Member] dm on dm.MemberNumber = dl.MemberNumber"+
" join[dbo].[DVDCopy] dc on dc.CopyNumber = dl.CopyNumber"+
" join[dbo].[DVDTitle] dt on dt.DVDNumber = dc.DVDNumber"+
" WHERE dl.DateOut <= DATEADD(day, -31, GETDATE())");


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
    }
}