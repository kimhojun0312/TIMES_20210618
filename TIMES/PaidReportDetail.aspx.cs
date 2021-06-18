using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class PaidReportDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Paid paid = (Paid)Session["Paid"];
            UserInfo user = (UserInfo)Session["User"];

            lblName.Text = "社員名 : " + user.UserName;
            lblWantDay.Text = "有給希望日 : " + Convert.ToString(paid.WantDay.Year + "年" + paid.WantDay.Month + "月" + paid.WantDay.Day + "日");
            lblTitle.Text = "タイトル : " + paid.Title;
            txtComment.Text =  paid.Comment;
            if(paid.Status == 0)
            {
                lblStatus.Text = "処理状況 : 処理中";
            }
            else if(paid.Status == 1)
            {
                lblStatus.Text = "処理状況 : 承認";
            }
            else
            {
                lblStatus.Text = "処理状況 : 拒否";
            }

            txtAdminComment.Text =　 paid.AdminComment;
            
            
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Server.Transfer("PaidReport.aspx");
        }
    }
}