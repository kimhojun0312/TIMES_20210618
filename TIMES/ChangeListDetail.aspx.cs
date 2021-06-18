using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class ChangeListDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChangeReport report = (ChangeReport)Session["ChangeReport"];

            lblUserNo.Text = Convert.ToString(report.UserNo);
            lblTitle.Text = report.Title;
            lblComment.Text = report.Comment;
            txtComment.Text = report.AdminComment;

            UserInfo user = (UserInfo)Session["User"];
            lblUserName.Text = user.UserName;

            if(report.Status == 0)
            {
                lblStatus.Text = "処理中";
            }
            else if(report.Status == 1)
            {
                lblStatus.Text = "処理完了";
            }
            else
            {
                lblStatus.Text = "拒否";
            }

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home.aspx");
        }
    }
}