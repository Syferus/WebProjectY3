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
    public partial class Home : System.Web.UI.Page
    {
        static string connString = WebConfigurationManager.ConnectionStrings["EyeMDb"].ConnectionString;

        SqlConnection conn = new SqlConnection(connString);
        SqlCommand command = new SqlCommand();
        SqlDataReader queryResults;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}