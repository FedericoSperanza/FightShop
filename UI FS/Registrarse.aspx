<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Registrarse.aspx.vb" Inherits="Registrarse" %>

<%@ Register Assembly="GoogleReCaptcha" Namespace="GoogleReCaptcha" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <title>FightShop</title>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<link href="css/style.css" rel="stylesheet" type="text/css" media="all"/>
<link href="css/slider.css" rel="stylesheet" type="text/css" media="all"/>
<script type="text/javascript" src="js/jquery-1.7.2.min.js"></script> 
  <script src="https://code.jquery.com/jquery-3.1.0.min.js"></script>
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.0.0/jquery.min.js" integrity="sha384-THPy051/pYDQGanwU6poAc/hOdQxjnOEXzbT+OuUAFqNqFjL+4IGLBgCJC3ZOShY" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>



<script type="text/javascript" src="js/move-top.js"></script>
<script type="text/javascript" src="js/easing.js"></script>
<script type="text/javascript" src="js/startstop-slider.js"></script>
    
    <style type="text/css">

        btnIngreso{
            text-align:center;
        }
        .auto-style1 {
            width: 363px;
            height: 107px;
        }
        .auto-style3 {
            display: block;
            width: 40%;
            height: 34px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-clip: padding-box;
            border-radius: 4px;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            -webkit-transition: border-color ease-in-out .15s, -webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            border: 1px solid #ccc;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
        }
        </style>
    


    

</head>
<body>
    <%-- INICIO DEL FORM PARA EL SERVIDOR --%>
    <form runat="server">


     <div class="wrap">
	<div class="header">
		<div class="headertop_desc">
		       
             
			<div class="account_desc">
				<%--<ul>
                    
					<li> </li>
					
                    
				</ul>--%>
                            



              
</div>
           
                           

         

               
			</div>
        
			    
                  
           
                        
          <%-- BUSCADOR --%>
		</div>
       
		<div class="header_top">
			<div class="logo">
				&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
				<img src="images/logo_fightshop.png" alt="" class="auto-style1" />
		           
            	<%-- SEARCH BUTTON --%>
 
     
</div>
           
          
	 <div class="clear"></div>
         
            <div class="clear">
           
            </div>
            
  </div>
      

         <nav class="navbar navbar-expand-lg navbar-light bg-light">
 
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
             <%-- collapse navbar-collapse --%>
  <div class="container" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" runat="server" href="Home.aspx">Home<span class="sr-only"></span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="Nosotros.aspx">Nosotros</a>
      </li>
        
    
        
    </ul>
    <div class="form-inline my-2 my-lg-0">
			&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
         <input class="form-control mr-sm-2" type="search" placeholder="Buscar" aria-label="Search">
      <button class="btn btn-outline-success my-2 my-sm-0" type="submit"><span class="glyphicon glyphicon-search"></span></button>
                </div>
    
      
     
    
  </div>
</nav>
         
    
  
      <div class="form-row mr-3 justify-content-center mt-3">
        <div class="col-md-4">
          <label for="txtName">Nombre</label>
          <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Nombre" required="required"></asp:TextBox>
        </div>
        <div class="col-md-4">
          <label for="txtSurname">Apellido</label>
          <asp:TextBox ID="txtSurname" runat="server" class="form-control" placeholder="Apellido" required="required"></asp:TextBox>
        </div>
      </div>

      <div class="form-row mr-3 justify-content-center mt-3">
        <div class="col-md-4">
          <label for="txtEmail">E-mail</label>
          <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="E-mail" required="required" TextMode="Email"></asp:TextBox>
        </div>
        <div class="col-md-4">
          <label for="txtPass">Clave</label>            
          <asp:TextBox ID="txtPass" runat="server" class="form-control" placeholder="Clave" required="required" TextMode="Password"></asp:TextBox>
        </div>
      </div>

         <div class="form-row mr-3 justify-content-center mt-3">
        <div class="col-md-4">
          <label for="txtEmail">Telefono</label>
          <asp:TextBox ID="txtTelf" runat="server" pattern="\d{2}\d{4}\d{4}" class="form-control" placeholder="Telefono(11-1111-1111)" required="required" TextMode="Phone"></asp:TextBox>
        </div>
        <div class="col-md-4">
         </div>
      </div>
          <div class="form-row mr-3 justify-content-center mt-3">
                                   <input type="checkbox" id="terminos" name="chs" required="required"/>
                                    Acepto &nbsp<a href="Terms.aspx" target="_blank">terminos y condiciones.</a>
                                </div>
         <%-- CAPTCHA --%>
         <div class="form-row mr-3 justify-content-center mt-3">
        <cc1:googlerecaptcha ID="ctrlGoogleReCaptcha" runat="server" PublicKey="6LepOW8UAAAAAFwZFhj-UoOlcaIMriOVt6mUledX" PrivateKey="6LepOW8UAAAAAN9LCwQMTTyC3B4Vfqyenfc59V5E" />
    </div>



      <div class="form-row mr-3 justify-content-center mt-3">
         
        <asp:Button class="btn btn-primary" ID="btnCrearCuenta" runat="server" Text="Crear cuenta" />
      </div>  
         <%-- Si se le pone a la class collapse, no aparece hasta que se pone .show --%>
         <div runat="server" visible="false" id="regSuccess" class="alert alert-success" role="alert">
  
</div>

    <div>
        <%-- Script de mensaje --%>
         <%-- <script type="text/javascript"> 
              $(document).ready(function () {
                  $('#btnCrearCuenta').click(function () {
                      $('#regSuccess').show(''); 
                  } ) ;
              });
              </script>--%>
       



<%--  <input type="checkbox" id="terminos" name="chs" required="required"/>
                                    Acepto <a href="Terms.aspx" target="_blank">terminos y condiciones.</a>--%>
  <%--TERMINOS Y CONDICIONES--%>

       <br />
        <br />
   	  <div class="wrap" >	
	     <div class="section group">
				<div class="col_1_of_4 span_1_of_4">
						<h4><a href="Nosotros.aspx">¿Quienes Somos?</a></h4>
						                    
					</div>
			<div class="col_1_of_4 span_1_of_4">
						<h4><a href="Terms.aspx">Terminos y Condiciones</a</h4>
						
                   
					</div>
			<div class="col_1_of_4 span_1_of_4">
						<h4><a href="#">Politicas de Seguridad</a</h4>
						
                   
					</div>

                	
             <div class="col_1_of_4 span_1_of_4">
					
						<div class="social-icons">
							<h4>Redes</h4>
					   		  <ul>
							      <li><a href="#" target="_blank"><img src="" alt="" /></a></li>
							      <li><a href="#" target="_blank"><img src="" alt="" /></a></li>
							      <li><a href="#" target="_blank"><img src="" alt="" /> </a></li>
							      <li><a href="#" target="_blank"> <img src="" alt="" /></a></li>
							      <li><a href="#" target="_blank"> <img src="images/linkedin.png" alt="" /></a></li>
							      <div class="clear"></div>
						     </ul>
   	 					</div>
				</div>
			</div>			
        </div>
       
   
        <div class="copy_right">
				<p> <a href="/"></a></p>
		   </div>
    </div>
    <%--    </div>--%>
   
    <a href="#" id="toTop"><span id="toTopHover"> </span></a>
        </form>
</body>
</html>