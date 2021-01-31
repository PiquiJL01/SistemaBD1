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
        protected void Page_Load(object sender, EventArgs e)
        {

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