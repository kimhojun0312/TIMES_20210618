using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class PaidReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo User =　(UserInfo)Session["User"];

            PaidTable pt = new PaidTable();

            gvTimes.DataSource = pt.GetPaid(User);
            gvTimes.DataBind();
        }

        protected void gvTimes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                int index = Convert.ToInt32(e.CommandArgument); 

                Paid paid = new Paid();
                paid.PaidReportNo = Convert.ToInt32(gvTimes.Rows[index].Cells[0].Text);

                PaidTable pt = new PaidTable();
                Session["Paid"] = pt.GetPaidAll(paid); ;

                Server.Transfer("PaidReportDetail.aspx");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("Home.aspx");
        }

        protected void btnPaid_Click(object sender, EventArgs e)
        {
            Server.Transfer("PaidSignIn.aspx");
        }
    }
}