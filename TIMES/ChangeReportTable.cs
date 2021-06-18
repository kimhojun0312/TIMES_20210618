using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TIMES
{
    public class ChangeReportTable
    {
        public int Insert(ChangeReport report)
        {
            int cnt = 0;

            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "insert into ChangeReport(UserNo,WorkNo,Title,NewInTime,NewOutTime,Comment,Status) values(@UserNo, @WorkNo, @Title,@NewInTime,@NewOutTime,@Comment,@Status)";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@UserNo", SqlDbType.Int);
                command.Parameters["@UserNo"].Value = report.UserNo;

                command.Parameters.Add("@WorkNo", SqlDbType.Int);
                command.Parameters["@WorkNo"].Value = report.WorkNo;

                command.Parameters.Add("@Title", SqlDbType.NVarChar);
                command.Parameters["@Title"].Value = report.Title;

                command.Parameters.Add("@NewInTime", SqlDbType.DateTime);
                command.Parameters["@NewInTime"].Value = report.NewInTime;

                command.Parameters.Add("@NewOutTime", SqlDbType.DateTime);
                command.Parameters["@NewOutTime"].Value = report.NewOutTime;

                command.Parameters.Add("@Status", SqlDbType.Int);
                command.Parameters["@Status"].Value = report.Status;

                command.Parameters.Add("@Comment", SqlDbType.NVarChar);
                command.Parameters["@Comment"].Value = report.Comment;

                connection.Open();
                cnt = command.ExecuteNonQuery();
                connection.Close();


            }

            return cnt;
        }
        public ChangeReport GetAll(ChangeReport report)
        {
            ChangeReport retReport = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from ChangeReport where ChangeReportNo = @ChangeReportNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@ChangeReportNo", SqlDbType.Int);

                adapter.SelectCommand.Parameters["@ChangeReportNo"].Value = report.ChangeReportNo;

                DataSet ds = new DataSet();

                int cnt = adapter.Fill(ds, "Report");

                if (cnt != 0)
                {
                    retReport = new ChangeReport();
                    DataTable dt = ds.Tables["Report"];
                    retReport.UserNo = (int)dt.Rows[0]["UserNo"];
                    retReport.ChangeReportNo = (int)dt.Rows[0]["ChangeReportNo"];
                    retReport.WorkNo = (int)dt.Rows[0]["WorkNo"];
                    retReport.Title = dt.Rows[0]["Title"].ToString();
                    retReport.Comment = dt.Rows[0]["Comment"].ToString();
                    retReport.NewInTime = (DateTime)dt.Rows[0]["NewInTime"];
                    retReport.NewOutTime = (DateTime)dt.Rows[0]["NewOutTime"];
                    retReport.Status = (int)dt.Rows[0]["Status"];
                    retReport.AdminComment = dt.Rows[0]["AdminComment"].ToString();
                }

                return retReport;
            }
        }

        public ChangeReport SearchWorkNo(Work work)
        {
            ChangeReport retReport = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from ChangeReport where WorkNo = @WorkNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@WorkNo", SqlDbType.Int);

                adapter.SelectCommand.Parameters["@WorkNo"].Value = work.WorkNo;

                DataSet ds = new DataSet();

                int cnt = adapter.Fill(ds, "Report");

                if (cnt != 0)
                {
                    retReport = new ChangeReport();
                    DataTable dt = ds.Tables["Report"];
                    retReport.UserNo = (int)dt.Rows[0]["UserNo"];
                    retReport.ChangeReportNo = (int)dt.Rows[0]["ChangeReportNo"];
                    retReport.WorkNo = (int)dt.Rows[0]["WorkNo"];
                    retReport.Title = dt.Rows[0]["Title"].ToString();
                    retReport.Comment = dt.Rows[0]["Comment"].ToString();
                    retReport.NewInTime = (DateTime)dt.Rows[0]["NewInTime"];
                    retReport.NewOutTime = (DateTime)dt.Rows[0]["NewOutTime"];
                    retReport.Status = (int)dt.Rows[0]["Status"];
                    retReport.AdminComment = dt.Rows[0]["AdminComment"].ToString();
                }

                return retReport;
            }
        }

        public DataTable GetChange()
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select ChangeReportNo,UserName,UserPosition,ChangeReport.Title,(CASE WHEN ChangeReport.Status = 0 THEN  '新規'  WHEN ChangeReport.Status = 1 THEN  '承認'  ELSE '拒否' END) AS Status from ChangeReport Inner join UserInfo ON ChangeReport.UserNo = UserInfo.UserNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "ChangeReport");
                dt = ds.Tables["ChangeReport"];
            }

            return dt;
        }

        public int Update(ChangeReport report)
        {
            int cnt = 0;

            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "Update ChangeReport set AdminComment = @AdminComment, Status = @Status Where ChangeReportNo = @ChangeReportNo";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@AdminComment", SqlDbType.VarChar);
                command.Parameters["@AdminComment"].Value = report.AdminComment;


                command.Parameters.Add("@Status", SqlDbType.Int);
                command.Parameters["@Status"].Value = report.Status;

                command.Parameters.Add("@ChangeReportNo", SqlDbType.Int);
                command.Parameters["@ChangeReportNo"].Value = report.ChangeReportNo;

                connection.Open();
                cnt = command.ExecuteNonQuery();
                connection.Close();


            }

            return cnt;
        }

        public int SearchNo(ChangeReport report)
        {
            int cnt = 0;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from ChangeReport where WorkNo = @WorkNo";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@WorkNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@WorkNo"].Value = report.WorkNo;

                DataSet ds = new DataSet();

                cnt = adapter.Fill(ds, "report");
                if (cnt != 0)
                {
                    DataTable dt = ds.Tables["report"];
                    cnt = 1;
                }
            }
            return cnt;
        }
    }
}