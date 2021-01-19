using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Controller;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class ConsultarClienteNatural : System.Web.UI.Page
    {
        public string tabla; // para contruir y mostrar la tabla con html 
        public string cadena;
        public Natural ctrlConsultaNatural;
        public Juridico ctrlConsultaJuridico;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dplTipoCliente.SelectedValue == "Natural")
                {
                    /// imprimo la cabecera de la tabla de esta manera
                    /// para no perder los estilos de bootstrap
                    tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
                    tabla += "<thead>";
                    tabla += "<tr>";
                    tabla += "<th>Cedula</th>";
                    tabla += "<th>Nombre1</th>";
                    tabla += "<th>Nombre2</th>";
                    tabla += "<th>Apellido1</th>";
                    tabla += "<th>Apellido2</th>";
                    tabla += "<th>RIF</th>";
                    tabla += "<th>Password</th>";
                    tabla += "<th>CodigoCorreoElectronico</th>";
                    tabla += "<th>CodigoTienda</th>";
                    tabla += "</tr>";
                    tabla += "</thead>";

                    tabla += "<tbody>";

                    List<Natural> listaNatural = new List<Natural>();
                    ctrlConsultaNatural = new Natural();

                    listaNatural = ctrlConsultaNatural.TodosNaturales();

                    foreach (Natural item in listaNatural)
                    {
                        /// cuerpo o contenido de la tabla

                        tabla += "<tr>";
                        tabla += "<td>" + item.Cedula + "</td>";
                        tabla += "<td>" + item.Nombre1 + "</td>";
                        tabla += "<td>" + item.Nombre2 + "</td>";
                        tabla += "<td>" + item.Apellido1 + "</td>";
                        tabla += "<td>" + item.Apellido2 + "</td>";
                        tabla += "<td>" + item.RIF + "</td>";
                        tabla += "<td>" + item.Password + "</td>";
                        tabla += "<td>" + item.CodigoCorreoElectronico + "</td>";
                        tabla += "<td>" + item.CodigoTienda + "</td>";
                        tabla += "<td><a class=" + "portfolio - link" + " data-toggle=" + "modal" + " href=" + "#portfolioModal1" + "> Ver Carnet </a></td>";
                        tabla += "</tr>";
                    }

                    tabla += "</tbody>";
                    tabla += "</table>";

                    Label1.Text = "Hola";
                    Label2.Text = "qué tal?";
                    Label3.Text = "todo bien?";
                    Label4.Text = "esta es una";
                    Label5.Text = "tabla natural";

                    cadena += Label1.Text + "\n" + Label2.Text + "\n" + Label3.Text + "\n" + Label4.Text + "\n" + Label4.Text + "\n";
                    VerQrNatural carnet = new VerQrNatural();
                    imgCtrl = carnet.GenerarQr(imgCtrl, cadena);

                }
                else
                {
                    tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
                    tabla += "<thead>";
                    tabla += "<tr>";
                    tabla += "<th>DenominacionComercial</th>";
                    tabla += "<th>RazonSocial</th>";
                    tabla += "<th>Capital</th>";
                    tabla += "<th>PaginaWeb</th>";
                    tabla += "<th>DireccionFisica</th>";
                    tabla += "<th>DireccionFiscal</th>";
                    tabla += "<th>RIF</th>";
                    tabla += "<th>Password</th>";
                    tabla += "<th>CodigoCorreoElectronico</th>";
                    tabla += "<th>CodigoTienda</th>";
                    tabla += "</tr>";
                    tabla += "</thead>";

                    tabla += "<tbody>";

                    List<Juridico> listaJuridico = new List<Juridico>();
                    ctrlConsultaJuridico = new Juridico();
                    listaJuridico = ctrlConsultaJuridico.TodosJuridicos();

                    foreach (Juridico item in listaJuridico)
                    {
                        /// cuerpo o contenido de la tabla
                        tabla += "<tr>";
                        tabla += "<td>" + item.DenominacionComercial + "</td>";
                        tabla += "<td>" + item.RazonSocial + "</td>";
                        tabla += "<td>" + item.Capital + "</td>";
                        tabla += "<td>" + item.PaginaWeb + "</td>";
                        tabla += "<td>" + item.DireccionFisica + "</td>";
                        tabla += "<td>" + item.DireccionFiscal + "</td>";
                        tabla += "<td>" + item.RIF + "</td>";
                        tabla += "<td>" + item.Password + "</td>";
                        tabla += "<td>" + item.CodigoCorreoElectronico + "</td>";
                        tabla += "<td>" + item.CodigoTienda + "</td>";
                        tabla += "<td><a class=" + "portfolio - link" + " data-toggle=" + "modal" + " href=" + "#portfolioModal1" + "> Ver Carnet </a></td>";
                        tabla += "</tr>";
                    }

                    tabla += "</tbody>";
                    tabla += "</table>";
                }
                listaPersonaTabla.InnerHtml = tabla;
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error con la base de datos. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No hay conexión con la base de datos');", true);
            }
        }
        
    }
}