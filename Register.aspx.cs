using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
namespace WebApplication1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable team = DropdownlistDB.GetTeamInfo();
                this.ddlTeam.DataSource = team;
                this.ddlTeam.DataTextField = "TeamName";
                this.ddlTeam.DataValueField = "TeamID";
                this.ddlTeam.DataBind();
                ddlTeam.SelectedIndex = 0;
            }
            
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            if (!AddUrl(UserName.Text))
            {
                StatusMessage.Text = "The html doesn't have content.";
                return;
            }
            else if (!AddUser(UserName.Text, Password.Text,this.ddlTeam.SelectedValue))
            {
                StatusMessage.Text = "This user already exists.";
                return;
            }

            var user = new IdentityUser() { UserName = UserName.Text.Replace(" ", "") };
            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                //StatusMessage.Text = string.Format("User {0} was created successfully!", user.UserName);
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                //DefaultAuthenticationTypes.ApplicationCookie.
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                Response.Redirect("~/WebForm1.aspx");
            }
            else
            {
                StatusMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        public bool AddUrl(string name)
        {
            string url = "https://social.msdn.microsoft.com/Profile/" + name + "/activity/";

            Console.WriteLine("Now loading " + url);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.Accept = "text/html";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0;Win64;x64)";
            //req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0)";

            try
            {
                string html = null;
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                {
                    html = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(html) || html.Contains("The resource you are looking for has been removed, had its name changed, or is temporarily unavailable."))
                    {
                        //Response.Write("The html doesn't have content.");
                        return false;
                    }
                    else
                    {
                        //Response.Write("You can add it normally");
                        return true;
                    }
                }
            }
            catch (WebException we)
            {
                Console.Write(we.Message);
                //Response.Write("The html doesn't have content.");
                return false;
            }
        }

        public bool AddUser(string name, string password,string team)
        {
            int i = 0;
            SqlConnection con = new SqlConnection("server=.;database=Test;uid=sa;pwd=GZMgzm123");
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    string sqlStr = "INSERT INTO [User](UserName,UserPassword,UserTeam) VALUES('" + name + "','" + password + "','" + team + "')";
                    cmd.Connection = con;
                    cmd.CommandText = sqlStr;
                    cmd.CommandType = CommandType.Text;
                    i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        con.Close();
                        return true;
                    }
                    else
                    {
                        con.Close();
                        return false;
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
                return false;
            }
            
        }

        protected void btn_return_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTeam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}