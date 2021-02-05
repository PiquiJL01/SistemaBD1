<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarEmpleado.aspx.cs" Inherits="Ucabmart.Views.Employee.ModificarEmpleado" %>

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
                          <li class="li-4" >NOMINA-UCABMART</li>
                          <li><img src="../../Content/assets/img/Employees/Employee-Icon.png" height="80px"/>  </li>
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
                                <h1 class="h4 text-gray-900 mb-4">Modificar Empleado</h1>
                            </div>
                            
                            <%--<form id="form1" runat="server">--%>
                                <div class="form-group" style="width: 500px; margin-left: auto; margin-right: auto;">
                                    <div class="input-group mb-3"><span class="input-group-prepend" style="box-shadow: 1.5px 1px 5px #443939;"><span class="input-group-text"><i class="fa fa-user"></i></span></span> 
<%--                                        <asp:DropDownList ID="dplTipoCliente" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                            <asp:ListItem>Natural</asp:ListItem>
                                            <asp:ListItem>Jurídico</asp:ListItem>
                                        </asp:DropDownList>   --%>
                                        <asp:TextBox ID="BuscarCod" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                         placeholder="Ingrese el codigo del empleado..." autocomplete="off" class="form-control" style="padding:10px 50px 10px 50px; text-align: left;">
                                        </asp:TextBox>

                                        <asp:Button ID="btnBuscar" runat="server" class="btn btn-space btn-primary ml-1" Text="Buscar" OnClick="btnBuscar_Click" Width="87px" />
                                        
                                    </div>
                                </div>

                                <br />
                                <br />
                             <%--<Datos del Cliente>--%>
                              <div style="margin-left: 100px; margin-right: 100px;">
                                <div class="PC">
                                <asp:Label ID="Label6" runat="server" Text="Datos del Empleado"></asp:Label>
                                </div> 
                               
                                 <%--<NOMBRE Y APELLIDO >--%>
                                <br/>
                                 <div class="Contacto" style="margin-bottom:40px">
                                 <asp:Label ID="Label7" runat="server" Text="Nombre - Apellido"></asp:Label>
                                 </div>

                                 <%--<Campo de texto del nombre >--%>

                                 <div class="form-group row">
                                    <div class="col-sm-6">
                                         <asp:Label ID="Label26" runat="server" Text="1er Nombre"></asp:Label>
                                        <asp:TextBox ID="Nombre1" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Primer Nombre" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                       <asp:Label ID="Label27" runat="server" Text="2do Nombre"></asp:Label>
                                       <asp:TextBox ID="Nombre2" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Segundo Nombre" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>


                                 <%--<Campo de texto del apellido >--%>

                                 <div class="form-group row" style="margin-bottom:-10px">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                         <asp:Label ID="Label28" runat="server" Text="Apellido1"></asp:Label>
                                        <asp:TextBox ID="Apellido1" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Primer Apellido" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:Label ID="Label29" runat="server" Text="Apellido2"></asp:Label>
                                       <asp:TextBox ID="Apellido2" runat="server" type="name" name="name" data-parsley-trigger="change"  
                                            placeholder="Segundo Apellido" autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>


                                 <%--<RIF Y CEDULA>--%>

                                 <div class="Contacto" style="margin-bottom:10px; margin-top: 10px;">
                                    <asp:Label ID="Label30" runat="server" Text="Cedula - Rif"></asp:Label>
                                 </div>

                                 <%--<Campo de texto del Rif >--%>
                                 <asp:Label ID="Label31" runat="server" Text="Rif"></asp:Label>
                                 <div class="form-group row" style="margin-bottom:-10px">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <br >
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user-times"></i></span></span>
                                            <asp:DropDownList ID="dplrif" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                <asp:ListItem>V</asp:ListItem>
                                                <asp:ListItem>E</asp:ListItem>
                                                <asp:ListItem>P</asp:ListItem>
                                              </asp:DropDownList>
                                        </div>
                                     </div>
                                    <div class="col-sm-6">
                                        <br >
                                        <asp:TextBox ID="txtRif" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Numero de Rif" autocomplete="off" class="form-control" style="height: 45px;width: 590px;margin-left: -190px;">
                                         </asp:TextBox>
                                    </div>
                                </div>

                                <%--<Campo de texto de la cédula>--%>
                                <asp:Label ID="Label32" runat="server" Text="Cédula"></asp:Label>
                                 <div class="form-group row" style="margin-bottom:-10px">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <br >
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user-times"></i></span></span>
                                            <asp:DropDownList ID="dplCedula" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                <asp:ListItem>V</asp:ListItem>
                                                <asp:ListItem>E</asp:ListItem>
                                                <asp:ListItem>P</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <br >
                                        <asp:TextBox ID="txtCedula" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Numero de Cedula" autocomplete="off" class="form-control" style="height: 45px;width: 590px;margin-left: -190px;">
                                        </asp:TextBox>
                                    </div>
                                </div>


                               <%--<CORREO Y TELEFONOS>--%>

                                 <div class="Contacto" style="margin-bottom:20px; margin-top: 10px;">
                                    <asp:Label ID="Label8" runat="server" Text="Correo Eletronico - Telefonos"></asp:Label>
                                 </div>
                               
                                <%--<Campo de texto del correo >--%>
                                <div class="form-group">
                                    <asp:Label ID="Label9" runat="server" Text="Correo Electrónico"></asp:Label>
                                    <asp:TextBox ID="txtCorreo" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Correo electrónico" autocomplete="off" class="form-control">
                                     </asp:TextBox>
                                </div>

                                <%--<Campo de texto de los telefonos >--%>
                                <div class="form-group row" style="margin-left: 5px;">
                                    <asp:Label ID="Label33" runat="server" Text="Telefonos"></asp:Label>
                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="CodigoPais1" runat="server" style="padding-bottom: 15px; margin-top: 10px; margin-bottom: 50px; background-color: #0f136bd6;color: white; width: 220px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Codigo de País</asp:ListItem>
                                                <asp:ListItem Value="58">Venezuela</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>
                                    <br />

                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="TipoTelf" runat="server" style="padding-bottom: 15px; margin-top: -105px; margin-bottom: 80px; margin-left: 240px; background-color: #0f136bd6;color: white; width: 220px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Tipo de Telefono</asp:ListItem>
                                                <asp:ListItem Value="Movil">Movil</asp:ListItem>
                                                <asp:ListItem Value="Fijo">Fijo</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="CodAre" runat="server" type="text" name="number" data-parsley-trigger="change"  
                                            placeholder="Codigo Area" autocomplete="off" class="form-control" style="width: 330px; margin-top: -81px; margin-left: 290px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="txtTelefono1" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Teléfono 1 " autocomplete="off" class="form-control" style="width: 810px; margin-left: -190px; margin-top: -20px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="input-group mb-3">
                                        <asp:DropDownList ID="CodigoPais2" runat="server" style="padding-bottom: 15px; margin-top: 10px; margin-bottom: 50px; background-color: #0f136bd6;color: white; width: 220px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Codigo de País</asp:ListItem>
                                                <asp:ListItem Value="58">Venezuela</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                     <div class="input-group mb-3">
                                        <asp:DropDownList ID="TipoTelf2" runat="server" style="padding-bottom: 15px; margin-top: -105px; margin-bottom: 80px; margin-left: 240px; background-color: #0f136bd6;color: white; width: 220px;" class="input-group-prepend be-addon">
                                                <asp:ListItem Value="">Tipo de Telefono</asp:ListItem>
                                                <asp:ListItem Value="Movil">Movil</asp:ListItem>
                                                <asp:ListItem Value="Fijo">Fijo</asp:ListItem>
                                        </asp:DropDownList>
                                     </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-left: 180px; margin-top: -30px;">
                                        <asp:TextBox ID="CodAre2" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Codigo Area" autocomplete="off" class="form-control" style="width: 330px; margin-top: -81px; margin-left: 290px;">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-sm-6" style="margin-top: -30px; margin-left: 180px;">
                                        <asp:TextBox ID="txtTelefono2" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Teléfono 2" autocomplete="off" class="form-control" style="width: 810px; margin-left: -190px; margin-top: -20px;">
                                        </asp:TextBox>
                                    </div>
                                </div>
                               
                                  
                                  
                                 <%--<CARGO - DEPARTAMENTO - TIENDA - JEFE>--%>


                                 <div class="Contacto" style="margin-bottom:40px; margin-top: 10px;">
                                    <asp:Label ID="Label19" runat="server" Text="Cargo - Departamento - Tienda -Jefe"></asp:Label>
                                 </div>

                                 <div class="form-group" style="margin-bottom:20px; margin-top:30px">

                                    <asp:DropDownList ID="Cargos" runat="server" style="padding-bottom: 15px; background-color: #0f136bd6;color: white; width: 370px;" class="input-group-prepend be-addon">
                                   </asp:DropDownList>

                                   <asp:DropDownList ID="Departamentos" runat="server" style="padding-bottom: 15px; margin-left: 400px; margin-top: -40px; background-color: #0f136bd6;color: white; width:420px;" class="input-group-prepend be-addon">
                                   </asp:DropDownList>

                                </div>


                                 <div class="form-group" style="margin-bottom:20px; margin-top:50px">

                                   <asp:DropDownList ID="Tiendas" runat="server" style="padding-bottom: 15px; background-color: #0f136bd6;color: white; width: 370px;" class="input-group-prepend be-addon">
                                   </asp:DropDownList>

                                   <div style="margin-left: 400px; margin-top: -60px;">
                                     <asp:Label ID="Label18" runat="server" Text="Jefe"></asp:Label>
                                     <asp:TextBox ID="Jefe" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese el rif del Jefe" autocomplete="off" class="form-control">
                                     </asp:TextBox>
                                  </div>

                                </div>


                                 <%--<HORARIOS>--%>
                             
                                <div class="Contacto" style="margin-top: 40px;">
                                    <asp:Label ID="Label12" runat="server" Text="Horarios"></asp:Label>
                                </div>

                              <div class="form-group" style="margin-bottom:20px; margin-top:30px">

                                  <%--<Hora de Inicio >--%>
                                   <div>
                                    <asp:Label ID="Label13" runat="server" Text="Hora de Inicio"></asp:Label>
                                    <asp:TextBox ID="HoraInicio" runat="server" type="time" name="name" data-parsley-trigger="change"  
                                          placeholder="Hora Inicio" autocomplete="off" class="form-control" style="width:370px;">
                                    </asp:TextBox>
                                   </div>

                                    <br />
                                  <%--<Hora de Fin >--%>
                                  <div style="margin-left: 400px; margin-top: -84px;">
                                    <asp:Label ID="Label15" runat="server" Text="Hora de Fin"></asp:Label>
                                    <asp:TextBox ID="HoraFin" runat="server" type="time" name="name" data-parsley-trigger="change"  
                                          placeholder="Hora Fin" autocomplete="off" class="form-control" style="width:420px;">
                                   </asp:TextBox>
                                  </div>

                                    <br />
                                   <%--<Turnos >--%>
                                   <asp:DropDownList ID="Turno" runat="server" style="padding-bottom: 15px; background-color: #0f136bd6;color: white; width: 500px; margin-left: 160px;" class="input-group-prepend be-addon">
                                       <asp:ListItem Value="Diurno">Diurno</asp:ListItem>
                                       <asp:ListItem Value="Matutino">Matutino</asp:ListItem>
                                       <asp:ListItem Value="Nocturno">Nocturno</asp:ListItem>
                                       <asp:ListItem Value="Vespertino">Vespertino</asp:ListItem>
                                   </asp:DropDownList>

                                    <br />
                                    <%--<Dias >--%>
                                    <div style="margin-top: 20px;">
                                        <div class="Contacto2" style="margin-bottom: 20px;">
                                        <asp:Label ID="Label16" runat="server" Text="Dias del horario"></asp:Label>
                                        </div>
                                        <asp:CheckBoxList ID="Dias" runat="server" style="background-color:#4e73df; color: white; border-radius: 10px; padding: 10px 10px 10px 10px; margin-top: 40px;" class="input-group-prepend be-addon">
                                            <asp:ListItem Value="Lunes">Lunes</asp:ListItem>
                                            <asp:ListItem Value="Martes">Martes</asp:ListItem>
                                            <asp:ListItem Value="Miercoles">Miercoles</asp:ListItem>
                                            <asp:ListItem Value="Jueves">Jueves</asp:ListItem>
                                            <asp:ListItem Value="Viernes">Viernes</asp:ListItem>
                                            <asp:ListItem Value="Sabado">Sabado</asp:ListItem>
                                            <asp:ListItem Value="Domingo">Domingo</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>

                               </div>


                                 <%--<BENEFICIOS>--%>
                             
                                <div class="Contacto" style="margin-top: 40px;">
                                    <asp:Label ID="Label20" runat="server" Text="Beneficios"></asp:Label>
                                </div>

                                    <div style="margin-top: 20px;">
                                        <asp:CheckBoxList ID="Options" runat="server" style="background-color:#4e73df; color: white; border-radius: 10px; padding: 10px 10px 10px 10px; margin-top: 40px;" class="input-group-prepend be-addon">

                                        </asp:CheckBoxList>
                                    </div>




                                 <%--<DIRECCION Y CONTRASEÑA>--%>
                                 
                                  <div class="Contacto" style="margin-top: 40px;">
                                    <asp:Label ID="Label10" runat="server" Text="Direccion - Contraseña"></asp:Label>
                                 </div>

                                <%--<Direccion del Cliente >--%>
                                <br />
                                <div class="form-group">
                                         <asp:Label ID="Label11" runat="server" Text="Estado"></asp:Label>
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user"></i></span></span>
                                            <asp:DropDownList ID="dplEstado" runat="server" style="padding:10px 10px 10px 10px; text-align: left;" class="input-group-prepend be-addon" OnSelectedIndexChanged="dplEstado_SelectedIndexChanged" AutoPostBack="True">
                                                
                                            </asp:DropDownList>
                                        </div>
                                </div>

                                <div class="form-group"  style="margin-top: -84px; margin-left: 230px;">
                                        <asp:Label ID="Label14" runat="server" Text="Municipio"></asp:Label>
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user"></i></span></span>
                                            <asp:DropDownList ID="dplMunicipio" runat="server" style="padding:10px 10px 10px 10px; text-align: left;" class="input-group-prepend be-addon" AutoPostBack="True" OnSelectedIndexChanged="dplMunicipio_SelectedIndexChanged">
                                                
                                            </asp:DropDownList>
                                        </div>
                                </div>

                                <div class="form-group"  style="margin-top: -84px; margin-left: 510px;">
                                        <asp:Label ID="Label25" runat="server" Text="Parroquia"></asp:Label>
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user"></i></span></span>
                                            <asp:DropDownList ID="dplParroquia" runat="server" style="padding:10px 10px 10px 10px; text-align: left;" class="input-group-prepend be-addon">
                                                
                                            </asp:DropDownList>
                                        </div>
                                 </div>

                                 <%--<Campo de la contraseña >--%>
                                <br >
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                         <asp:Label ID="Label34" runat="server" Text="Contraseña"></asp:Label>
                                        <asp:TextBox ID="txtContraseña" runat="server" type="password" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese contraseña " autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-6" style="margin-top:24px">
                                       <asp:TextBox ID="txtRepetirContraseña" runat="server" type="password" name="name" data-parsley-trigger="change"  
                                            placeholder="Repetir Contraseña " autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>


                                <hr>
                                <asp:Button ID="btnModificar" runat="server" class="btn btn-primary btn-user btn-block" Text="Guardar Cambios" OnClick="btnGuardarCambios"/>

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
