<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="IFMTYP_team02.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="row">
        <div class="col s12 m10 l8 push-l2 push-m1">
            <div class="card white">
                <div class="card-content black-text">
                    <div class="row">
                        <div class="input-field col s12 m9 l10">
                            <i class="material-icons prefix">search</i>
                            <input id="txtSearch" type="text" class="black-text" runat="server" autofocus/> 
                            <label for="txtSearch">Click here to search</label>
                        </div>
                        <div class="input-field col m2 l2">
                            <button id="btnSearch" type="submit" class="btn waves-effect waves-light" runat="server" onserverclick="btnSearch_ServerClick">Search</button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s6 m4 l3">
                            <select id="SortDrop" runat="server">
                                <option value="default" selected>Default</option>
                                <option value="titleAZ">Title (A-Z)</option>
                                <option value="titleZA">Title (Z-A)</option>
                                <option value="platformAZ">Platform (A-Z)</option>
                                <option value="platformZA">Platform (Z-A)</option>
                                <option value="priceHighLow">Price (High-Low)</option>
                                <option value="priceLowHigh">Price (Low-High)</option>
                            </select> 
                            <label for="SortDrop">Sort By</label>
                        </div>
                        <div class="input-field col s6 m4 l3">
                            <select id="PlatformDrop" runat="server">
                                <option value="default" selected>All</option>
                            </select> 
                            <label for="PlatformDrop">Filter Platform</label>
                        </div>
                        <div class="input-field col s6 m4 l3">
                            <select id="LocationDrop" runat="server">
                                <option value="default" selected>All</option>
                                <option value="eastern">Eastern Cape</option>
                                <option value="free">Free State</option>
                                <option value="gauteng">Gauteng</option>
                                <option value="natal">KwaZulu-Natal</option>
                                <option value="limpopo">Limpopo</option>
                                <option value="mpumalanga">Mpumalanga</option>
                                <option value="northern">Northern Cape</option>
                                <option value="north west">North West</option>
                                <option value="western">Western Cape</option>
                            </select> 
                            <label for="LocationDrop">Filter Location</label>
                        </div>
                        <div class="input-field col s6 m4 l3">
                            <select id="PriceDrop" runat="server">
                                <option value="default" selected>All</option>
                                <option value="0-100">R0 - R100</option>
                                <option value="100-200">R100 - R200</option>
                                <option value="200-300">R200 - R300</option>
                                <option value="300-400">R300 - R400</option>
                                <option value="400+">R400 +</option>
                            </select> 
                            <label for="PriceDrop">Filter Price</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="searchedAdsDisplay" runat="server" class="row">

    </div>
</asp:Content>
