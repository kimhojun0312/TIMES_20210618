using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo User = (UserInfo)Session["User"];
            lblName.Text = "ようこそ、" + User.UserName + " 様";
            lblTime.Text = "現在時刻 ： " + DateTime.Now.ToString("yyyy年 MM月 dd日") + "  ";
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Server.Transfer("WorkHistory.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");
        }

        protected void btnInTime_Click(object sender, EventArgs e)
        {
            UserInfo User = new UserInfo();

            User = (UserInfo)Session["User"];

            Work work = new Work();
            WorkTable wt = new WorkTable();

            work.UserNo = User.UserNo;
            work.InTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy년 MM월 dd일 HH 시 mm 분 ss초"));

            DateTime Start = Convert.ToDateTime(work.InTime.Year + "-" + work.InTime.Month + "-" + work.InTime.Day);
            DateTime End = Convert.ToDateTime(work.InTime.Year + "-" + work.InTime.Month + "-" + (Start.Day + 1));

            if(wt.SearchInTime(work,Start,End) == 0)
            {
                wt.Insert(work);

                Session["Notice"] = "出勤登録を完了しました。";

                Response.Redirect("Notice.aspx");
            }
            else
            {
                Session["Notice"] = "出勤登録済みです。";

                Response.Redirect("Notice.aspx");
            }
            



        }

        protected void btnOutTime_Click(object sender, EventArgs e)
        {
            UserInfo User = new UserInfo();

            User = (UserInfo)Session["User"];

            Work work = new Work();
            WorkTable wt = new WorkTable();

            work.UserNo = User.UserNo;

            work.OutTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy년 MM월 dd일 HH 시 mm 분 ss초"));

            work.WorkStatus = 0;

            TimeSpan gapTime = work.OutTime - DateTime.Now;

            work.WorkTime = (gapTime.Hours * 60) + gapTime.Minutes;

            DateTime Start = Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
            DateTime End = Convert.ToDateTime(Start.Year + "-" + Start.Month + "-" + (Start.Day + 1));
            if (wt.SearchOutTime(work, Start, End) == 0)
            {
                if (work.WorkTime >= 480) // 勤務時間が８時間以上だったら
                {
                    work.WorkCheck = 0;
                    wt.Update(work);

                    Session["Notice"] = "退勤登録を完了しました。";
                    Response.Redirect("Notice.aspx");
                }
                else
                {
                    work.WorkCheck = 1;
                    wt.Update(work);

                    Session["Notice"] = "退勤登録を完了しました。";
                    Response.Redirect("Notice.aspx");
                }
            }
            else
            {
                Session["Notice"] = "退勤登録済みです。";

                Response.Redirect("Notice.aspx");
            }

        }

        protected void btnEarly_Click(object sender, EventArgs e)
        {
            UserInfo User = new UserInfo();

            User = (UserInfo)Session["User"];

            Work work = new Work();
            WorkTable wt = new WorkTable();

            work.UserNo = User.UserNo;

            work.OutTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy년 MM월 dd일 HH 시 mm 분 ss초"));

            work.WorkStatus = 1; //早退

            TimeSpan gapTime = work.OutTime - DateTime.Now;

            work.WorkTime = (gapTime.Hours * 60) + gapTime.Minutes;

            work.WorkCheck = 1;

            DateTime Start = Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
            DateTime End = Convert.ToDateTime(Start.Year + "-" + Start.Month + "-" + (Start.Day + 1));

            if (wt.SearchOutTime(work, Start, End) == 0)
            {
                wt.Update(work);

                Session["Notice"] = "早退登録を完了しました。";

                Response.Redirect("Notice.aspx");
            }
            else
            {
                Session["Notice"] = "退勤登録済みです。";

                Response.Redirect("Notice.aspx");
            }
        }

        protected void btnChangeResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeList.aspx");
        }

        protected void btnPaid_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaidReport.aspx");
        }
    }
}