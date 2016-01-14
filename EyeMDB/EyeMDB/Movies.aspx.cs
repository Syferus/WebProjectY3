using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyeMDB
{
    public partial class Movies : System.Web.UI.Page
    {
        static string connString = WebConfigurationManager.ConnectionStrings["EyeMDb"].ConnectionString;

        SqlConnection connnection = new SqlConnection(connString);
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (string name in GetMovieNames())
                    lblTitle.Text = name;
            }
        }
        private List<String> GetMovieNames()
        {
            List<string> results = new List<string>();

            try
            {
                connnection = new SqlConnection(connString);
                command.Connection = connnection;

                connnection.Open();

                command.CommandText = "SELECT Title FROM [dbo].[MovieTbl]";

                reader = command.ExecuteReader();

                while (reader.Read())
                    results.Add(reader["Title"].ToString());

                reader.Close();
            }
            catch (Exception ex)
            {
                lblErrors.Text = ex.Message;
            }
            finally
            {
                connnection.Close();
            }

            return results;
        } 
    }
}