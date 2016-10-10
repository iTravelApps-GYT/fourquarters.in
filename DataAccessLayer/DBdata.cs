using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using FourQuarterMVC.Models;

namespace FourQuarterMVC.DataAccessLayer
{
    public class DBdata
    {
        #region Variables Used

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        #endregion

        #region Insert Action..........

        public string insertTitle(UpdateTitle UT)
        {
            string result = "";
            try
            {
            cmd = new SqlCommand("SpHomeModule",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DDLValue",UT.DDlValues);
            cmd.Parameters.AddWithValue("@Title1",UT.Title);
            cmd.Parameters.AddWithValue("@Title2",UT.SubTitle);
            cmd.Parameters.AddWithValue("@ImagePath",UT.ImagePath);
            cmd.Parameters.AddWithValue("@Div1",UT.Div1);
            cmd.Parameters.AddWithValue("@Div1",UT.Div1);
            cmd.Parameters.AddWithValue("@Div1",UT.Div1);
            cmd.Parameters.AddWithValue("@Qtype","Insert");
            con.Open();
            result = cmd.ExecuteScalar().ToString();
            return result;

            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        
        #endregion
    }
}