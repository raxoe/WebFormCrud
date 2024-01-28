using BusinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    public class DemoDA
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbTestCon"].ToString());

        public void AddDemo(DemoBO demoBo)
        {
            try
            {
                string query = "INSERT INTO TblDemo Values (@Name,@Category,@Description)";
                //using (SqlConnection con = new SqlConnection(constr))
                //{
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Name", demoBo.Name);
                    cmd.Parameters.AddWithValue("@Category", demoBo.Category);
                    cmd.Parameters.AddWithValue("@Description", demoBo.Description);

                    cmd.Connection = con;
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

                con.Close();
                con.Dispose();
            }
        }

        public List<DemoBO> GetDemo()
        {
            List<DemoBO> lstDemoBO = new List<DemoBO>();
            try
            {
                string query = "SELECT * FROM TblDemo";

                using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);

                        lstDemoBO = (from DataRow dr in dt.Rows
                                     select new DemoBO()
                                     {
                                         Id = Convert.ToInt32(dr["Id"]),
                                         Name = dr["Name"].ToString(),
                                         Category = dr["Category"].ToString(),
                                         Description = dr["Description"].ToString(),
                                     }
                                    ).ToList();


                    }
                }

            }
            catch (Exception ex) { throw; }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return lstDemoBO;
        }

        public DemoBO GetDemoById(int id)
        {
            DemoBO demoBO = new DemoBO();
            try
            {
                string query = $"SELECT * FROM TblDemo where Id={id}";


                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    //using (var reader = cmd.ExecuteReader())
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            demoBO.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            demoBO.Name = reader.GetString(reader.GetOrdinal("Name"));
                            demoBO.Category = reader.GetString(reader.GetOrdinal("Category"));
                            demoBO.Description = reader.GetString(reader.GetOrdinal("Description"));
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return demoBO;
        }

        public void UpdateDemo(DemoBO demoBO)
        {
            try
            {
                string query = "UPDATE TblDemo SET Name=@Name,Category=@Category,Description=@Description where Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@Name", demoBO.Name);
                    cmd.Parameters.AddWithValue("@Category", demoBO.Category);
                    cmd.Parameters.AddWithValue("@Description", demoBO.Description);
                    cmd.Parameters.AddWithValue("@Id", demoBO.Id);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void Delete(int id)
        {
            try
            {
                string query = $"DELETE FROM TblDemo WHERE Id={id}";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
