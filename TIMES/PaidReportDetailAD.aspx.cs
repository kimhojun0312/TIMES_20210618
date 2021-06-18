using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class PaidReportDetailAD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Paid paid = (Paid)Session["Paid"];
            UserInfo user = new UserInfo();
            user.UserNo = paid.UserNo;
            UserInfoTable ut = new UserInfoTable();

            user = ut.SearchUserNo(user);
            Session["User"] = user;

            lblName.Text = "社員名 : " + user.UserName;
            lblWantDay.Text = "有給希望日 : " + Convert.ToString(paid.WantDay.Year + "年" + paid.WantDay.Month + "月" + paid.WantDay.Day + "日");
            lblTitle.Text = "タイトル : " + paid.Title;
            txtComment.Text = paid.Comment;

            if(paid.Status == 1 || paid.Status == 2)
            {
                
                btnOK.Visible = false;
                btnNG.Visible = false;
                txtAdminComment.ReadOnly = true;
                txtAdminComment.Text = paid.AdminComment;
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Paid paid = (Paid)Session["Paid"];
            PaidTable pt = new PaidTable();

            paid.AdminComment = txtAdminComment.Text;
            paid.Status = 1;

            pt.Update(paid);

            UserInfo user = (UserInfo)Session["User"];
            Work work = new Work();
            WorkTable wt = new WorkTable();

            work.UserNo = user.UserNo;
            work.InTime =  Convert.ToDateTime(paid.WantDay.Year + "-" + paid.WantDay.Month + "-" + paid.WantDay.Day + " 09:00:00");
            work.OutTime = Convert.ToDateTime(paid.WantDay.Year + "-" + paid.WantDay.Month + "-" + paid.WantDay.Day + " 18:00:00");
            work.WorkTime = 480;

            wt.InsertPaid(work);

            Session["Notice"] = "有給申請を承認しました。";

            Response.Redirect("NoticeAdmin.aspx");
        }

        protected void btnNG_Click(object sender, EventArgs e)
        {
            Paid paid = (Paid)Session["Paid"];
            PaidTable pt = new PaidTable();

            paid.AdminComment = txtAdminComment.Text;
            paid.Status = 2;

            pt.Update(paid);

            Session["Notice"] = "有給申請を拒否しました。";

            Response.Redirect("NoticeAdmin.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("ReportAdmin.aspx");
        }
    }
}