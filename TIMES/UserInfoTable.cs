using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TIMES
{
    public class UserInfoTable
    {
        public int LoginUser(UserInfo User)
        {
            int cnt = 0;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select UserPwd = pwdcompare(@UserPwd,UserPwd) from UserInfo where UserId = @UserId";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserId", SqlDbType.VarChar);
                adapter.SelectCommand.Parameters["@UserId"].Value = User.UserId;

                adapter.SelectCommand.Parameters.Add("@UserPwd", SqlDbType.VarChar);
                adapter.SelectCommand.Parameters["@UserPwd"].Value = User.UserPwd;

                DataSet ds = new DataSet();

                cnt = adapter.Fill(ds, "User");
                if (cnt != 0)
                {
                    DataTable dt = ds.Tables["User"];
                    cnt = (int)dt.Rows[0]["UserPwd"];
                }
            }
            return cnt;
        }

        public UserInfo getUser(UserInfo User)
        {
            UserInfo returnUser = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from UserInfo where UserId = @UserId";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserId", SqlDbType.VarChar);

                adapter.SelectCommand.Parameters["@UserId"].Value = User.UserId;

                DataSet ds = new DataSet();

                int cnt = adapter.Fill(ds, "User");

                if (cnt != 0)
                {
                    returnUser = new UserInfo();
                    DataTable dt = ds.Tables["User"];
                    returnUser.UserNo = (int)dt.Rows[0]["UserNo"];
                    returnUser.UserId = dt.Rows[0]["UserId"].ToString(); ;
                    returnUser.UserName = dt.Rows[0]["UserName"].ToString();
                    returnUser.UserType = (int)dt.Rows[0]["UserType"];
                    returnUser.UserPosition = dt.Rows[0]["UserPosition"].ToString();
                }

            }

            return returnUser;
        }


        public int Insert(UserInfo User)
        {
            int cnt = 0;

            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "insert into UserInfo(UserId,UserPwd,UserName,UserType,StartDate,UserPosition) values(@UserId, pwdencrypt(@UserPwd), @UserName,@UserType,@StartDate,@UserPosition)";

                SqlCommand command = new SqlCommand(sql, connection);


                command.Parameters.Add("@UserId", SqlDbType.VarChar);
                command.Parameters["@UserId"].Value = User.UserId;

                command.Parameters.Add("@UserPwd", SqlDbType.VarChar);
                command.Parameters["@UserPwd"].Value = User.UserPwd;

                command.Parameters.Add("@UserType", SqlDbType.Int);
                command.Parameters["@UserType"].Value = User.UserType;

                command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                command.Parameters["@UserName"].Value = User.UserName;

                command.Parameters.Add("@StartDate", SqlDbType.Date);
                command.Parameters["@StartDate"].Value = User.StartDate;

                command.Parameters.Add("@UserPosition", SqlDbType.NVarChar);
                command.Parameters["@UserPosition"].Value = User.UserPosition;

                connection.Open();
                cnt = command.ExecuteNonQuery();
                connection.Close();


            }
            
            return cnt;
        }
        public int UpdateUser(UserInfo user)
        {
            int cnt = 0;

            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "Update UserInfo set UserName = @UserName, StartDate = @StartDate, UserPosition = @UserPosition, UserType = @UserType Where UserNo = @UserNo";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                command.Parameters["@UserName"].Value = user.UserName;

                command.Parameters.Add("@StartDate", SqlDbType.DateTime);
                command.Parameters["@StartDate"].Value = user.StartDate;

                command.Parameters.Add("@UserPosition", SqlDbType.NVarChar);
                command.Parameters["@UserPosition"].Value = user.UserPosition;

                command.Parameters.Add("@UserNo", SqlDbType.Int);
                command.Parameters["@UserNo"].Value = user.UserNo;

                command.Parameters.Add("@UserType", SqlDbType.Int);
                command.Parameters["@UserType"].Value = user.UserType;

                connection.Open();
                cnt = command.ExecuteNonQuery();
                connection.Close();


            }

            return cnt;
        }

        public DataTable GetAllUser()
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select UserNo,UserName,UserPosition,convert(varchar(10), StartDate, 120) AS StartDate,(CASE WHEN UserType = 0 THEN  '管理者' WHEN UserType = 1 THEN  '正社員' ELSE 'パ-トタイム' END) AS UserType FROM UserInfo ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "UserInfo");
                dt = ds.Tables["UserInfo"];
            }

            return dt;
        }
        public DataTable GetSearchName(UserInfo user)
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select UserNo,UserName,UserPosition,convert(varchar(10), StartDate, 120) AS StartDate,(CASE WHEN UserType = 0 THEN  '管理者' WHEN UserType = 1 THEN  '正社員' ELSE 'パ-トタイム' END) AS UserType FROM UserInfo  where UserName = @UserName ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserName", SqlDbType.NVarChar);
                adapter.SelectCommand.Parameters["@UserName"].Value = user.UserName;

                DataSet ds = new DataSet();
                adapter.Fill(ds, "UserInfo");
                dt = ds.Tables["UserInfo"];
            }

            return dt;
        }

        public DataTable GetSearchPosition(UserInfo user)
        {
            DataTable dt = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select UserNo,UserName,UserPosition,convert(varchar(10), StartDate, 120) AS StartDate,(CASE WHEN UserType = 0 THEN  '管理者' WHEN UserType = 1 THEN  '正社員' ELSE 'パ-トタイム' END) AS UserType FROM UserInfo where UserPosition = @UserPosition ";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserPosition", SqlDbType.NVarChar);
                adapter.SelectCommand.Parameters["@UserPosition"].Value = user.UserPosition;

                DataSet ds = new DataSet();
                adapter.Fill(ds, "UserInfo");
                dt = ds.Tables["UserInfo"];
            }

            return dt;
        }
        public UserInfo SearchUserNo(UserInfo User)
        {
            UserInfo returnUser = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from UserInfo where UserNo = @UserNo";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@UserNo", SqlDbType.Int);

                adapter.SelectCommand.Parameters["@UserNo"].Value = User.UserNo;

                DataSet ds = new DataSet();

                int cnt = adapter.Fill(ds, "User");

                if (cnt != 0)
                {
                    returnUser = new UserInfo();
                    DataTable dt = ds.Tables["User"];
                    returnUser.UserNo = (int)dt.Rows[0]["UserNo"];
                    returnUser.UserId = dt.Rows[0]["UserId"].ToString(); ;
                    returnUser.UserName = dt.Rows[0]["UserName"].ToString();
                    returnUser.StartDate = (DateTime)dt.Rows[0]["StartDate"];
                    returnUser.UserType = (int)dt.Rows[0]["UserType"];
                    returnUser.UserPosition = dt.Rows[0]["UserPosition"].ToString();
                }

            }

            return returnUser;
        }



    }
}