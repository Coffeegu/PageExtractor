using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.cs
{
    public class MyIdentity:System.Security.Principal.IIdentity
    {
        private string userID;
        private string password;

        public MyIdentity(string currentUserID, string currentPassword)
        {
            // 
            // TODO: 在此处添加构造函数逻辑 
            // 
            userID = currentUserID;
            password = currentPassword;
        }

        private bool CanPass()
        {
            //这里朋友们可以根据自己的需要改为从数据库中验证用户名和密码， 
            //这里为了方便我直接指定的字符串 
            SqlConnection con = new SqlConnection("server=.;database=Test;uid=sa;pwd=GZMgzm123");
            using (SqlCommand sc = new SqlCommand())
            {
                string sql = "";
                con.Open();
                sc.Connection = con;
                sc.CommandType = CommandType.Text;
                SqlDataReader sr = null;
                if (!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(password))
                {
                    sql="select UserPassword from[User] where UserName='"+userID+"'";
                    sc.CommandText = sql;
                    sr = sc.ExecuteReader();
                    if (sr.Read())
                    {
                        if (password == Convert.ToString(sr[0]))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            
            
    }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        #region IIdentity 成员 

        public bool IsAuthenticated
        {
            get
            {
                // TODO:   添加 MyIdentity.IsAuthenticated getter 实现 
                return CanPass();
            }
        }

        public string Name
        {
            get
            {
                // TODO:   添加 MyIdentity.Name getter 实现 
                return userID;
            }
        }

        //这个属性我们可以根据自己的需要来灵活使用,在本例中没有用到它 
        public string AuthenticationType
        {
            get
            {
                // TODO:   添加 MyIdentity.AuthenticationType getter 实现 
                return null;
            }
        }

        #endregion
    }
}