<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Role_Admin.aspx.cs" Inherits="Ucabmart.Views.Role.Role_Admin" %>

<!DOCTYPE html>
<html lang="es">
    <head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Ucabmart</title>
        <link rel="icon" type="image/x-icon" href="../../Content/assets/img/favicon.ico" />
        <!-- Font Awesome icons (free version)-->
        <script src="https://use.fontawesome.com/releases/v5.15.1/js/all.js" crossorigin="anonymous"></script>
        <!-- Google fonts-->
        <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700" rel="stylesheet" type="text/css" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="../../Content/css/Role.css" rel="stylesheet" />
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
                        <li class="nav-item"> <a class="nav-item"></a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Clientes_Admin.aspx">Clientes</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Tiendas-Admin.aspx">Tiendas</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Productos_Admin.aspx">Productos</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Proveedores.aspx">Proveedores</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Nomina_Admin.aspx">Nomina</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Role/Role_Admin.aspx">Roles</a></li>
                        <li class="nav-item"><a class="nav-link js-scroll-trigger" href="/Views/Inicio_Admin.aspx">Inicio</a></li>
                    
                        <li class="nav-item dropdown no-arrow">
                            <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span > <%: nombreUsuario %></span>
                                <img class="img-profile rounded-circle"
                                    src="../../Content/assets/img/undraw_profile.svg" style="width:35px;">
                            </a>
                            <!-- Dropdown - User Information -->
                            <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in"
                                aria-labelledby="userDropdown">
                                <a class="dropdown-item" href="#">
                                    <i class="fas fa-user fa-sm fa-fw mr-2 text-gray-400"></i>
                                    Perfil
                                </a>
                                <a class="dropdown-item" href="#">
                                    <i class="fas fa-cogs fa-sm fa-fw mr-2 text-gray-400"></i>
                                    Configuración
                                </a>
                                <a class="dropdown-item" href="#">
                                    <i class="fas fa-list fa-sm fa-fw mr-2 text-gray-400"></i>
                                    Activity Log
                                </a>
                                <div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#" data-toggle="modal" data-target="#logoutModal">
                                    <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                                    Logout

                                </a>
                            </div>
                        </li>                    
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
                          <li class="li-4" >ROLES-UCABMART</li>
                          <li><img src="../../Content/assets/img/Role/Roles-Icon2.png" height="80px"/>  </li>
                      </ul>
                  </li>
                  <li class="li-3"></li>
              </ul>
          </div>

          <header class="masthead" style="margin-top: -14px; margin-bottom: 40px;">
          </header>

       <!-- Options -->
           <div class="option">Opciones</div>

      <section class="page-section" id="categorias">
         <div class="container cuadro" style="margin-top: -150px; padding-top: 80px;">
            <div class="row" style="padding-left: 150px;">
                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="categorias-item">
                            <a class="categorias-link" href="/Views/Role/AsignarRol.aspx">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Provider/Add-Provider.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-68px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Asignar Rol</div>
                                <div class="categorias-caption-subheading text-muted">Permite asignarle el rol a un usuario...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="margin-left: 120px">
                        <div class="categorias-item">
                            <a class="categorias-link" href="ConsultarRol.aspx">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Provider/Consulting-Provider.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-69px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Consultar Rol</div>
                                <div class="categorias-caption-subheading text-muted">Permite revisar los roles de los usuarios......</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="box-sizing: initial">
                        <div class="categorias-item">
                            <a class="categorias-link" href="/Views/Role/ModificarRol.aspx">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Provider/Update-Provider.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-44px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Modificar Rol</div>
                                <div class="categorias-caption-subheading text-muted">Permite cambiar los roles de los usuarios......</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="margin-left: 100px">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Provider/Delete-Provider.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-68px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Eliminar Rol</div>
                                <div class="categorias-caption-subheading text-muted">Permite eliminar los roles de los usuarios......</div>
                            </div>
                        </div>
                    </div>

                    <!-- Permisos -->

                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Role/Assign-permisos.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-68px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Asignar Permisos</div>
                                <div class="categorias-caption-subheading text-muted">Permite asignar los permisos asociados al rol...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="margin-left: 120px">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Role/Query_Permisos.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-69px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Consultar Permisos</div>
                                <div class="categorias-caption-subheading text-muted">Permite consultar los permisos asociados a los roles......</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="box-sizing: initial">
                        <div class="categorias-item">
                            <a class="categorias-link" href="/Views/Role/ModificarRol.aspx">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Role/Update_Permisos.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-44px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Modificar Permisos</div>
                                <div class="categorias-caption-subheading text-muted">Permite cambiar los permisos de los roles......</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="margin-left: 100px">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Role/delete-Permisos.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-68px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Eliminar Permisos</div>
                                <div class="categorias-caption-subheading text-muted">Permite eliminar uno o varios permisos de un rol......</div>
                            </div>
                        </div>
                    </div>

                   
            </div>
          </div>
        </section>

           <br>
           <br>
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

           <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
              aria-hidden="true">
              <div class="modal-dialog" role="document">
                  <div class="modal-content">
                      <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">¿Listo para salir?</h5>
                            <button class="close" type="button" data-dismiss="modal" aria-label="Cerrar Sesión">
                                <span aria-hidden="true">×</span>
                            </button>
                        </div>
                        <div class="modal-body">¿Está seguro que desea cerrar sesión?</div>
                        <div class="modal-footer">
                            <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancelar</button>
                            <a class="btn btn-primary" href="IniciarSesion.aspx">Logout</a>
                        </div>
                    </div>
                </div>
            </div>

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

