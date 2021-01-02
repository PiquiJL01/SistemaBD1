<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarClienteJuridico.aspx.cs" Inherits="Ucabmart.Views.RegistrarClienteJuridico" %>

<!DOCTYPE html>
<html lang="es">
    <head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Ucabmart - Agregar Cliente</title>
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
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Crear Cuenta - Persona Jurídica</h1>
                            </div>
                            <form id="form1" runat="server">
                                 <%--<Campo de texto del Rif >--%>
                                 <asp:Label ID="lblRif" runat="server" Text="Rif"></asp:Label> 
                                 <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                       <br >
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user-times"></i></span></span>
                                            <asp:DropDownList ID="dplRif" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                <asp:ListItem>J</asp:ListItem>
                                                <asp:ListItem>G</asp:ListItem>
                                              </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 ">
                                       <br >
                                        <asp:TextBox ID="txtRif" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su número de Rif " autocomplete="off" class="form-control">
                                         </asp:TextBox>
                                    </div>
                                </div>

                                 <%--<Campo de texto la denominacion comercial >--%>
                                <div class="form-group">
                                    <asp:TextBox ID="txtDenoComercial" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Denominación Comercial" autocomplete="off" class="form-control" style="text-align: center">
                                     </asp:TextBox>
                                </div>
                                 <%--<Campo de texto de la razon social >--%>
                                <div class="form-group">
                                    <asp:TextBox ID="txtRazonSocial" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                         placeholder="Razón Social " autocomplete="off" class="form-control" style="text-align: center">
                                    </asp:TextBox>
                                </div>
                                  <%--<Campo de texto del correo >--%>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCorreo" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese su correo electrónico" autocomplete="off" class="form-control"  style="text-align: center">
                                     </asp:TextBox>
                                </div>
                                <br >
                                 <%--<Campo de texto de los telefonos >--%>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtTelefono1" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Teléfono 1 " autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtTelefono2" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Teléfono 2" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                 <%--<Campo de texto de la dirección fiscal >--%>
                                <div class="form-group">
                                    <asp:Label ID="Label1" for="txtDireccionFiscal" runat="server" Text="Dirección Físcal"></asp:Label>
                                    <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fa fa-user"></i></span></span>
                                        <asp:TextBox ID="txtDireccionFiscal" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="" autocomplete="off" class="form-control" Height="87px" Width="361px"></asp:TextBox>
                                    </div>
                                </div>
                                <%--<Campo de texto de la dirección fisica principal>--%>
                                <div class="form-group">
                                    <asp:Label ID="Label2" for="txtDireccionFisica" runat="server" Text="Dirección Física Principal"></asp:Label>
                                    <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fa fa-user"></i></span></span>
                                        <asp:TextBox ID="txtDireccionFisica" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="" autocomplete="off" class="form-control" Height="87px" Width="361px"></asp:TextBox>
                                    </div>
                                </div>
                                  <%--<Campo de texto de la pagina web >--%>
                                <div class="form-group">
                                    <asp:TextBox ID="txtPaginaWeb" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese su Página Web" autocomplete="off" class="form-control"  style="text-align: center">
                                     </asp:TextBox>
                                </div>
                                <%--<Campo de texto capital disponible >--%>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCapitalDisponible" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese su Capital Disponible" autocomplete="off" class="form-control"  style="text-align: center">
                                     </asp:TextBox>
                                </div>
                                <%--<Campo de texto para Personas de Contacto >--%>
                                <asp:Label ID="Label3" runat="server" Text="Personas de Contacto"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtContacto1" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Nombres y apellidos Persona 1" autocomplete="off" class="form-control"  style="text-align: center">
                                     </asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox ID="txtContacto2" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Nombres y apellidos Persona 2" autocomplete="off" class="form-control"  style="text-align: center">
                                     </asp:TextBox>
                                </div>

                                <%--<Campo de seleccion para medios de pagos>--%>
                                <asp:Label ID="lblPagos" runat="server" Text="Medios de Pago"></asp:Label>
                                <div class="form-group">
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user-times"></i></span></span>
                                            <asp:DropDownList ID="dplPago" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                <asp:ListItem>Tarjeta de Débito</asp:ListItem>
                                                <asp:ListItem>Tarjeta de Crédito</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                </div>
                                 <%--<Campo de texto para la contraseña>--%>
                                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <br>
                                        <asp:TextBox ID="txtContraseña" runat="server" type="password" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese contraseña " autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <br>
                                       <asp:TextBox ID="txtRepetirContraseña" runat="server" type="password" name="name" data-parsley-trigger="change"  
                                            placeholder="Repetir Contraseña " autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>
                               
                                <asp:Button ID="btnRegistrar" runat="server" class="btn btn-primary btn-user btn-block" Text="Registrar Cuenta" OnClick="btnRegistrar_Click" />
                            </form>
                        </div>
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


