using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class NoticeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNotice.Text = Session["Notice"].ToString();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("HomeAdmin.aspx");
        }
    }
}