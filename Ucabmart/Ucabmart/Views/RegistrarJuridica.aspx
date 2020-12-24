<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" AutoEventWireup="true" CodeBehind="RegistrarJuridica.aspx.cs" Inherits="Ucabmart.Views.RegistrarJuridica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Ucabmart - Registra Persona Natural</title>

    <!-- Custom fonts for this template-->
    <link href="../../Content/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="../../Content/css/sb-admin-2.min.css" rel="stylesheet">

</head>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <body>

    <div class="container">
        <br>
        <br>
        <br>
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
                                <hr>
                                <asp:Button ID="btnRegistrar" runat="server" class="btn btn-primary btn-user btn-block" Text="Registrar Cuenta" OnClick="btnRegistrar_Click" />
                            </form>
                            <hr>
                            <div class="text-center">
                                <a class="small" href="OlvidoPassword.aspx">Olvidé mi contraseña</a>
                            </div>
                            <div class="text-center">
                                <a class="small" href="IniciarSesion.aspx">¿Ya tienes una cuenta? Inicia Sesión</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="../../Content/vendor/jquery/jquery.min.js"></script>
    <script src="../../Content/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../../Content/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="../../Content/js/sb-admin-2.min.js"></script>
</body>
</asp:Content>
