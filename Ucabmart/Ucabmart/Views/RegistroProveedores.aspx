﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroProveedores.aspx.cs" Inherits="Ucabmart.Views.WebForm7" %>

<!DOCTYPE html>
<html lang="es">
    <head runat="server">
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Ucabmart - Registrar Proveedor</title>
        <link rel="icon" type="image/x-icon" href="../../Content/assets/img/favicon.ico" />
        <!-- Font Awesome icons (free version)-->
        <script src="https://use.fontawesome.com/releases/v5.15.1/js/all.js" crossorigin="anonymous"></script>
        <!-- Google fonts-->
        <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic" rel="stylesheet" type="text/css" />
        <link href="https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700" rel="stylesheet" type="text/css" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href="../Content/css/RegistroProveedores.css" rel="stylesheet" />
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
                        <li ID="Clientes" class="nav-item" runat="server"><a class="nav-link js-scroll-trigger" href="/Views/Clientes_Admin.aspx">Clientes</a></li>
                        <li ID="Tiendas" class="nav-item" runat="server"><a class="nav-link js-scroll-trigger" href="/Views/Tiendas-Admin.aspx">Tiendas</a></li>
                        <li ID="Productos" class="nav-item" runat="server"><a class="nav-link js-scroll-trigger" href="/Views/Productos_Admin.aspx">Productos</a></li>
                        <li ID="Proveedores" class="nav-item" runat="server"><a class="nav-link js-scroll-trigger" href="/Views/Proveedores.aspx">Proveedores</a></li>
                        <li ID="Nomina" class="nav-item" runat="server"><a class="nav-link js-scroll-trigger" href="/Views/Nomina_Admin.aspx">Nomina</a></li>
                        <li ID="RolesA" class="nav-item" runat="server"><a class="nav-link js-scroll-trigger" href="/Views/Role/Role_Admin.aspx">Roles</a></li>
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
                          <li class="li-4" >PROVEEDORES-UCABMART</li>
                          <li><img src="../Content/assets/img/icono-distribucion.png" height="80px"/>  </li>
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
                                <h1 class="h4 text-gray-900 mb-4">Registrar Proveedor</h1>
                            </div>
                            <form id="form1" runat="server">
                                 <%--<Campo de texto del Rif >--%>
                                 <asp:Label ID="lblRif" runat="server" Text="Rif"></asp:Label> 
                                 <div class="form-group row" style="margin-bottom:-10px">
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
                                            placeholder="Ingrese su número de Rif " autocomplete="off" class="form-control" style="height: 45px;width: 330px;margin-left: -70px;">
                                         </asp:TextBox>
                                    </div>
                                </div>

                                 <%--<Campo de texto la denominacion comercial >--%>
                                <div class="form-group">
                                    <asp:Label ID="DenominacionComercial" runat="server" Text="Denominacion Comercial"></asp:Label> 
                                    <asp:TextBox ID="txtDenoComercial" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Denominación Comercial" autocomplete="off" class="form-control" style="text-align: center">
                                     </asp:TextBox>
                                </div>
                                 <%--<Campo de texto de la razon social >--%>
                                <div class="form-group">
                                    <asp:Label ID="RazónSocial" runat="server" Text="Razón Social"></asp:Label>
                                    <asp:TextBox ID="txtRazonSocial" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                         placeholder="Razón Social " autocomplete="off" class="form-control" style="text-align: center">
                                    </asp:TextBox>
                                </div>
                                  <%--<Campo de texto del correo >--%>
                                <div class="form-group">
                                    <asp:Label ID="CorreoElectrónico" runat="server" Text="Correo Electrónico"></asp:Label>
                                    <asp:TextBox ID="txtCorreo" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese su correo electrónico" autocomplete="off" class="form-control"  style="text-align: center">
                                     </asp:TextBox>
                                </div>

                                 <%--<Campo de texto de los telefonos >--%>
                                <div class="form-group row" style="margin-left: 5px;">
                                    <asp:Label ID="Telefonos" runat="server" Text="Telefonos"></asp:Label>
                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="CodigoPais1" runat="server" style="padding-bottom: 15px; margin-top: 10px; margin-bottom: 50px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Codigo de País</asp:ListItem>
                                                <asp:ListItem Value="54">Argentina</asp:ListItem>
                                                <asp:ListItem Value="55">Brasil</asp:ListItem>
                                                <asp:ListItem Value="57">Colombia</asp:ListItem>
                                                <asp:ListItem Value="593">Ecuador</asp:ListItem>
                                                <asp:ListItem Value="66">Tailandia</asp:ListItem>
                                                <asp:ListItem Value="58">Venezuela</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>
                                    <br />

                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="TipoTelf" runat="server" style="padding-bottom: 15px; margin-top: -105px; margin-bottom: 80px; margin-left: 200px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Tipo de Telefono</asp:ListItem>
                                                <asp:ListItem Value="Movil">Movil</asp:ListItem>
                                                <asp:ListItem Value="Fijo">Fijo</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="CodAre" runat="server" type="text" name="number" data-parsley-trigger="change"  
                                            placeholder="Codigo Area" autocomplete="off" class="form-control" style="width: 140px; margin-top: -81px; margin-left: 210px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="txtTelefono1" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Teléfono 1 " autocomplete="off" class="form-control" style="width: 540px; margin-left: -190px; margin-top: -20px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="input-group mb-3">
                                        <asp:DropDownList ID="CodigoPais2" runat="server" style="padding-bottom: 15px; margin-top: 10px; margin-bottom: 50px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Codigo de País</asp:ListItem>
                                                <asp:ListItem Value="54">Argentina</asp:ListItem>
                                                <asp:ListItem Value="55">Brasil</asp:ListItem>
                                                <asp:ListItem Value="57">Colombia</asp:ListItem>
                                                <asp:ListItem Value="593">Ecuador</asp:ListItem>
                                                <asp:ListItem Value="66">Tailandia</asp:ListItem>
                                                <asp:ListItem Value="58">Venezuela</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="TipoTelf2" runat="server" style="padding-bottom: 15px; margin-top: -105px; margin-bottom: 80px; margin-left: 200px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Tipo de Telefono</asp:ListItem>
                                                <asp:ListItem Value="Movil">Movil</asp:ListItem>
                                                <asp:ListItem Value="Fijo">Fijo</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="CodAre2" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Codigo Area" autocomplete="off" class="form-control" style="width: 140px; margin-top: -81px; margin-left: 210px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-sm-6" style="margin-top: -30px; margin-left: 180px;">
                                        <asp:TextBox ID="txtTelefono2" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Teléfono 2" autocomplete="off" class="form-control" style="width: 540px; margin-left: -190px; margin-top: -20px;">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                 <%--<Campo de texto de la dirección fiscal >--%>
                                <div class="PC">
                                <asp:Label ID="Label1" runat="server" Text="Dirección Fiscal"></asp:Label>
                                </div>
                                <br />
                                <asp:Label ID="Label11" runat="server" Text="Estado"></asp:Label>
                                <div class="form-group">
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user"></i></span></span>
                                            <asp:DropDownList ID="dplEstado" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon"  AutoPostBack="True" OnSelectedIndexChanged="dplEstado_SelectedIndexChanged">
                                                
                                            </asp:DropDownList>
                                        </div>
                                </div>
                                <asp:Label ID="Label12" runat="server" Text="Municipio"></asp:Label>
                                <div class="form-group">
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user"></i></span></span>
                                            <asp:DropDownList ID="dplMunicipio" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon" AutoPostBack="True" OnSelectedIndexChanged="dplMunicipio_SelectedIndexChanged">
                                                
                                            </asp:DropDownList>
                                        </div>
                                 </div>
                                <asp:Label ID="Label13" runat="server" Text="Parroquia"></asp:Label>
                                <div class="form-group">
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user"></i></span></span>
                                            <asp:DropDownList ID="dplParroquia" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                
                                            </asp:DropDownList>
                                        </div>
                                </div>

                                <%--<Campo de texto de la dirección fisica principal>--%>
                                <div class="PC">
                                <asp:Label ID="Label2" runat="server" Text="Dirección Fisica Principal"></asp:Label>
                                </div>
                                <br />
                                <asp:Label ID="Label14" runat="server" Text="Estado"></asp:Label>
                                <div class="form-group">
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user"></i></span></span>
                                            <asp:DropDownList ID="dplEstado2" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon" AutoPostBack="True" OnSelectedIndexChanged="dplEstado2_SelectedIndexChanged">
                                                
                                            </asp:DropDownList>
                                        </div>
                                </div>
                                <asp:Label ID="Label15" runat="server" Text="Municipio"></asp:Label>
                                <div class="form-group">
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user"></i></span></span>
                                            <asp:DropDownList ID="dplMunicipio2" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon" AutoPostBack="True" OnSelectedIndexChanged="dplMunicipio2_SelectedIndexChanged" >
                                                
                                            </asp:DropDownList>
                                        </div>
                                     </div>

                                <asp:Label ID="Label16" runat="server" Text="Parroquia"></asp:Label>
                                <div class="form-group">
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user"></i></span></span>
                                            <asp:DropDownList ID="dplParroquia2" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                
                                            </asp:DropDownList>
                                        </div>
                                     </div>
                                  <%--<Campo de texto de la pagina web >--%>
                                <div class="form-group">
                                    <asp:Label ID="PaginaWeb" runat="server" Text="Pagina Web"></asp:Label>
                                    <asp:TextBox ID="txtPaginaWeb" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese su Página Web" autocomplete="off" class="form-control"  style="text-align: center">
                                     </asp:TextBox>
                                </div>
                                <%--<Campo de texto capital disponible >--%>

