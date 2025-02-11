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
    public partial class WebForm7 : System.Web.UI.Page
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
                
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int loanNumber, payable = 0;
            if(!int.TryParse(TextBox1.Text,out loanNumber))
            {
                ErrorReturnDVD.Text = ("Invalid loan number 🤨");
            }
            else
            {
                
                DataTable dt = new DataTable();
                dt = db.Get("SELECT dt.StandardCharge, l.LoanNumber, dt.PenaltyCharge, l.DateOut, l.DateDue FROM[dbo].[Loan] l JOIN[dbo].[DVDCopy] dc on l.CopyNumber = dc.CopyNumber JOIN[dbo].[DVDTitle] dt on dt.DVDNumber = dc.DVDNumber WHERE l.LoanNumber = " + loanNumber);
                if(dt.Rows.Count < 1)
                {
                    ErrorReturnDVD.Text = ("NO LOAN FOUND");
                }
                else
                {
                    DateTime dateDue = Convert.ToDateTime(dt.Rows[0]["DateDue"].ToString());
                    DateTime dateOut = Convert.ToDateTime(dt.Rows[0]["DateOut"].ToString());

                    if(dateDue > dateOut)
                    {
                        int daysToCharge     = Convert.ToInt32((dateDue - dateOut).TotalDays);
                        int totalChargeToPay = daysToCharge * Convert.ToInt32(dt.Rows[0]["PenaltyCharge"].ToString());
                        ErrorReturnDVD.Text = ("");

                        Label1.Text = "Price To Pay: NPR." + totalChargeToPay.ToString();
                        payable = totalChargeToPay;
                    }
                    else
                    {
                        Label1.Text = "Price To Pay: NPR." + Convert.ToInt32(dt.Rows[0]["StandardCharge"].ToString());
                        payable = Convert.ToInt32(dt.Rows[0]["StandardCharge"].ToString());
                    }
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now.Date;
            int loanNumber, payable = 0;
            if (!int.TryParse(TextBox1.Text, out loanNumber))
            {
                ErrorReturnDVD.Text = ("Invalid loanNumber 🤨");
            }
            else
            {
                db.ExecuteSqlQuery("UPDATE [dbo].[Loan] SET DateReturned='"+currentTime+"' WHERE LoanNumber=" + loanNumber);
                TextBox1.Text = "";
                Label1.Text = "";
                SuccessReturnMessage.Text = ("Loan Cleared ✅");
            }
        }
    }
}