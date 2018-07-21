<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="IFMTYP_team02.MyProfile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">

    
        
        <div class="row" id="myProfileView" runat="server">
            <div class="col s12 m10 l8 push-m1 push-l2">
              <div class="card white">
                <div class="card-content black-text">
                  <span id="myProfileTitle" runat="server" class="card-title">My Profile</span>
              

                          <div class="row">
                                    <div class="input-field col s12 m6 l6">
                                      <input id="txtFirstName" type="text" runat="server" class="black-text"/>
                                      <label for="txtFirstName">First Name</label>
                                    </div>
                                    <div class="input-field col s6">
                                      <input id="txtLastName" type="text" runat="server" class="black-text"/>
                                      <label for="txtLastName">Last Name</label>
                                    </div>
                          </div>

                          <div class="row">
                                    <div class="input-field col s12 m6 l6">
                                        <input id="txtCellNumber" runat="server" type="tel" class="black-text"/>
                                        <label for="txtCellNumber">Cellphone Number</label>
                                    </div>
                                    <div class="input-field col s12 m6 l6">
                                        <input type="date" id="txtDoB" runat="server" class="datepicker black-text"/>
                                        <label for="txtDoB">Date Of Birth</label>
                                    </div>
                            </div>

                            <div class="row">
                                <a href="#AcceptUpdate" class="btn waves-effect waves-light modal-trigger"><i class="material-icons left">save</i>Update Account</a>
                            </div>
                       

                     </div>
                         <div class="card-action">
                  
                        <div id="lblPremUserLink" class="row" runat="server"><a href="PremUserReg.aspx" class="teal-text text-lighten-2">Become a Premium User</a></div>
                        <div class="row"><a href="MyAds.aspx" class="teal-text text-lighten-2">My Ads</a></div>
                        <div class="row"><a href="#AccSettModal" class="teal-text text-lighten-2 modal-trigger">Account Settings</a></div>
                        <div class="row"><a href="Help.aspx" class="teal-text text-lighten-2">Help</a></div>
                        <div class="row"><a href="#AcceptDelete" class="red-text text-lighten-2 modal-trigger">Delete Account</a></div>
                 
                </div>
              </div>
            </div>
          </div>
        
                    <div class="modal" id="AcceptUpdate">
                            <div class="modal-content">
                              <h4>Confirm Update</h4>
                              <p>Are you sure you wish to update your account details?</p>
                            </div>
                            <div class="modal-footer">
                              <a href="#" runat="server" OnServerClick="btnUpdateAccount_ServerClick" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-orange btn-flat orange-text lighten-2">Cancel</a>
                            </div>
                      </div>

                    <div class="modal" id="AcceptDelete">
                            <div class="modal-content">
                              <h4>Confirm Delete</h4>
                              <p>Are you sure you wish to delete your account?</p>
                            </div>
                            <div class="modal-footer">
                              <a href="#" runat="server" OnServerClick="btnDeleteAcc_Click" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
                            </div>
                      </div>

                      <!--<div class="modal modal-fixed-footer" id="AcceptDelete2">
                            <div class="modal-content">
                              <h4>Really...You Sure?</h4>
                              <p>Are you absolutly sure you wish to delete your account. This is permanent and cannot be undone.</p>
                            </div>
                            <div class="modal-footer">
                              <a href="#" runat="server" OnServerClick="btnDeleteAcc_Click" class="modal-action modal-close waves-effect waves-green btn-flat">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat">Cancel</a>
                            </div>
                      </div>-->
        

                    <div class="modal" id="AccSettModal">
                        <div class="modal-content">
                            <h4>Account Settings</h4>
                            <br />
                            <p><a href="UpdatePassword.aspx" class="waves-effect teal-text">Update My Password</a></p>
                            <p><a href="UpdateEmail.aspx" class="waves-effect teal-text">Update My Email Address</a></p>
                            <br />
                            <div class="divider"></div>
                            <p id="accountType" runat="server" class="grey-text"></p>
                        </div>
                        <div class="modal-footer">
                            <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat">Close</a>
                        </div>
                    </div>
       
</asp:Content>