<%--                                <div class="form-group">
                                    <asp:TextBox ID="txtCapitalDisponible" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese su Capital Disponible" autocomplete="off" class="form-control"  style="text-align: center">
                                     </asp:TextBox>
                                </div>--%>

                                <%--<Campo de texto para Personas de Contacto >--%>
                               <div class="PC">
                                    <asp:Label ID="Label3" runat="server" Text="Personas de Contacto"></asp:Label>
                               </div>
                                <br />
                                <%--<Persona de Contacto Nº1 >--%>
                                <div class="Contacto">
                                    <asp:Label ID="Label4" runat="server" Text="Contacto Nº1"></asp:Label>
                                </div>

                                <%--<Campo de texto de la cédula>--%>
                                <asp:Label ID="lblCedula" runat="server" Text="Cédula"></asp:Label>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <br >
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user-times"></i></span></span>
                                            <asp:DropDownList ID="CedulaDrop" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                <asp:ListItem>V</asp:ListItem>
                                                <asp:ListItem>E</asp:ListItem>
                                                <asp:ListItem>P</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <br >
                                        <asp:TextBox ID="txtCedula" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su cédula " autocomplete="off" class="form-control" style="height: 45px;width: 330px;margin-left: -70px;">
                                        </asp:TextBox>
                                    </div>
                                </div>

                                <%--<Campo de texto para los nombres de la Persona de Contacto Nº1 >--%>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                         <asp:Label ID="Nombre" runat="server" Text="Nombres"></asp:Label>
                                        <asp:TextBox ID="Nombre1" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su 1er Nombre" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-6" style="margin-top:24px">
                                       <asp:TextBox ID="Nombre2" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su 2do Nombre" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>

                                 <%--<Campo de texto para los apellidos de la Persona de Contacto Nº1 >--%>
                                
                                 <div class="form-group row" style="margin-bottom:-10px">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                         <asp:Label ID="Apellido" runat="server" Text="Apellidos"></asp:Label>
                                        <asp:TextBox ID="Apellido1" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su 1er Apellido" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-6" style="margin-top:24px">
                                       <asp:TextBox ID="Apellido2" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su 2do Apellido" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <br/>
                                <%--<Campo de texto de los telefonos de las personas de contacto1>--%>

                                  <div class="form-group row" style="margin-left: 5px;">
                                    <asp:Label ID="Label5" runat="server" Text="Telefonos"></asp:Label>
                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="CodigoPais3" runat="server" style="padding-bottom: 15px; margin-top: 10px; margin-bottom: 50px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Codigo de País</asp:ListItem>
                                                <asp:ListItem Value="54">Argentina</asp:ListItem>
                                                <asp:ListItem Value="55">Brasil</asp:ListItem>
                                                <asp:ListItem Value="57">Colombia</asp:ListItem>
                                                <asp:ListItem Value="593">Ecuador</asp:ListItem>
                                                <asp:ListItem Value="66">Tailandia</asp:ListItem>
                                                <asp:ListItem Value="58">Venezuela</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="TipoTelf3" runat="server" style="padding-bottom: 15px; margin-top: -105px; margin-bottom: 80px; margin-left: 200px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Tipo de Telefono</asp:ListItem>
                                                <asp:ListItem Value="Movil">Movil</asp:ListItem>
                                                <asp:ListItem Value="Fijo">Fijo</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="CodAre3" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Codigo Area" autocomplete="off" class="form-control" style="width: 140px; margin-top: -81px; margin-left: 210px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="txtTelefono3" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Teléfono 1 " autocomplete="off" class="form-control" style="width: 540px; margin-left: -190px; margin-top: -20px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="input-group mb-3">
                                        <asp:DropDownList ID="CodigoPais4" runat="server" style="padding-bottom: 15px; margin-top: 10px; margin-bottom: 50px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Codigo de País</asp:ListItem>
                                                <asp:ListItem Value="54">Argentina</asp:ListItem>
                                                <asp:ListItem Value="55">Brasil</asp:ListItem>
                                                <asp:ListItem Value="57">Colombia</asp:ListItem>
                                                <asp:ListItem Value="593">Ecuador</asp:ListItem>
                                                <asp:ListItem Value="66">Tailandia</asp:ListItem>
                                                <asp:ListItem Value="58">Venezuela</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="TipoTelf4" runat="server" style="padding-bottom: 15px; margin-top: -105px; margin-bottom: 80px; margin-left: 200px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Tipo de Telefono</asp:ListItem>
                                                <asp:ListItem Value="Movil">Movil</asp:ListItem>
                                                <asp:ListItem Value="Fijo">Fijo</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="CodAre4" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Codigo Area" autocomplete="off" class="form-control" style="width: 140px; margin-top: -81px; margin-left: 210px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-sm-6" style="margin-top: -30px; margin-left: 180px;">
                                        <asp:TextBox ID="txtTelefono4" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Teléfono 2" autocomplete="off" class="form-control" style="width: 540px; margin-left: -190px; margin-top: -20px;">
                                        </asp:TextBox>
                                    </div>
                                </div>

                              <%--<Persona de Contacto Nº2 >--%>

