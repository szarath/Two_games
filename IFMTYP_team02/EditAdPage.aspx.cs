using IFMTYP_team02.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IFMTYP_team02
{
    public partial class EditAdPage : System.Web.UI.Page
    {
        //private string pic1server = "";
        //private string pic2server = "";
        //private string pic3server = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    string adID = Request.QueryString.Get("ad");

                    AdService.AdCRUDClient adService = new AdService.AdCRUDClient();
                    adService.Open();
                    Object[] platforms = adService.getPlatforms();
                    if (!(platforms == null))
                    {
                        //PlatformDrop.Items.Add(new ListItem("Platform",""));      
                        //InnerHtml = "<option value='' disabled selected>Platform</option>";
                        for (int i = 0; i <= platforms.Length - 1; i++)
                        {
                            drpGamePlatform.Items.Add(new ListItem(Convert.ToString(platforms[i]), Convert.ToString(platforms[i])));
                            //PlatformDrop.InnerHtml += "<option value='"+ Convert.ToString(platforms[i]) + "' disabled selected>" + Convert.ToString(platforms[i]) + "</option>";
                        }
                    }
                    else
                    {
                        drpGamePlatform.Items.Add(new ListItem("XBOX ONE", "XBOX ONE"));
                        drpGamePlatform.Items.Add(new ListItem("PS4", "PS4"));
                        drpGamePlatform.Items.Add(new ListItem("XBOX 360", "XBOX 360"));
                        drpGamePlatform.Items.Add(new ListItem("PS3", "PS3"));
                        drpGamePlatform.Items.Add(new ListItem("3DS", "3DS"));
                        drpGamePlatform.Items.Add(new ListItem("WII U", "WII U"));
                        drpGamePlatform.Items.Add(new ListItem("GAMECUBE", "GAMECUBE"));
                    }
                    Object[] adDetails = adService.getAdDetails(adID);
                    adService.Close();

                    //----------------TITLE
                    txtGameTile.Value = (string)adDetails[1];
                    Title = "twoGAMES: " + (string)adDetails[1];

                    txtGamePrice.Value = (string)adDetails[6];
                    if (!((string)adDetails[9]).Equals("NOPIC"))
                    {
                        pic1Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + (string)adDetails[9] + "'/>"; 
                    }
                    if (!((string)adDetails[10]).Equals("NOPIC"))
                    {
                        pic2Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + (string)adDetails[10] + "'/>"; 
                    }
                    if (!((string)adDetails[11]).Equals("NOPIC"))
                    {
                        pic3Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + (string)adDetails[11] + "'/>"; 
                    }
                    drpGamePlatform.Items.FindByText((string)adDetails[2]).Selected = true;
                    txtGameDescription.Value = (string)adDetails[4];
                    txtGameLocation.Value = (string)adDetails[5];

                    //pic1server = (string)adDetails[9];
                    //pic2server = (string)adDetails[10];
                    //pic3server = (string)adDetails[11];
                    Session["pic1"] = (string)adDetails[9];
                    Session["pic2"] = (string)adDetails[10];
                    Session["pic3"] = (string)adDetails[11];

                    if (Convert.ToBoolean(adDetails[8]))
                        ShowPhone.Checked = true;
                    else
                        ShowPhone.Checked = false;

                    if (Convert.ToBoolean(adDetails[7]))
                        NegotiableCheck.Checked = true;
                    else
                        NegotiableCheck.Checked = false;


                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }


        protected void btnUpdateAd_ServerClick(object sender, EventArgs e)
        {

            Boolean postad = true;



            if (txtGameTile.Value.Equals("") || txtGamePrice.Value == null || drpGamePlatform.Items[drpGamePlatform.SelectedIndex].Text.Equals("Platform") || txtGameDescription.Value.Equals(""))
            {
                InvlaidPostAd.InnerHtml = "<p>Please fill in all the fields</p>";
                postad = false;
            }
            else
            {
                try
                {
                    int temp = Int32.Parse(txtGamePrice.Value);
                }
                catch (FormatException ex)
                {
                    txtGamePrice.Value = "";
                    InvlaidPostAd.InnerHtml = "<p>Please fill in a price</p>";
                    postad = false;
                }
            }

            

            if (postad)
            {
                int negChecked = 0;
                int ShowPhoneChecked = 0;
                if (NegotiableCheck.Checked)
                    negChecked = 1;
                if (ShowPhone.Checked)
                    ShowPhoneChecked = 1;


                //**************Check files exist********************
                //string base64String1 = "";
                //string base64String2 = "";
                //string base64String3 = "";

                //Check if there is a file 1
                if (pic1files.PostedFile.ContentLength != 0)
                {
                    string base64String1 = ImageFunctions.validateImage(new BinaryReader(pic1files.PostedFile.InputStream).ReadBytes(pic1files.PostedFile.ContentLength));
                    if (base64String1.Equals("NOPIC"))
                    {
                        InvlaidPostAd.InnerHtml = "<p>Picture 1 is an invalid image. Please attach only the pictures you took of your game.</p>";
                        return;
                    }
                    Session["pic1"] = base64String1;
                    
                    /*
                    //convert pic 1 to byte[]
                    byte[] pic1Data = null;
                    using (var binaryReader = new BinaryReader(pic1files.PostedFile.InputStream))
                    {
                        pic1Data = CompressImage(binaryReader.ReadBytes(pic1files.PostedFile.ContentLength));
                    }

                    /*base64String1 this.pic1server Session["pic1"] = Convert.ToBase64String(pic1Data);*/
                }
                /*else
                    base64String1 = "NOPIC";*/

                //Check if there is a file 2
                if (pic2files.PostedFile.ContentLength != 0)
                {
                    string base64String2 = ImageFunctions.validateImage(new BinaryReader(pic2files.PostedFile.InputStream).ReadBytes(pic2files.PostedFile.ContentLength));
                    if (base64String2.Equals("NOPIC"))
                    {
                        InvlaidPostAd.InnerHtml = "<p>Picture 2 is an invalid image. Please attach only the pictures you took of your game.</p>";
                        return;
                    }
                    Session["pic2"] = base64String2;

                    /*
                    //convert pic 2 to byte[]
                    byte[] pic2Data = null;
                    using (var binaryReader = new BinaryReader(pic2files.PostedFile.InputStream))
                    {
                        pic2Data = CompressImage(binaryReader.ReadBytes(pic2files.PostedFile.ContentLength));
                    }
                    base64String2 this.pic2server Session["pic2"] = Convert.ToBase64String(pic2Data);*/
                }
                /*else
                    base64String2 = "NOPIC";*/

                //Check if there is a file 3
                if (pic3files.PostedFile.ContentLength != 0)
                {
                    string base64String3 = ImageFunctions.validateImage(new BinaryReader(pic3files.PostedFile.InputStream).ReadBytes(pic3files.PostedFile.ContentLength));
                    if (base64String3.Equals("NOPIC"))
                    {
                        InvlaidPostAd.InnerHtml = "<p>Picture 3 is an invalid image. Please attach only the pictures you took of your game.</p>";
                        return;
                    }
                    Session["pic3"] = base64String3;

                    /*
                    //convert pic 3 to byte[]
                    byte[] pic3Data = null;
                    using (var binaryReader = new BinaryReader(pic3files.PostedFile.InputStream))
                    {
                        pic3Data = CompressImage(binaryReader.ReadBytes(pic3files.PostedFile.ContentLength));
                    }
                    base64String3 this.pic3server
                    Session["pic3"] = Convert.ToBase64String(pic3Data);*/
                }
                /*else
                    base64String3 = "NOPIC";*/




                /*if (base64String1.Equals("NOPIC"))
                {
                    if (!pic1server.Equals("NOPIC"))
                        base64String1 = pic1server;
                }
                if (base64String2.Equals("NOPIC"))
                {
                    if (!pic2server.Equals("NOPIC"))
                        base64String2 = pic2server;
                }
                if (base64String3.Equals("NOPIC"))
                {
                    if (!pic3server.Equals("NOPIC"))
                        base64String3 = pic3server;
                }*/



                //byte[][] sendPics = new byte[3][];
                // sendPics[0] = pic1Data;
                // sendPics[1] = pic2Data;
                //sendPics[2] = pic3Data;

                //--------------------------------------------------------------------------

                UserData user = (UserData)Session["User"];
                AdService.AdCRUDClient service = new AdService.AdCRUDClient();
                service.Open();

                string adID = Request.QueryString.Get("ad");

                int success = service.updateAd(Convert.ToInt32(adID), txtGameTile.Value, drpGamePlatform.Items[drpGamePlatform.SelectedIndex].Text, txtGameDescription.Value, txtGameLocation.Value, Convert.ToDouble(txtGamePrice.Value), negChecked, ShowPhoneChecked, /*base64String1 this.pic1server*/(string)Session["pic1"], /*base64String2 this.pic2server*/(string)Session["pic2"], /*base64String3 this.pic3server*/(string)Session["pic3"], user.isPrem());

                if (success == 1)
                {
                    editAdDiv.InnerHtml = "<div class='col s12 m6 push-m3'>";
                    editAdDiv.InnerHtml += "<div class='card white'>";
                    editAdDiv.InnerHtml += "<div class='card-content Black-text'>";
                    editAdDiv.InnerHtml += "<span class='card-title bold'>Ad Updated Successfully</span>";
                    editAdDiv.InnerHtml += "<p>You have successfully Updated your ad. To view your ad, proceeed to the My Ads page.</p>";

                    editAdDiv.InnerHtml += "</div>";
                    editAdDiv.InnerHtml += "<div class='card-action'>";
                    editAdDiv.InnerHtml += "<a href='MyAds.aspx' runat='server' class='btn waves-effect waves-light'>My Ads</a>";
                    editAdDiv.InnerHtml += "</div>";
                    editAdDiv.InnerHtml += "</div>";
                    editAdDiv.InnerHtml += "</div>";
                    
                }
                else
                {
                    editAdDiv.InnerHtml = "<div class='col s12 m6 push-m3'>";
                    editAdDiv.InnerHtml += "<div class='card white'>";
                    editAdDiv.InnerHtml += "<div class='card-content Black-text'>";
                    editAdDiv.InnerHtml += "<span class='card-title bold'>Ad Update Unsuccessfully</span>";
                    editAdDiv.InnerHtml += "<p>We where unable to update your add. Please try again and if the problem persists pleas contact us <a href='ContactUs.aspx'>here</a>.</p>";

                    editAdDiv.InnerHtml += "</div>";
                    editAdDiv.InnerHtml += "<div class='card-action'>";
                    editAdDiv.InnerHtml += "<a href='MyAds.aspx' runat='server' class='btn waves-effect waves-light'>Continue</a>";
                    editAdDiv.InnerHtml += "</div>";
                    editAdDiv.InnerHtml += "</div>";
                    editAdDiv.InnerHtml += "</div>";
                }
                service.Close();

                Session["pic1"] = null;
                Session["pic2"] = null;
                Session["pic3"] = null;
            }
        }

        protected void btnDeleteAd_ServerClick(object sender, EventArgs e)
        {
            UserData user = (UserData)Session["User"];
            AdService.AdCRUDClient service = new AdService.AdCRUDClient();
            service.Open();

            int success = service.deleteAd(Convert.ToInt32(Request.QueryString.Get("ad")));
            if (success == 1)
            {
                //remember variable in code bellow
                editAdDiv.InnerHtml = "<div class='col s12 m6 push-m3'>";
                editAdDiv.InnerHtml += "<div class='card white'>";
                editAdDiv.InnerHtml += "<div class='card-content Black-text'>";
                editAdDiv.InnerHtml += "<span class='card-title bold'>Ad Deleted Successfully</span>";
                editAdDiv.InnerHtml += "<p>You have Deleted this ad. To view your other ads, proceeed to the My Ads page.</p>";

                editAdDiv.InnerHtml += "</div>";
                editAdDiv.InnerHtml += "<div class='card-action'>";
                editAdDiv.InnerHtml += "<a href='MyAds.aspx' runat='server' class='btn waves-effect waves-light'>My Ads</a>";
                if (Session["User"] != null)
                {
                    if (((UserData)Session["User"]).isAdmin() == 1 || ((UserData)Session["User"]).isMod() == 1)
                    {
                        editAdDiv.InnerHtml += "<a class='btn right waves-effect waves-light orange lighten-2' href='AdManagement.aspx'>Manage Ads</a>";
                    }
                }
                editAdDiv.InnerHtml += "</div>";
                editAdDiv.InnerHtml += "</div>";
                editAdDiv.InnerHtml += "</div>";


            }
            else
            {
                editAdDiv.InnerHtml = "<div class='col s12 m6 push-m3'>";
                editAdDiv.InnerHtml += "<div class='card white'>";
                editAdDiv.InnerHtml += "<div class='card-content Black-text'>";
                editAdDiv.InnerHtml += "<span class='card-title bold'>Unable to delete Ad</span>";
                editAdDiv.InnerHtml += "<p>We where unable to delete this ad. Please try again and if the problem persists pleas contact us <a href='ContactUs.aspx'>here</a>.</p>";

                editAdDiv.InnerHtml += "</div>";
                editAdDiv.InnerHtml += "<div class='card-action'>";
                editAdDiv.InnerHtml += "<a href='MyAds.aspx' runat='server' class='btn waves-effect waves-light'>My Ads</a>";
                if (Session["User"] != null)
                {
                    if (((UserData)Session["User"]).isAdmin() == 1 || ((UserData)Session["User"]).isMod() == 1)
                    {
                        editAdDiv.InnerHtml += "<a class='btn right waves-effect waves-light orange lighten-2' href='AdManagement.aspx'>Manage Ads</a>";
                    }
                }
                editAdDiv.InnerHtml += "</div>";
                editAdDiv.InnerHtml += "</div>";
                editAdDiv.InnerHtml += "</div>";
            }
            service.Close();
        }



        public byte[] CompressImage(byte[] image)
        {
            MemoryStream ms = new MemoryStream(image);
            MemoryStream tempMS = new MemoryStream();

            long size = ms.ToArray().Length;


            try
            {
                if (size > 512000)
                {
                    Bitmap bmp = (Bitmap)System.Drawing.Image.FromStream(ms);
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(Encoder.Quality, 50L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    bmp.Save(tempMS, jpgEncoder, myEncoderParameters);
                    size = tempMS.ToArray().Length;
                }
                else
                    return ms.ToArray();
            }

            catch (ObjectDisposedException e)
            { }
            catch (Exception ex) { }
            finally
            {
                ms.Dispose();
            }
            return tempMS.ToArray();
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
    }