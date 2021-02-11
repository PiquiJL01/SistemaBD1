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
            Productos.Visible = false;
            Tiendas.Visible = false;
            Nomina.Visible = false;
            Proveedores.Visible = false;
            Clientes.Visible = false;
            RolesA.Visible = false;

            string rol = Session["Rol"].ToString();
            int codigoRol = Int32.Parse(rol);
            Rol nombreRol = new Rol(codigoRol);
            List<Permiso> listaPermiso = nombreRol.Permisos();

            foreach (Permiso permiso in listaPermiso)
            {
                switch (permiso.Codigo)
                {
                    case 1:
                        Productos.Visible = true;
                        break;
                    case 2:
                        Tiendas.Visible = true;
                        break;
                    case 3:
                        Nomina.Visible = true;
                        break;
                    case 4:
                        Proveedores.Visible = true;
                        break;
                    case 5:
                        Clientes.Visible = true;
                        break;
                    case 6:
                        RolesA.Visible = true;
                        break;

                }
            }
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

                    List<int> listaCargo = empleado.BuscarEnCargo();

                    foreach (int codigoCargo in listaCargo)
                    {
                        Cargo nombreCargo = new Cargo(codigoCargo);
                        empleadoM_M.Eliminar(empleado, nombreCargo);
                    }
                    

                    empleado.Eliminar();
                    correo.Eliminar();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El empleado ha sido eliminada');" +
                                "window.location ='../Nomina_Admin.aspx';", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El empleado no existe');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Hubo un error al eliminar');", true);
            }
        }
    }
}