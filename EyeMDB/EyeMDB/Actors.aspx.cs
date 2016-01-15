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
    public partial class Actors : System.Web.UI.Page
    {
        static string connString = WebConfigurationManager.ConnectionStrings["EyeMDb"].ConnectionString;

        SqlConnection connnection = new SqlConnection(connString);
        SqlCommand command = new SqlCommand();
        SqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (string name in GetActorNames())
                    lbxActors.Items.Add(name);

                GetSelectedActorInformation("Harrison Ford");
            }
        }

        private List<String> GetActorNames()
        {
            List<string> results = new List<string>();

            try
            {
                connnection = new SqlConnection(connString);
                command.Connection = connnection;

                connnection.Open();

                command.CommandText = "SELECT ActorName FROM [dbo].[ActorTbl]";

                reader = command.ExecuteReader();

                while (reader.Read())
                    results.Add(reader["ActorName"].ToString());

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

        private void GetSelectedActorInformation(string actorName)
        {
            try
            {
                connnection = new SqlConnection(connString);
                command.Connection = connnection;

                connnection.Open();

                command.CommandText = "SELECT * FROM [dbo].[ActorTbl] WHERE ActorName ='" + actorName + "'";

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        lblActorName.Text = reader["ActorName"].ToString();
                        lblDob.Text = reader["DOB"].ToString();
                        lblNationality.Text = reader["Nationality"].ToString();
                        imgActor.ImageUrl = reader["ActorImageURL"].ToString();
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
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
                Response.Redirect("~/AddActor.aspx");
            else
                lblErrors.Text = "You need to be signed in to add an actor!";
        }

        protected void lbxActors_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxActors.SelectedIndex > -1)
            {
                string actorName = lbxActors.SelectedItem.Value.ToString();

                GetSelectedActorInformation(actorName);
            }
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            GetSelectedActorInformation(txtActors.Text);
        }
    }
}