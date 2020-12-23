<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarNatural.aspx.cs" Inherits="Ucabmart.Views.User.RegistrarNatural" %>

<!DOCTYPE html>
<html lang="es">

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

<body class="bg-gradient-primary">

    <div class="container">

        <div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row">
                    <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                    <div class="col-lg-7">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Crear Cuenta - Persona Natural</h1>
                            </div>
                            <form id="form1" runat="server">
                                 <%--<Campo de texto del nombre >--%>
                                <div class="form-group">
                                    <asp:TextBox ID="txtNombre" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese Primer y Segundo Nombre " autocomplete="off" class="form-control">
                                     </asp:TextBox>
                                </div>
                                 <%--<Campo de texto del apellido >--%>
                                <div class="form-group">
                                    <asp:TextBox ID="txtApellido" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                         placeholder="Ingrese Primer y Segundo Apellido " autocomplete="off" class="form-control">
                                    </asp:TextBox>
                                </div>
                                 <%--<Campo de texto del Rif >--%>
                                 <asp:Label ID="lblRif" runat="server" Text="Rif"></asp:Label>
                                 <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user-times"></i></span></span>
                                            <asp:DropDownList ID="DropDownList1" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                <asp:ListItem>V</asp:ListItem>
                                                <asp:ListItem>E</asp:ListItem>
                                                <asp:ListItem>P</asp:ListItem>
                                              </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtRif" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su número de Rif " autocomplete="off" class="form-control">
                                         </asp:TextBox>
                                    </div>
                                </div>
                                <%--<Campo de texto de la cédula>--%>
                                <asp:Label ID="lblCedula" runat="server" Text="Cédula"></asp:Label>
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fas fa-user-times"></i></span></span>
                                            <asp:DropDownList ID="DropDownList2" runat="server" style="padding:10px 50px 10px 50px; text-align: left;" class="input-group-prepend be-addon">
                                                <asp:ListItem>V</asp:ListItem>
                                                <asp:ListItem>E</asp:ListItem>
                                                <asp:ListItem>P</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtCedula" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese su cédula " autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <%--<Campo de texto del correo >--%>
                                <div class="form-group">
                                    <asp:TextBox ID="txtCorreo" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                          placeholder="Ingrese su correo electrónico" autocomplete="off" class="form-control">
                                     </asp:TextBox>
                                </div>
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
                                <%--<Campo de texto de la dirección >--%>
                                <div class="form-group">
                                    <asp:Label ID="Label6" for="txtDireccion" runat="server" Text="Dirección"></asp:Label>
                                    <div class="input-group mb-3"><span class="input-group-prepend"><span class="input-group-text"><i class="fa fa-user"></i></span></span>
                                        <asp:TextBox ID="txtDireccion" runat="server" type="text" name="name" data-parsley-trigger="change"  
                                            placeholder="" autocomplete="off" class="form-control" Height="87px" Width="361px"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtContraseña" runat="server" type="password" name="name" data-parsley-trigger="change"  
                                            placeholder="Ingrese contraseña " autocomplete="off" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
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
                                <a class="small" href="../OlvidoPassword.aspx">Olvidé mi contraseña</a>
                            </div>
                            <div class="text-center">
                                <a class="small" href="../IniciarSesion.aspx">¿Ya tienes una cuenta? Inicia Sesión</a>
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

</html>