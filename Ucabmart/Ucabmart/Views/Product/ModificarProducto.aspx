<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarProducto.aspx.cs" Inherits="Ucabmart.Views.Product.ModificarProducto" %>

<!DOCTYPE html>
<html lang="es">
    <head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Ucabmart - Modificar Producto</title>
        <link rel="icon" type="image/x-icon" href="../../Content/assets/img/favicon.ico" />
        <!-- Font Awesome icons (free version)-->
        <script src="https://use.fontawesome.com/releases/v5.15.1/js/all.js" crossorigin="anonymous"></script>
        <!-- Google fonts-->
        <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700" rel="stylesheet" type="text/css" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="../../Content/css/ModificarCliente.css" rel="stylesheet" />
        
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
                          <li class="li-4" >PRODUCTOS-UCABMART</li>
                          <li><img src="../../Content/assets/img/Product/Product-Icon.png" height="80px"/>  </li>
                      </ul>
                  </li>
                  <li class="li-3"></li>
              </ul>
          </div>

      <form id="form1" runat="server">  
        <div class="container">
            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <div>
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Modificar Producto</h1>
                            </div>
                            
                            <%--<form id="form1" runat="server">--%>
                                <div class="form-group" style="width: 500px; margin-left: auto; margin-right: auto;">
                                    <div class="input-group mb-3"><span class="input-group-prepend" style="box-shadow: 1.5px 1px 5px #443939;"><span class="input-group-text"><i class="fa fa-user"></i></span></span> 
<%--                                        <asp:DropDownList ID="dplTipoCliente" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                            <asp:ListItem>Natural</asp:ListItem>
                                            <asp:ListItem>Jurídico</asp:ListItem>
                                        </asp:DropDownList>   --%>
                                        <asp:TextBox ID="BuscarCod" runat="server" type="number" name="name" data-parsley-trigger="change"  
                                         placeholder="Ingrese el codigo del producto..." autocomplete="off" class="form-control" style="padding:10px 50px 10px 50px; text-align: left;">
                                        </asp:TextBox>

                                        <asp:Button ID="btnBuscar" runat="server" class="btn btn-space btn-primary ml-1" Text="Buscar" OnClick="btnBuscar_Click" Width="87px" />
                                        
                                    </div>
                                </div>

                                <br />
                                <br />
                             <%--<Datos del Cliente>--%>
                              <div style="margin-left: 100px; margin-right: 100px;">
                                <div class="PC">
                                <asp:Label ID="Label6" runat="server" Text="Datos del Producto"></asp:Label>
                                </div> 
                               
                                 <%--<NOMBRE - PRECIO - DESCRIPCION >--%>
                                <br/>
                                 <div class="Contacto">
                                 <asp:Label ID="Label7" runat="server" Text="Nombre   -   Precio   -   Descripcion"></asp:Label>
                                 </div>

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
                                    <asp:Label ID="Label8" runat="server" Text="Descripcion"></asp:Label>
                                    <asp:TextBox ID="TxtDescripcion" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese la descripcion del producto" autocomplete="off" class="form-control">
                                     </asp:TextBox>
                                </div>


                               <%--<ALIMENTICIO Y CAREGORIA>--%>

                                 <div class="Contacto" style=" margin-top: 40px;">
                                    <asp:Label ID="Label11" runat="server" Text="Alimenticio   -   Categoria"></asp:Label>
                                 </div>
                              
                                
                                 <div class="form-group" style="margin-bottom:-10px">
                                     
                                     <%--<Campo de si el producto es alimenticio >--%>

                                            <asp:DropDownList ID="dplAlimenticio" runat="server" style="padding-bottom: 15px; margin-top: 35px; margin-bottom: 15px; background-color: #0f136bd6;color: white; width: 390px;" class="input-group-prepend be-addon">
                                                <asp:ListItem value ="">Alimenticio</asp:ListItem>
                                                <asp:ListItem value ="Si">Si</asp:ListItem>
                                                <asp:ListItem value ="No">No</asp:ListItem>
                                              </asp:DropDownList>
                                     <br />

                                      <%--<Campo de la Categoria>--%>

                                            <asp:DropDownList ID="dplCalidad" runat="server" style="padding-bottom: 15px; margin-top: -78px; margin-bottom: 28px; margin-left: 430px; background-color: #0f136bd6;color: white; width: 390px;" class="input-group-prepend be-addon">
                                                <asp:ListItem value ="">Calidad</asp:ListItem>
                                                <asp:ListItem value ="Alta">Alta</asp:ListItem>
                                                <asp:ListItem value ="Baja">Baja</asp:ListItem>
                                                <asp:ListItem value ="Regular">Regular</asp:ListItem>
                                            </asp:DropDownList>

                                </div>


                                
                                  <%--<MARCAS - CLASIFICACION >--%>
                                 
                                 <br />
                                  <div class="Contacto" style="margin-bottom: 10px;">
                                    <asp:Label ID="Label12" runat="server" Text="Marca   -   Clasificacion"></asp:Label>
                                 </div>

                                <br />
                                <div class="form-group">
                                    <asp:DropDownList ID="Marcas" runat="server" style="padding-bottom: 15px; background-color: #0f136bd6;color: white; width: 390px;" class="input-group-prepend be-addon">
                                   </asp:DropDownList>

                                    <asp:DropDownList ID="Clasificacion" runat="server" style="padding-bottom: 15px; margin-left: 430px; margin-top: -40px; background-color: #0f136bd6;color: white; width: 390px;" class="input-group-prepend be-addon">
                                   </asp:DropDownList>

                                </div>
                                <hr>
                                <asp:Button ID="btnModificar" runat="server" class="btn btn-primary btn-user btn-block" Text="Guardar Cambios" style="margin-top: 30px;" OnClick="btnGuardarCambios"/>

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

        <!-- Modal 1-->
        <div class="tiendas-modal modal fade" id="portfolioModal1" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="close-modal" data-dismiss="modal"><img src="../Content/assets/img/close-icon.svg" alt="Close modal" /></div>
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-8">
                                <div class="modal-body">
                                    <!-- Project Details Go Here-->
                                    <h2 class="text-uppercase">Vista Carnet</h2>
                                    <img  runat="server" id ="imgCtrl" />
                                    <div>
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                    </div> 
                                    <div>
                                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

</form>
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
