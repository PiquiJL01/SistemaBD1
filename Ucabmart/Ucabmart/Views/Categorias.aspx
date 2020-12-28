<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Ucabmart.Views.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
  <body class="bg-gradient-primary">
    <section class="page-section" id="categorias">
         <br>
         <br>
            <div class="container cuadro">
                <div class="text-center">
                    <br>
                    <h2 class="section-heading text-uppercase" style="border: 8px outset">Categorías</h2>
                    <br>
                    <br>
                </div>
                <div class="row" style="padding-left: 150px">
                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/portfolio/01-thumbnail.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-68px; background-color:#fed136">
                                <div class="categorias-caption-heading">Alimentos</div>
                                <div class="categorias-caption-subheading text-muted">Pollo, pavos, embutidos, chocolates...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="categorias-item" style="margin-left: 120px">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/portfolio/02-thumbnail.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-188px; background-color:#fed136">
                                <div class="categorias-caption-heading">Productos de Limpieza</div>
                                <div class="categorias-caption-subheading text-muted">Cloro, jabón, lavaplatos...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="box-sizing: initial">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/portfolio/04-thumbnail.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-44px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Artículos de Oficina</div>
                                <div class="categorias-caption-subheading text-muted">Papelería, escritorios, mesas, sillas, mesas...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="margin-left: 100px">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/portfolio/03-thumbnail.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-68px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Accesorios y Otros</div>
                                <div class="categorias-caption-subheading text-muted">Lencerías, toallas, colchones, cauchos para vehículos...</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
  </body>
</asp:Content>
