using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Product
{
    public partial class EliminarProducto : System.Web.UI.Page
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
                Producto consultaProducto = new Producto(Int32.Parse(txtEliminar.Text));

                if (consultaProducto != null)
                {
                    consultaProducto.EliminarEnPR_PR();
                    consultaProducto.Eliminar();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El producto ha sido eliminado');" +
                                "window.location ='../Productos_Admin.aspx';", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El producto no existe');", true);

            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error al ingresar los datos. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El código del producto debe ser un númmero entero');", true);
            }
        }
    }
}