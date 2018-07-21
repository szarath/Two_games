<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="PostAd.aspx.cs" Inherits="IFMTYP_team02.PostAd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="server">

    <style>
        .thumb 
        {
            height: 75px;
            margin: 10px 5px 0 0;
        }
    </style>
  

    <div class="row" id="postAdDiv" runat="server">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title">Post New Ad</span>
              
                <div id="InvlaidPostAd" runat="server" class="row red-text text-lighten-2">

                </div>

                <div class="row">
                    <div class="input-field col s6 m8 l9"> 
                        <input id="txtGameTitle" type="text" class="validate autocomplete-content" runat="server"/>
                        <label for="txtGameTitle">Game Title</label>
                    </div>
                    <div class="input-field col s6 m4 l3">
                        <select id="PlatformDrop" runat="server">
                            <option value="" disabled selected>Choose Platform</option>
                        </select> 
                        <label for="PlatformDrop">Platform</label>
                    </div>
                </div> 

                <div class="row">
                    <div id="locationField" class="input-field col s12 m6 l6">
                       <input id="txtLocation" onFocus="geolocate()" type="text" runat="server" ClientIDMode="static" placeholder=""/>
                        <label for="txtLocation">Location</label>
                       <!--<div id="MapOutput"></div>-->
                    </div>
                    <div class="input-field col s6 m3 l3">
                        <input id="txtPrice" type="number" class="validate black-text" runat="server"/>
                        <label for="txtPrice">Price</label>
                    </div>
                    <div class="input-field col s6 m3 l3">
                        <input type="checkbox" id="NegotiableCheck" ClientIDMode="static" runat="server"/>
                        <label for="NegotiableCheck">Negotiable</label>
                    </div>
                </div>

                <div class="row">
                    <div class="input-field col s12 m12 l12">
                        <textarea id="txtGameDesc" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtGameDesc">Game Description</label>
                    </div>
                </div>


           

                <div class="row">
                    <div class="file-field input-field col s12 m4 l4">
                          <div class="btn waves-effect waves-light">
                            <span>Pic 1</span>
                            <input id="pic1files" type="file" name="pic1files[]" ClientIDMode="static" runat="server"/>
                          </div>
                          <div class="file-path-wrapper">
                            <input  id="txtPicUpload1" type="text" class="file-path validate" placeholder="Upload Photo" runat="server"/>
                          </div>
                        <div id="pic1Thumb"></div>
                     </div>
                    
                

                
                <script>
                  function handleFileSelect(evt) {
                      var pic1files = evt.target.files; // FileList object

                    // Loop through the FileList and render image files as thumbnails.
                      for (var i = 0, f; f = pic1files[i]; i++) {

                      // Only process image files.
                      if (!f.type.match('image.*')) {
                        continue;
                      }

                      var reader = new FileReader();

                      // Closure to capture the file information.
                      reader.onload = (function(theFile) {
                        return function(e) {
                          // Render thumbnail.
                            document.getElementById('pic1Thumb').innerHTML = ['<img class="thumb" src="', e.target.result, '" title="', escape(theFile.name), '"/>'].join('');
                        };
                      })(f);

                      // Read in the image file as a data URL.
                      reader.readAsDataURL(f);
                    }
                  }

                  document.getElementById('pic1files').addEventListener('change', handleFileSelect, false);
                </script>

                    <div class="file-field input-field col s12 m4 l4">
                          <div class="btn waves-effect waves-light">
                            <span>Pic 2</span>
                            <input id="pic2files" type="file" name="pic2files[]" ClientIDMode="static" runat="server"/>
                          </div>
                          <div class="file-path-wrapper">
                            <input id="txtPicUpload2" class="file-path validate" type="text" placeholder="Upload Photo" runat="server"/>
                          </div>
                        <div id="pic2Thumb"></div>
                        </div>

                     <script>
                  function handleFileSelect(evt) {
                      var pic2files = evt.target.files; // FileList object

                    // Loop through the FileList and render image files as thumbnails.
                      for (var i = 0, f; f = pic2files[i]; i++) {

                      // Only process image files.
                      if (!f.type.match('image.*')) {
                        continue;
                      }

                      var reader = new FileReader();

                      // Closure to capture the file information.
                      reader.onload = (function(theFile) {
                        return function(e) {
                          // Render thumbnail.
                            document.getElementById('pic2Thumb').innerHTML = ['<img class="thumb" src="', e.target.result, '" title="', escape(theFile.name), '"/>'].join('');
                        };
                      })(f);

                      // Read in the image file as a data URL.
                      reader.readAsDataURL(f);
                    }
                  }

                  document.getElementById('pic2files').addEventListener('change', handleFileSelect, false);
                </script>







                    <div class="file-field input-field col s12 m4 l4">
                          <div class="btn waves-effect waves-light">
                            <span>Pic 3</span>
                            <input id="pic3files" type="file" name="pic3files[]" ClientIDMode="static" runat="server"/>
                          </div>
                          <div class="file-path-wrapper">
                            <input id="txtPicUpload3" class="file-path validate" type="text" placeholder="Upload Photo" runat="server"/>
                          </div>
                        </div>
                    <div id="pic3Thumb"></div>
                    </div>



                 <script>
                  function handleFileSelect(evt) {
                      var pic3files = evt.target.files; // FileList object

                    // Loop through the FileList and render image files as thumbnails.
                      for (var i = 0, f; f = pic3files[i]; i++) {

                      // Only process image files.
                      if (!f.type.match('image.*')) {
                        continue;
                      }

                      var reader = new FileReader();

                      // Closure to capture the file information.
                      reader.onload = (function(theFile) {
                        return function(e) {
                          // Render thumbnail.
                            document.getElementById('pic3Thumb').innerHTML = ['<img class="thumb" src="', e.target.result, '" title="', escape(theFile.name), '"/>'].join('');
                        };
                      })(f);

                      // Read in the image file as a data URL.
                      reader.readAsDataURL(f);
                    }
                  }

                  document.getElementById('pic3files').addEventListener('change', handleFileSelect, false);
                </script>


                <div class="row">
                    <input type="checkbox" id="ShowPhone" ClientIDMode="static" runat="server"/>
                    <label for="ShowPhone">Show Phone Number</label>
                    <blockquote>If you select "Show Phone Number" then other users broswing ads will be able to see your phone number.</blockquote>
                </div>

                 
            </div>
            <div class="card-action">
              <button id="btnPostAd" class="btn waves-effect waves-light" runat="server" onserverclick="btnPostAd_ServerClick">Post</button>
              <a href="Index.aspx" class="waves-effect waves-light btn red">Cancel</a>
            </div>
          </div>
        </div>
      </div>

    <script>
      // This example displays an address form, using the autocomplete feature
      // of the Google Places API to help users fill in the information.

      // This example requires the Places library. Include the libraries=places
      // parameter when you first load the API. For example:
      // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

      var placeSearch, autocomplete;
      /*var componentForm = {
        street_number: 'short_name',
        route: 'long_name',
        locality: 'long_name',
        administrative_area_level_1: 'short_name',
        country: 'long_name',
        postal_code: 'short_name'
      };*/

      function initAutocomplete() {
        // Create the autocomplete object, restricting the search to geographical
        // location types.
        autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('txtLocation')),
            {types: ['geocode']});

        // When the user selects an address from the dropdown, populate the address
        // fields in the form.
        autocomplete.addListener('place_changed', fillInAddress);
      }

      function fillInAddress() {
        // Get the place details from the autocomplete object.
        var place = autocomplete.getPlace();
        //document.getElementById('txtLocation').value = '';
        /*for (var component in componentForm)
        {
          document.getElementById(component).value = '';
          document.getElementById(component).disabled = false;
        }*/

        //document.getElementById('MapOutput').innerHTML = "<iframe width='60' height='60' frameborder='0' style='border:0' src='https://www.google.com/maps/embed/v1/place?key=AIzaSyB7eq5IZFtbXZitO0yI53upIROFqC5RBcY&q=Space+Needle,Seattle+WA'></iframe>";

        // Get each component of the address from the place details
        // and fill the corresponding field on the form.
        
        for (var i = 0; i < place.address_components.length; i++)
        {

          var addressType = place.address_components[i].types[0];
          //if (componentForm[addressType])
          //{
            var val = place.address_components[i][componentForm[addressType]];
            document.getElementById('txtLocation').value += val;
          //}

        }
        

      }

      // Bias the autocomplete object to the user's geographical location,
      // as supplied by the browser's 'navigator.geolocation' object.
      function geolocate() {
        if (navigator.geolocation) {
          navigator.geolocation.getCurrentPosition(function(position) {
            var geolocation = {
              lat: position.coords.latitude,
              lng: position.coords.longitude
            };
            var circle = new google.maps.Circle({
              center: geolocation,
              radius: position.coords.accuracy
            });
            autocomplete.setBounds(circle.getBounds());
          });
        }
      }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB7eq5IZFtbXZitO0yI53upIROFqC5RBcY&libraries=places&callback=initAutocomplete"
        async defer></script>
  

</asp:Content>
