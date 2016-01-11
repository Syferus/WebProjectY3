using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyeMDB
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        static string connString = WebConfigurationManager.ConnectionStrings["EyeMDb"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand command = new SqlCommand();
        SqlDataReader queryResults;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_OnClick_(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }

        protected void btnLogIn_OnClick(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                command.Connection = conn;

                string md5Password = GetMd5Hash(txtPassword.Text);

                //read data from the database - to check if the user name and password exist
                command.CommandText = string.Format("select UserName, Password from usersTbl where UserName='{0}' and UserPassword='{1}'", txtUsername.Text, md5Password);

                queryResults = command.ExecuteReader();

                // check if the login was successful
                if (queryResults.Read())
                    FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, true);

                else
                    lblError.Text = "No such user or wrong password";

                queryResults.Close();

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

        static string GetMd5Hash(string input)
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
    }
}