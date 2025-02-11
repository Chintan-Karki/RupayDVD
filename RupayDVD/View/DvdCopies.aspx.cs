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
    public partial class WebForm2 : System.Web.UI.Page
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
                string Query =
                    "select dt.DVDTitle, COUNT(dt.DVDNumber) AS dvdCopynumber from [dbo].[DVDTitle] dt join DVDCopy dc on dt.DVDNumber=dc.DVDNumber join [dbo].[CastMember] cm" +
                    " on cm.DVDNumber=dt.DVDNumber join [dbo].[Actor] ac on ac.ActorNumber=cm.ActorNumber WHERE dc.CopyNumber NOT IN (select CopyNumber from [dbo].[Loan] WHERE DateReturned IS NULL) GROUP BY dt.DVDNUmber,dt.DVDTitle"
                    ;
                dt = db.Get(Query);
            }
            else
            {

                string Query =
                    "select dt.DVDTitle, COUNT(dt.DVDNumber) AS dvdCopynumber from [dbo].[DVDTitle] dt join DVDCopy dc on dt.DVDNumber=dc.DVDNumber join [dbo].[CastMember] cm" +
                    " on cm.DVDNumber=dt.DVDNumber join [dbo].[Actor] ac on ac.ActorNumber=cm.ActorNumber where ac.ActorSurname='"+filter+ "' AND dc.CopyNumber NOT IN (select CopyNumber from [dbo].[Loan] WHERE DateReturned IS NULL) GROUP BY dt.DVDNUmber,dt.DVDTitle"
                    ;
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
            Panel pnl = new Panel();
            
            Panel1.Controls.Add(new Label { Text = sb.ToString() });
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filter = Search.Text;
            if (!string.IsNullOrEmpty(filter))
            {
                this.LoadData(filter);
                MessageLabelCopies.Text = "";

            }
            else
            {
                MessageLabelCopies.Text = ("Actors LastName is Required 🙂");
                this.LoadData();
                return;
            }
        }
    }
}