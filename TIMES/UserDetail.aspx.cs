using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class UserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo user = (UserInfo)Session["User"];
            lblUserNo.Text = "社員番号：" + user.UserNo;
            lblUserName.Text = "社員名 : ";
            lblStartDay.Text = "入社日 : ";
            lblUserType.Text = "勤務形態 : ";
            lblUserPosition.Text = "役職 : ";
            txtName.Text = user.UserName;
            ddlYear.Text = Convert.ToString(user.StartDate.Year);
            ddlMonth.Text = Convert.ToString(user.StartDate.Month);
            ddlDay.Text = Convert.ToString(user.StartDate.Day);


        }

        

        protected void btnResetOk_Click(object sender, EventArgs e)
        {
            UserInfo user = (UserInfo)Session["User"];
            UserInfoTable ut = new UserInfoTable();

            user.UserName = txtName.Text;

            int Year = Convert.ToInt32(ddlYear.Text); 
            int Month = Convert.ToInt32(ddlMonth.Text); 
            int Day = Convert.ToInt32(ddlDay.Text); 

            user.StartDate = Convert.ToDateTime(Year + "-" + Month + "-" + Day);
            user.UserPosition = ddlPosition.Text;

            if (ddlType.SelectedIndex == 0)
            {
                user.UserType = 1;
            }
            else
            {
                user.UserType = 2;
            }

            ut.UpdateUser(user);

            Session["Notice"] = "社員情報変更を完了しました。";

            Response.Redirect("NoticeAdmin.aspx");


        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            Server.Transfer("WorkDetailAdmin.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("WorkAdmin.aspx");
        }
    }
}