using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Server.Transfer("CreateUser.aspx");
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Server.Transfer("WorkAdmin.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Server.Transfer("Login.aspx");
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Server.Transfer("ReportAdmin.aspx");
        }
    }
}