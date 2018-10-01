<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsConOAuthNemiro._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Bienvenido a MiBar!</h1>
        <p class="lead">Para empezar a utilizar la apliacion selecciona una opcion!</p>        
    </div>

    <div class="row">
        <div class="col-sm-6 col-md-6 col-lg-6">
            <h2>Con Mesa</h2>
            <p>
                Si tenes una mesa selecciona esta opcion y acercate a la misma para ingresar el numero o leer el codigo QR                
            </p>
            <br />
            
            <div style="text-align:center">
               <a href="Views/qr.aspx"> <img width="250px" height="250px" src="Content/img/mesa.png" class="" /></a>
            </div>
        </div>
        <div class="col-sm-6 col-md-6 col-lg-6">
            <h2>Solo</h2>
            <p>
                ¿Venis solo y queres hacer pedidos en la barra sin esperar?. Selecciona esta opcion, hace tu pedido, pasa por caja 
                y listo espera que te avisemos para ir a buscar tu pedido!
            </p>
                           
            <div style="text-align:center">
               <a href="Views/qr.aspx"> <img width="250px" height="250px" src="Content/img/barra.png" class="" /></a>
            </div>
            
        </div>        
    </div>

</asp:Content>
