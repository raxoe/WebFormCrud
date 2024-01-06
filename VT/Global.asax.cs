using System;
using System.Collections.Generic;
using System.IO;
//using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace VT
{
    public class People
    {
        public string name { get; set; }
        public string age{ get; set; }
    }
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["objApp"] = new People() { name="thura",age="30" }; //assign to Application

            if (Application["objApp"] != null)
            {
                People obj = (People)Application["objApp"];     //retrive from Application
            }

            Application["AppLevelMessage"] = "Application has started";

            string filePath = Context.Server.MapPath("Log.txt");
            string fileContent = "Applictaion has started";
            //Context.Server.WriteAllText(FilePath, FileContent);
            FileInfo _file = new FileInfo(filePath);

            using (FileStream fs = _file.Create())
            {
                Byte[] txt = new UTF8Encoding(true).GetBytes("New file.");
                fs.Write(txt, 0, txt.Length);
                Byte[] msg = new UTF8Encoding(true).GetBytes(Application["AppLevelMessage"].ToString());
                fs.Write(msg, 0, msg.Length);
            }

        }
        void Session_Start(object sender, EventArgs e)
        {
            Session["TestSessionStart"] = "SessionBegin";
        }

        void Session_End(object sender, EventArgs e)
        {            


            string result=Session["TestSessionStart"].ToString();            
        }

        void Application_End(object sender,EventArgs e)
        {
            string resultSession = Session["TestSessionStart"].ToString();
            string result = Application["AppLevelMessage"].ToString();
        }


    }
}