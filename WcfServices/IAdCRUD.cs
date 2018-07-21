using System;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdCRUD" in both code and config file together.
    [ServiceContract]
    public interface IAdCRUD
    {
        //Insert method for inserting a new Ad record into the database
        [OperationContract]
        int insertAd(string Title, string Platform, DateTime CreatedDate, string Description, string Location, Double Price, int Negotiable, int ShowNumber, string Pic1Path, string Pic2Path, string Pic3Path, int PremiumAd, int UserID);

        //Delete method for deleting an Ad record from the database
        [OperationContract]
        int deleteAd(int AdID);

        //Update method for users to update an Ad record in database
        [OperationContract]
        int updateAd(int AdID, string Title, string Platform, string Description, string Location, Double Price, int Negotiable, int ShowNumber, string Pic1Path, string Pic2Path, string Pic3Path, int PremiumAd);

        //Method for displaying the details of an Ads
        [OperationContract]
        Object[] getAdDetails(string AdID);

        //Method for displaying the details of an Ads
        [OperationContract]
        Object[] getEditAdDetails(string AdID, int userID);

        //Method for searching for an ad
        [OperationContract]
        Object[][] searchAds(string searchTerm, string extraSQLParams, string extraSQLOrderBys);

        //Method for retreiving the platforms
        [OperationContract]
        Object[] getPlatforms();

        //Method for getting all of a users ads
        [OperationContract]
        Object[][] getUserAds(int userID);

        //Method for getting all the recently added ads
        [OperationContract]
        Object[][] getRecentlyAdded();

        //Method for getting the number of ads a user has
        [OperationContract]
        int getNumUserAds(int userID);

        //Method to get an ads pictures
        /*[OperationContract]
        byte[][] getPictures(int aID);

        //Method to store an ads pictures
        [OperationContract]
        int sendPictures(byte[][] pics, int aID);*/

        //Method to get all the flagged ads
        [OperationContract]
        Object[][] getFlaggedAdsManagement();

        //Method to get all the ads for management
        [OperationContract]
        Object[][] getAllAdsManagement();

        //Method to search ads for management
        [OperationContract]
        Object[][] searchAdsManagement(string searchTerm, string extraSQLParams);

        //Method for getting a user's email address from ad id
        [OperationContract]
        string[] getUserEmail(int aID);

        //Method to unflag an ad
        [OperationContract]
        int unflagAd(int adID);

        //Method to flag an ad
        [OperationContract]
        int flagAd(int adID);

        [OperationContract]
        int reportAd(int adID);

        [OperationContract]
        int unreportAd(int adID);

        [OperationContract]
        Object[][] getReportedAdsManagement();

        [OperationContract]
        Object[][] getUsersAdsManagement(int ID);

        [OperationContract]
        int numNewAdsYearManagement(DateTime date);

        [OperationContract]
        int numNewAdsMonthManagement(DateTime date);

        [OperationContract]
        int numNewAdsWeekManagement(DateTime date);

        [OperationContract]
        int numNewAdsDayManagement(DateTime date);

        [OperationContract]
        int numReportedAdsManagement();

        [OperationContract]
        int numFlaggedAdsManagement();

        [OperationContract]
        int numPremAdsManagement();

        [OperationContract]
        int incViewCount(int aID);

        [OperationContract]
        int getViewCount(int aID);
    }
}
