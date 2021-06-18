using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class WorkDetailAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo User = new UserInfo();

            User = (UserInfo)Session["User"];

            lblUserNo.Text = "社員番号 :" + User.UserNo;
            lblId.Text = "社員名 : " + User.UserName;


            Calendar.Visible = false;
            lblYear.Visible = false;
            lblMonth.Visible = false;
            lblDay.Visible = false;

            lblStart.Visible = false;

            ddlSYear.Visible = false;
            ddlSMonth.Visible = false;
            ddlSDay.Visible = false;

            lblYears.Visible = false;
            lblMonths.Visible = false;
            lblDays.Visible = false;

            ddlYear.Visible = false;
            ddlMonth.Visible = false;
            ddlDay.Visible = false;



            btnSearch.Visible = false;
            lblClickDay.Text = "";
        }

        protected void Calendar_SelectionChanged(object sender, EventArgs e)
        {
            DateTime t = Calendar.SelectedDate;

            int InYear = t.Year;
            int InMonth = t.Month;
            int InDay = t.Day;

            lblClickDay.Text = "検索日付 ; " + t.Year + "/" + t.Month + "/" + t.Day;

            UserInfo User = new UserInfo();

            User = (UserInfo)Session["User"];

            WorkTable wt = new WorkTable();
            Work work = new Work();

            work.UserNo = User.UserNo;


            gvTimes.DataSource = wt.GetSelectDate(work, InYear, InMonth, InDay);
            gvTimes.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int StartYear = Convert.ToInt32(ddlSYear.Text);
            int StartMonth = Convert.ToInt32(ddlSMonth.Text);
            int StartDay = Convert.ToInt32(ddlSDay.Text);

            int EndYear = Convert.ToInt32(ddlYear.Text);
            int EndMonth = Convert.ToInt32(ddlMonth.Text);
            int EndDay = Convert.ToInt32(ddlDay.Text);

            UserInfo User = new UserInfo();

            User = (UserInfo)Session["User"];

            WorkTable wt = new WorkTable();
            Work work = new Work();

            work.UserNo = User.UserNo;

            DateTime StartTime = Convert.ToDateTime(StartYear + "-" + StartMonth + "-" + StartDay);
            DateTime EndTime = Convert.ToDateTime(EndYear + "-" + EndMonth + "-" + (EndDay + 1));


            gvTimes.DataSource = wt.GetSelectRange(work, StartTime, EndTime);
            gvTimes.DataBind();

            lblClickDay.Text = "検索範囲 : " + StartTime.Year + "年 " + StartTime.Month + "월 " + StartTime.Day + "日から " + EndTime.Year + "年 " + EndTime.Month + "月 " + Convert.ToString(EndDay) + " 日まで";
        }

        protected void btnDay_Click(object sender, EventArgs e)
        {
            Calendar.Visible = false;

            lblYear.Visible = true;
            lblMonth.Visible = true;
            lblDay.Visible = true;

            btnSearch.Visible = true;
            lblStart.Visible = true;

            ddlYear.Visible = true;
            ddlMonth.Visible = true;
            ddlDay.Visible = true;

            ddlSYear.Visible = true;
            ddlSMonth.Visible = true;
            ddlSDay.Visible = true;

            lblYears.Visible = true;
            lblMonths.Visible = true;
            lblDays.Visible = true;

            ddlYear.Visible = true;
            ddlMonth.Visible = true;
            ddlDay.Visible = true;

            ddlSYear.Visible = true;
            ddlSMonth.Visible = true;
            ddlSDay.Visible = true;

            ddlYear.Text = Convert.ToString(DateTime.Today.Year);
            ddlMonth.Text = Convert.ToString(DateTime.Today.Month);
            ddlDay.Text = Convert.ToString(DateTime.Today.Day);

            ddlSYear.Text = Convert.ToString(DateTime.Today.Year);
            ddlSMonth.Text = Convert.ToString(DateTime.Today.Month);
            ddlSDay.Text = Convert.ToString(DateTime.Today.Day);
        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            Calendar.Visible = true;

            lblYear.Visible = false;
            lblMonth.Visible = false;
            lblDay.Visible = false;
            ddlYear.Visible = false;
            ddlMonth.Visible = false;
            ddlDay.Visible = false;
            btnSearch.Visible = false;
            lblStart.Visible = false;
            ddlSYear.Visible = false;
            ddlSMonth.Visible = false;
            ddlDay.Visible = false;
            ddlSDay.Visible = false;

            lblYears.Visible = false;
            lblMonths.Visible = false;
            lblDays.Visible = false;
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            UserInfo User = new UserInfo();

            User = (UserInfo)Session["User"];

            WorkTable wt = new WorkTable();

            gvTimes.DataSource = wt.GetWorkTable(User);
            gvTimes.DataBind();
        }

        protected void gvTimes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                int index = Convert.ToInt32(e.CommandArgument); // 선택된 값

                Work work = new Work();
                WorkTable wt = new WorkTable();

                UserInfo User = (UserInfo)Session["User"];

                work.UserNo = User.UserNo;
                work.InTime = Convert.ToDateTime(gvTimes.Rows[index].Cells[1].Text);

                Session["Work"] = wt.GetWorkNo(work, work.InTime);

                Server.Transfer("WorkChangeAdmin.aspx");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("UserDetail.aspx");
        }
    }
}