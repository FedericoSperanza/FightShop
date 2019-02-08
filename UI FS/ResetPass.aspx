<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ResetPass.aspx.vb" Inherits="ResetPass" %>

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
        btnIngreso {
            text-align: center;
        }

        .auto-style4 {
            margin-left: 880px;
        }
    </style>
    


    

</head>
<body>
    <%-- INICIO DEL FORM PARA EL SERVIDOR --%>
    <form runat="server">

          

         

               
			
        
			    
                  
           
                        
          <%-- BUSCADOR --%>
		</div>
       
		<div class="header_top">
		
           
          
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
         <nav>
         <h2><p>Olvidaste Contraseña?</p></h2>
         </nav>
         <h3><p>Recupere su contraseña Aqui</p></h3>

        <p> Por favor ingrese su Email</p>

           <div class="form-row mr-3 justify-content-center mt-3">
        <div class="col-md-4">
          <label for="txtEmail">E-mail</label>
          <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="E-mail" required="required" TextMode="Email"></asp:TextBox>
        <%-- Ingreso de codigo --%>
         <label runat="server" id="lblTxtCodigo" visible="false" for="txtCodigo">Codigo</label>
          <asp:TextBox ID="txtCodigo" runat="server" Visible="false" class="form-control" placeholder="Codigo" required="required"></asp:TextBox>
       
        </div>

               
               
               </div>
          <div class="auto-style4">
              <asp:Button class="btn btn-primary" ID="btnResetPass" runat="server" Text="Aplicar" />
          </div>
    
   
         <%-- Si se le pone a la class collapse, no aparece hasta que se pone .show --%>
         <div runat="server" visible="false" id="regSuccess" class="alert alert-success" role="alert">
  Hemos enviado un mail a su casilla. Por favor ingrese el codigo enviado.
</div>


        <br />
        <br />
        <br />
        <br />
         <br />
        <br />
        <br />
        <br />
   
   
    <a href="#" id="toTop"><span id="toTopHover"> </span></a>
        </form>

    <div class="footer">
       <br />
        <br />
   	  <div class="auto-style21" >	
	     <div class="section group" style="height: 91px">
				<div class="col_1_of_4 span_1_of_4">
						<h4><a href="Nosotros.aspx">Nosotros</a></h4>
						                    
					</div>
			<div class="col_1_of_4 span_1_of_4">
						<h4><a href="Terms.aspx">Terminos y Condiciones</a</h4>
						
                   
					</div>
			<div class="col_1_of_4 span_1_of_4">
						<h4><a href="Politicas.aspx">Politicas de Seguridad</a</h4>
						
                   
					</div>

                	
             <div class="col_1_of_4 span_1_of_4">
					
						
							<h4><a href="#">Redes</a></h4>
					   		  <ul>
							     <%-- <li><a href="#" target="_blank"><img src="" alt="" /></a></li>
							      <li><a href="#" target="_blank"><img src="" alt="" /></a></li>
							      <li><a href="#" target="_blank"><img src="" alt="" /> </a></li>
							      <li><a href="#" target="_blank"> <img src="" alt="" /></a></li>
							      <li><a href="#" target="_blank"> <img src="" alt="" /></a></li>--%>
							      <div class="clear"></div>
						     </ul>
   	 					
				</div>
			</div>			
        </div>
       
   
        <%--<div class="copy_right">
				<p> FightShop 2018</p>
		   </div>--%>
    </div>
        
   
    <a href="#" id="toTop"><span id="toTopHover"> </span></a>
</body>
</html>
