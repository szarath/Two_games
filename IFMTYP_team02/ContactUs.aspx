<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="IFMTYP_team02.ContactUs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">

    <div class="row" id="contactUsDiv" runat="server">
        <div class="col s12 m6 l6 push-l3 push-m3">
            <div class="card white">
                <div class="card-content black-text">
                    <!--Card Information-->
                    <span class="card-title">Contact Us</span>
                    <br />
                    <p>Extra Help? Feedback? Queries? Feel free send us an email</p>
                    <p>Please provide us with as much detail as possible.</p>
                    <br />

                    <div id="errorContactUs" runat="server">
                        
                    </div>

                    <div class="row">
                        <div class="input-field col s6">
                            <input id="txtName" type="text" class="validate black-text" runat="server"/> 
                            <label for="txtName">Name</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s6">
                            <input id="txtEmail" type="email" class="validate black-text" runat="server"/>
                            <label for="txtEmal">Email</label>
                        </div>
                    </div>

                    <!--<div class="row">
                        <div class="input-field col s6">
                            <input id="txtSubject" type="text" class="validate black-text" runat="server"/>
                            <label for="subject">Subject</label>
                        </div>
                    </div>-->
                      <div class="input-field col s12">
                        <select id="drpdwnSubject" runat="server">
                          <option value="" disabled selected>Select an issue</option>
                          <option value="1">Add Managment</option>
                          <option value="2">Premium Subscription</option>
                          <option value="3">Account Managment</option>
                          <option value="4">Log in</option>
                          <option value="5">Registration</option>
                          <option value="6">Improvement Suggestions</option>
                          <option value="7">Other</option>
                        </select>
                        <label>Issue Category</label>
                      </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <textarea id="txtDesc" class="materialize-textarea validate" runat="server"></textarea>
                            <label for="txtDesc">Description</label>
                        </div>
                    </div>

                    <div class="row">
                        <button type="submit" runat="server" id="submitbtn" class="waves-effect waves-light btn" onserverclick="Submit_ServerClick">Submit</button>
                    </div>
                    
                    </div>
                </div>
            </div>
        </div>

    

</asp:Content>
