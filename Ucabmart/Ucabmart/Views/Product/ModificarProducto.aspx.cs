using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Product
{
    public partial class ModificarProducto : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
            this.Agregar_Marcas();
            this.Agregar_Clasificaciones();
            this.EnableFields(false);

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

        protected void Agregar_Marcas()
        {
            Marca marca = new Marca();

            List<Marca> lista = new List<Marca>();
            lista = marca.Todos();

            ListItem Title = new ListItem("Marca", "");
            Marcas.Items.Insert(Marcas.Items.Count, Title);

            foreach (Marca item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Nombre);
                Marcas.Items.Insert(Marcas.Items.Count, listItem);
            }
        }

        protected void Agregar_Clasificaciones()
        {
            Clasificacion clasificacion = new Clasificacion();

            List<Clasificacion> lista = new List<Clasificacion>();
            lista = clasificacion.Todos();


            ListItem Title = new ListItem("Clasificacion", "");
            Clasificacion.Items.Insert(Clasificacion.Items.Count, Title);


            foreach (Clasificacion item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Nombre);
                Clasificacion.Items.Insert(Clasificacion.Items.Count, listItem);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto(int.Parse(BuscarCod.Text));

            TxtNombre.Text = producto.Nombre;
            TxtPrecio.Text = producto.Precio.ToString();
            TxtDescripcion.Text = producto.Descripcion;
            dplCalidad.SelectedValue = producto.Calidad;
            dplAlimenticio.SelectedValue = producto.EsAlimenticio.Replace(" ","");

            Marca marca = new Marca(producto.CodigoMarca);
            Marcas.Items.Clear();
            this.Agregar_Marcas();
            Marcas.SelectedValue = marca.Nombre;

            Clasificacion clasificacion = new Clasificacion(producto.CodigoClasificacion);
            Clasificacion.Items.Clear();
            this.Agregar_Clasificaciones();
            Clasificacion.SelectedValue = clasificacion.Nombre;

            this.EnableFields(true);

        }

        protected void btnGuardarCambios(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Producto(int.Parse(BuscarCod.Text));

                producto.Nombre = TxtNombre.Text;
                producto.Precio = float.Parse(TxtPrecio.Text);
                producto.Descripcion = TxtDescripcion.Text;
                producto.Calidad = dplCalidad.SelectedValue;
                producto.EsAlimenticio = dplAlimenticio.SelectedValue;

                Marca marca = new Marca();
                int Codmarca = marca.Get_CodMarca(Marcas.SelectedValue);

                Clasificacion clasificacion = new Clasificacion();
                int CodClasificacion = clasificacion.Get_Clasificacion(Clasificacion.SelectedValue);

                producto.CodigoMarca = Codmarca;
                producto.CodigoClasificacion = CodClasificacion;

                producto.Actualizar();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El producto se ha sido modificado exitosamente');" +
                    "window.location ='../Productos_Admin.aspx';", true);
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error al modificar el producto. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS');", true);
            }

        }

        protected void EnableFields (bool enable)
        {
            if (enable)
            {
                TxtNombre.Enabled = true;
                TxtPrecio.Enabled = true;
                TxtDescripcion.Enabled = true;
                dplCalidad.Enabled = true;
                dplAlimenticio.Enabled = true;
                Marcas.Enabled = true;
                Clasificacion.Enabled = true;
                btnModificar.Enabled = true;
            }
            else
            {
                TxtNombre.Enabled = false;
                TxtNombre.CssClass = "form-control";
                TxtPrecio.Enabled = false;
                TxtPrecio.CssClass = "form-control";
                TxtDescripcion.Enabled = false;
                TxtDescripcion.CssClass = "form-control";

                dplCalidad.Enabled = false;
                dplCalidad.CssClass = "input-group-prepend be-addon";
                dplAlimenticio.Enabled = false;
                dplAlimenticio.CssClass = "input-group-prepend be-addon";
                Marcas.Enabled = false;
                Marcas.CssClass = "input-group-prepend be-addon";
                Clasificacion.Enabled = false;
                Clasificacion.CssClass = "input-group-prepend be-addon";

                btnModificar.Enabled = false;
                btnModificar.CssClass = "btn btn-primary btn-user btn-block";

            }


        }
    }
}