<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="IFMTYP_team02.DetailedUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div id="userCard" runat="server" class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card">
            <div class="card-content black-text">
              <span class="card-title bold">Edit User Account</span>
                <div id="invalidUserUpdate" class="row red-text text-lighten-2" runat="server">

                </div>
                        
                          <div class="row">
                                    <div class="input-field col s12 m6 l6">
                                      <input id="txtFirstName" runat="server" type="text" class="validate black-text"/>
                                      <label for="txtFirstName">First Name</label>
                                    </div>
                                    <div class="input-field col s12 m6 l6">
                                        <input id="txtLastName" runat="server" type="text" class="validate black-text"/>
                                      <label for="txtLastName">Last Name</label>
                                    </div>
                          </div>

                          <div class="row">
                                    <div class="input-field col s12 m6 l6">
                                      <input id="txtEmail" runat="server" type="email" class="validate black-text"/>
                                      <label for="txtEmail">Email</label>
                                    </div>
                              
                                    <div class="input-field col s12 m6 l6">
                                        <input id="txtCellNumber" runat="server" type="tel" class="validate black-text"/>
                                        <label for="txtCellNumber">Cellphone Number</label>
                                    </div>
                          </div>

                            <div class="row">
                                    <div class="input-field col s12 m6 l6">
                                        <input type="date" id="txtDoB" runat="server" class="datepicker black-text"/>
                                       <label for="txtDoB">Date Of Birth</label>
                                    </div>

                                <div class="input-field col s12 m6 l6">
                                        <input type="date" id="txtRegDate" runat="server" class="datepicker black-text"/>
                                       <label for="txtRegDate">Registration Date</label>
                                    </div>
                            </div>
                            
                            <div class="divider"></div>
                            <br />

                            <div class="row">
                                        <div class="input-field col s12 m6 l6">
                                          <input id="txtUsername" runat="server" type="text" class="validate black-text"/>
                                          <label for="txtUsername">Username</label>
                                        </div>
                             </div>

                            <div class="row">
                                <h6>Account Type</h6>
                                
                                <div class="col s12 m6 l3">
                                    <input name="userTypeGroup" type="radio" id="radioFree" ClientIDMode="static" runat="server"/>
                                    <!--<input type="checkbox" id="radioFree1" runat="server" />-->
                                    <label for="radioFree">Free User</label>
                                </div>

                                <div class="col s12 m6 l3">
                                    <input name="userTypeGroup" type="radio" id="radioPrem" ClientIDMode="static" runat="server"/>
                                    <!--<input type="checkbox" id="radioPrem1" runat="server" />-->
                                    <label for="radioPrem">Premium User</label>
                                </div>

                                <div class="col s12 m6 l3">  
                                    <input name="userTypeGroup" type="radio" id="radioMod" ClientIDMode="static" runat="server"/>
                                    <!--<input type="checkbox" id="radioMod1" runat="server" />-->
                                    <label for="radioMod">Moderator</label>
                                </div>
                                
                                <div class="col s12 m6 l3">
                                    <input name="userTypeGroup" type="radio" id="radioAdmin" ClientIDMode="static" runat="server"/>
                                    <!--<input type="checkbox" id="radioAdmin1" runat="server" />-->
                                    <label for="radioAdmin">Administrator</label>
                                </div>
                            </div>

                <div class="row">
                    <h6>Flagged</h6>
                    <div class="switch">
                        <label>
                          No
                          <input type="checkbox" id="flaggedSwitch" ClientIDMode="static" runat="server"/>
                          <span class="lever"></span>
                          Yes
                        </label>
                      </div>
                </div>


                            <!--Card Actions-->
                            <div class="row"></div>
                            <div class="row">
                                <button id="btnUpdateUser" runat="server" class="btn waves-effect waves-light" onserverclick="btnUpdateUser_ServerClick">Update User</button>
                                <a href="#AcceptDelete" class="btn waves-effect waves-light red modal-trigger">Delete User</a>
                                <a href="UserManagement.aspx" runat="server"  class="waves-effect waves-light btn orange lighten-2">Cancel</a>
                            </div>

                        </div>
          </div>
        </div>
    </div>

    <div class="modal" id="AcceptDelete">
        <div class="modal-content">
            <h4>Confirm Delete</h4>
            <p>Are you sure you wish to delete your account?</p>
        </div>
        <div class="modal-footer">
            <a href="#" id="btnDeleteUser" runat="server" OnServerClick="btnDeleteUser_ServerClick" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
            <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
        </div>
    </div>
</asp:Content>
