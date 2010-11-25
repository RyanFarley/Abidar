using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;

namespace Abidar.TestSite
{
    public class Global : System.Web.HttpApplication
    {
        private TaskScheduler _scheduler = null;

        protected void Application_Start(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Server.MapPath(@"\config\tasks.config"));
            XmlNodeList nodes = xml.SelectNodes("Tasks/Task");

            this._scheduler = new TaskScheduler(nodes);
            this._scheduler.StartTasks();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            this._scheduler.StopTasks();
        }
    }
}