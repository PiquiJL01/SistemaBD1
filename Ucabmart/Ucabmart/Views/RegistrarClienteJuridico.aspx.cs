using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ucabmart.Views
{
    public partial class RegistrarClienteJuridico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
         
        }

        protected void Agregar(object sender, EventArgs e)
        {
            List<ListItem> lista = new List<ListItem>();
            lista.Add(new ListItem("España", "+40"));
            lista.Add(new ListItem("Puerto Rico", "+42"));
            lista.Add(new ListItem("Francia", "+34"));

            foreach (ListItem item in lista)
            {
               DropDownList1.Items.Insert(DropDownList1.Items.Count,item);
            }
        }

        //protected void AddAreaCode(object sender, EventArgs e)
        //{
        //    String cadena = "0248 Monagas";
        //    String[] codigo = cadena.Split(' ');

        //    //foreach (String item in codigo)
        //    //{
        //    CodArea.Items.Insert(CodArea.Items.Count,new ListItem(codigo.ElementAt(1), codigo.ElementAt(0)));
        //    //}
        //}


    }
}