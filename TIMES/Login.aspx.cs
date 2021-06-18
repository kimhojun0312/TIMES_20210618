using System;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;

namespace TIMES
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

 

        protected void cvLogin_ServerValidate(object source, ServerValidateEventArgs args)
        {
            UserInfo user = new UserInfo();

            user.UserId = txtId.Text;

            user.UserPwd = txtPwd.Text;

            UserInfoTable ut = new UserInfoTable();

            Boolean LoginCheck = false;

            if (ut.LoginUser(user) == 1) // 1 = ログイン成功
            {
                Session["User"] = ut.getUser(user);
                LoginCheck = true;
            }
            args.IsValid = LoginCheck;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                UserInfo user = (UserInfo)Session["User"];

                if (user.UserType == 0)
                {
                    Response.Redirect("HomeAdmin.aspx");
                    //Server.Transfer("Home.aspx");
                }
                else
                {
                    Response.Redirect("Home.aspx");
                    //Server.Transfer("HomeAdmin.aspx");
                }
            }
        }

    }
}