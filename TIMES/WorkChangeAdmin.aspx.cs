using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class WorkChangeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Work work = (Work)Session["Work"];

            lblIntime.Text = Convert.ToString(work.InTime.ToString("yyyy年  MM月  dd日  HH時  mm分"));
            lblOuttime.Text = Convert.ToString(work.OutTime.ToString("yyyy年 MM月  dd日  HH時  mm分"));

            UserInfo user = (UserInfo)Session["User"];

            lblName.Text = user.UserName;

            if (work.WorkStatus == 0)
            {
                lblStatus.Text = "正常";
            }
            else if (work.WorkStatus == 1)
            {
                lblStatus.Text = "早退";
            }
            else if (work.WorkStatus == 2)
            {
                lblStatus.Text = "有給";
            }

        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("WorkAdmin.aspx");
        }


        protected void btnOk_Click(object sender, EventArgs e)
        {
            Work work = (Work)Session["Work"];
            WorkTable wt = new WorkTable();

            work.InTime = Convert.ToDateTime(work.InTime.Year + "-" + work.InTime.Month + "-" + work.InTime.Day + " " + txtInHour.Text + ":" + txtInMinute.Text);
            work.OutTime = Convert.ToDateTime(work.OutTime.Year + "-" + work.OutTime.Month + "-" + work.OutTime.Day + " " + txtOutHour.Text + ":" + txtOutMinute.Text);

            TimeSpan gapTime = work.OutTime - work.InTime;

            work.WorkTime = (gapTime.Hours * 60) + gapTime.Minutes;

            wt.UpdateWork(work);

            Session["Notice"] = "出勤・退勤時間変更を完了しました。";

            Response.Redirect("NoticeAdmin.aspx");
        }
    }
}