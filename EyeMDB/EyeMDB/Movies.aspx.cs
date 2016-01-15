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
                    lbxMovies.Items.Add(name);

                GetSelectedMovieInformation("Star Wars The Force Awakens");
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

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if(HttpContext.Current.Request.IsAuthenticated)
                Response.Redirect("~/AddMovie.aspx");
            else
                Response.Redirect("~/Home.aspx");
        }

        private void GetSelectedMovieInformation(string movieName)
        {
            int movieIDInt = 0;
            try
            {
                connnection = new SqlConnection(connString);
                command.Connection = connnection;

                connnection.Open();

                command.CommandText = "SELECT * FROM [dbo].[MovieTbl] WHERE Title ='" + movieName + "'";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        lblTitle.Text = reader["Title"].ToString();
                        lblReleased.Text = reader["ReleaseDate"].ToString();
                        lblStudio.Text = reader["Studio"].ToString();
                        lblDirector.Text = reader["Director"].ToString();
                        imgMovie.ImageUrl = reader["MovieArtURL"].ToString();
                        lblAdded.Text = reader["AddedBy"].ToString();

                        string movieID = reader["MovieId"].ToString();
                        movieIDInt = Convert.ToInt32(movieID);
                    }
                    catch (Exception ex)
                    {
                        lblErrors.Text = ex.Message;
                    }
                }

                reader.Close();

                command.CommandText = $"Select ActorName FROM [dbo].[ActorTbl] WHERE ActorId = '{movieIDInt}' ";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        lblActors.Text = reader["ActorName"].ToString();
                    }
                    catch (Exception ex)
                    {
                        lblErrors.Text = ex.Message;
                    }
                }

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
        }

        protected void lbxMovies_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMovies.SelectedIndex > -1)
            {
                string movieName = lbxMovies.SelectedItem.Value.ToString();

                GetSelectedMovieInformation(movieName);
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            GetSelectedMovieInformation(txtMovies.Text);
        }
    }
}