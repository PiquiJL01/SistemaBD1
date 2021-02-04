using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Product
{
    public partial class RegistrarProducto : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
            this.Agregar_Marcas();
            this.Agregar_Clasificaciones();
        }

        protected void Agregar_Marcas()
        {
            Marca marca = new Marca();

            List<Marca> lista = new List<Marca>();
            lista = marca.Todos();
            
            ListItem Title = new ListItem("Marca", "");
            Marcas.Items.Insert(Marcas.Items.Count,Title);

            foreach (Marca item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Nombre);
                Marcas.Items.Insert(Marcas.Items.Count,listItem);
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

        protected TipoCalidad Get_Calidad() {

            TipoCalidad tipoCalidad = new TipoCalidad();

            switch (dplCalidad.SelectedValue)
            {
               case "Alta":
                  tipoCalidad = TipoCalidad.Alta;
                  break;

               case "Baja":
                  tipoCalidad = TipoCalidad.Baja;
                  break;

               case "Regular":
                  tipoCalidad = TipoCalidad.Regular;
                   break;
            }

            return tipoCalidad;
  
        
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Marca marca = new Marca();
                int Codmarca = marca.Get_CodMarca(Marcas.SelectedValue);

                Clasificacion clasificacion = new Clasificacion();
                int CodClasificacion = clasificacion.Get_Clasificacion(Clasificacion.SelectedValue);

                Producto producto = new Producto(TxtNombre.Text, dplAlimenticio.SelectedValue, float.Parse(TxtPrecio.Text), Get_Calidad(), TxtDescripcion.Text, new Marca(Codmarca),new Clasificacion(CodClasificacion));
                producto.Insertar();


                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('el producto ha sido registrado exitosamente');" +
                                "window.location ='../Productos_Admin.aspx';", true);
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error al registrar un producto. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS');", true);
            }

        }



    }
}