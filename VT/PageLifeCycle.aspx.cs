using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VT
{
    public partial class PageLifeCycle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblmessage.Text += " load occour<br/>";
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //lblmessage.Text += " preinit occour<br/>";
        }
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            lblmessage.Text += " init complete occour<br/>";
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            lblmessage.Text += " init occour<br/>";
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            lblmessage.Text += " pre render occour<br/>";
        }
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            lblmessage.Text += "render complete occour<br/><br/><br/>";
        }
        protected void btnsubmit_click(object sender, EventArgs e)
        {
            lblmessage.Text += "submit event occour<br/>";
        }
    }
}