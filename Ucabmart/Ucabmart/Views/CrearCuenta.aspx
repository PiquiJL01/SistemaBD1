<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" AutoEventWireup="true" CodeBehind="CrearCuenta.aspx.cs" Inherits="Ucabmart.Views.CrearCuenta1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ucabmart - Crear Cuenta</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
  <body class="bg-gradient-primary">
    <section class="page-section" id="tiendas">
        <br>
        <br>
            <div class="container cuadro">
                <div class="text-center">
                    <br>
                    <h2 class="section-heading text-uppercase">Crear Cuenta</h2>
                    <br>
                    <br>
                </div>
                <div class="justify-content-center cut">
                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="tiendas-item">
                            <a class="tiendas-link" href="../Views/User/RegistrarNatural.aspx">
                                <div class="tiendas-hover">
                                    <div class="tiendas-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/Natural-Create.jpg" alt="" />
                            </a>
                            <div class="tiendas-caption" style="background-color:#4e73df">
                                <div class="tiendas-caption-heading">Persona Natural</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6">
                        <div class="tiendas-item">
                            <a class="tiendas-link" href="RegistrarJuridica.aspx">
                                <div class="tiendas-hover">
                                    <div class="tiendas-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/Business-Create.jpg" alt="" />
                            </a>
                            <div class="tiendas-caption" style="background-color:#fed136">
                                <div class="tiendas-caption-heading">Persona Jurídica</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
 </body>
</asp:Content>
