using System;
using System.ServiceModel;


namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserCRUD" in both code and config file together.
    [ServiceContract]
    public interface IUserCRUD
    {
        
        //Insert method for inserting a User record into the database
        [OperationContract]
        int insertUser(string Username, string Password, string firstName, string surname,
            string Email, string cellNumber, DateTime DoB, DateTime RegDate, int modAccess, int adminAccess, int premAccess);

        //Delete method for deleting a User record from the database
        [OperationContract]
        int deleteUser(string ID);

        //Update Method for users to update User record in database
        [OperationContract]
        int updateUserInfo(int ID, string firstName, string surname, string cellNumber, DateTime DoB);

        //Method for Authenticating a user
        [OperationContract]
        Object[] Authenticate(string UserEmailOrUsername, string Password);

        //Method for updating a user's password
        [OperationContract]
        int updateUserPassword(int ID, string emailAddress, string oldPass, string newPass);

        //Method for getting a user's email address
        [OperationContract]
        string getUserEmail(int ID);

        //Method for updating a user's email address
        [OperationContract]
        int updateUserEmail(int ID, string userPass, string oldEmail, string newEmail);

        //Method for updating a user's premium membership
        [OperationContract]
        int updateUserPremAccess(int ID, string userPass, string userEmail, string cellNumber, DateTime DoB, int premAccess);

        [OperationContract]
        Object[][] getFlaggedUsersManagement();

        [OperationContract]
        Object[][] getAllUsersManagement();

        [OperationContract]
        int unflagUser(int userID);

        [OperationContract]
        int flagUser(int userID);

        [OperationContract]
        int reportUser(int userID);

        [OperationContract]
        int unreportUser(int userID);

        [OperationContract]
        Object[][] getReportedUsersManagement();

        [OperationContract]
        string getUsername(int userID);

        [OperationContract]
        string isUserPrem(int userID);

        [OperationContract]
        Object[] getUserDetailsManagement(int userID);

        [OperationContract]
        int updateUserDetailsManagement(int userID, string username, string firstName, string surname, string Email, string cellNumber, DateTime DoB, DateTime regDate, int modAccess, int adminAccess, int premAccess, int flagged, int reportCount);

        [OperationContract]
        int numNewUsersYearManagement(DateTime date);

        [OperationContract]
        int numNewUsersMonthManagement(DateTime date);

        [OperationContract]
        int numNewUsersWeekManagement(DateTime date);

        [OperationContract]
        int numNewUsersDayManagement(DateTime date);

        [OperationContract]
        int numReportedUsersManagement();

        [OperationContract]
        int numFlaggedUsersManagement();

        [OperationContract]
        int numPremUsersManagement();
    }
}
