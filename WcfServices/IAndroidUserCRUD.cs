using System;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAndroidUserCRUD" in both code and config file together.
    [ServiceContract]
    public interface IAndroidUserCRUD
    {
        //Android Insert method for inserting a User record into the database
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidinsertUser/{Username}/{Password}/{firstName}/{surname}/{Email}/{cellNumber}/{DOB}/{RegDate}")]///{modAccess}/{adminAccess}/{premAccess}
        [OperationContract]
        int AndroidinsertUser(string Username, string Password, string firstName, string surname, string Email, string cellNumber, string DOB, string RegDate);//, string modAccess, string adminAccess, string premAccess

        //Android Delete method for deleting a User record from the database
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroiddeleteUser/{Username}")]
        int AndroiddeleteUser(String Username);


        //Android Update Method for users to update User record in database
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidupdateUserInfo/{ID}/{firstName}/{surname}/{cellNumber}/{DOB}/{Email}")]
        int AndroidupdateUserInfo(string ID, string firstName, string surname, string cellNumber, string DOB,string Email);
        //Android Get metod to report users 

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidreportUser/{userID}")]
        int AndroidreportUser(string userID);



        //Android Method for Authenticating a user
        [OperationContract]
        [WebInvoke(Method = "GET" ,RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidAuthenticate/{UserEmail}/{Password}")]
        Object[] AndroidAuthenticate(string UserEmail, string Password);

        //Android Method for updating a user's password
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidUpdateUserPassword/{ID}/{emailAddress}/{oldPass}/{newPass}")]
        int AndroidupdateUserPassword(string ID, string emailAddress, string oldPass, string newPass);

        //Android Method for getting a user's email address
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidgetUserEmail/{ID}")]
        string AndroidgetUserEmail(string ID);

        //Android Method for updating a user's email address
        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/AndroidupdateUserEmail/{ID}/{userPass}/{oldEmail}/{newEmail}")]
        int AndroidupdateUserEmail(string ID, string userPass, string oldEmail, string newEmail);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/ouch")]
        string ouch();
    }
}
