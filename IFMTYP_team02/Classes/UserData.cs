using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Author: Devin Harmse
//Class used to store user authentication info
namespace IFMTYP_team02
{
    public class UserData
    {
        private int ID;
        private string username;
        private string firstName;
        private string surname;
        private string cellNumber;
        private DateTime DoB;
        private int modAccess = 0;
        private int adminAccess = 0;
        private int premAccess = 0;

        public UserData(int ID, string username, string firstname, string Surname, string cellNumber, DateTime DoB, int Mod, int Admin, int Prem)
        {
            this.ID = ID;
            this.username = username;
            this.firstName = firstname;
            this.surname = Surname;
            this.cellNumber = cellNumber;
            this.DoB = DoB;
            this.modAccess = Mod;
            this.adminAccess = Admin;
            this.premAccess = Prem;
        }

        //----getters
        public int getID() { return this.ID; }
        public string getUsername() { return this.username; }
        public string getFirstName() { return this.firstName; }
        public string getSurname() { return this.surname; }
        public string getCellNumber() { return this.cellNumber; }
        public DateTime getDoB() { return this.DoB; }
        public int isMod() { return this.modAccess; }
        public int isAdmin() { return this.adminAccess; }
        public int isPrem() { return this.premAccess; }
        
        //----setters-commented out due to security reasons
        //public void setFirstName(string firstname) { this.firstName = firstname; }
        //public void setSurname(string Surname) { this.surname = Surname; }
        //public void setModAccess(int access) { modAccess = access; }
        //public void setAdminAccess(int access) { adminAccess = access; }
        //public void setPremAccess(int access) { premAccess = access; }
    }
}