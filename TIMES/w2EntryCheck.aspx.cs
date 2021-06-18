using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIMES
{
    public partial class w2EntryCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TimeSpan time = TimeSpan.FromSeconds(Convert.ToInt32(Label1.Text) * 60);
                string str = time.ToString(@"hh\:mm\:ss");
                Label1.Text = str;
            }
            mail.Text = Session["CheckID"].ToString() + "認証メールを送りました。";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(string.Compare(TextBox1.Text, Session["CheckMail"].ToString(), true) == 0)
            {
                Response.Redirect("w2EntryFinal.aspx");
            }
               
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            TimeSpan result = TimeSpan.FromSeconds(TimeSpan.Parse(Label1.Text).TotalSeconds - 1);
            string fromTimeString = result.ToString(@"hh\:mm\:ss") ;
            Label1.Text = fromTimeString;

        }
    }
}