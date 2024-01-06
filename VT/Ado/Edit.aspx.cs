using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VT.Ado
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("List.aspx");
            }
            if (!IsPostBack)
            {
                BindDetail();
            }
        }

        protected void BindDetail()
        {
            string id = Request.QueryString["id"].ToString();
            string constr = ConfigurationManager.ConnectionStrings["DbTestCon"].ConnectionString;
            string query = $"SELECT * FROM TblDemo where Id={id}";

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    //using (var reader = cmd.ExecuteReader())
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var foo = reader[1];    //testing
                            hdnId.Value = reader.GetInt32(reader.GetOrdinal("Id")).ToString();
                            txtName.Text = reader.GetString(reader.GetOrdinal("Name"));
                            txtCategory.Text = reader.GetString(reader.GetOrdinal("Category"));
                            txtDescription.Text = reader.GetString(reader.GetOrdinal("Description"));
                        }

                        //return null;
                    }

                    //object obj = cmd.ExecuteScalar();
                    //var fristCell = obj.ToString();

                    con.Close();
                }
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string id = hdnId.Value.ToString();
                //log.Trace("tblDemo querystring ID : " + id);
                string constr = ConfigurationManager.ConnectionStrings["DbTestCon"].ConnectionString;
                constr = "foo";
                string query = "UPDATE TblDemo SET Name=@Name,Category=@Category,Description=@Description where Id=@Id";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@Id", id);

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                //log.Info("Updated successfully for "+id);
                Response.Redirect("List.aspx");
            }
            catch(Exception ex)
            {
                //log.Error(ex.message.tostring());
            }
            finally{
                
                lblInfo.Text = "Something got wrong, please contact to administrator";
            }
        }
    }
}