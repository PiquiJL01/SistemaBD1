using System;
using System.Collections.Generic;
using System.Web.UI;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class EliminarClienteJuridico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteJuridico = new Cliente(txtEliminar.Text);

                if (clienteJuridico != null)
                {
                    Juridico personaJuridica = new Juridico(txtEliminar.Text);
                    PersonaContacto personaContacto = new PersonaContacto(personaJuridica);
                    Telefono telefono = new Telefono();
                    List<Telefono> listaTelefonoJuridico = telefono.Leer(clienteJuridico);
                    List<Telefono> listaTelefonoContacto = telefono.Leer(personaContacto);
                    CorreoElectronico correo = new CorreoElectronico(clienteJuridico.CodigoCorreoElectronico);

                    foreach (Telefono numero in listaTelefonoContacto)
                    {
                        numero.Eliminar();
                    }

                    foreach (Telefono numero in listaTelefonoJuridico)
                    {
                        numero.Eliminar();
                    }

                    personaContacto.Eliminar();
                    personaJuridica.Eliminar();
                    clienteJuridico.Eliminar();
                    correo.Eliminar();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('la persona ha sido eliminada');" +
                                "window.location ='Clientes_Admin.aspx';", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La persona no existe');", true);

            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error con la base de datos. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No hay conexión con la base de datos');", true);
            }
        }
    }
}