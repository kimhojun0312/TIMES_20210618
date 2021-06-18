using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class PaidSignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo user = (UserInfo)Session["User"];

            lblName.Text = "申請者 ： " + user.UserName;

            int month = Convert.ToInt32(DateTime.Now.Month);
            int day = Convert.ToInt32(DateTime.Now.Day);

            for (int i = 12; month <= i; month++)
            {
                ddlMonth.Items.Add(Convert.ToString(month));
            }

            if(ddlMonth.SelectedValue == "4")
            {
                for (int i = 31; day <= i; day++)
                {
                    ddlDay.Items.Add(Convert.ToString(day));
                }
            }
            else
            {
                for (int i = 1; i <= 31; i++)
                {
                    ddlDay.Items.Add(Convert.ToString(i));
                }
            }

            

            

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            UserInfo user = (UserInfo)Session["User"];
            Paid paid = new Paid();
            PaidTable pt = new PaidTable();

            paid.UserNo = user.UserNo;
            paid.Title = txtTitle.Text;
            paid.Comment = txtComment.Text;

            int Year = Convert.ToInt32(ddlYear.Text); // 출근년도
            int Month = Convert.ToInt32(ddlMonth.Text); //출근 월
            int Day = Convert.ToInt32(ddlDay.Text); //출근 일자

            paid.WantDay = Convert.ToDateTime(Year + "-" + Month + "-" + Day);

            pt.Insert(paid);

            Session["Notice"] = "有給申請を完了しました。";

            Response.Redirect("Notice.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaidReport.aspx");
        }
    }
}