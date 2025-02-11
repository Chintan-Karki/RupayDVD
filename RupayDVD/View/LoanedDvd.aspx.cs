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
    public partial class WebForm8 : System.Web.UI.Page
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
            DataTable dt,dttr;
            
            
           dt = db.Get("select distinct m.MemberNumber,CONCAT(m.MemberFirstName, ' ', m.MemberLastName) As name, m.MemberDOB,mc.MembershipCategoryDescription, mc.MembershipCategoryTotalLoans from [dbo].[Member] m join [dbo].[MembershipCategory] mc on mc.MembershipCategoryNumber=m.MembershipCategoryNumber join [dbo].[Loan] l on l.MemberNumber=m.MemberNumber");
            


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
            sb.Append("<th>");
            sb.Append("Total Loans");
            sb.Append("</th>");

            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                dttr = db.Get("select COUNT(l.LoanNumber) AS \"Count\" from [dbo].[Loan] l WHERE l.MemberNumber=1");

                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<td>");
                    sb.Append(dr[dc.ColumnName].ToString());
                    sb.Append("</td>");
                }

                sb.Append("<td>");
                    if(Convert.ToInt32(dttr.Rows[0]["Count"].ToString()) > Convert.ToUInt32(dr["MembershipCategoryTotalLoans"].ToString()))
                {
                    sb.Append("Too Many DVD on Loan");
                }
                else
                {
                    sb.Append(dttr.Rows[0]["Count"].ToString());
                }
                    
                sb.Append("</td>");


                sb.Append("</tr>");
            }
            sb.Append("</center>");
            sb.Append("</table>");
            Panel1.Controls.Add(new Label { Text = sb.ToString() });
        }

    }
}