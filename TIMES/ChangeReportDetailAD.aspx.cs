using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class ChangeReportDetailAD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ChangeReport report = (ChangeReport)Session["ChangeReport"];
            Work work = (Work)Session["Work"];

            lblReportNo.Text = "申請書番号 : " + Convert.ToString(report.ChangeReportNo);
            lblUserNo.Text = "社員番号 : " + Convert.ToString(report.UserNo);
            lblTitle.Text = "タイトル : " + report.Title;
            lblIntime.Text = "出勤時間(変更前) : " + Convert.ToString(work.InTime);
            lblOutTime.Text = "退勤時間(変更前) : " + Convert.ToString(work.OutTime);
            lblNewIntime.Text = "出勤時間(変更希望) : " + Convert.ToString(report.NewInTime);
            lblNewOutTime.Text = "退勤時間(変更希望) : " + Convert.ToString(report.NewOutTime);
            lblComment.Text = "希望理由 : " + report.Comment;

            UserInfo user = new UserInfo();
            UserInfoTable ut = new UserInfoTable();

            user.UserNo = report.UserNo;

            user = ut.SearchUserNo(user);

            lblUserName.Text = "社員名 : " + user.UserName;

            if(report.Status == 1 || report.Status == 2)
            {
                lblIntime.Visible = false;
                lblOutTime.Visible = false;

                btnOk.Visible = false;
                btnNo.Visible = false;

                txtComment.ReadOnly = true;
                txtComment.Text = "内容 : "+ report.AdminComment;
            }

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            ChangeReport report = (ChangeReport)Session["ChangeReport"];
            ChangeReportTable ct = new ChangeReportTable();

            report.Status = 1;
            report.AdminComment = "管理者のコメント : "　+ txtComment.Text;

            ct.Update(report);

            Work work = (Work)Session["Work"];
            WorkTable wt = new WorkTable();

            work.InTime = report.NewInTime;
            work.OutTime = report.NewOutTime;

            TimeSpan gapTime = work.OutTime - work.InTime;
            work.WorkTime = (gapTime.Hours * 60) + gapTime.Minutes - 60;

            wt.UpdateWork(work);
            Session["Notice"] = "出・退勤時間の変更処理を完了しました。";

            Response.Redirect("NoticeAdmin.aspx");
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {

            ChangeReport report = (ChangeReport)Session["ChangeReport"];
            ChangeReportTable ct = new ChangeReportTable();

            report.Status = 2;
            report.AdminComment = "管理者のコメント : "　+ txtComment.Text;

            ct.Update(report);

            Session["Notice"] = "出・退勤時間の変更処理を完了しました。";

            Response.Redirect("NoticeAdmin.aspx");

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("ReportAdmin.aspx");
        }
    }
}