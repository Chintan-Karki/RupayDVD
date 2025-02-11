using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using static GroupCourseWork.Models.DatabaseController;

namespace GroupCourseWork.View
{
    public partial class WebForm6 : System.Web.UI.Page
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
                LoanType.DataSource = db.AddToDropDown("select * from [dbo].[LoanType]");
                LoanType.DataTextField = "LoanType";
                LoanType.DataValueField = "LoanTypeNumber";
                LoanType.DataBind();
            }
        }

        public int get_age(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            return age;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int memberid;
            int copyid;
            int loanTypeID;
            int age = 1;

            if (!int.TryParse(MemberId.Text, out memberid))
            {
                SuccessIssueMessage.Text = "";
                ErrorIssueMessage.Text = ("Member id is not int 😐");
            }

            else if (!int.TryParse(DVDCopyNumber.Text, out copyid))
            {
                SuccessIssueMessage.Text = "";

                ErrorIssueMessage.Text = ("Copy Number id is not int 😐");
            }

            else
            {
                string value = LoanType.SelectedValue;
                if (!int.TryParse(value, out loanTypeID))
                {
                    ErrorIssueMessage.Text = ("Loan id is not int 🤨");
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt = db.Get("select * from [dbo].[LoanType]");
                    if (dt.Rows.Count > 0)
                    {

                        DataTable member = new DataTable();

                        member = db.Get("select * from [dbo].[Member]");

                        if (member.Rows.Count > 0)
                        {
                            DateTime date = Convert.ToDateTime(member.Rows[0]["MemberDOB"].ToString());
                            age = this.get_age(date);
                        }


                        DataTable agerestricted = new DataTable();
                        agerestricted = db.Get("select dcat.AgeRestrited from [dbo].[DVDCopy] dcopy" +
                                        " join[dbo].[DVDTitle] dt on dcopy.DVDNumber = dt.DVDNumber" +
                                        " join[dbo].[DVDCategory] dcat on dcat.CategoryNumber = dt.CategoryNumber WHERE" +
                                        " dcopy.CopyNumber = " + copyid);

                        if (Convert.ToInt32(agerestricted.Rows[0]["AgeRestrited"]) > 0 && age < 18)
                        {
                            ErrorIssueMessage.Text = ("Sorry! This DVD is age restricted 😎");
                            SuccessIssueMessage.Text = "";
                        }
                        else
                        {
                            DataTable checkLoanLimit = new DataTable();
                            checkLoanLimit = db.Get("select mc.MembershipCategoryTotalLoans from [dbo].[Member] m join [dbo].[MembershipCategory] mc on m.MembershipCategoryNumber=mc.MembershipCategoryNumber WHERE m.MemberNumber=" + memberid);
                            DataTable checkLoanCount = new DataTable();
                            checkLoanCount = db.Get("select COUNT(LoanNumber) as Cnt from [dbo].[Loan] WHERE MemberNumber=" + memberid);

                            if (Convert.ToInt32(checkLoanCount.Rows[0]["Cnt"].ToString()) >= Convert.ToInt32(checkLoanLimit.Rows[0]["MembershipCategoryTotalLoans"].ToString()))
                            {
                                ErrorIssueMessage.Text = ("Loan Limit reached 😐");
                                SuccessIssueMessage.Text = "";
                            }
                            else
                            {
                                int duration = int.Parse(dt.Rows[0]["LoanDuration"].ToString());
                                string DueDate = DateTime.Now.AddDays(duration).ToString();
                                DateTime dateTime = DateTime.UtcNow.Date;
                                db.ExecuteSqlQuery("insert into [dbo].[Loan] (LoanTypeNumber,MemberNumber,DateOut,DateDue,DateReturned,CopyNumber) Values" +
                                    "(" + loanTypeID + "," + memberid + ",'" + dateTime + "','" + DueDate + "',NULL," + copyid + ")"
                               );
                                MemberId.Text = "";
                                DVDCopyNumber.Text = "";
                                SuccessIssueMessage.Text = ("Loan Success ✅");
                                ErrorIssueMessage.Text = "";
                            }
                        }
                    }
                }
            }
        }
    }
}