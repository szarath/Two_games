using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfServices
{

	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAndroidAdCRUD" in both code and config file together.
	[ServiceContract]
	public interface IAndroidAdCRUD
	{

        //Insert method for inserting a new Ad record into the database
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/AndroidinsertAd")]
        int AndroidinsertAd(insertAd ia);

      

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "/test")]
        string test(string hello, string what);

        //Delete method for deleting an Ad record from the database
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroiddeleteAd/{AdID}")]
        int AndroiddeleteAd(string AdID);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Androidmessage/{productemail}/{productusername}/{producttitle}/{buyeremail}/{buyerusername}/{description}")]
        string message(string productemail, string productusername, string producttitle, string buyeremail, string buyerusername, string description);

        //Update method for users to update an Ad record in database
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/AndroidupdateAd")]
        int AndroidupdateAd(editAd ea);

        //Method for displaying the details of an Ads
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidgetAdDetails/{AdID}")]
        Object[] AndroidgetAdDetails(string AdID);

        //Method for searching for an ad
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidsearchAds/{searchTerm}")]
        Object[][] AndroidsearchAds(string searchTerm);

        //Method for retreiving the platforms
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidgetPlatforms")]
        Object[] AndroidgetPlatforms();


        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Contact/{useremail}/{usernmae}/{issueselect}/{description}")]
        string issue(string useremail, string usernmae, string issueselect,string description);

        //Method for getting all of a users ads
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidgetUserAds/{userID}")]
        Object[][] AndroidgetUserAds(string userID);

        //Method for getting all the recently added ads
        [OperationContract]
        [WebGet( RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidgetRecentlyAdded")]
        Object[][] AndroidgetRecentlyAdded();

        //Method for getting the number of ads a user has
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidgetNumUserAds/{userID}")]
        int AndroidgetNumUserAds(string userID);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidgetPictures/{aID}")]
        byte[][] AndroidgetPictures(string aID);


        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidgetUserEmail/{aID}")]
        string[] AndroidgetUserEmail(string aID);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/Androidreportad/{adID}")]
        int Androidreportad(string adID);



        /* [OperationContract]
         [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidsendPictures/{pics}/{aID}")]
         int AndroidsendPictures(byte[][] pics, string aID);*/
    }

 

    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class insertAd
    {

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Platform;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CreatedDate;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Location;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Price;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Negotiable;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShowNumber;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pic1Path;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pic2Path;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pic3Path;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PremiumAd;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserID;
    }

    //?AdID={AdID}&Title={Title}&Platform={Platform}&Description={Description}&Location={Location}&Price={Price}&Negotiable={Negotiable}&ShowNumber={ShowNumber}&Pic1Path={Pic1Path}&Pic2Path={Pic2Path}&Pic3Path={Pic3Path}&PremiumAd={PremiumAd}
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class editAd
    {
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AdID;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Platform;


        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Location;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Price;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Negotiable;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShowNumber;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pic1Path;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pic2Path;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pic3Path;

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PremiumAd;

        
    }

}
