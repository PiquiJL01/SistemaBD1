using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class EliminarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor consultaProveedor = new Proveedor(txtEliminar.Text);

                if (consultaProveedor != null)
                {
                    PersonaContacto personaContacto = new PersonaContacto(consultaProveedor);
                    Telefono telefono = new Telefono();
                    List<Telefono> listaTelefono = telefono.Leer(consultaProveedor);
                    List<Telefono> listaTelefonoPerContacto = telefono.Leer(personaContacto);
                    CorreoElectronico correo = new CorreoElectronico(consultaProveedor.CodigoCorreoElectronico);

                    foreach (Telefono numero in listaTelefono)
                    {
                        numero.Eliminar();
                    }

                    foreach (Telefono numero in listaTelefonoPerContacto)
                    {
                        numero.Eliminar();
                    }

                    Producto todosProductos = new Producto();
                    List<Producto> listaProducto = todosProductos.Todos();

                    foreach (Producto producto in listaProducto)
                    {
                        consultaProveedor.EliminarProducto(producto);
                    }

                    personaContacto.Eliminar();
                    consultaProveedor.Eliminar();
                    correo.Eliminar();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El proveedor ha sido eliminado');" +
                                "window.location ='Proveedores.aspx';", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El Proveedor no existe');", true);

            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error con la base de datos. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No hay conexión con la base de datos');", true);
            }
        }
    }
}