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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(GroupCourseWork.User.IsLoggedIn() == false)
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
            
            dt = db.Get("select dt.DVDTitle,p.ProducerName,s.StudioName,CONCAT(a.ActorFirstName, ' ',a.ActorSurname) AS \"Cast Member\",dt.DateReleased from [dbo].[DVDTitle] dt join [dbo].[Producer] p on dt.ProducerNumber=p.ProducerNumber join [dbo].[Studio] s on s.StudioNumber=dt.StudioNumber join [dbo].[CastMember] cm on dt.DVDNumber=cm.DVDNumber join [dbo].[Actor] a on a.ActorNumber=cm.ActorNumber Order By dt.DateReleased, a.ActorSurname");
            
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