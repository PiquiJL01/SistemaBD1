<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarClienteNatural.aspx.cs" Inherits="Ucabmart.Views.ConsultarClienteNatural" %>

<!DOCTYPE html>
<html lang="es">
    <head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Ucabmart - Consultar Cliente Natural</title>
        <link rel="icon" type="image/x-icon" href="../../Content/assets/img/favicon.ico" />
        <!-- Font Awesome icons (free version)-->
        <script src="https://use.fontawesome.com/releases/v5.15.1/js/all.js" crossorigin="anonymous"></script>
        <!-- Google fonts-->
        <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700" rel="stylesheet" type="text/css" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="../Content/css/RegistroCliente.css" rel="stylesheet" />
    </head>

    <body id="page-top" class="bg-gradient-primary">
        <!-- Navigation-->
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top" id="mainNav">
            <div class="container">
                <a class="navbar-brand js-scroll-trigger" href="#page-top"><img class="Icon" src="../../Content/assets/img/Ucabmart-Logo.png" alt="" /></a>
               
                <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    Menu
                    <i class="fas fa-bars ml-1"></i>
                </button>

                <div class="collapse navbar-collapse" id="navbarResponsive">      
                   <!-- Topbar Search -->
                    <ul class="navbar-nav text-uppercase ml-auto">
                        <li class="nav-item"> <a class="nav-item">      </a></li>
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
                        <li class="li-4" >CLIENTES-UCABMART</li>
                        <li><img src="../Content/assets/img/Client/Client-Icono.png" height="80px"/>  </li>
                    </ul>
                </li>
                <li class="li-3"></li>
            </ul>
        </div>
        
        <div class="container">
            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <div>
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Consultar Cliente - Persona Natural</h1>
                            </div>
                            
                            <form id="form1" runat="server">
                                <div class="table-responsive">
                                    <table class="table table-striped table-sm">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Header</th>
                                                <th>Header</th>
                                                <th>Header</th>
                                                <th>Header</th>
                                            </tr>
                                        </thead>

                                        <tbody>
                                            <tr>
                                                <td>1,001</td>
                                                <td>Lorem</td>
                                                <td>ipsum</td>
                                                <td>dolor</td>
                                                <td>sit</td>
                                            </tr>

                                            <tr>
                                                <td>1,002</td>
                                                <td>amet</td>
                                                <td>consectetur</td>
                                                <td>adipiscing</td>
                                                <td>elit</td>
                                            </tr>
                                            
                                            <tr>
                                                <td>1,003</td>
                                                <td>Integer</td>
                                                <td>nec</td>
                                                <td>odio</td>
                                                <td>Praesent</td>
                                            </tr>
                                            
                                            <tr>
                                                <td>1,003</td>
                                                <td>libero</td>
                                                <td>Sed</td>
                                                <td>cursus</td>
                                                <td>ante</td>
                                            </tr>
                                           
                                            <tr>
                                                <td>1,004</td>
                                                <td>dapibus</td>
                                                <td>diam</td>
                                                <td>Sed</td>
                                                <td>nisi</td>
                                            </tr>
                                            
                                            <tr>
                                                <td>1,005</td>
                                                <td>Nulla</td>
                                                <td>quis</td>
                                                <td>sem</td>
                                                <td>at</td>
                                            </tr>
                                            
                                            <tr>
                                                <td>1,006</td>
                                                <td>nibh</td>
                                                <td>elementum</td>
                                                <td>imperdiet</td>
                                                <td>Duis</td>
                                            </tr>
                                            
                                            <tr>
                                                <td>1,007</td>
                                                <td>sagittis</td>
                                                <td>ipsum</td>
                                                <td>Praesent</td>
                                                <td>mauris</td>
                                            </tr>
                                            
                                            <tr>
                                                <td>1,008</td>
                                                <td>Fusce</td>
                                                <td>nec</td>
                                                <td>tellus</td>
                                                <td>sed</td>
                                            </tr>
                                            
                                            <tr>
                                                <td>1,009</td>
                                                <td>augue</td>
                                                <td>semper</td>
                                                <td>porta</td>
                                                <td>Mauris</td>
                                            </tr>
                                          
                                            <tr>
                                                <td>1,010</td>
                                                <td>massa</td>
                                                <td>Vestibulum</td>
                                                <td>lacinia</td>
                                                <td>arcu</td>
                                            </tr>
                                          
                                            <tr>
                                                <td>1,011</td>
                                                <td>eget</td>
                                                <td>nulla</td>
                                                <td>Class</td>
                                                <td>aptent</td>
                                            </tr>
                                            
                                            <tr>
                                                <td>1,012</td>
                                                <td>taciti</td>
                                                <td>sociosqu</td>
                                                <td>ad</td>
                                                <td>litora</td>
                                            </tr>
                                          
                                            <tr>
                                                <td>1,013</td>
                                                <td>torquent</td>
                                                <td>per</td>
                                                <td>conubia</td>
                                                <td>nostra</td>
                                            </tr>
                                         
                                            <tr>
                                                <td>1,014</td>
                                                <td>per</td>
                                                <td>inceptos</td>
                                                <td>himenaeos</td>
                                                <td>Curabitur</td>
                                            </tr>
                                          
                                            <tr>
                                                <td>1,015</td>
                                                <td>sodales</td>
                                                <td>ligula</td>
                                                <td>in</td>
                                                <td>libero</td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>

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


