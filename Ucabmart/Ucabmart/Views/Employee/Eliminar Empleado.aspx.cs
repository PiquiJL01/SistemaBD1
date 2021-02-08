using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Employee
{
    public partial class EliminarEmpleado : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado empleado = new Empleado(txtEliminar.Text);

                if (empleado != null)
                {
                    Telefono telefono = new Telefono();
                    List<Telefono> listaTelefono = telefono.Leer(empleado);
                    CorreoElectronico correo = new CorreoElectronico(empleado.CodigoCorreoElectronico);
                    correo.Eliminar();
                    foreach (Telefono numero in listaTelefono)
                    {
                        numero.Eliminar();
                    }

                    Beneficio beneficio = new Beneficio();
                    List<int> listaBeneficios = beneficio.codigoBeneficios(empleado.Codigo);
                    MuchosAMuchos empleadoM_M = new MuchosAMuchos();

                    foreach (int codigoBeneficios in listaBeneficios)
                    {
                        beneficio = beneficio.Leer(codigoBeneficios);
                        empleadoM_M.Eliminar(empleado, beneficio);
                    }

                    Horario horario = new Horario();
                    List<int> listaHorario = horario.codHorario(empleado);
                   
                    foreach (int codigoHorario in listaHorario)
                    {
                        horario = horario.Leer(codigoHorario);
                        empleadoM_M.Eliminar(empleado, horario);
                        horario.Eliminar();
                    }

                    int codigoCargo = empleadoM_M.BuscarEnCargo(empleado);
                    Cargo nombreCargo = new Cargo(codigoCargo);
                    empleadoM_M.Eliminar(empleado, nombreCargo);

                    empleado.Eliminar();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El empleado ha sido eliminada');" +
                                "window.location ='../Nomina_Admin.aspx';", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El empleado no existe');", true);

            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error con la base de datos. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hubo un error al eliminar');", true);
            }
        }
    }
}