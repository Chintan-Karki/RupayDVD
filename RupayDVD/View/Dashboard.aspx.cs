using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using static GroupCourseWork.Models.DatabaseController;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupCourseWork.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
                dt = db.Get("select DVDTitle, DateReleased from [dbo].[DVDTitle]");
            }
            else
            {

                string Query = "select dt.DVDTitle from [dbo].[Actor] ac inner join [dbo].[CastMember] cM ON ac.ActorNumber=cM.ActorNumber " +
                    "join [dbo].[DVDTitle] dt ON cM.DVDNumber=dt.DVDNumber WHERE ac.ActorSurname='" + filter + "'";
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
                MessageLabelDashboard.Text = "";

            }
            else
            {
                MessageLabelDashboard.Text = "Actors LastName is Required 😐";
                
                this.LoadData();
                return;
            }
        }
    }
}