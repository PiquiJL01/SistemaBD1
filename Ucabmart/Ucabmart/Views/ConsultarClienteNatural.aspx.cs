using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Controller;

namespace Ucabmart.Views
{
    public partial class ConsultarClienteNatural : System.Web.UI.Page
    {
        public string tabla; // para contruir y mostrar la tabla con html 
        public string cadena;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dplTipoCliente.SelectedValue == "Natural")
            {
                /// imprimo la cabecera de la tabla de esta manera
                /// para no perder los estilos de bootstrap
                tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
                tabla += "<thead>";
                tabla += "<tr>";
                tabla += "<th>ID</th>";
                tabla += "<th>T. De Documento</th>";
                tabla += "<th>Nro. Cédula</th>";
                tabla += "<th>Nombre o Razón Social</th>";
                tabla += "<th>Sexo</th>";
                tabla += "<th>Carnet</th>";
                tabla += "</tr>";
                tabla += "</thead>";

                tabla += "<tbody>";

                /// cuerpo o contenido de la tabla
               
                tabla += "<tr>";
                tabla += "<td>Hola</td>";
                tabla += "<td> qué tal?</td>";
                tabla += "<td>todo bien?</td>";
                tabla += "<td> esta es una </td>";
                tabla += "<td>tabla natural</td>";
                tabla += "<td><a class=" + "portfolio - link" + " data-toggle=" + "modal" + " href=" + "#portfolioModal1" + "> Ver Carnet </a></td>";
                tabla += "</tr>";

                tabla += "</tbody>";

                tabla += "</table>";
                Label1.Text = "Hola";
                Label2.Text = "qué tal?";
                Label3.Text = "todo bien?";
                Label4.Text = "esta es una";
                Label5.Text = "tabla natural";

                cadena += Label1.Text + "\n"+ Label2.Text + "\n" + Label3.Text + "\n" + Label4.Text + "\n" + Label4.Text + "\n";
                VerQrNatural carnet = new VerQrNatural();
                imgCtrl = carnet.GenerarQr(imgCtrl, cadena);

                int numrows = 3;
                int numcells = 2;
                for (int j = 0; j < numrows; j++)
                {
                    TableRow r = new TableRow();
                    for (int i = 0; i < numcells; i++)
                    {
                        TableCell c = new TableCell();
                        TableHeaderCell columnaHeader = new TableHeaderCell();
                                               
                        c.Controls.Add(new LiteralControl("row "
                            + j.ToString() + ", cell " + i.ToString()));
                        if (j == 0) {
                            columnaHeader.Controls.Add(new LiteralControl("row "
                           + j.ToString() + ", cell " + i.ToString()));
                            r.Cells.Add(columnaHeader);
                        }
                        else
                        r.Cells.Add(c);                        
                    }
                    listaPersonaTabla.Rows.Add(r);


                    int rowCounter = 0;
                    TableRow[] myRowArray = null;
                    TableCell[] myCellArray = null;
                    StringBuilder tb = new StringBuilder();

                    // Copy the Rows collection to an array.
                    listaPersonaTabla.Rows.CopyTo(myRowArray, 0);

                    tb.Append("The copied items from the table are: \n");

                    // Iterate through the TableRows in the array.
                    foreach (TableRow rw in myRowArray)
                    {
                        // Copy the Cells collection of a row to an array.
                        listaPersonaTabla.Rows[rowCounter].Cells.CopyTo(myCellArray, 0);

                        // Iterate through the cell array 
                        // and display its contents.
                        foreach (TableCell cell in myCellArray)
                            tb.Append(cell.Text + ", ");

                        Label6.Text = tb.ToString();
                        rowCounter++;
                    }

                }

            }
            else
            {
                tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
                tabla += "<thead>";
                tabla += "<tr>";
                tabla += "<th>ID</th>";
                tabla += "<th>T. De Documento</th>";
                tabla += "<th>Nro. Cédula</th>";
                tabla += "<th>Nombre o Razón Social</th>";
                tabla += "<th>Sexo</th>";
                tabla += "<th>Edad</th>";
                tabla += "<th>Direccion</th>";
                tabla += "</tr>";
                tabla += "</thead>";

                tabla += "<tbody>";

                /// cuerpo o contenido de la tabla

                tabla += "<tr>";
                tabla += "<td> Hola </td>";
                tabla += "<td> qué tal?</td>";
                tabla += "<td>todo bien?</td>";
                tabla += "<td> esta es una </td>";
                tabla += "<td>tabla juridica</td>";
                tabla += "<td>Aprende menor!</td>";
                tabla += "<td>JAJAJA</td>";
                tabla += "</tr>";

                tabla += "</tbody>";

                tabla += "</table>";
            }
           // listaPersonaTabla.InnerHtml = tabla;
            
        }
    }
}