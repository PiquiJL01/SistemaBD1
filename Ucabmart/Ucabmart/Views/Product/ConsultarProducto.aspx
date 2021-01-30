<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarProducto.aspx.cs" Inherits="Ucabmart.Views.Product.ConsultarProducto" %>

<!DOCTYPE html>
<html lang="es">
    <head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Ucabmart - Registrar Cliente Jurídico</title>
        <link rel="icon" type="image/x-icon" href="../../Content/assets/img/favicon.ico" />
        <!-- Font Awesome icons (free version)-->
        <script src="https://use.fontawesome.com/releases/v5.15.1/js/all.js" crossorigin="anonymous"></script>
        <!-- Google fonts-->
        <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700" rel="stylesheet" type="text/css" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="../../Content/css/RegistroProveedores.css" rel="stylesheet" />
    </head>

      <body id="page-top" class="bg-gradient-primary">


        <!-- Navigation-->
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top" id="mainNav">
            <div class="container">
                <a class="navbar-brand js-scroll-trigger" href="#page-top"><img class="Icon" src="../../Content/assets/img/Ucabmart-Logo.png" alt="" /></a>
                <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    <i class="fas fa-bars ml-1"></i>
                </button>
                <div class="collapse navbar-collapse" id="navbarResponsive">      
                   <!-- Topbar Search -->
                       
                    <ul class="navbar-nav text-uppercase ml-auto">
                        <li class="nav-item"> <a class="nav-item">      </a>     </li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Clientes_Admin.aspx">Clientes</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Tiendas-Admin.aspx">Tiendas</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Productos_Admin.aspx">Productos</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Proveedores.aspx">Proveedores</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Nomina_Admin.aspx">Nomina</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Inicio_Admin.aspx">Inicio</a></li>
                    </ul>  
                </div>
            </div>
        </nav>
       
          <!-- Top Frame -->
          <div class="Top-Frame">
              <ul class="Ordened">
                  <li class="li-1"></li>
                  <li class="li-2">
                      <ul class="Ordened">
                          <li class="li-4" >PRODUCTOS-UCABMART</li>
                          <li><img src="../../Content/assets/img/Product/Product-Icon.png" height="80px"/>  </li>
                      </ul>
                  </li>
                  <li class="li-3"></li>
              </ul>
          </div>
          
        <!-- Options -->
           <div class="option">Consultar Producto</div>
          
          <form id="form1" runat="server">  
              <div class="container">
                  <div class="card o-hidden border-0 shadow-lg my-5">
                      <div class="card-body p-0">
                          <div>
                              <div class="p-5">  
                                  <div class="table-responsive" ID="listaPersonaTabla" runat="server">
                                      <div class="text-center">

                                      </div>
                                </div>
                              </div>
                          </div>
                      </div>
                  </div>
              </div>
          </form>

        <!-- Footer-->
        <footer class="footer py-4">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-4 text-lg-left">Copyright © Your Website 2020</div>
                    <div class="col-lg-4 my-3 my-lg-0">
                        <a class="btn btn-dark btn-social mx-2" href="#!"><i class="fab fa-twitter"></i></a>
                        <a class="btn btn-dark btn-social mx-2" href="#!"><i class="fab fa-facebook-f"></i></a>
                        <a class="btn btn-dark btn-social mx-2" href="#!"><i class="fab fa-linkedin-in"></i></a>
                    </div>
                    <div class="col-lg-4 text-lg-right">
                        <a class="mr-3" href="#!">Privacy Policy</a>
                        <a href="#!">Terms of Use</a>
                    </div>
                </div>
            </div>
        </footer>
        <!-- Bootstrap core JS-->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js"></script>
        <!-- Third party plugin JS-->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.4.1/jquery.easing.min.js"></script>
        <!-- Contact form JS-->
        <script src="../../Content/assets/mail/jqBootstrapValidation.js"></script>
        <script src="../../Content/assets/mail/contact_me.js"></script>
        <!-- Core theme JS-->
        <script src="../../Content/js/scripts.js"></script>
    </body>
</html>
