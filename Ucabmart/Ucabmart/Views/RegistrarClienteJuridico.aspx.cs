using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views
{
    public partial class RegistrarClienteJuridico : System.Web.UI.Page
    {
        Lugar nombreLugar = new Lugar(0);
        int codigoEstado = -1, codigoMunicipio = -1;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Lugar> listaLugar = new List<Lugar>();
            listaLugar = nombreLugar.Todos();
            foreach (Lugar item in listaLugar)
            {
                if (item.Tipo == "Estado")
                {
                    dplEstado.Items.Add(item.Nombre);
                    dplEstado2.Items.Add(item.Nombre);
                }
            }

            foreach (Lugar item in listaLugar)
            {
                if (dplEstado.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                    codigoEstado = item.Codigo;
                //almacena el codigo del estado
            }

            foreach (Lugar item in listaLugar)
            {
                if (item.CodigoUbicacion == codigoEstado)
                {  //compara el codigo del estado con el codigo del municipio
                    dplMunicipio.Items.Add(item.Nombre);      //agrega los municipios   
                    dplMunicipio2.Items.Add(item.Nombre);
                }
            }

            foreach (Lugar item in listaLugar)
            {
                if (dplMunicipio.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)   //compara el codigo del estado con el codigo del municipio
                    codigoMunicipio = item.Codigo;
                //almacena el codigo del municipio 
            }

            foreach (Lugar item in listaLugar)
            {
                if (item.CodigoUbicacion == codigoMunicipio)
                {  //compara el codigo del municipio con el codigo de la parroquia
                    dplParroquia.Items.Add(item.Nombre);
                    dplParroquia2.Items.Add(item.Nombre);
                }
            }

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

        protected void dplEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Lugar> listaLugar = new List<Lugar>();
            listaLugar = nombreLugar.Todos();
            foreach (Lugar item in listaLugar)
            {
                if (dplEstado.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                    codigoEstado = item.Codigo;
            }
            dplMunicipio.Items.Clear();
            dplParroquia.Items.Clear();

            foreach (Lugar item in listaLugar)
            {
                if (codigoEstado == item.CodigoUbicacion)
                    dplMunicipio.Items.Add(item.Nombre);
            }

            foreach (Lugar item in listaLugar)
            {
                if (dplMunicipio.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)
                    codigoMunicipio = item.Codigo;

            }

            foreach (Lugar item in listaLugar)
            {
                if (codigoMunicipio == item.CodigoUbicacion)
                    dplParroquia.Items.Add(item.Nombre);

            }
        }

        protected void dplMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Lugar> listaLugar2 = new List<Lugar>();
            listaLugar2 = nombreLugar.Todos();

            foreach (Lugar item in listaLugar2)
            {
                if (dplEstado.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                    codigoEstado = item.Codigo;
            }
            dplParroquia.Items.Clear();

            foreach (Lugar item in listaLugar2)
            {
                if (dplMunicipio.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)
                    codigoMunicipio = item.Codigo;
            }

            foreach (Lugar item in listaLugar2)
            {
                if (codigoMunicipio == item.CodigoUbicacion)
                    dplParroquia.Items.Add(item.Nombre);
            }
        }

        protected void dplEstado2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Lugar> listaLugar = new List<Lugar>();
            listaLugar = nombreLugar.Todos();
            foreach (Lugar item in listaLugar)
            {
                if (dplEstado2.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                    codigoEstado = item.Codigo;
            }
            dplMunicipio2.Items.Clear();
            dplParroquia2.Items.Clear();

            foreach (Lugar item in listaLugar)
            {
                if (codigoEstado == item.CodigoUbicacion)
                    dplMunicipio2.Items.Add(item.Nombre);
            }

            foreach (Lugar item in listaLugar)
            {
                if (dplMunicipio2.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)
                    codigoMunicipio = item.Codigo;

            }

            foreach (Lugar item in listaLugar)
            {
                if (codigoMunicipio == item.CodigoUbicacion)
                    dplParroquia2.Items.Add(item.Nombre);

            }
        }

        protected void dplMunicipio2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Lugar> listaLugar2 = new List<Lugar>();
            listaLugar2 = nombreLugar.Todos();

            foreach (Lugar item in listaLugar2)
            {
                if (dplEstado2.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                    codigoEstado = item.Codigo;
            }
            dplParroquia2.Items.Clear();

            foreach (Lugar item in listaLugar2)
            {
                if (dplMunicipio2.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)
                    codigoMunicipio = item.Codigo;
            }

            foreach (Lugar item in listaLugar2)
            {
                if (codigoMunicipio == item.CodigoUbicacion)
                    dplParroquia2.Items.Add(item.Nombre);
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