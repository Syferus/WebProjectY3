using System;
using System.Collections.Generic;
using System.Data;
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
        private static string connString = WebConfigurationManager.ConnectionStrings["EyeMDb"].ConnectionString;

        private SqlConnection conn = new SqlConnection(connString);
        private SqlCommand command = new SqlCommand();
        private SqlDataReader queryResults;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["myAuthCookie"] != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies["myAuthCookie"].Value);

                string name = ticket.Name;
                string cookiePath = ticket.CookiePath;
                DateTime expiration = ticket.Expiration;
                bool expired = ticket.Expired;
                bool isPersisted = ticket.IsPersistent;
                DateTime issueDate = ticket.IssueDate;
                string userData = ticket.UserData;
                string version = ticket.Version.ToString();

                lblUsername.Text = $"Hi, {name}";
                login.Visible = false;
                loggedIn.Visible = true;
            }
            else
            {
                login.Visible = true;
                loggedIn.Visible = false;
            }
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
  //              command.CommandText =
       //             string.Format("select UserName, Password from UserTbl where UserName='{0}' and Password='{1}'",
         //               txtUsername.Text, md5Password);

                command.CommandText = "SELECT UserName, Password from UserTbl where UserName = @uName and Password = @uPassword";

                command.Parameters.Add("@uName", SqlDbType.VarChar);
                command.Parameters["@uName"].Value = txtUsername.Text;

                command.Parameters.AddWithValue("@uPassword", md5Password);

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

        protected void btnLogOut_OnClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            login.Visible = true;
            loggedIn.Visible = false;
        }


    }
}