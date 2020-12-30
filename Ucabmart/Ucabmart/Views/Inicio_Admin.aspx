<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" AutoEventWireup="true" CodeBehind="Inicio_Admin.aspx.cs" Inherits="Ucabmart.Views.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<!-- Masthead-->
       <header class="masthead">
            <div class="container">
                 <div class="masthead-heading text-uppercase">¡Bienvenido a Ucabmart!</div>
                <form class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search" runat="server">
                    <div class="input-group" style="width:700px;">
                        <asp:TextBox ID="txtBuscar" runat="server" type="text" name="name" data-parsley-trigger="change" 
                                 placeholder="Buscar" autocomplete="off" class="form-control">
                        </asp:TextBox>    
                        
                        <asp:ImageButton id="imagebutton1" runat="server"  style="width:55px;" class="btn btn-primary search" AlternateText="Buscar" ImageAlign="left" ImageUrl="../Content/assets/img/Lupa.png" OnClick="btnBuscar_Click"/>
                    </div>
                </form>
            </div>
        </header>
            
        
</asp:Content>
