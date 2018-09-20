using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Threading;
using System.Timers;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{

    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable team = GetTeamInfo();
                this.ddlTeam.DataSource = team;
                this.ddlTeam.DataTextField = "TeamName";
                this.ddlTeam.DataValueField = "TeamID";
                this.ddlTeam.DataBind();
                ListItem li = new ListItem("All", "0");
                this.ddlTeam.Items.Insert(0, li);
                ddlTeam.SelectedIndex = 0;
                DataTable major = DropdownlistDB.GetMemberByTeamID("*");
                this.ddlMember.DataSource = major;
                this.ddlMember.DataTextField = "UserName";
                this.ddlMember.DataValueField = "UserID";
                this.ddlMember.DataBind();
                ListItem lm = new ListItem("", "0");
                this.ddlMember.Items.Insert(0, lm);
            }
        }

        public static DataTable GetTeamInfo()
        {
            string sql = "select * from [dbo].[Team]";
            DataTable dt = OperatorDb.GetDataTable(sql);
            return dt;
        }
        public static DataTable GetMemberInfo(string UserID)
        {
            string sql = "select * from [dbo].[User],Team where UserTeam=TeamID";
            if (UserID != "0")
            {
                sql += " and UserID='" + UserID + "'";
            }
            DataTable dt = OperatorDb.GetDataTable(sql);
            return dt;
        }
        public static DataTable GetMemberByTeamID(string TeamID)
        {
            string sql = "select * from [dbo].[User],Team where UserTeam=TeamID";
            if (TeamID != "0")
            {
                sql += " and TeamID='" + TeamID + "'";
            }
            DataTable dt = OperatorDb.GetDataTable(sql);
            return dt;
        }

        protected void ddlTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable major = DropdownlistDB.GetMemberByTeamID(this.ddlTeam.SelectedValue);
            List<Member> memberList = new List<Member>();
            this.ddlMember.DataSource = major;
            this.ddlMember.DataTextField = "UserName";
            this.ddlMember.DataValueField = "UserID";
            this.ddlMember.DataBind();
            ListItem lm = new ListItem("", "");
            this.ddlMember.Items.Insert(0, lm);
        }

        protected void ddlMember_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSel_Click(object sender, EventArgs e)
        {
            DataTable ddd = new DataTable();
            if (this.ddlMember.SelectedValue == "" || this.ddlMember.SelectedValue == "0")
            {
                ddd = GetMemberByTeamID(this.ddlTeam.SelectedValue);
            }
            else
            {
                ddd = GetMemberInfo(this.ddlMember.SelectedValue);
            }

            DataView dv = new DataView(ddd);
            dv.Sort = "UserTeam ASC";
            GridView1.DataSource = dv;
            GridView1.DataBind();
            //GridView1.Columns
            MergeGridViewCell.MergeRow(GridView1, 0, 1);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            GridView1.Columns[4].Visible = true;
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].FindControl("CheckItem").Visible = (e.Row.Cells[2].Text.Trim() == "0" ? true : false);
                //e.Row.Cells[2].Text = (e.Row.Cells[2].Text.Trim() == "0" ? "No" : "Yes");
                //e.Row.Cells[0].FindControl("CheckItem").Visible = true;
            }
        }
        protected void btnDel_Click(object sender, EventArgs e)
        {
            int rowCount = GridView1.Rows.Count;

            string checkIDlink = "";


            for (int i = 0; i < rowCount; i++)
            {
                CheckBox tempChk = (CheckBox)GridView1.Rows[i].FindControl("CheckItem");
                HiddenField HidID = (HiddenField)GridView1.Rows[i].FindControl("HidID");
                if (tempChk.Checked == true)
                {
                    checkIDlink += HidID.Value + "|";
                }
            }


            if (String.IsNullOrEmpty(checkIDlink.Trim()))
            {
                string ErroMsg = @"<mce:script language=""javascript""><!--alert(""No Row is Selected!"")// --></mce:script>";
                Results.Text = ErroMsg;
                return;
            }
            checkIDlink = checkIDlink.Substring(0, checkIDlink.LastIndexOf("|"));


            int returnRows = DeleteUser(checkIDlink);

            //GridView1.DataSourceID = ***;
            GridView1.DataBind();
        }
        public int DeleteUser(string userIDLink)
        {
            string conStr = "server=.;database=Test;uid=sa;pwd=GZMgzm123";
            string[] userID = userIDLink.Split(Convert.ToChar("|"));
            string[] SQLs = new string[userID.Length];
            for (int i = 0; i < userID.Length; i++)
            {
                SQLs[i] = "Delete from [User] WHERE UserID = '" + Convert.ToInt32(userID[i]) + "'";
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    connection.Open();

                    SqlTransaction transaction;

                    // Start a local transaction.  
                    transaction = connection.BeginTransaction();

                    int executeCount = 0;
                    try
                    {
                        for (int i = 0; i < SQLs.Length; i++)
                        {
                            // Call the overload that takes a connection in place of the connection string
                            SqlCommand sqlCommand = connection.CreateCommand();
                            sqlCommand.CommandText = SQLs[i];
                            sqlCommand.CommandType = CommandType.Text;
                            sqlCommand.Transaction = transaction;
                            executeCount += sqlCommand.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new ArgumentNullException("The transaction is rollbacked , please check the execute SQL.");
                    }

                    transaction.Dispose();

                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    return executeCount;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

    }
    public interface ISchedulerJob
    {
        void Execute();
    }
    public class SampleJob : ISchedulerJob
    {
        public void Execute()
        {
            //文件保存的物理路径，CSTest为虚拟目录名称，F:\Inetpub\wwwroot\CSTest为物理路径
            string p = @"C:\Users\coffeeg\Desktop\Folder1";
            //我们在虚拟目录的根目录下建立SchedulerJob文件夹，并设置权限为匿名可修改，
            //SchedulerJob.txt就是我们所写的文件
            string FILE_NAME = p + "\\SchedulerJob\\SchedulerJob.txt";
            //取得当前服务器时间，并转换成字符串
            //SimpleDateFormat sdf = new SimpleDateFormat(" yyyy年MM月dd日 ");
            string c = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //标记是否是新建文件的标量
            bool flag = false;
            //如果文件不存在，就新建该文件
            if (!File.Exists(FILE_NAME))
            {
                flag = true;
                StreamWriter sr = File.CreateText(FILE_NAME);
                sr.Close();
            }
            //向文件写入内容
            StreamWriter x = new StreamWriter(FILE_NAME, true, System.Text.Encoding.UTF8);
            if (flag) x.Write("计划任务测试开始：");
            x.Write("\r\n" + c);
            x.Close();
        }
    }
    public class SchedulerConfiguration
    {
        //时间间隔
        private int sleepInterval;
        //任务列表
        private ArrayList jobs = new ArrayList();

        public int SleepInterval { get { return sleepInterval; } }
        public ArrayList Jobs { get { return jobs; } }

        //调度配置类的构造函数
        public SchedulerConfiguration(int newSleepInterval)
        {
            sleepInterval = newSleepInterval;
        }
    }
    public class Scheduler
    {
        private SchedulerConfiguration configuration = null;

        public Scheduler(SchedulerConfiguration config)
        {
            configuration = config;
        }

        public void Start()
        {
            while (true)
            {
                //执行每一个任务
                foreach (ISchedulerJob job in configuration.Jobs)
                {
                    ThreadStart myThreadDelegate = new ThreadStart(job.Execute);
                    Thread myThread = new Thread(myThreadDelegate);
                    myThread.Start();
                    Thread.Sleep(configuration.SleepInterval);
                }
            }
        }
    }


    /// <summary>

    /// 合并GridView单元格

    /// </summary>

    public class MergeGridViewCell

    {

        /// <summary>

        /// GridView Merge Row，

        /// </summary>

        /// <param name="gv">GridView</param>

        /// <param name="startCol">startColumn</param>

        /// <param name="endCol">endColumn</param>

        public static void MergeRow(GridView gv, int startCol, int endCol)

        {

            RowArg init = new RowArg()

            {

                StartRowIndex = 0,

                EndRowIndex = gv.Rows.Count - 2

            };

            for (int i = startCol; i < endCol + 1; i++)

            {

                if (i > 0)

                {

                    List<RowArg> list = new List<RowArg>();

                    //从第二列开始就要遍历前一列

                    TraversesPrevCol(gv, i - 1, list);

                    foreach (var item in list)

                    {

                        MergeRow(gv, i, item.StartRowIndex, item.EndRowIndex);

                    }

                }

                //合并开始列的行

                else

                {

                    MergeRow(gv, i, init.StartRowIndex, init.EndRowIndex);

                }

            }

        }



        /// <summary>

        /// Merging GridView Cells

        /// </summary>

        /// <param name="gv">The GridView to merge</param>

        /// <param name="cols">Set the columns to be passed in order</param>

        public static void MergeRow(GridView gv, params int[] cols)

        {

            RowArg init = new RowArg()

            {

                StartRowIndex = 0,

                EndRowIndex = gv.Rows.Count - 2

            };

            for (int i = 0; i < cols.Length; i++)

            {

                if (i > 0)

                {

                    List<RowArg> list = new List<RowArg>();

                    //从第二列开始就要遍历前一列

                    TraversesPrevCol(gv, cols[i - 1], list);

                    foreach (var item in list)

                    {

                        MergeRow(gv, cols[i], item.StartRowIndex, item.EndRowIndex);

                    }

                }

                //合并开始列的行

                else

                {

                    MergeRow(gv, i, init.StartRowIndex, init.EndRowIndex);

                }

            }

        }



        /// <summary>

        /// Traverse previous Column

        /// </summary>

        /// <param name="gv">GridView</param>

        /// <param name="prevCol">The previous column of current column</param>

        /// <param name="list"></param>

        private static void TraversesPrevCol(GridView gv, int prevCol, List<RowArg> list)

        {

            if (list == null)

            {

                list = new List<RowArg>();

            }

            RowArg ra = null;

            for (int i = 0; i < gv.Rows.Count; i++)

            {

                if (!gv.Rows[i].Cells[prevCol].Visible)

                {

                    continue;

                }

                ra = new RowArg();

                ra.StartRowIndex = gv.Rows[i].RowIndex;

                ra.EndRowIndex = ra.StartRowIndex + gv.Rows[i].Cells[prevCol].RowSpan - 2;

                list.Add(ra);

            }

        }



        /// <summary>

        /// Merging rows in a single column

        /// </summary>

        /// <param name="gv">GridView</param>

        /// <param name="currentCol">currentColumn</param>

        /// <param name="startRow">startRow</param>

        /// <param name="endRow">endRow</param>

        private static void MergeRow(GridView gv, int currentCol, int startRow, int endRow)

        {

            for (int rowIndex = endRow; rowIndex >= startRow; rowIndex--)

            {

                GridViewRow currentRow = gv.Rows[rowIndex];

                GridViewRow prevRow = gv.Rows[rowIndex + 1];

                if (currentRow.Cells[currentCol].Text != "" && currentRow.Cells[currentCol].Text != " ")

                {

                    if (currentRow.Cells[currentCol].Text == prevRow.Cells[currentCol].Text)

                    {

                        currentRow.Cells[currentCol].RowSpan = prevRow.Cells[currentCol].RowSpan < 1 ? 2 : prevRow.Cells[currentCol].RowSpan + 1;

                        prevRow.Cells[currentCol].Visible = false;

                    }

                }

            }

        }



        class RowArg

        {

            public int StartRowIndex { get; set; }

            public int EndRowIndex { get; set; }

        }

    }

    public class Member
    {
        public string Team { get; set; }
        public string Name { get; set; }

        public string Grade { get; set; }
    }
    public class OperatorDb
    {
        private static string conStr = "server=.;database=Test;uid=sa;pwd=GZMgzm123";
        //连接字符串，Initial Catalog设置为自己的数据库
        public static DataTable GetDataTable(string sql)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlDataAdapter ada = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            con.Close();
            return dt;
        }

    }

    public class DropdownlistDB
    {
        public static DataTable GetTeamInfo()
        {
            string sql = "select * from [dbo].[Team] ";
            DataTable dt = OperatorDb.GetDataTable(sql);
            return dt;
        }
        public static DataTable GetMemberInfo()
        {
            string sql = "select * from [dbo].[User] ";
            DataTable dt = OperatorDb.GetDataTable(sql);
            return dt;
        }
        public static DataTable GetMemberByTeamID(string groupID)
        {
            string sql = "";
            if (groupID == "*" || groupID == "0")
            {
                sql = "select * from [dbo].[User],Team where TeamID=UserTeam";
            }
            else
            {
                sql = "select * from [dbo].[User] where UserTeam='" + groupID + "'";
            }

            DataTable dt = OperatorDb.GetDataTable(sql);
            return dt;
        }
    }
}