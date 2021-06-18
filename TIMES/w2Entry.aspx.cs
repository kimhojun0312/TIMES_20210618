using System;
using System.Net.Mail;
using System.Text;

namespace TIMES
{
    public partial class w2Entry : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public static string GetRandomCharacter(Random random, int length)
        {
            StringBuilder sb = new StringBuilder();
            int value = 0;
            for (int i = 0; i < length; i++)
            {
                do
                {
                    value = random.Next(48, 90);
                } while (value > 57 && value < 65);

                sb.Append(Convert.ToChar(value));
            }

            return sb.ToString();
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
                    btnCheck.Visible = false;
                    Button1.Visible = true;

                }
                else if(ut.getUser(user) != null && ut.getUser(user).Authstatus == 0) 
                {
                    lblIdOk.Text = "このIDは使用可能です。";
                    lblIdCheck.Text = "";
                    btnCheck.Visible = false;
                    Button1.Visible = true;

                }
                else
                {
                    lblIdOk.Text = "既に存在するIDです。";
                    lblIdCheck.Text = "";
                }
            }
            else
            {
                lblIdCheck.Text = "IDを入力してください。";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

                Random random = new Random();
                GetRandomCharacter(random, 5);

                MailMessage message = new MailMessage();
                string id = txtUserId.Text;
                string title = "인증 메일입니다";
                string secret = GetRandomCharacter(random, 5);
                string contents= "인증 코드를 입력해 주세요. 인증 코드 : " + secret;
                

                message.To.Add(id);
                message.From = new MailAddress("bigdokim@gmail.com", "김호준", System.Text.Encoding.UTF8);
                MailAddress bcc = new MailAddress("bigdokim@gmail.com");//참조 메일계정
                message.Bcc.Add(bcc);
                message.Subject = title;
                message.SubjectEncoding = UTF8Encoding.UTF8;
                message.Body = contents;
                message.BodyEncoding = UTF8Encoding.UTF8;
                message.IsBodyHtml = true; //메일내용이 HTML형식임
                message.Priority = MailPriority.High; //중요도 높음
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure; //메일 배달 실패시 알림
                //Attachment attFile = new Attachment("\\testtext.ini");//첨부파일
                //message.Attachments.Add(attFile);

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com"; //SMTP(발송)서버 도메인
                client.Port = 587; //25, SMTP서버 포트
                client.EnableSsl = true; //SSL 사용
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("bigdokim@gmail.com", "rlaghwns1");//보내는 사람 메일 서버접속계정, 암호, Anonymous이용시 생략
                client.Send(message);

                message.Dispose();

                Session["CheckID"] = txtUserId.Text;
                Session["CheckMail"] = secret;

                Response.Redirect("w2EntryCheck.aspx");
            
        }
    }
}