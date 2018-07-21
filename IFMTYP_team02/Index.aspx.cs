using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IFMTYP_team02.Classes;

namespace IFMTYP_team02
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null) //Logged in
            {
                indexTitle.InnerHtml = "Welcome " + ((UserData)Session["User"]).getFirstName() + ", here are the latest ads";
            }

            Title = "twoGAMES: Home";

            AdService.AdCRUDClient adCRUDService = new AdService.AdCRUDClient();
            adCRUDService.Open();
            Object[][] ads = adCRUDService.getRecentlyAdded();
            adCRUDService.Close();

            if (ads != null)
            {
                string recentAds = "<div class='row'>";

                for (int k = 0; k < ads.Length; k++)
                {
                    if ((k % 2) != 0)
                    {
                        recentAds += AdCard.createAdCard((string)ads[k][0], (string)ads[k][1], (string)ads[k][2], (string)ads[k][3], (string)ads[k][4], (string)ads[k][5], Convert.ToBoolean(ads[k][6]), "DetailedAd.aspx", false);
                        recentAds += "</div>";
                        recentAds += "<div class=\"row\">";
                    }
                    else
                    {
                        recentAds += AdCard.createAdCard((string)ads[k][0], (string)ads[k][1], (string)ads[k][2], (string)ads[k][3], (string)ads[k][4], (string)ads[k][5], Convert.ToBoolean(ads[k][6]), "DetailedAd.aspx", false);
                    }
                }

                recentAds += "</div>";

                recentlyAddedView.InnerHtml = recentAds;
            }
        }
    }
}