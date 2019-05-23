using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCF.Demo.DAL
{
    public class User
    {
        private static readonly string connectionString = "server=.;database=wcfDemo;uid=sa;pwd=123456;";

        //添加
        public static bool Add(Model.User user)
        {
            string sql = string.Format("INSERT INTO [dbo].[UserDemo]([UserName],[Password],[Discribe],[SubmitTime]) VALUES('{0}','{1}','{2}','{3}')", user.UserName, user.Password, user.Discribe, user.SubmitTime);
            int result = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql);
            if (result > 0)
                return true;
            else
                return false;
        }

        //修改
        public static bool Save(Model.User user)
        {
            string sql = string.Format("UPDATE [dbo].[UserDemo] SET [UserName] = '{0}',[Password] = '{1}',[Discribe] = '{2}',[SubmitTime] = '{3}' WHERE UserID = {4}", user.UserName, user.Password, user.Discribe, user.SubmitTime, user.UserID);
            int result = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql);
            if (result > 0)
                return true;
            else
                return false;
        }

        //删除
        public static bool Remove(int UserID)
        {
            string sql = string.Format("DELETE FROM [dbo].[UserDemo] WHERE UserID = {0}", UserID);
            int result = SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql);
            if (result > 0)
                return true;
            else
                return false;
        }

        //查找用户
        public static Model.User Search(int UserID)
        {
            Model.User user = new Model.User();
            string sql = string.Format("SELECT * FROM [dbo].[UserDemo] WHERE UserID = {0}", UserID);
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    user.UserID = Convert.ToInt32(dr["UserID"]);
                    user.UserName = dr["UserName"].ToString();
                    user.Password = dr["Password"].ToString();
                    user.Discribe = dr["Discribe"].ToString();
                    user.SubmitTime = Convert.ToDateTime(dr["SubmitTime"]);
                }
            }
            return user;
        }

        //获取用户列表
        public static List<Model.User> GetUsers()
        {
            List<Model.User> Users = new List<Model.User>();
            string sql = string.Format("SELECT * FROM [dbo].[UserDemo]");
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Model.User user = new Model.User();
                        user.UserID = Convert.ToInt32(dr["UserID"]);
                        user.UserName = dr["UserName"].ToString();
                        user.Password = dr["Password"].ToString();
                        user.Discribe = dr["Discribe"].ToString();
                        user.SubmitTime = Convert.ToDateTime(dr["SubmitTime"]);
                        Users.Add(user);
                    }
                }
            }
            return Users;
        }
    }
}
