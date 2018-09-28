<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba01.aspx.cs" Inherits="MiBarWeb.Prueba01" %>

<!DOCTYPE html>

<html lang="en">
  <head>
    <meta name="google-signin-scope" content="profile email">
    <meta name="google-signin-client_id" content="188020733885-mbtmrvhv4nqjf24ip0j04vun2q91sh5o.apps.googleusercontent.com">
    <script src="https://apis.google.com/js/platform.js" async defer></script>
  </head>
  <body>
   <form id="form1" runat="server">
      <div class="g-signin2" data-onsuccess="onSignIn" data-theme="dark"></div>
      <a href="#" onclick="signOut();">Sign out</a>
        <script>
          function onSignIn(googleUser) {
            // Useful data for your client-side scripts:  X0oSClq7YfDBBB_kQ3WcMDQn

              var profile = googleUser.getBasicProfile();
              alert("ID: " + profile.getId());
            //console.log("ID: " + profile.getId()); // Don't send this directly to your server!
            //console.log('Full Name: ' + profile.getName());
            //console.log('Given Name: ' + profile.getGivenName());
            //console.log('Family Name: ' + profile.getFamilyName());
            //console.log("Image URL: " + profile.getImageUrl());
            //console.log("Email: " + profile.getEmail());

            // The ID token you need to pass to your backend:
            var id_token = googleUser.getAuthResponse().id_token;
              //console.log("ID Token: " + id_token);
              sessionStorage.setItem('id', profile.getId());
              sessionStorage.setItem('name', profile.getName());
              sessionStorage.setItem('email', profile.getEmail());
              sessionStorage.setItem('id_token', id_token);
          
              window.location.href = "Prueba01.aspx?id=" + id_token;
                    
              alert("ID Token: " + id_token);
            };
          function signOut() {
                var auth2 = gapi.auth2.getAuthInstance();
                auth2.signOut().then(function () {
                    console.log('User signed out.');
                });
            }
        </script>
        <span>Email</span><br />
        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
    </form>
  </body>
</html>