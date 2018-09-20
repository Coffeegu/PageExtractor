using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace WebApplication1
{
    /*public partial class login : System.Web.UI.Page
    {
        //private static string ConStr = "server=.;database=Test;uid=sa;pwd=GZMgzm123";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LogoutButton.Visible = true;
                LoginForm.Visible = true;
            }
        }

        public class IntRole : IdentityRole<int, IntUserRole>
        {
            public IntRole()
            {

            }
            public IntRole(string name) : this() { Name = name; }
        }
        public class IntUserRole : IdentityUserRole<int> { }
        public class IntUserClaim : IdentityUserClaim<int> { }
        public class IntUserLogin : IdentityUserLogin<int> { }

        public class IntUserContext : IdentityDbContext<ApplicationUser, IntRole, int, IntUserLogin, IntUserRole, IntUserClaim>
        {
            public IntUserContext()
                : base("DefaultConnection")
            {

            }
        }

        public class ApplicationDbContext:IdentityDbContext<ApplicationUser,IntRole,int, IntUserLogin, IntUserRole, IntUserClaim> 
        {
        }
        public class ApplicationUser : IdentityUser<int, IntUserLogin, IntUserRole, IntUserClaim>
        {
            public ApplicationUser() { }
            public async System.Threading.Tasks.Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
            {
                // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // 在此处添加自定义用户声明
                return userIdentity;
            }
            public ApplicationUser(string name) : this() { UserName = name; }
        }
        public class ApplicationUserManager : UserManager<ApplicationUser, int>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
                : base(store)
            {

            }


            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {
                var manager = new ApplicationUserManager(new IntUserStore(context.Get<ApplicationDbContext>()));

                // 配置用户名的验证逻辑
                manager.UserValidator = new UserValidator<ApplicationUser, int>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true,
                };

                // 配置密码的验证逻辑
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                // 配置用户锁定默认值
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                // 注册双重身份验证提供程序。此应用程序使用手机和电子邮件作为接收用于验证用户的代码的一个步骤
                // 你可以编写自己的提供程序并将其插入到此处。
                manager.RegisterTwoFactorProvider("电话代码", new PhoneNumberTokenProvider<ApplicationUser, int>
                {
                    MessageFormat = "你的安全代码是 {0}"
                });
                manager.RegisterTwoFactorProvider("电子邮件代码", new EmailTokenProvider<ApplicationUser, int>
                {
                    Subject = "安全代码",
                    BodyFormat = "你的安全代码是 {0}"
                });
                manager.EmailService = new EmailService();
                manager.SmsService = new SmsService();
                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<ApplicationUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
                }
                return manager;
            }
        }
        protected void SignIn(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            var user = userManager.Find(UserName.Text, Password.Text);

            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                Response.Redirect("~/WebForm1.aspx");
                //Response.Redirect("~/Login.aspx");
            }
            else
            {
                StatusText.Text = "Invalid username or password.";
                LoginStatus.Visible = true;
            }
        }

        protected void btn_Select(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }*/
    public partial class login : cs.MyPage
    {
        protected void SignIn(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            var user = userManager.Find(UserName.Text.Replace(" ",""), Password.Text);

            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                Response.Redirect("~/WebForm1.aspx");
                //Response.Redirect("~/Login.aspx");
            }
            else
            {
                StatusText.Text = "Invalid username or password.";
                LoginStatus.Visible = true;
            }
        }

        protected void btn_Select(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                LogoutButton.Visible = true;
                LoginForm.Visible = true;
            }
        }
        /*
        protected System.Web.UI.WebControls.TextBox tbxUserID;
        protected System.Web.UI.WebControls.TextBox tbxPassword;
        protected System.Web.UI.WebControls.Panel Panel1;
        protected System.Web.UI.WebControls.Button btnAdmin;
        protected System.Web.UI.WebControls.Button btnUser;
        protected System.Web.UI.WebControls.Label lblRoleMessage;
        protected System.Web.UI.WebControls.Label lblLoginMessage;
        protected System.Web.UI.WebControls.Button btnLogin;



        #region Web 窗体设计器生成的代码 
        override protected void OnInit(EventArgs e)
        {
            // 
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。 
            // 
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改 
        /// 此方法的内容。 
        /// </summary> 
        private void InitializeComponent()
        {
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            cs.MyPrincipal principal = new cs.MyPrincipal(tbxUserID.Text, tbxPassword.Text);
            if (!principal.Identity.IsAuthenticated)
            {
                lblLoginMessage.Text = "用户名或密码不正确";
                Panel1.Visible = false;
            }
            else
            {
                // 如果用户通过验证,则将用户信息保存在缓存中,以备后用 
                // 在实际中,朋友们可以尝试使用用户验证票的方式来保存用户信息,这也是.NET内置的用户处理机制 
                Context.User = principal;
                Hashtable userMessage = new Hashtable();
                userMessage.Add("UserID", tbxUserID.Text);
                userMessage.Add("UserPassword", tbxPassword.Text);
                Context.Cache.Insert("UserMessage", userMessage);
                lblLoginMessage.Text = tbxUserID.Text + "已经登录";
                Panel1.Visible = true;
            }
        }

        private void btnAdmin_Click(object sender, System.EventArgs e)
        {
            // 验证用户的Role中是否包含Admin 
            if (Context.User.IsInRole("Admin"))
            {
                lblRoleMessage.Text = "用户" + ((cs.MyPrincipal)Context.User).Identity.Name + "属于Admin组";
            }
            else
            {
                lblRoleMessage.Text = "用户" + Context.User.Identity.Name + "不属于Admin组";
            }
        }

        private void btnUser_Click(object sender, System.EventArgs e)
        {
            // 验证用户的Role中是否包含User 
            if (Context.User.IsInRole("User"))
            {
                lblRoleMessage.Text = "用户" + Context.User.Identity.Name + "属于User组";
            }
            else
            {
                lblRoleMessage.Text = "用户" + Context.User.Identity.Name + "不属于User组";
            }
        }*/
    }
}