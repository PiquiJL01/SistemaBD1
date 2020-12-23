<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" AutoEventWireup="true" CodeBehind="CrearCuenta.aspx.cs" Inherits="Ucabmart.Views.CrearCuenta1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="page-section bg-light" id="tiendas">
            <div class="container">
                <div class="text-center">
                    <h2 class="section-heading text-uppercase">Crear Cuenta</h2>
                    <h3 class="section-subheading text-muted">Lorem ipsum dolor sit amet consectetur.</h3>
                </div>
                <div class="row justify-content-center">
                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="tiendas-item">
                            <a class="tiendas-link" data-toggle="modal" href="#tiendasModal1">
                                <div class="tiendas-hover">
                                    <div class="tiendas-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/portfolio/01-thumbnail.jpg" alt="" />
                            </a>
                            <div class="tiendas-caption">
                                <div class="tiendas-caption-heading">Threads</div>
                                <div class="tiendas-caption-subheading text-muted">Illustration</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4">
                        <div class="tiendas-item">
                            <a class="tiendas-link" data-toggle="modal" href="#tiendasModal2">
                                <div class="tiendas-hover">
                                    <div class="tiendas-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid" src="../../Content/assets/img/portfolio/02-thumbnail.jpg" alt="" />
                            </a>
                            <div class="tiendas-caption">
                                <div class="tiendas-caption-heading">Explore</div>
                                <div class="tiendas-caption-subheading text-muted">Graphic Design</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>
