using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VT.StateManagement
{
    public partial class StateManagement : System.Web.UI.Page
    {
        public int counter
        {
            get
            {
                if (ViewState["pcounter"] != null)
                {
                    return ((int)ViewState["pcounter"]);
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["pcounter"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = counter.ToString();
            counter++;
        }

        protected void btnSetSession_Click(object sender, EventArgs e)
        {
            Session["UserName"] = txtName.Text;            
        }

        protected void btnRetriveSession_Click(object sender,EventArgs e)
        {
            lblMessage.Text = Session["UserName"].ToString();
        }

    }
}