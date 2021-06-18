using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class WorkAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            UserInfoTable ut = new UserInfoTable();

            gvTimes.DataSource = ut.GetAllUser();
            gvTimes.DataBind();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("HomeAdmin.aspx");
        }

        protected void btnSearchName_Click(object sender, EventArgs e)
        {
            UserInfo User = new UserInfo();
            UserInfoTable wt = new UserInfoTable();

            User.UserName = txtName.Text;


            gvTimes.DataSource = wt.GetSearchName(User);
            gvTimes.DataBind();
        }

        protected void btnSearchLevel_Click(object sender, EventArgs e)
        {
            UserInfo User = new UserInfo();
            UserInfoTable ut = new UserInfoTable();

            User.UserPosition = ddlPosition.Text;

            gvTimes.DataSource = ut.GetSearchPosition(User);
            gvTimes.DataBind();
        }

        protected void gvTimes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                int index = Convert.ToInt32(e.CommandArgument); // 선택된 값

                UserInfo user = new UserInfo();
                UserInfoTable ut = new UserInfoTable();

                user.UserNo = Convert.ToInt32(gvTimes.Rows[index].Cells[0].Text);

                Session["User"] = ut.SearchUserNo(user);

                Server.Transfer("UserDetail.aspx");
            }
        }
    }
}