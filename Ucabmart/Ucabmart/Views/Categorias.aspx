<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Ucabmart.Views.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="page-section bg-light" id="categorias">
            <div class="container">
                <div class="text-center">
                    <br>
                    <h2 class="section-heading text-uppercase">Categorías</h2>
                    <br>
                    <br>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/portfolio/01-thumbnail.jpg" alt="" />
                            </a>
                            <div class="categorias-caption">
                                <div class="categorias-caption-heading">Alimentos</div>
                                <div class="categorias-caption-subheading text-muted">Pollo, pavos, embutidos, chocolates...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/portfolio/02-thumbnail.jpg" alt="" />
                            </a>
                            <div class="categorias-caption">
                                <div class="categorias-caption-heading">Productos de Limpieza</div>
                                <div class="categorias-caption-subheading text-muted">Cloro, jabón, lavaplatos...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/portfolio/04-thumbnail.jpg" alt="" />
                            </a>
                            <div class="categorias-caption">
                                <div class="categorias-caption-heading">Artículos de Oficina</div>
                                <div class="categorias-caption-subheading text-muted">Papelería, escritorios, mesas, sillas, mesas...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/portfolio/03-thumbnail.jpg" alt="" />
                            </a>
                            <div class="categorias-caption">
                                <div class="categorias-caption-heading">Accesorios y Otros</div>
                                <div class="categorias-caption-subheading text-muted">Lencerías, toallas, colchones, cauchos para vehículos...</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>
