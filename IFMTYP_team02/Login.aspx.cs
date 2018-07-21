
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using IFMTYP_team02.Classes;

namespace IFMTYP_team02
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
                Response.Redirect("MyAds.aspx");

            Title = "twoGAMES: Log In";
        }

       protected void LoginUser_ServerClick(object sender, EventArgs e)
        {
            btnLogin.Disabled = true;
            loginSpinner.Visible = true;
            UserService.UserCRUDClient service = new UserService.UserCRUDClient();
            service.Open();
            Object[] ds = service.Authenticate(user_name.Value, Security.HashPassword(password.Value));
            //invalidLogin.InnerHtml = "<p>" +  Security.HashPassword(password.Value) +"</p>";
            UserData user = null;
            
            if (!(ds == null))
            {
                int ds5 = 0;
                int ds6 = 0;
                int ds7 = 0;

                if (Convert.ToBoolean(ds[5]))
                    ds5 = 1;
                if (Convert.ToBoolean(ds[6]))
                    ds6 = 1;
                if (Convert.ToBoolean(ds[7]))
                    ds7 = 1;

                user = new UserData(Convert.ToInt32((String)ds[0]), user_name.Value, (String)ds[1], (String)ds[2], (string)ds[3], Convert.ToDateTime((string)ds[4]), ds5, ds6, ds7);
                Session["User"] = user;
                Response.Redirect("Index.aspx");
            }
            else
            {
                invalidLogin.InnerHtml = "<p>Invalid username or password. Please try again.</p>";
                btnLogin.Disabled = false;
                loginSpinner.Visible = false;
            }
            service.Close();
        }
    }
}