<%--                                <div class="Contacto">
                                  <asp:Label ID="Label6" runat="server" Text="Contacto Nº2"></asp:Label>
                                </div>--%>

                                 <%--<Campo de texto de la cédula>--%>
<%--                                <asp:Label ID="lblCedula2" runat="server" Text="Cédula"></asp:Label>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <br >
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user-times"></i></span></span>
                                            <asp:DropDownList ID="CedulaDrop2" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                <asp:ListItem>V</asp:ListItem>
                                                <asp:ListItem>E</asp:ListItem>
                                                <asp:ListItem>P</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <br >
                                        <asp:TextBox ID="txtCedula2" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su cédula " autocomplete="off" class="form-control" style="height: 45px;width: 330px;margin-left: -70px;">
                                        </asp:TextBox>
                                    </div>
                                </div>--%>

                                <%--<Campo de texto para los nombres de la Persona de Contacto Nº2 >--%>
<%--                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                         <asp:Label ID="Label7" runat="server" Text="Nombres"></asp:Label>
                                        <asp:TextBox ID="Nombre3" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su 1er Nombre" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-6" style="margin-top:24px">
                                       <asp:TextBox ID="Nombre4" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su 2do Nombre" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>--%>

                                 <%--<Campo de texto para los apellidos de la Persona de Contacto Nº2 >--%>
                                
