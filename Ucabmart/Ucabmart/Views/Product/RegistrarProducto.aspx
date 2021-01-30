<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarProducto.aspx.cs" Inherits="Ucabmart.Views.Product.RegistrarProducto" %>

<!DOCTYPE html>
<html lang="es">
    <head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Ucabmart - Registrar Producto</title>
        <link rel="icon" type="image/x-icon" href="../../Content/assets/img/favicon.ico" />
        <!-- Font Awesome icons (free version)-->
        <script src="https://use.fontawesome.com/releases/v5.15.1/js/all.js" crossorigin="anonymous"></script>
        <!-- Google fonts-->
        <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700" rel="stylesheet" type="text/css" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="../../Content/css/RegistrarProducto.css" rel="stylesheet" />
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
                          <li class="li-4" >PRODUCTOS-UCABMART</li>
                          <li><img src="../../Content/assets/img/Product/Product-Icon.png" height="80px"/>  </li>
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
                                <h1 class="h4 text-gray-900 mb-4">Registrar Producto</h1>
                            </div>
                            <form id="form1" runat="server">

                                 <%--<Campo de texto del nombre >--%>

                                <br/>
                                 <div class="form-group">
                                         <asp:Label ID="Nombre" runat="server" Text="Nombre"></asp:Label>
                                        <asp:TextBox ID="TxtNombre" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese el nombre del producto" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                </div>

                                 <%--<Campo de texto del precio >--%>

                                 <div class="form-group" style="margin-bottom:-10px">
                                     <asp:Label ID="Precio" runat="server" Text="Precio"></asp:Label>
                                     <asp:TextBox ID="TxtPrecio" runat="server" type="number"  data-parsley-trigger="change"  
                                            placeholder="Ingrese el precio del producto" autocomplete="off" class="form-control">
                                     </asp:TextBox>
                                </div>

                                <br/>
                                <%--<Campo de texto de la Descripcion >--%>
                                <div class="form-group">
                                    <asp:Label ID="Label14" runat="server" Text="Descripcion"></asp:Label>
                                    <asp:TextBox ID="TxtDescripcion" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese la descripcion del producto" autocomplete="off" class="form-control">
                                     </asp:TextBox>
                                </div>


                                <%--<ALIMENTICIO Y CAREGORIA>--%>
                                
                                 <div class="form-group" style="margin-bottom:-10px">
                                     
                                     <%--<Campo de si el producto es alimenticio >--%>

                                            <asp:DropDownList ID="dplAlimenticio" runat="server" style="padding-bottom: 15px; margin-top: 35px; margin-bottom: 15px; background-color: #0f136bd6;color: white; width: 260px;" class="input-group-prepend be-addon">
                                                <asp:ListItem value ="">Alimenticio</asp:ListItem>
                                                <asp:ListItem value ="Si">Si</asp:ListItem>
                                                <asp:ListItem value ="No">No</asp:ListItem>
                                              </asp:DropDownList>
                                     <br />

                                      <%--<Campo de la Categoria>--%>

                                            <asp:DropDownList ID="dplCalidad" runat="server" style="padding-bottom: 15px; margin-top: -78px; margin-bottom: 28px; margin-left: 280px; background-color: #0f136bd6;color: white; width: 260px;" class="input-group-prepend be-addon">
                                                <asp:ListItem value ="">Calidad</asp:ListItem>
                                                <asp:ListItem value ="Alta">Alta</asp:ListItem>
                                                <asp:ListItem value ="Media">Media</asp:ListItem>
                                                <asp:ListItem value ="Baja">Baja</asp:ListItem>
                                            </asp:DropDownList>

                                </div>
                               

                                <br />

                                <div class="form-group">
                                    <asp:DropDownList ID="Marcas" runat="server" style="padding-bottom: 15px; background-color: #0f136bd6;color: white; width: 260px;" class="input-group-prepend be-addon">
                                   </asp:DropDownList>

                                    <asp:DropDownList ID="Clasificacion" runat="server" style="padding-bottom: 15px; margin-left: 280px; margin-top: -40px; background-color: #0f136bd6;color: white; width: 260px;" class="input-group-prepend be-addon">
                                   </asp:DropDownList>

                                </div>


                                <hr>
                                <asp:Button ID="btnRegistrar" runat="server" class="btn btn-primary btn-user btn-block" Text="Registrar Producto" OnClick="btnRegistrar_Click"/>
                                          
                            
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
