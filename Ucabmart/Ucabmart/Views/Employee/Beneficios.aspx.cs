using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Employee
{
    public partial class Beneficios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Items(object sender, EventArgs e)
        {
            Beneficio p1 = new Beneficio();

            List<Beneficio> lista = new List<Beneficio>();
            lista = p1.Todos();

            foreach (Beneficio item in lista)
            {
                ListItem ChckItem = new ListItem(item.Nombre);
                Options.Items.Insert(Options.Items.Count, ChckItem);

            }

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            int EmpleadoRif = int.Parse(Session["EmpleadoRif"].ToString());
            //Proveedor proveedor = new Proveedor(ProveedorRif);

            //List<String> elements = new List<string>();

            //foreach (ListItem item in Options.Items)
            //{
            //    if (item.Selected)
            //    {
            //        elements.Add(item.Value);
            //    }
            //}

            //Producto prod1 = new Producto();
            //List<int> CodigosProduct = prod1.ProductosCod(elements);

            //foreach (int codigo in CodigosProduct)
            //{
            //    proveedor.AgregarProducto(new Producto(codigo));
            //}

            //Response.Redirect("/Views/Proveedores.aspx", false);
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El proveedor se ha sido registrado exitosamente');" +
            //                       "window.location ='Proveedores.aspx';", true);

        }
    }
}