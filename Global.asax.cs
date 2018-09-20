using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
namespace WebApplication1
{
    public class Global : HttpApplication
    {
        public System.Threading.Thread schedulerThread = null;
        protected void Application_Start(Object sender, EventArgs e)
        {
            int nowhour = Convert.ToInt32(DateTime.Now.Hour.ToString());
            int nowmin = Convert.ToInt32(DateTime.Now.Minute.ToString());
            SchedulerConfiguration config = new SchedulerConfiguration(1000000 * 3);
            //config.Jobs.Add(new SampleJob());
            //Scheduler scheduler = new Scheduler(config);
            //System.Threading.ThreadStart myThreadStart = new System.Threading.ThreadStart(scheduler.Start);
            //System.Threading.Thread schedulerThread = new System.Threading.Thread(myThreadStart);

            /*config.Jobs.Add(new GraspJob());
            Scheduler scheduler = new Scheduler(config);
            System.Threading.ThreadStart myThreadStart = new System.Threading.ThreadStart(scheduler.Start);
            System.Threading.Thread schedulerThread = new System.Threading.Thread(myThreadStart);
            //if ((nowhour >= 13 && nowmin >= 48) && (nowhour >= 13 && nowmin < 50))
            //{
                schedulerThread.Start();
            //}
            /*schedulerThread.Start();
            System.Timers.Timer tr1 = new System.Timers.Timer(8000);
            tr1.AutoReset = true;
            tr1.Enabled = true;
            tr1.Start();
            tr1.Elapsed += new System.Timers.ElapsedEventHandler(tr1_Elapsed);
            */
        }
        void tr1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            int nowhour = Convert.ToInt32(DateTime.Now.Hour.ToString());
            int nowmin = Convert.ToInt32(DateTime.Now.Minute.ToString());
            SchedulerConfiguration config = new SchedulerConfiguration(1000 * 3);
            config.Jobs.Add(new SampleJob());
            Scheduler scheduler = new Scheduler(config);
            System.Threading.ThreadStart myThreadStart = new System.Threading.ThreadStart(scheduler.Start);
            System.Threading.Thread schedulerThread = new System.Threading.Thread(myThreadStart);
            if ((nowhour >= 10 && nowmin >= 28) && (nowhour >= 11 && nowmin < 29)) 
            {
                
                schedulerThread.Start();
            }
            else
            {
                schedulerThread.Abort();
                while (schedulerThread.ThreadState != ThreadState.Aborted)
                {
                    Thread.Sleep(100);
                }
            }
        }
        protected void Application_End(Object sender, EventArgs e)
        {
            if (null != schedulerThread)
            {
                schedulerThread.Abort();
            }
        }
    }
}