<%--                                 <div class="form-group row" style="margin-bottom:-10px">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                         <asp:Label ID="Label8" runat="server" Text="Apellidos"></asp:Label>
                                        <asp:TextBox ID="Apellido3" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su 1er Apellido" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-6" style="margin-top:24px">
                                       <asp:TextBox ID="Apellido4" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su 2do Apellido" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>--%>
<%--                                <br/>--%>
                                <%--<Campo de texto de los telefonos de las personas de contacto2>--%>

<%--                                 <div class="form-group row" style="margin-left: 5px;">
                                    <asp:Label ID="Label9" runat="server" Text="Telefonos"></asp:Label>
                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="CodigoPais5" runat="server" style="padding-bottom: 15px; margin-top: 10px; margin-bottom: 50px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Codigo de País</asp:ListItem>
                                                <asp:ListItem Value="54">Argentina</asp:ListItem>
                                                <asp:ListItem Value="55">Brasil</asp:ListItem>
                                                <asp:ListItem Value="57">Colombia</asp:ListItem>
                                                <asp:ListItem Value="593">Ecuador</asp:ListItem>
                                                <asp:ListItem Value="66">Tailandia</asp:ListItem>
                                                <asp:ListItem Value="58">Venezuela</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="TipoTelf5" runat="server" style="padding-bottom: 15px; margin-top: -105px; margin-bottom: 80px; margin-left: 200px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Tipo de Telefono</asp:ListItem>
                                                <asp:ListItem Value="Movil">Movil</asp:ListItem>
                                                <asp:ListItem Value="Fijo">Fijo</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="CodAre5" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Codigo Area" autocomplete="off" class="form-control" style="width: 140px; margin-top: -81px; margin-left: 210px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="txtTelefono5" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Teléfono 1 " autocomplete="off" class="form-control" style="width: 540px; margin-left: -190px; margin-top: -20px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="input-group mb-3">
                                        <asp:DropDownList ID="CodigoPais6" runat="server" style="padding-bottom: 15px; margin-top: 10px; margin-bottom: 50px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Codigo de País</asp:ListItem>
                                                <asp:ListItem Value="54">Argentina</asp:ListItem>
                                                <asp:ListItem Value="55">Brasil</asp:ListItem>
                                                <asp:ListItem Value="57">Colombia</asp:ListItem>
                                                <asp:ListItem Value="593">Ecuador</asp:ListItem>
                                                <asp:ListItem Value="66">Tailandia</asp:ListItem>
                                                <asp:ListItem Value="58">Venezuela</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="TipoTelf6" runat="server" style="padding-bottom: 15px; margin-top: -105px; margin-bottom: 80px; margin-left: 200px; background-color: #0f136bd6;color: white; width: 180px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Tipo de Telefono</asp:ListItem>
                                                <asp:ListItem Value="Movil">Movil</asp:ListItem>
                                                <asp:ListItem Value="Fijo">Fijo</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="CodAre6" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Codigo Area" autocomplete="off" class="form-control" style="width: 140px; margin-top: -81px; margin-left: 210px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-sm-6" style="margin-top: -30px; margin-left: 180px;">
                                        <asp:TextBox ID="txtTelefono6" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Teléfono 2" autocomplete="off" class="form-control" style="width: 540px; margin-left: -190px; margin-top: -20px;">
                                        </asp:TextBox>
                                    </div>
                                </div>--%>

                                <hr />

                                <%--<Campo de seleccion para medios de pagos>--%>
<%--                                <asp:Label ID="lblPagos" runat="server" Text="Medios de Pago"></asp:Label>
                                <div class="form-group">
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user-times"></i></span></span>
                                            <asp:DropDownList ID="dplPago" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                <asp:ListItem>Tarjeta de Débito</asp:ListItem>
                                                <asp:ListItem>Tarjeta de Crédito</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                </div>--%>
                                 <%--<Campo de texto para la contraseña>--%>
<%--                                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
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
                                </div>--%>
                               <br/>
                                <asp:Button ID="btnRegistrar" runat="server" class="btn btn-primary btn-user btn-block" Text="Siguiente" OnClick="btnRegistrar_Click"/>
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
