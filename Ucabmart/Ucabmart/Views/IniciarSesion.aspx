<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="Ucabmart.Views.IniciarSesionPrueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Ucabmart - Iniciar Sesión</title>

    <!-- Custom fonts for this template-->
    <link href="../Content/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="../Content/css/sb-admin-2.min.css" rel="stylesheet">

</head>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <body class="bg-gradient-primary">

    <div class="container">
        <br>
        <br>
        <br>
        <br>
       
        <!-- Outer Row -->
        <div class="row justify-content-center">

            <div class="col-xl-10 col-lg-12 col-md-9">

                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Bienvenido a Ucabmart</h1>
                                    </div>
                                    <form class="user" runat="server">

                                        <%--<Campo de texto del Email >--%> 
                                        <div class="form-group">
                                              <asp:TextBox ID="Email" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                                    placeholder="Introduzca su correo electrónico" autocomplete="off" class="form-control form-control-user" style="text-align: center">
                                               </asp:TextBox>
                                        </div>

                                        <%--<Campo de texto de la Contraseña >--%> 
                                        <div class="form-group">
                                               <asp:TextBox ID="Password" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                                    placeholder="Contraseña" autocomplete="off" class="form-control form-control-user" style="text-align: center">
                                               </asp:TextBox>
                                        </div>

                                        <asp:Button ID="InitialSesion" runat="server" class="btn btn-primary btn-user btn-block" Text="Iniciar Sesión" OnClick="btnRegistrar_Click"/>
                                        <hr>
                                    </form>
                                    <hr>
                                    <div class="text-center">
                                        <a class="small" href="OlvidoPassword.aspx">Olvidé mi contraseña</a>
                                    </div>
                                    <div class="text-center">
                                        <a class="small" href="CrearCuenta.aspx">Crear Cuenta</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="../Content/vendor/jquery/jquery.min.js"></script>
    <script src="../Content/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../Content/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="../Content/js/sb-admin-2.min.js"></script>

</body>
</asp:Content>
