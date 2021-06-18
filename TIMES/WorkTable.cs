using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TIMES
{
    public class WorkTable
    {
        public int SearchInTime(Work work, DateTime Start, DateTime End)
        {
            int cnt = 0;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Work where InTime BETWEEN @Start AND @End AND UserNo = @UserNo";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@UserNo"].Value = work.UserNo;

                adapter.SelectCommand.Parameters.AddWithValue("@Start", Start);
                adapter.SelectCommand.Parameters.AddWithValue("@End", End);

                DataSet ds = new DataSet();

                cnt = adapter.Fill(ds, "Work");
                if (cnt != 0)
                {
                    cnt = 1;
                }
            }
            return cnt;
        }

        public int SearchOutTime(Work work, DateTime Start, DateTime End)
        {
            int cnt = 0;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Work where OutTime BETWEEN @Start AND @End AND UserNo = @UserNo";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@UserNo"].Value = work.UserNo;

                adapter.SelectCommand.Parameters.AddWithValue("@Start", Start);
                adapter.SelectCommand.Parameters.AddWithValue("@End", End);

                DataSet ds = new DataSet();

                cnt = adapter.Fill(ds, "Work");
                if (cnt != 0)
                {
                    cnt = 1;
                }
            }
            return cnt;
        }
        public int Insert(Work work)
        {
            int cnt = 0;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "insert into Work (UserNo,InTime,OutTime,WorkTime) values(@UserNo,@InTime,0,0)";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@UserNo", SqlDbType.Int);
                command.Parameters["@UserNo"].Value = work.UserNo;

                command.Parameters.Add("@InTime", SqlDbType.DateTime);
                command.Parameters["@InTime"].Value = work.InTime;


                connection.Open();
                cnt = command.ExecuteNonQuery();
                connection.Close();
            }

            return cnt;
        }

        public Work InsertInTIme(Work work)
        {
            Work returnWork = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "insert into Work (UserNo,InTime,OutTime,WorkTime) values(@UserNo,@InTime,0,0)";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@UserNo"].Value = work.UserNo;

                adapter.SelectCommand.Parameters.Add("@InTime", SqlDbType.DateTime);
                adapter.SelectCommand.Parameters["@InTime"].Value = work.InTime;

                DataSet ds = new DataSet(); // sql文実行

                int cnt = adapter.Fill(ds, "Work");

                if (cnt != 0)
                {
                    returnWork = new Work();
                    DataTable dt = ds.Tables["Work"];
                    returnWork.WorkNo = (int)dt.Rows[0]["WorkNo"];
                    returnWork.UserNo = (int)dt.Rows[0]["UserNo"];
                    returnWork.InTime = (DateTime)dt.Rows[0]["InTime"];
                    returnWork.OutTime = (DateTime)dt.Rows[0]["OutTime"];
                    returnWork.WorkTime = (int)dt.Rows[0]["WorkTime"];
                    returnWork.WorkStatus = (int)dt.Rows[0]["WorkStatus"];
                }

            }

            return returnWork;
        }

        public Work GetWork(Work work)
        {
            Work returnWork = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Work where UserNo = @UserNo AND OutTime = 0";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.VarChar);
                adapter.SelectCommand.Parameters["@UserNo"].Value = work.UserNo;

                DataSet ds = new DataSet(); // sql文実行

                int cnt = adapter.Fill(ds, "Work");

                if (cnt != 0)
                {
                    returnWork = new Work();
                    DataTable dt = ds.Tables["Work"];
                    returnWork.UserNo = (int)dt.Rows[0]["UserNo"];
                    returnWork.InTime = (DateTime)dt.Rows[0]["InTime"];
                    returnWork.OutTime = (DateTime)dt.Rows[0]["OutTime"];
                    returnWork.WorkTime = (int)dt.Rows[0]["WorkTime"];
                }

            }

            return returnWork;
        }

        public int Update(Work work)
        {
            int cnt = 0;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "UPDATE Work set OutTIme = @OutTime , WorkTime = @WorkTime , WorkStatus = @WorkStatus , WorkCheck = @WorkCheck where UserNo = @UserNo AND OutTime = 0";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@UserNo", SqlDbType.Int);
                command.Parameters["@UserNo"].Value = work.UserNo;

                command.Parameters.Add("@WorkNo", SqlDbType.Int);
                command.Parameters["@WorkNo"].Value = work.WorkNo;

                command.Parameters.Add("@OutTime", SqlDbType.DateTime);
                command.Parameters["@OutTime"].Value = work.OutTime;

                command.Parameters.Add("@WorkTime", SqlDbType.Int);
                command.Parameters["@WorkTime"].Value = work.WorkTime;

                command.Parameters.Add("@WorkStatus", SqlDbType.Int);
                command.Parameters["@WorkStatus"].Value = work.WorkStatus;

                command.Parameters.Add("@WorkCheck", SqlDbType.Int);
                command.Parameters["@WorkCheck"].Value = work.WorkCheck;


                connection.Open();
                cnt = command.ExecuteNonQuery();
                connection.Close();
            }
            return cnt;
        }

        public DataTable GetWorkTable(UserInfo user)
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select WorkNo,InTime,OutTime,CONVERT(Char,WorkTime / 60) + '時間' +  CONVERT(Char,WorkTime % 60) + '分' as WorkTime, "
                            + " (CASE WHEN WorkStatus = 0 THEN  '正常' WHEN WorkStatus = 1 THEN  '早退' ELSE '有給' END) AS WorkStatus "
                            + " from Work where 2 = 2 AND UserNo = @UserNo ORDER BY InTime ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@UserNo"].Value = user.UserNo;


                DataSet ds = new DataSet();

                adapter.Fill(ds, "Work");
                dt = ds.Tables["Work"];
            }

            return dt;
        }

        public DataTable GetSelectRange(Work work, DateTime StartTime, DateTime EndTime)
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select WorkNo,Intime,OutTime,CONVERT(Char, WorkTime / 60) + '時間' + CONVERT(Char, WorkTime % 60) + '分' as WorkTime, "
                            + " (CASE WHEN WorkStatus = 0 THEN  '正常' WHEN WorkStatus = 1 THEN  '早退' ELSE '有給' END) AS WorkStatus"
                             + " FROM Work WHERE UserNo = @UserNo AND Intime Between @StartTime AND @EndTime ORDER BY Intime ASC ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@UserNo"].Value = work.UserNo;

                adapter.SelectCommand.Parameters.Add("@StartTime", SqlDbType.Date);
                adapter.SelectCommand.Parameters["@StartTime"].Value = StartTime;

                adapter.SelectCommand.Parameters.Add("@EndTime", SqlDbType.Date);
                adapter.SelectCommand.Parameters["@EndTime"].Value = EndTime;


                DataSet ds = new DataSet();
                adapter.Fill(ds, "Work");
                dt = ds.Tables["Work"];
            }

            return dt;
        }

        public DataTable GetSelectDate(UserInfo user, DateTime StartDate, DateTime EndDate)
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select InTime,OutTime,CONVERT(Char,WorkTime / 60) + '時間' +  CONVERT(Char,WorkTime % 60) + '分' as WorkTime, "
                            + " (CASE WHEN WorkStatus = 0 THEN  '正常' WHEN WorkStatus = 1 THEN  '早退' ELSE '有給' END) AS WorkStatus "
                            + "FROM Work WHERE Intime Between @StartDate AND @EndDate AND UserNo = UserNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.VarChar);
                adapter.SelectCommand.Parameters["@UserNo"].Value = user.UserNo;

                adapter.SelectCommand.Parameters.AddWithValue("@StartDate", StartDate);
                adapter.SelectCommand.Parameters.AddWithValue("@EndDate", EndDate);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Work");
                dt = ds.Tables["Work"];
            }

            return dt;
        }
        public DataTable GetSelectDate(Work work, int InYear, int InMonth, int InDay)
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select WorkNo,UserNo, InTime, OutTIme, CONVERT(Char,WorkTime / 60) + '時間' +  CONVERT(Char,WorkTime % 60) + '分' as WorkTime ,"
                             + " (CASE WHEN WorkStatus = 0 THEN  '正常' WHEN WorkStatus = 1 THEN  '早退' ELSE '有給' END) AS WorkStatus "
                             + "FROM Work WHERE YEAR(InTime) = @InYear AND  MONTH(InTime) = @InMonth AND  DAY(InTime) >= @InDay AND DAY(InTime) <= @InDay AND UserNo = @UserNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@UserNo"].Value = work.UserNo;

                adapter.SelectCommand.Parameters.AddWithValue("@InYear", InYear);
                adapter.SelectCommand.Parameters.AddWithValue("@InMonth", InMonth);
                adapter.SelectCommand.Parameters.AddWithValue("@InDay", InDay);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Work");
                dt = ds.Tables["Work"];
            }

            return dt;
        }

        public Work GetWorkNo(Work work, DateTime InTime)
        {
            Work retWork = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Work where InTime = @InTime AND UserNo = @UserNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@InTime", SqlDbType.DateTime);
                adapter.SelectCommand.Parameters["@InTime"].Value = InTime;

                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@UserNo"].Value = work.UserNo;

                DataSet ds = new DataSet();

                int cnt = adapter.Fill(ds, "Work");

                if (cnt != 0)
                {
                    retWork = new Work();
                    DataTable dt = ds.Tables["Work"];
                    retWork.UserNo = (int)dt.Rows[0]["UserNo"];
                    retWork.WorkNo = (int)dt.Rows[0]["WorkNo"];
                    retWork.WorkStatus = (int)dt.Rows[0]["WorkStatus"];
                    retWork.InTime = (DateTime)dt.Rows[0]["InTime"];
                    retWork.OutTime = (DateTime)dt.Rows[0]["OutTime"];
                    retWork.WorkTime = (int)dt.Rows[0]["WorkTime"];
                }

            }

            return retWork;
        }

        public DataTable GetWorkReport(UserInfo user)
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select ChangeReport.WorkNo AS ChangeReportNo, ChangeReport.Title, (CASE WHEN ChangeReport.Status = 0 THEN  '処理中' WHEN ChangeReport.Status = 1 THEN  '承認'  ELSE '拒否' END) AS Status　"
                        + " FROM Work Inner join ChangeReport ON Work.WorkNo = ChangeReport.WorkNo where Work.UserNo = @UserNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@UserNo"].Value = user.UserNo;

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Work");
                dt = ds.Tables["Work"];
            }

            return dt;
        }
        public Work GetNo(int WorkNo)
        {
            Work retWork = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Work where WorkNo = @WorkNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@WorkNo", SqlDbType.Int);
                adapter.SelectCommand.Parameters["@WorkNo"].Value = WorkNo;

                DataSet ds = new DataSet();

                int cnt = adapter.Fill(ds, "Work");

                if (cnt != 0)
                {
                    retWork = new Work();
                    DataTable dt = ds.Tables["Work"];
                    retWork.UserNo = (int)dt.Rows[0]["UserNo"];
                    retWork.WorkNo = (int)dt.Rows[0]["WorkNo"];
                    retWork.InTime = (DateTime)dt.Rows[0]["InTime"];
                    retWork.OutTime = (DateTime)dt.Rows[0]["OutTime"];
                    retWork.WorkTime = (int)dt.Rows[0]["WorkTime"];
                }

            }

            return retWork;
        }

        public int UpdateWork(Work work)
        {
            int cnt = 0;

            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "Update Work set InTime = @InTime, OutTime = @OutTime, WorkTime = @WorkTime Where WorkNo = @WorkNo";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@WorkNo", SqlDbType.Int);
                command.Parameters["@WorkNo"].Value = work.WorkNo;


                command.Parameters.Add("@InTime", SqlDbType.DateTime);
                command.Parameters["@InTime"].Value = work.InTime;


                command.Parameters.Add("@OutTime", SqlDbType.DateTime);
                command.Parameters["@OutTime"].Value = work.OutTime;

                command.Parameters.Add("@WorkTime", SqlDbType.Int);
                command.Parameters["@WorkTime"].Value = work.WorkTime;

                connection.Open();
                cnt = command.ExecuteNonQuery();
                connection.Close();


            }

            return cnt;
        }
        public int InsertPaid(Work work)
        {
            int cnt = 0;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "insert into Work (UserNo,InTime,OutTime,WorkTime,WorkStatus,WorkCheck) values(@UserNo,@InTime,@OutTime,@WorkTime,2,0)";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@UserNo", SqlDbType.Int);
                command.Parameters["@UserNo"].Value = work.UserNo;

                command.Parameters.Add("@InTime", SqlDbType.DateTime);
                command.Parameters["@InTime"].Value = work.InTime;

                command.Parameters.Add("@OutTime", SqlDbType.DateTime);
                command.Parameters["@OutTime"].Value = work.OutTime;

                command.Parameters.Add("@WorkTime", SqlDbType.Int);
                command.Parameters["@WorkTime"].Value = work.WorkTime;

                connection.Open();
                cnt = command.ExecuteNonQuery();
                connection.Close();
            }

            return cnt;
        }
    }
}