<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="DetailedAd.aspx.cs" Inherits="IFMTYP_team02.DetailedAd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">

      <div class="row" id="detailedAdActionResutView" runat="server">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span id="lblGameTitle" class="card-title" runat="server"></span>
              <div class="row">
                  <h6 id="lblGamePrice" runat="server"></h6>
                   <span id="editButtonSpan" runat="server"></span> 
                   <a class='btn right waves-effect waves-light orange-text text-lighten-2 btn-flat' runat='server' id='btnFlagAdAdminMod' onserverclick="flagAd_ServerClick" visible='false'>Flag Ad</a> 
                   <a class='btn right waves-effect waves-light orange-text text-lighten-2 btn-flat' runat='server' id='btnUnflagAdAdminMod' onserverclick='unflagAd_ServerClick' visible='false'>Unflag Ad</a> 
                   <a class='btn right waves-effect waves-light orange-text text-lighten-2 btn-flat' runat='server' id='btnReportUser' onserverclick="btnReportUser_ServerClick" visible='true'>Report User</a> 
                   <a class='btn right waves-effect waves-light orange-text text-lighten-2 btn-flat' runat='server' id='btnReportAd' onserverclick="btnReportAd_ServerClick" visible='true'>Report Ad</a>
              </div>
               
   
                <div class="row">
                    <img class="materialboxed col s12 m4 l4 responsive-img" id="imgPic1" src="#" runat="server"/>
                    <img class="materialboxed col s12 m4 l4 responsive-img" id="imgPic2" src="#" runat="server"/>
                    <img class="materialboxed col s12 m4 l4 responsive-img" id="imgPic3" src="#" runat="server"/>
                </div>

                <div class="row">
                    <div class="divider"></div>    
                </div>

                <div class="row">
                    <p id="lblGamePlatform" runat="server"></p>
                </div>

                <div class="row">
                    <div class="input-field col s12 m12 l12">
                      <textarea id="txtGameDescription" class="materialize-textarea" runat="server" readonly></textarea>
                      <label for="txtGameDescription">Description</label>
                    </div>
                  </div>
                <div class="row">
                    <div class="input-field col s12 m6 l6">
                      <input id="txtGameLocation" type="text" runat="server" readonly/>
                      <label for="txtGameLocation">Location</label>
                    </div>
                    <div id="sellerCellNumberDiv" class="input-field col s12 m6 l6" runat="server">
                      <input id="txtCellNumber" type="tel" runat="server" readonly/>
                      <label for="txtCellNumber">Seller's Contact Number</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12 m12 l12">
                        <div id="replysentdiv" runat="server"></div>
                        <a href="#replyAdModal" id="btnReplyAd" class="btn waves-effect waves-light modal-trigger col s12 m12 l12" runat="server">Reply to Ad</a>
                    </div>
                </div>
                <div class="row">
                    <iframe id="adMap" runat="server" class="col s12 m6 l6" height='300' frameborder='0' style='border:0' src='https://www.google.com/maps/embed/v1/place?key=AIzaSyB7eq5IZFtbXZitO0yI53upIROFqC5RBcY&q=Johannesburg,+South+Africa'></iframe>
                    <iframe id="adYoutubeFrame" runat="server" class="col s12 m6 l6" height="300" src="//www.youtube.com/embed/Q8TXgCzxEnw?rel=0" frameborder="0" allowfullscreen></iframe>
                </div>
            </div>
          </div>
        </div>
      </div>


    <div class="modal" id="replyAdModal">
        <div class="modal-content">
            <h4>Reply to Ad</h4>
            <br />
            <div class="row">
                <div class="input-field col s12 m6 l6">
                    <input id="txtName" type="text" runat="server"/>
                    <label for="txtName">Your Name</label>
                </div>
                <div class="input-field col s12 m6 l6">
                    <input id="txtemail" type="text" runat="server"/>
                    <label for="txtemail">Your Email</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12 m12 l12">
                    <textarea id="txtMessage" class="materialize-textarea" runat="server"></textarea>
                    <label for="txtMessage">Your Message</label>
                </div>
            </div>
            <div class="modal-footer">
                <a href="#" onserverclick="btnReplyAd_ServerClick" class="waves-effect waves-green btn-flat green-text" runat="server">Send</a>
                <a href="#" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Close</a>
            </div>
        </div>
    </div>

</asp:Content>
