using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnEntry.Visible = false;
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo();

            user.UserId = txtUserId.Text;

            UserInfoTable ut = new UserInfoTable();

            if (txtUserId.Text != "")
            {
                if (ut.getUser(user) == null)
                {
                    lblIdOk.Text = "このIDは使用可能です。";
                    lblIdCheck.Text = "";
                    btnEntry.Visible = true;

                }
                else
                {
                    lblIdOk.Text = "";
                    lblIdCheck.Text = "このIDは既に登録されています。";

                }
            }
            else
            {
                lblIdCheck.Text = "IDを入力してください。";
            }
        }

        protected void btnEntry_Click(object sender, EventArgs e)
        {
            UserInfo User = new UserInfo();

            User.UserId = txtUserId.Text;
            User.UserPwd = txtPassword.Text;
            User.UserName = txtName.Text;

            if(ddlType.SelectedIndex == 0)
            {
                User.UserType = 1;
            }
            else
            {
                User.UserType = 2;
            }
            

            int Year = Convert.ToInt32(ddlYear.Text); // 출근년도
            int Month = Convert.ToInt32(ddlMonth.Text); //출근 월
            int Day = Convert.ToInt32(ddlDay.Text); //출근 일자

            User.StartDate = Convert.ToDateTime(Year + "-" + Month + "-" + Day);

            User.UserPosition = ddlLevel.Text;

            UserInfoTable ut = new UserInfoTable();

            int ret = ut.Insert(User);
            if (ret == 1)
            {
                Session["Notice"] = "社員登録を完了しました。";

                Response.Redirect("NoticeAdmin.aspx");
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Server.Transfer("HomeAdmin.aspx");
        }
    }
}