using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyeMDB
{
    public partial class AddMovie : System.Web.UI.Page
    {
        private static string connString = WebConfigurationManager.ConnectionStrings["EyeMDb"].ConnectionString;

        private SqlConnection conn = new SqlConnection(connString);
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        private SqlDataReader queryResults;

        public delegate string MovieDelegate(string s1, string s2);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    conn.Open();
                    command.Connection = conn;

                    string userName = "N/A";

                    if (Request.Cookies["myAuthCookie"] != null) // Checking authentication cookie for the user's name.
                    {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies["myAuthCookie"].Value);

                        userName = ticket.Name;
                    }

                    AddMovie.MovieDelegate del = new AddMovie.MovieDelegate(CombineText);
                    string img = string.IsNullOrEmpty(tbxMovieImage.Text) ? "" : tbxMovieImage.Text;
                    string values = PutAllTogether(del, tbxTitle.Text, tbxDirector.Text, tbxReleaseDate.Text, img, tbxStudio.Text, userName);

                    command.CommandText = $"insert into MovieTbl (Title, Director, ReleaseDate, MovieImageURL) values ({values}) ";
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                }

                Response.Redirect("Movies.aspx");
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx");
        }

        public string CombineText(string s1, string s2)
        {
            return $"'{s1}', '{s2}'";
        }

        public string PutAllTogether(MovieDelegate d, string s1, string s2, string s3, string s4, string s5, string s6)
        {
            return $"{d(s1, s2)} , {d(s3, s4)} , {d(s5, s6)}";
        }
    }
}