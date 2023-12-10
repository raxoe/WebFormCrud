using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VT.Ado
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["DbTestCon"].ConnectionString;
            //string query = $"INSERT INTO TblDemo (Name,Category,Description) Values ({txtName.Text},{txtCategory.Text},{txtDescription.Text})";
            string query = "INSERT INTO TblDemo Values (@Name,@Category,@Description)";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Name", txtNameFoo.Text);
                    cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);

                    cmd.Connection = con;
                    con.Open();                    

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("List.aspx");
        }
    }
}