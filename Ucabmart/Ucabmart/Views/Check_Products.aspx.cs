using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class Check_Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Items(object sender, EventArgs e)
        {
            Producto p1 = new Producto();

            List<Producto> lista = new List<Producto>();
            lista = p1.Todos();

            foreach (Producto item in lista)
            {
                if (Options.Items.Count == 0 | Options.Items.Count % 2 == 0)
                {

                    ListItem ChckItem = new ListItem(item.Nombre);
                    ChckItem.Attributes.Add("class", "ColorChangeBlue");
                    Options.Items.Insert(Options.Items.Count, ChckItem);

                }
                else
                {
                    ListItem ChckItem = new ListItem(item.Nombre);
                    ChckItem.Attributes.Add("class", "ColorChangeYellow");
                    Options.Items.Insert(Options.Items.Count, ChckItem);

                }

            }

            //Options.Items.Insert(Options.Items.Count, new ListItem("Limon"));
            //Options.Items.Insert(Options.Items.Count, new ListItem("Pera"));
            //Options.Items.Insert(Options.Items.Count, new ListItem("Manzana"));

            //ListItem a = new ListItem("Coco");
            //a.Attributes.Add("class","ColorChangeBlue");
            //Options.Items.Insert(Options.Items.Count,a);

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            String ProveedorRif = Session["ProveedorRif"].ToString();
            Proveedor proveedor = new Proveedor(ProveedorRif);

            List<String> elements = new List<string>();

            foreach (ListItem item in Options.Items)
            {
                if (item.Selected)
                {
                    elements.Add(item.Value);
                }
            }

            Producto prod1 = new Producto();
            List<int> CodigosProduct = prod1.ProductosCod(elements);

            foreach (int codigo in CodigosProduct)
            {
                proveedor.AgregarProducto(new Producto(codigo));
            }

            Response.Redirect("/Views/Proveedores.aspx", false);

        }


    }

}