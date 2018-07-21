using IFMTYP_team02.Classes;
using System;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Title = "twoGAMES: Search";

                //string searchTerm = Request.QueryString.Get("search");
                searchedAdsDisplay.InnerHtml = "";
                //txtSearch.Value = ""; ----------breaks search when button clicked

                //Retrieve and populate platforms list

                AdService.AdCRUDClient service = new AdService.AdCRUDClient();
                service.Open();
                Object[] platforms = service.getPlatforms();
                if (!(platforms == null))
                {
                    //PlatformDrop.Items.Add(new ListItem("Platform",""));      
                    //InnerHtml = "<option value='' disabled selected>Platform</option>";
                    PlatformDrop.Items.Clear();
                    PlatformDrop.Items.Add(new ListItem("All", "default"));
                    for (int i = 0; i <= platforms.Length - 1; i++)
                    {
                        PlatformDrop.Items.Add(new ListItem(Convert.ToString(platforms[i]), Convert.ToString(platforms[i])));
                        //PlatformDrop.InnerHtml += "<option value='"+ Convert.ToString(platforms[i]) + "' disabled selected>" + Convert.ToString(platforms[i]) + "</option>";
                    }
                }
                else
                {
                    PlatformDrop.Items.Add(new ListItem("XBOX ONE", "XBOX ONE"));
                    PlatformDrop.Items.Add(new ListItem("PS4", "PS4"));
                    PlatformDrop.Items.Add(new ListItem("XBOX 360", "XBOX 360"));
                    PlatformDrop.Items.Add(new ListItem("PS3", "PS3"));
                    PlatformDrop.Items.Add(new ListItem("3DS", "3DS"));
                    PlatformDrop.Items.Add(new ListItem("WII U", "WII U"));
                    PlatformDrop.Items.Add(new ListItem("GAMECUBE", "GAMECUBE"));
                }
                service.Close();

                txtSearch.Focus(); 
            }
        }

        protected void btnSearch_ServerClick(object sender, EventArgs e)
        {
            searchedAdsDisplay.InnerHtml = "";

            if(txtSearch.Value.Equals(""))
            {
                searchedAdsDisplay.InnerHtml = "<div class='col s12 m10 l8 push-m1 push-l2'>";
                searchedAdsDisplay.InnerHtml += "<div class='card white'>";
                searchedAdsDisplay.InnerHtml += "<div class='card-content Black-text'>";
                searchedAdsDisplay.InnerHtml += "<span class='card-title bold'>Ah Ha...Gotcha!</span>";
                searchedAdsDisplay.InnerHtml += "<div class='row'>";
                searchedAdsDisplay.InnerHtml += "<p>See what you did there. Try entering a search term now...who knows what will happen?</p>";
                searchedAdsDisplay.InnerHtml += "</div>";
                searchedAdsDisplay.InnerHtml += "</div>";
                searchedAdsDisplay.InnerHtml += "</div>";
                searchedAdsDisplay.InnerHtml += "</div>";
                txtSearch.Value = "";
                txtSearch.Focus();
                return;
            }

            AdService.AdCRUDClient adCRUDService = new AdService.AdCRUDClient();
            adCRUDService.Open();
            Object[][] ads = null;

            //-------FILTERS
            string strSQLFilters = "";
            string strSQLOrderBys = "";

            //-------SORT DROP
            if (SortDrop.Items[SortDrop.SelectedIndex].Value.Equals("titleAZ"))
            {
                strSQLOrderBys = "aTitle ASC, ";
            }
            else if (SortDrop.Items[SortDrop.SelectedIndex].Value.Equals("titleZA"))
            {
                strSQLOrderBys = "aTitle DESC, ";
            }
            else if (SortDrop.Items[SortDrop.SelectedIndex].Value.Equals("platformAZ"))
            {
                strSQLOrderBys = "aPlatform ASC, ";
            }
            else if (SortDrop.Items[SortDrop.SelectedIndex].Value.Equals("platformZA"))
            {
                strSQLOrderBys = "aPlatform DESC, ";
            }
            else if (SortDrop.Items[SortDrop.SelectedIndex].Value.Equals("priceHighLow"))
            {
                strSQLOrderBys = "aPrice DESC, ";
            }
            else if (SortDrop.Items[SortDrop.SelectedIndex].Value.Equals("priceLowHigh"))
            {
                strSQLOrderBys = "aPrice ASC, ";
            }

            //-------PLATFORM DROP
            if (!PlatformDrop.Items[PlatformDrop.SelectedIndex].Value.Equals("default"))
            {
                strSQLFilters += "AND (aPlatform='"+ PlatformDrop.Items[PlatformDrop.SelectedIndex].Value+ "') ";
            }

            //-------LOCATION DROP
            if (!LocationDrop.Items[LocationDrop.SelectedIndex].Value.Equals("default"))
            {
                strSQLFilters += "AND (aLocation LIKE '%" + LocationDrop.Items[LocationDrop.SelectedIndex].Value + "%') ";
            }

            //-------PRICE DROP
            if (PriceDrop.Items[PriceDrop.SelectedIndex].Value.Equals("0-100"))
            {
                strSQLFilters += "AND (aPrice <= 100) ";
            }
            else if (PriceDrop.Items[PriceDrop.SelectedIndex].Value.Equals("100-200"))
            {
                strSQLFilters += "AND (aPrice > 100) AND (aPrice <= 200) ";
            }
            else if (PriceDrop.Items[PriceDrop.SelectedIndex].Value.Equals("200-300"))
            {
                strSQLFilters += "AND (aPrice > 200) AND (aPrice <= 300) ";
            }
            else if (PriceDrop.Items[PriceDrop.SelectedIndex].Value.Equals("300-400"))
            {
                strSQLFilters += "AND (aPrice > 300) AND (aPrice <= 400) ";
            }
            else if (PriceDrop.Items[PriceDrop.SelectedIndex].Value.Equals("400+"))
            {
                strSQLFilters += "AND (aPrice > 400) ";
            }

            /*if (((UserData)Session["User"]).isAdmin() == 0 && ((UserData)Session["User"]).isMod() == 0)
            {*/
                ads = adCRUDService.searchAds(txtSearch.Value, strSQLFilters, strSQLOrderBys); 
            /*}
            else
            {
                ads = adCRUDService.searchAdsManagement(txtSearch.Value, "");
            }*/
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

                searchedAdsDisplay.InnerHtml = recentAds;
                txtSearch.Focus();
            }
            else
            {
                searchedAdsDisplay.InnerHtml = "<div class='col s12 m10 l8 push-m1 push-l2'>";
                searchedAdsDisplay.InnerHtml += "<div class='card white'>";
                searchedAdsDisplay.InnerHtml += "<div class='card-content Black-text'>";
                searchedAdsDisplay.InnerHtml += "<span class='card-title bold'>Oh No...Where Did They Go?</span>";
                searchedAdsDisplay.InnerHtml += "<div class='row'>";
                searchedAdsDisplay.InnerHtml += "<p>It looks like you've searched for ads which haven't been posted yet<br/><br/>You can help with that by clicking the \"Register\" button bellow to register your account</p>";
                searchedAdsDisplay.InnerHtml += "</div>";
                searchedAdsDisplay.InnerHtml += "<div class='row'>";
                searchedAdsDisplay.InnerHtml += "<a href=\"Registration.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Register</a> ";
                //searchedAdsDisplay.InnerHtml += "<a href=\"Index.aspx\" runat=\"server\" class=\"btn waves-effect waves-light red\">Cancel</a>";
                searchedAdsDisplay.InnerHtml += "</div>";
                searchedAdsDisplay.InnerHtml += "</div>";
                searchedAdsDisplay.InnerHtml += "</div>";
                searchedAdsDisplay.InnerHtml += "</div>";
            }
        }
    }
}