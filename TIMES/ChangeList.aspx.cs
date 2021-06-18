using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class ChangeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo  User = (UserInfo)Session["User"];


            WorkTable wt = new WorkTable();

            gvTimes.DataSource = wt.GetWorkReport(User);
            gvTimes.DataBind();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home.aspx");
        }

        protected void gvTimes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                int index = Convert.ToInt32(e.CommandArgument); // 선택된 값

                ChangeReport report = new ChangeReport();
                ChangeReportTable ct = new ChangeReportTable();
                Work work = new Work();
                WorkTable wt = new WorkTable();
                work.WorkNo = Convert.ToInt32(gvTimes.Rows[index].Cells[0].Text);

                Session["Work"] = wt.GetNo(work.WorkNo);
                Session["ChangeReport"] = ct.SearchWorkNo(work);

                Server.Transfer("ChangeListDetail.aspx");
            }
        }
    }
}