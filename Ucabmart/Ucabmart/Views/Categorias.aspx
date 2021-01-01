<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Ucabmart.Views.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ucabmart - Categorías</title>
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
                                <img class="img-fluid2" src="../../Content/assets/img/Categories/Refrigerados.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-68px; background-color:#fed136">
                                <div class="categorias-caption-heading">Refrigerados</div>
                                <div class="categorias-caption-subheading text-muted">Pollo, Pavo, Queso, Pescado...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="margin-left: 120px">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Categories/Limpieza.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-69px; background-color:#fed136">
                                <div class="categorias-caption-heading">Limpieza</div>
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
                                <img class="img-fluid2" src="../../Content/assets/img/Categories/Lenceria.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-44px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Lenceria</div>
                                <div class="categorias-caption-subheading text-muted">Toallas, Camisas, Pantalones...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="margin-left: 100px">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Categories/Accesorios.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-68px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Accesorios</div>
                                <div class="categorias-caption-subheading text-muted">Cartera, Lente, Collar, Reloj...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="box-sizing: initial">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Categories/Papeleria.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-44px; background-color:#fed136">
                                <div class="categorias-caption-heading">Papeleria</div>
                                <div class="categorias-caption-subheading text-muted">Borra, Lapiz, Sacapuntas, Tijera...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="margin-left: 100px">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Categories/Mobilario.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-68px; background-color:#fed136">
                                <div class="categorias-caption-heading">Mobilario</div>
                                <div class="categorias-caption-subheading text-muted">Mesas, Sillas, Colchones, Vitrinas...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="box-sizing: initial">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Categories/Empaquetado.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-44px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Empaquetado</div>
                                <div class="categorias-caption-subheading text-muted">Dorito, Chocolate, Avena, Aceite, Gelatina...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="margin-left: 100px">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Categories/Electrodomesticos.png" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-68px; background-color:#4e73dfd1">
                                <div class="categorias-caption-heading">Electrodoméstico</div>
                                <div class="categorias-caption-subheading text-muted">Nevera, Cocina, Licuadora, Televisor...</div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-sm-6 mb-4" style="box-sizing: initial">
                        <div class="categorias-item">
                            <a class="categorias-link" href="#">
                                <div class="categorias-hover">
                                    <div class="categorias-hover-content"><i class="fas fa-plus fa-3x"></i></div>
                                </div>
                                <img class="img-fluid2" src="../../Content/assets/img/Categories/Repuestos.jpg" alt="" />
                            </a>
                            <div class="categorias-caption" style="margin-right:-44px; background-color:#fed136">
                                <div class="categorias-caption-heading">Repuestos</div>
                                <div class="categorias-caption-subheading text-muted">Cauchos, Amortiguador, Arranque, Boquilla...</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
  </body>
</asp:Content>
