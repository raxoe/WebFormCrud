using BusinessLogic;
using BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
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
            //string constr = ConfigurationManager.ConnectionStrings["DbTestCon"].ConnectionString;
            //string query = $"SELECT * FROM TblDemo where Id={id}";

            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        //using (var reader = cmd.ExecuteReader())
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                var foo = reader[1];    //testing
            //                hdnId.Value = reader.GetInt32(reader.GetOrdinal("Id")).ToString();
            //                txtName.Text = reader.GetString(reader.GetOrdinal("Name"));
            //                txtCategory.Text = reader.GetString(reader.GetOrdinal("Category"));
            //                txtDescription.Text = reader.GetString(reader.GetOrdinal("Description"));
            //            }

            //            //return null;
            //        }

            //        //object obj = cmd.ExecuteScalar();
            //        //var fristCell = obj.ToString();

            //        con.Close();
            //    }
            //}

            DemoBL demoBl = new DemoBL();
            DemoBO demoBO = demoBl.GetDemoById(Convert.ToInt32(id));
            hdnId.Value = demoBO.Id.ToString();
            txtName.Text = demoBO.Name;
            txtCategory.Text = demoBO.Category;
            txtDescription.Text = demoBO.Description;


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string id = hdnId.Value.ToString();
                DemoBL demoBl = new DemoBL();
                DemoBO demoBO = demoBl.GetDemoById(Convert.ToInt32(id));
                demoBO.Id = Convert.ToInt32(hdnId.Value);
                demoBO.Name= txtName.Text;
                demoBO.Category = txtCategory.Text;
                demoBO.Description= txtDescription.Text;

                demoBl.UpdateDemo(demoBO);

                Response.Redirect("List.aspx");
            }
            catch (Exception ex)
            {
                //log.Error(ex.message.tostring());
            }
            finally
            {

                lblInfo.Text = "Something got wrong, please contact to administrator";
            }
        }
    }
}