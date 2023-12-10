using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace VT.Ado
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)    //only first time
            {
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["DbTestCon"].ConnectionString;            
            string query = "SELECT * FROM TblDemo";

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvList.DataSource = dt;
                        gvList.DataBind();
                    }
                }
            }


        }

        protected void gvList_RowCommand(object sender,CommandEventArgs e)
        {
            string command = e.CommandName;
            if (e.CommandName.ToLower() == "mydelete")
            {
                string id = e.CommandArgument.ToString();
                string constr = ConfigurationManager.ConnectionStrings["DbTestCon"].ConnectionString;
                string query = $"DELETE FROM TblDemo WHERE Id={id}";
                //string query = $"DELETE FROM TblDemo WHERE Id=@id";

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        //cmd.Parameters.AddWithValue("@id", id);                        

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                BindGrid();
            }
        }
    }
}