using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EyeMDB
{
    public partial class AddMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Movies.aspx");
        }
    }
}