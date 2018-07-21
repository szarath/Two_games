using System;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;
using Google.Apis.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using IFMTYP_team02.Classes;

namespace IFMTYP_team02
{
    public partial class PostAd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Title = "twoGAMES: Post Ad";

                //Retrieve and populate platforms list

                AdService.AdCRUDClient service = new AdService.AdCRUDClient();
                service.Open();
                Object[] platforms = service.getPlatforms();
                if (!(platforms == null))
                {
                    //PlatformDrop.Items.Add(new ListItem("Platform",""));      
                    //InnerHtml = "<option value='' disabled selected>Platform</option>";
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
            }
        }

        protected void btnPostAd_ServerClick(object sender, EventArgs e)
        {
            Boolean postad = true;
            //string adultResponse = "NOINFO";
            //string spoofResponse = "NOINFO";


            if (txtGameTitle.Value.Equals("") || txtPrice.Value == null || PlatformDrop.Items[PlatformDrop.SelectedIndex].Text.Equals("Platform") || txtGameDesc.Value.Equals(""))
            {
                InvlaidPostAd.InnerHtml = "<p>Please fill in all the fields</p>";
                postad = false;
                return;
            }
            else
            {
                try
                {
                    int temp = Int32.Parse(txtPrice.Value);
                }
                catch (FormatException ex)
                {
                    txtPrice.Value = "";
                    InvlaidPostAd.InnerHtml = "<p>Please fill in a price</p>";
                    postad = false;
                    return;
                }
                catch (OverflowException ex)
                {
                    txtPrice.Value = "";
                    InvlaidPostAd.InnerHtml = "<p>It seems the price you entered is two high.</p>";
                    postad = false;
                    return;
                }

            }

            if (pic1files.PostedFile.ContentLength == 0 && pic2files.PostedFile.ContentLength == 0 && pic3files.PostedFile.ContentLength == 0)
            {
                InvlaidPostAd.InnerHtml = "<p>Please add at least one picture</p>";
                postad = false;
                return;
            }



            if (postad)
            {
                int negChecked = 0;
                int ShowPhoneChecked = 0;
                if (NegotiableCheck.Checked)
                    negChecked = 1;
                if (ShowPhone.Checked)
                    ShowPhoneChecked = 1;



                //--------------------------------------------------------------------IMAGES

                //create service
                //var visionCredentails = CreateCredentials("C:\\Users\\James McGuire\\Desktop\\IMF third year project-46cd5c28569b.json");
                //var visionService = CreateService("twoGames", visionCredentails);
                

                //**************Check files exist********************
                string base64String1 = "";
                string base64String2 = "";
                string base64String3 = "";


                //----------------Check if there is PIC 1
                if (pic1files.PostedFile.ContentLength != 0)
                {
                    base64String1 = ImageFunctions.validateImage(new BinaryReader(pic1files.PostedFile.InputStream).ReadBytes(pic1files.PostedFile.ContentLength));
                    if(base64String1.Equals("NOPIC"))
                    {
                        InvlaidPostAd.InnerHtml = "<p>Picture 1 is an invalid image. Please attach only the pictures you took of your game.</p>";
                        return;
                    }
                }
                else
                    base64String1 = "NOPIC";


                //Check if there is a file 2
                if (pic2files.PostedFile.ContentLength != 0)
                {
                    base64String2 = ImageFunctions.validateImage(new BinaryReader(pic2files.PostedFile.InputStream).ReadBytes(pic2files.PostedFile.ContentLength));
                    if (base64String2.Equals("NOPIC"))
                    {
                        InvlaidPostAd.InnerHtml = "<p>Picture 2 is an invalid image. Please attach only the pictures you took of your game.</p>";
                        return;
                    }

                    /*
                    //convert pic 2 to byte[]
                    byte[] pic2Data = null;
                    using (var binaryReader = new BinaryReader(pic2files.PostedFile.InputStream))
                    {
                        pic2Data = binaryReader.ReadBytes(pic2files.PostedFile.ContentLength);
                        byte[] temp = pic2Data;

                        if (IsValidImage(pic2Data) && checkVision(pic2Data))
                        {
                            pic2Data = CompressImage(temp);
                            base64String2 = Convert.ToBase64String(pic2Data);
                        }
                        else
                        {
                            InvlaidPostAd.InnerHtml = "<p>Picture 2 is invalid</p>";
                            return;
                        }
                    }*/
                }
                else
                    base64String2 = "NOPIC";


                //Check if there is a file 3
                if (pic3files.PostedFile.ContentLength != 0)
                {
                    base64String3 = ImageFunctions.validateImage(new BinaryReader(pic3files.PostedFile.InputStream).ReadBytes(pic3files.PostedFile.ContentLength));
                    if (base64String3.Equals("NOPIC"))
                    {
                        InvlaidPostAd.InnerHtml = "<p>Picture 3 is an invalid image. Please attach only the pictures you took of your game.</p>";
                        return;
                    }

                    /*
                    //convert pic 3 to byte[]
                    byte[] pic3Data = null;
                    using (var binaryReader = new BinaryReader(pic3files.PostedFile.InputStream))
                    {
                        pic3Data = binaryReader.ReadBytes(pic3files.PostedFile.ContentLength);
                        byte[] temp = pic3Data;

                        if (IsValidImage(pic3Data) && checkVision(pic3Data))
                        {
                            pic3Data = CompressImage(temp);
                            base64String3 = Convert.ToBase64String(pic3Data);
                        }
                        else
                        {
                            InvlaidPostAd.InnerHtml = "<p>Picture 3 is invalid</p>";
                            return;
                        }
                    }*/
                }
                else
                    base64String3 = "NOPIC";



                //byte[][] sendPics = new byte[3][];
                // sendPics[0] = pic1Data;
                // sendPics[1] = pic2Data;
                //sendPics[2] = pic3Data;

                //--------------------------------------------------------------------------

                UserData user = (UserData)Session["User"];
                AdService.AdCRUDClient service = new AdService.AdCRUDClient();
                service.Open();


                //Inserting ad
                int success =0;
                success = service.insertAd(txtGameTitle.Value, PlatformDrop.Items[PlatformDrop.SelectedIndex].Text, DateTime.Today, txtGameDesc.Value, txtLocation.Value, Convert.ToDouble(txtPrice.Value), negChecked, ShowPhoneChecked, base64String1, base64String2, base64String3, user.isPrem(), user.getID());
                service.Close();

                //string Title, string Platform, DateTime CreatedDate, string Description, string Location, Double Price, int Negotiable, int ShowNumber, String Pic1Path, String Pic2Path, String Pic3Path, int PremiumAd, int UserID
                if (success == 1)
                {



                    //remember variable in code bellow
                    postAdDiv.InnerHtml = "<div class='col s12 m6 push-m3'>";
                    postAdDiv.InnerHtml += "<div class='card white'>";
                    postAdDiv.InnerHtml += "<div class='card-content Black-text'>";
                    postAdDiv.InnerHtml += "<span class='card-title bold'>Ad Created Successfully</span>";
                    postAdDiv.InnerHtml += "<p>You have successfully created your ad. To view your ad, proceeed to the My Ads page.</p>";

                    postAdDiv.InnerHtml += "</div>";
                    postAdDiv.InnerHtml += "<div class='card-action'> ";
                    postAdDiv.InnerHtml += "<a href='Index.aspx' class='btn waves-effect waves-light'>Continue</a> ";
                    postAdDiv.InnerHtml += "<a href='MyAds.aspx' class='btn waves-effect waves-light orange lighten-2'>My Ads</a> ";
                    postAdDiv.InnerHtml += "</div>";
                    postAdDiv.InnerHtml += "</div>";
                    postAdDiv.InnerHtml += "</div>";


                    //Object[] temp = service.getAdDetails("25");
                    //byte[][] temp = service.getPictures(1);
                    //string base64String1 = Convert.ToBase64String(temp[0], 0, temp[0].Length);
                    //temp1.Attributes["src"] = "data:image/jpeg;base64," + temp[9];
                    //string base64String2 = Convert.ToBase64String(temp[1], 0, temp[1].Length);
                    //temp2.Attributes["src"] = "data:image/jpeg;base64," + temp[10];
                    //string base64String3 = Convert.ToBase64String(temp[2], 0, temp[2].Length);
                    //temp3.Attributes["src"] = "data:image/jpeg;base64," + temp[11];
                    
                }
                else
                {
                    postAdDiv.InnerHtml = "<div class='col s12 m6 push-m3'>";
                    postAdDiv.InnerHtml += "<div class='card white'>";
                    postAdDiv.InnerHtml += "<div class='card-content Black-text'>";
                    postAdDiv.InnerHtml += "<span class='card-title bold'>Oh No...An Error Occured</span>";
                    postAdDiv.InnerHtml += "<p>Unfortunately we were unable to create your ad. Please try again or come back later.<br/>To view your current ads, proceeed to the My Ads page.</p>";

                    postAdDiv.InnerHtml += "</div>";
                    postAdDiv.InnerHtml += "<div class='card-action'> ";
                    postAdDiv.InnerHtml += "<a href='Index.aspx' class='btn waves-effect waves-light'>Continue</a> ";
                    postAdDiv.InnerHtml += "<a href='MyAds.aspx' runat='server' class='btn waves-effect waves-light'>My Ads</a> ";
                    postAdDiv.InnerHtml += "</div>";
                    postAdDiv.InnerHtml += "</div>";
                    postAdDiv.InnerHtml += "</div>";
                }
            }
        }
    }
}
