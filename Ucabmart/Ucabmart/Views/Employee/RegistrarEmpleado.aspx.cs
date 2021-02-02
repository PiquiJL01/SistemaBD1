using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Employee
{
    public partial class RegistrarEmpleado : System.Web.UI.Page
    {

        Lugar nombreLugar = new Lugar(0);
        int codigoEstado = -1, codigoMunicipio = -1;

        public void cargarPagina(Boolean flag)
        {
            List<Lugar> listaLugar = new List<Lugar>();
            listaLugar = nombreLugar.Todos();

            if (flag)
            {
                foreach (Lugar item in listaLugar)
                {
                    if (item.Tipo == "Estado")
                        dplEstado.Items.Add(item.Nombre);
                }

                foreach (Lugar item in listaLugar)
                {
                    if (dplEstado.SelectedValue == item.Nombre && item.CodigoUbicacion == 1)
                        codigoEstado = item.Codigo;
                    //almacena el codigo del estado
                }

                foreach (Lugar item in listaLugar)
                {
                    if (item.CodigoUbicacion == codigoEstado)   //compara el codigo del estado con el codigo del municipio
                        dplMunicipio.Items.Add(item.Nombre);      //agrega los municipios                       
                }

                foreach (Lugar item in listaLugar)
                {
                    if (dplMunicipio.SelectedValue == item.Nombre && codigoEstado == item.CodigoUbicacion)   //compara el codigo del estado con el codigo del municipio
                        codigoMunicipio = item.Codigo;
                    //almacena el codigo del municipio 
                }

                foreach (Lugar item in listaLugar)
                {
                    if (item.CodigoUbicacion == codigoMunicipio)  //compara el codigo del municipio con el codigo de la parroquia
                        dplParroquia.Items.Add(item.Nombre);
                }
            }
            else
            {

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
        }

        protected void Agregar_Cargos()
        {
            Cargo cargo = new Cargo();

            List<Cargo> lista = new List<Cargo>();
            lista = cargo.Todos();

            ListItem Title = new ListItem("Cargo", "");
            Cargos.Items.Insert(Cargos.Items.Count, Title);

            foreach (Cargo item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Nombre);
                Cargos.Items.Insert(Cargos.Items.Count, listItem);
            }
        }

        protected void Agregar_Departamentos()
        {
            Departamento departamento = new Departamento();

            List<Departamento> lista = new List<Departamento>();
            lista = departamento.Todos();

            ListItem Title = new ListItem("Departamento", "");
            Departamentos.Items.Insert(Departamentos.Items.Count, Title);

            foreach (Departamento item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Nombre);
                Departamentos.Items.Insert(Departamentos.Items.Count, listItem);
            }
        }

        protected void Agregar_Tiendas()
        {
            Tienda tienda = new Tienda();

            List<Tienda> lista = new List<Tienda>();
            lista = tienda.Todos();

            ListItem Title = new ListItem("Tienda", "");
            Tiendas.Items.Insert(Tiendas.Items.Count, Title);

            foreach (Tienda item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Nombre);
                Tiendas.Items.Insert(Tiendas.Items.Count, listItem);
            }
        }

        protected int CodLugar(DropDownList x, DropDownList y, DropDownList z)
        {
            List<Lugar> lugares = new List<Lugar>();
            lugares = new Lugar().Todos();
            int CodMunicpio = 0;
            int CodEstado = 0;


            foreach (Lugar lugar in lugares)
            {
                if (z.SelectedValue == lugar.Nombre && lugar.Tipo == "Estado")
                {
                    CodEstado = lugar.Codigo;
                }
            }

            foreach (Lugar lugar in lugares)
            {
                if (y.SelectedValue == lugar.Nombre && lugar.Tipo == "Municipio" && CodEstado == lugar.CodigoUbicacion)
                {
                    CodMunicpio = lugar.Codigo;
                }
            }

            foreach (Lugar lugar in lugares)
            {
                if (x.SelectedValue == lugar.Nombre && lugar.Tipo == "Parroquia" && CodMunicpio == lugar.CodigoUbicacion)
                {
                    return lugar.Codigo;
                }

            }

            return 0;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cargarPagina(true);
                this.Agregar_Cargos();
                this.Agregar_Departamentos();
                this.Agregar_Tiendas();
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error con la base de datos. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No hay conexión con la base de datos');", true);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e) {

            try
            {
                int CodLug1 = this.CodLugar(dplParroquia, dplMunicipio, dplEstado);

                CorreoElectronico correo = new CorreoElectronico(txtCorreo.Text);
                correo.Insertar();

                //Empleado empleado = new Empleado(,);

                //Session["EmpleadoRif"] = proveedor.RIF;
                Response.Redirect("/Views/Employee/RegistrarEmpleado.aspx", false);

            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error al registrar el empleado. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('NO DEBE HABER CAMPOS VACÍOS');", true);
            }

        }

        protected void dplEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPagina(false);

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

    }
}