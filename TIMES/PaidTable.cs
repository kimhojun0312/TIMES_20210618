using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TIMES
{
    public class PaidTable
    {
        public DataTable GetPaid(UserInfo user)
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select PaidReportNo,UserNo,Title,convert(varchar(10), WantDay, 120) AS WantDay ,(CASE WHEN Status = 0 THEN  '' WHEN Status = 1 THEN  '承認' ELSE '拒否' END) AS Status FROM Paid WHERE UserNo = @UserNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@UserNo"].Value = user.UserNo;

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Paid");
                dt = ds.Tables["Paid"];
            }

            return dt;
        }
        public int Insert(Paid paid)
        {
            int cnt = 0;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "insert into Paid(UserNo,Title,Comment,WantDay,Status) values(@UserNo,@Title,@Comment,@WantDay,0)";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@UserNo", SqlDbType.Int);
                command.Parameters["@UserNo"].Value = paid.UserNo;

                command.Parameters.Add("@Title", SqlDbType.NVarChar);
                command.Parameters["@Title"].Value = paid.Title;

                command.Parameters.Add("@Comment", SqlDbType.NVarChar);
                command.Parameters["@Comment"].Value = paid.Comment;

                command.Parameters.Add("@WantDay", SqlDbType.DateTime);
                command.Parameters["@WantDay"].Value = paid.WantDay;

                connection.Open();
                cnt = command.ExecuteNonQuery();
                connection.Close();
            }

            return cnt;
        }

        public Paid GetPaidAll(Paid paid)
        {
            Paid retPaid = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Paid where PaidReportNo = @PaidReportNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@PaidReportNo", SqlDbType.Int);

                adapter.SelectCommand.Parameters["@PaidReportNo"].Value = paid.PaidReportNo;

                DataSet ds = new DataSet();

                int cnt = adapter.Fill(ds, "Paid");

                if (cnt != 0)
                {
                    retPaid = new Paid();
                    DataTable dt = ds.Tables["Paid"];
                    retPaid.UserNo = (int)dt.Rows[0]["UserNo"];
                    retPaid.PaidReportNo = (int)dt.Rows[0]["PaidReportNo"];
                    retPaid.Title = dt.Rows[0]["Title"].ToString(); ;
                    retPaid.Comment = dt.Rows[0]["Comment"].ToString();
                    retPaid.WantDay = (DateTime)dt.Rows[0]["WantDay"];
                    retPaid.AdminComment = dt.Rows[0]["AdminComment"].ToString();
                    retPaid.Status = (int)dt.Rows[0]["Status"];
                }

                return retPaid;
            }
        }

        public DataTable GetPaid()
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select PaidReportNo,UserInfo.UserNo,UserInfo.UserName,UserPosition,Title,Comment,convert(varchar(10), WantDay, 120) AS WantDay, (CASE WHEN Status = 0 THEN  '新規'  WHEN Status = 1 THEN  '承認' ELSE '拒否' END) AS Status from Paid Inner join UserInfo ON Paid.UserNo = UserInfo.UserNo ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Paid");
                dt = ds.Tables["Paid"];
            }

            return dt;
        }

        public int Update(Paid paid)
        {
            int cnt = 0;

            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "Update Paid set AdminComment = @AdminComment, Status = @Status Where PaidReportNo = @PaidReportNo";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@AdminComment", SqlDbType.NVarChar);
                command.Parameters["@AdminComment"].Value = paid.AdminComment;

                command.Parameters.Add("@Status", SqlDbType.Int);
                command.Parameters["@Status"].Value = paid.Status;

                command.Parameters.Add("@PaidReportNo", SqlDbType.Int);
                command.Parameters["@PaidReportNo"].Value = paid.PaidReportNo;

                connection.Open();
                cnt = command.ExecuteNonQuery();
                connection.Close();


            }

            return cnt;
        }
    }
}