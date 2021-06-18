using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class ReportAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PaidTable pr = new PaidTable();

            gvPaid.DataSource = pr.GetPaid();
            gvPaid.DataBind();

            ChangeReportTable ct = new ChangeReportTable();

            gvChange.DataSource = ct.GetChange();
            gvChange.DataBind();

        }

        protected void gvPaid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                int index = Convert.ToInt32(e.CommandArgument);

                Paid paid = new Paid();
                paid.PaidReportNo = Convert.ToInt32(gvPaid.Rows[index].Cells[0].Text);

                PaidTable pt = new PaidTable();
                Session["Paid"] = pt.GetPaidAll(paid);

                Server.Transfer("PaidReportDetailAD.aspx");
            }
        }

        protected void gvChange_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                int index = Convert.ToInt32(e.CommandArgument);

                ChangeReport report = new ChangeReport();
                report.ChangeReportNo = Convert.ToInt32(gvChange.Rows[index].Cells[0].Text);

                ChangeReportTable ct = new ChangeReportTable();
                report = ct.GetAll(report);
                Session["ChangeReport"] = report;

                WorkTable wt = new WorkTable();
                Work work = new Work();
                work.WorkNo = report.WorkNo;
                Session["Work"] = wt.GetNo(work.WorkNo);

                Server.Transfer("ChangeReportDetailAD.aspx");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("HomeAdmin.aspx");
        }
    }
}