using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Employee
{
    public partial class ConsultarEmpleado : System.Web.UI.Page
    {
        public string tabla;
        public Empleado consultarEmpleado;
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();

            tabla += "<table id='example' class='table table-striped table-bordered second' style='width: 100%'>";
            tabla += "<thead>";
            tabla += "<tr>";
            tabla += "<th>Código</th>";
            tabla += "<th>Rif</th>";
            tabla += "<th>Cédula</th>";
            tabla += "<th>Primer Nombre</th>";
            tabla += "<th>Segundo Nombre</th>";
            tabla += "<th>Primer Apellido</th>";
            tabla += "<th>Segundo Apellido</th>";
            tabla += "<th>Tienda</th>";
            tabla += "<th>Departamento</th>";
            tabla += "<th>Código Empleado</th>";
            tabla += "<th>Código Lugar</th>";
            tabla += "<th>Código Correo</th>";
            tabla += "<th>Beneficios</th>";
            tabla += "<th>Contraseña</th>";
            tabla += "<th>Horas de Entrada</th>";
            tabla += "<th>Horas de Salida</th>";
            tabla += "<th>Turnos</th>";
            tabla += "<th>Días</th>";
            tabla += "</tr>";
            tabla += "</thead>";

            tabla += "<tbody>";

            consultarEmpleado = new Empleado();
            List<Empleado> listaEmpleado = consultarEmpleado.Todos();

            foreach (Empleado item in listaEmpleado)
            {
                tabla += "<tr>";
                tabla += "<td>" + item.Codigo + "</td>";
                tabla += "<td>" + item.RIF + "</td>";
                tabla += "<td>" + item.Cedula + "</td>";
                tabla += "<td>" + item.Nombre1 + "</td>";
                tabla += "<td>" + item.Nombre2 + "</td>";
                tabla += "<td>" + item.Apellido1 + "</td>";
                tabla += "<td>" + item.Apellido2 + "</td>";

                Tienda tienda = new Tienda(item.CodigoTienda);
                string nombreTienda = tienda.Nombre;

                tabla += "<td>" + nombreTienda + "</td>";

                Departamento departamento = new Departamento();
                departamento = departamento.Leer(item.CodigoDepartamento);
                string nombreDepartamento = departamento.Nombre;

                tabla += "<td>" + nombreDepartamento + "</td>";

                tabla += "<td>" + item.CodigoJefe + "</td>";
                tabla += "<td>" + item.CodigoDireccion + "</td>";
                tabla += "<td>" + item.CodigoCorreoElectronico + "</td>";

                Beneficio beneficio = new Beneficio();
                List<int> listaBeneficios = beneficio.codigoBeneficios(item.Codigo);
                string nombreBeneficio = "";

                foreach (int codigoBeneficios in listaBeneficios) {
                    beneficio = beneficio.Leer(codigoBeneficios);
                    nombreBeneficio += beneficio.Nombre + "\n";
                }

                tabla += "<td>" + nombreBeneficio + "</td>";
                tabla += "<td>" + item.Password + "</td>";

                List<Horario> horarios = item.Horarios();
                string horaInicio = "";
                string horaFin= "";
                string turno = "";
                string dia = "";

                foreach (Horario horario in horarios)
                {
                    horaInicio += horario.HoraEntrada + "\n";
                    horaFin += horario.HoraSalida + "\n";
                    turno += horario.Turno + "\n";
                    dia += horario.Dia + "\n";
                }

                tabla += "<td>" + horaInicio + "</td>";
                tabla += "<td>" + horaFin + "</td>";
                tabla += "<td>" + turno + "</td>";
                tabla += "<td>" + dia + "</td>";

                tabla += "</tr>";
            }

            tabla += "</tbody>";
            tabla += "</table>";

            listaPersonaTabla.InnerHtml = tabla;
        }
    }
}