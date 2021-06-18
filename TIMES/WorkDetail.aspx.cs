using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class WorkDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Work work = (Work)Session["Work"];

            WorkTable wt = new WorkTable();
            DateTime gtw = work.InTime;


            work = wt.GetWorkNo(work, gtw);

            Session["Work"] = work;

            lblIntime.Text = Convert.ToString(work.InTime.ToString("yyyy년  MM월  dd일  HH시  mm분"));
            lblOuttime.Text = Convert.ToString(work.OutTime.ToString("yyyy년 MM월  dd일  HH시  mm분"));

            UserInfo user = new UserInfo();
            UserInfoTable ut = new UserInfoTable();

            user.UserNo = work.UserNo;

            user = ut.SearchUserNo(user);

            lblName.Text = user.UserName;

        }


        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("WorkHistory.aspx");
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            Work work = (Work)Session["Work"];
            ChangeReport report = new ChangeReport();
            ChangeReportTable rt = new ChangeReportTable();

            report.UserNo = work.UserNo;
            report.WorkNo = work.WorkNo;
            report.Title = txtTitle.Text;
            report.NewInTime = Convert.ToDateTime(work.InTime.Year + "-" + work.InTime.Month + "-" + work.InTime.Day + " " + txtInHour.Text + ":" + txtInMinute.Text);
            report.NewOutTime = Convert.ToDateTime(work.OutTime.Year + "-" + work.OutTime.Month + "-" + work.OutTime.Day + " " + txtOutHour.Text + ":" + txtOutMinute.Text);
            report.Comment = txtComment.Text;
            report.Status = 0;

            if( Convert.ToInt32(txtInHour.Text) > Convert.ToInt32(txtOutHour.Text))
            {
                lblWarning.Text = "出勤・退勤時間をもう一度確認して下さい。";
            }
            else
            {
                rt.Insert(report);
                Session["Notice"] = "出勤・退勤時間変更申し込みが完了しました。";

                Response.Redirect("Notice.aspx");
            }

               

            
        }
    }
}