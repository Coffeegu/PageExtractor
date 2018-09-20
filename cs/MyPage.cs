using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace WebApplication1.cs
{
    public class MyPage : System.Web.UI.Page
    {
        public MyPage()
        {
            // 
            // TODO: 在此处添加构造函数逻辑 
            // 
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(MyPage_Load);
        }

        //在页面加载的时候从缓存中提取用户信息 
        private void MyPage_Load(object sender, System.EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                if (Context.Cache["UserMessage"] != null)
                {
                    Hashtable userMessage = (Hashtable)Context.Cache["UserMessage"];
                    MyPrincipal principal = new MyPrincipal(userMessage["UserID"].ToString(), userMessage["UserPassword"].ToString());
                    Context.User = principal;
                }
            }
        }
    }
}