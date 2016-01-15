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
    public partial class AddActor : System.Web.UI.Page
    {

        private static string connString = WebConfigurationManager.ConnectionStrings["EyeMDb"].ConnectionString;

        private SqlConnection conn = new SqlConnection(connString);
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        private SqlDataReader queryResults;

        public delegate string ActorDelegate(string s1, string s2);

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

                    ActorDelegate del = new ActorDelegate(CombineText);
                    string img = string.IsNullOrEmpty(tbxImage.Text) ? "" : tbxImage.Text;
                    string values = PutAllTogether(del, tbxActorName.Text, tbxNationality.Text,tbxDOB.Text,img);

                    command.CommandText = $"insert into ActorTbl (ActorName, Nationality, DOB, ActorImageURL) values ({values}) ";
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

                Response.Redirect("Actors.aspx");
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Actors.aspx");
        }


        public string CombineText(string s1, string s2 )
        {
            return $"'{s1}', '{s2}'";
        }

        public string PutAllTogether(ActorDelegate d, string s1, string s2, string s3, string s4)
        {
            return $"{d(s1, s2)} , {d(s3, s4)}";
        }
    }
}