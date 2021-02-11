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