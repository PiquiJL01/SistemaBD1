﻿using System;
using System.Web.UI;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class IniciarSesionPrueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                CorreoElectronico correo = new CorreoElectronico();
                correo = correo.LeerPorNombre(Email.Text);

                if (correo != null)
                {
                    Cliente buscar = new Cliente();
                    Empleado buscarEmpleado = new Empleado();

                    if (buscar.BuscarContrasenaCliente(correo.Codigo) == Password.Text)
                    {
                        string loginUsuario = Email.Text;
                        Session["NombreLogin"] = loginUsuario;


                        Response.Redirect("/Views/User/InicioUsuario.aspx", false);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", 
                        //                "window.location ='/Views/User/InicioUsuario.aspx';", true);
                    }
                    else
                        if(buscarEmpleado.BuscarContrasenaEmpleado(correo.Codigo) == Password.Text)
                    {
                        string loginUsuario = Email.Text;
                        Session["NombreLogin"] = loginUsuario;
                        int codigoEmpleado = buscarEmpleado.BuscarCodigoEmpleado(correo.Codigo);
                        MuchosAMuchos m_m = new MuchosAMuchos();
                        int codigoRol = m_m.BuscarRol(codigoEmpleado);
                        if (codigoRol != 0)
                        {
                            Session["Rol"] = codigoRol.ToString();
                            Response.Redirect("/Views/Inicio_Admin.aspx", false);
                        }
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Usted no tiene permisos para acceder al sistema');", true);
                    }
                        else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La contraseña es incorrecta');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El correo no está registrado');", true);
                }
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error al acceder en el Login. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS ');", true);

            }
        }


    }
}
