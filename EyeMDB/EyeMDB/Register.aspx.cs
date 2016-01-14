using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.Security;

namespace EyeMDB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static string connString = WebConfigurationManager.ConnectionStrings["EyeMDb"].ConnectionString;

        private SqlConnection conn = new SqlConnection(connString);
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        private SqlDataReader queryResults;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private static string GetMd5Hash(string input)
        {
            string output = "";

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                foreach (byte b in data)
                {
                    output = output + b.ToString("x2");
                }
            }
            return output;
        }

        protected void btnReg_OnClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    conn.Open();
                    command.Connection = conn;

                    //command.CommandText = "INSERT into UserTbl (UserName, FirstName, LastName, Email, Password) values ('" + tbxUserName.Text + "', '" +
                    //  tbxFirstName.Text + "', '" + tbxSurname.Text +
                    //  "', '" + tbxEmail.Text + "', '" + GetMd5Hash(tbxPassword.Text) + "')";
                    //command.ExecuteNonQuery();
                    // Checking if username is already in database
                    command.CommandText =
                        string.Format(
                            "SELECT UserName, Password from UserTbl where UserName='{0}' and Password='{1}'",
                            tbxUserName.Text, GetMd5Hash(tbxPassword.Text));

                    queryResults = command.ExecuteReader();

                    if (queryResults.Read())
                    {
                        lblError.Text =
                            string.Format("The user name {0} already exists - please provide a different user name",
                                tbxUserName.Text);
                        queryResults.Close();
                    }
                    else
                    {
                        queryResults.Close();

                        //insert data into the database
                        command.CommandText = "INSERT into UserTbl (UserName, FirstName, LastName, Email, Password) values ('" + tbxUserName.Text + "', '" +
                                              tbxFirstName.Text + "', '" + tbxSurname.Text +
                                              "', '" + tbxEmail.Text + "', '" + GetMd5Hash(tbxPassword.Text) + "')";
                        command.ExecuteNonQuery();

                        FormsAuthentication.RedirectFromLoginPage(tbxUserName.Text, true);
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }

            Response.Redirect("~/Home.aspx");
        }
    }
}