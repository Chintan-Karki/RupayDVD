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
    public partial class WebForm10 : System.Web.UI.Page
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
                this.LoadData();
            }
        }

        protected void LoadData(string filter = "")
        {
            
           
            DataTable dt;
            

            dt = db.Get("select DVDTitle,DateReleased from [dbo].[DVDTitle] WHERE DateReleased < dateadd(day,datediff(day,0,getdate())-365,0) AND DVDNumber NOT IN (select dt.DVDNumber from [dbo].[Loan] dl join [dbo].[DVDCopy] dc on dc.CopyNumber=dl.CopyNumber join [dbo].[DVDTitle] dt on dt.DVDNumber=dc.DVDNumber)");


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

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = db.Get("select DVDTitle,DateReleased,DVDNumber from [dbo].[DVDTitle] WHERE DateReleased < dateadd(day,datediff(day,0,getdate())-365,0) AND DVDNumber NOT IN (select dt.DVDNumber from [dbo].[Loan] dl join [dbo].[DVDCopy] dc on dc.CopyNumber=dl.CopyNumber join [dbo].[DVDTitle] dt on dt.DVDNumber=dc.DVDNumber)");
            foreach(DataRow dr in dt.Rows)
            {
                db.ExecuteSqlQuery("DELETE FROM [dbo].[DVDCopy] WHERE DVDNumber=" + Convert.ToInt32(dr["DVDNumber"]));
                db.ExecuteSqlQuery("DELETE FROM [dbo].[CastMember] WHERE DVDNumber=" + Convert.ToInt32(dr["DVDNumber"]));
                db.ExecuteSqlQuery("DELETE FROM [dbo].[DVDTitle] WHERE DVDNumber=" + Convert.ToInt32(dr["DVDNumber"]));
            }

            this.LoadData();
        }
    }
}