﻿using System;
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
        public string nombreUsuario { get; set; }

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
            
            if (!Cargos.Items.Contains(Title)) {
            
                Cargos.Items.Insert(Cargos.Items.Count, Title);

            }

            foreach (Cargo item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Nombre);

                if (!Cargos.Items.Contains(listItem))
                {
                    Cargos.Items.Insert(Cargos.Items.Count, listItem);
                }
            }
        }

        protected void Agregar_Departamentos()
        {
            Departamento departamento = new Departamento();

            List<Departamento> lista = new List<Departamento>();
            lista = departamento.Todos();

            ListItem Title = new ListItem("Departamento", "");

            if (!Departamentos.Items.Contains(Title))
            {
                Departamentos.Items.Insert(Departamentos.Items.Count, Title);
            }

            foreach (Departamento item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Nombre);

                if (!Departamentos.Items.Contains(listItem))
                {
                    Departamentos.Items.Insert(Departamentos.Items.Count, listItem);
                }
            }
        }

        protected void Agregar_Tiendas()
        {
            Tienda tienda = new Tienda();

            List<Tienda> lista = new List<Tienda>();
            lista = tienda.Todos();

            ListItem Title = new ListItem("Tienda", "");

            if (!Tiendas.Items.Contains(Title))
            {
                Tiendas.Items.Insert(Tiendas.Items.Count, Title);
            }

            foreach (Tienda item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Nombre);

                if (!Tiendas.Items.Contains(listItem))
                {
                    Tiendas.Items.Insert(Tiendas.Items.Count, listItem);
                }
            }
        }

        protected List<DayOfWeek> Get_Days()
        {

            List<DayOfWeek> days = new List<DayOfWeek>();

            foreach (ListItem item in Dias.Items)
            {
                if (item.Selected)
                {

                    switch (item.Value)
                    {
                        case "Domingo":
                            days.Add(DayOfWeek.Sunday);
                            break;
                        case "Lunes":
                            days.Add(DayOfWeek.Monday);
                            break;
                        case "Martes":
                            days.Add(DayOfWeek.Tuesday);
                            break;
                        case "Miercoles":
                            days.Add(DayOfWeek.Wednesday);
                            break;
                        case "Jueves":
                            days.Add(DayOfWeek.Thursday);
                            break;
                        case "Viernes":
                            days.Add(DayOfWeek.Friday);
                            break;
                        case "Sabado":
                            days.Add(DayOfWeek.Saturday);
                            break;
                    }

                }

            }

            return days;


        }

        protected TipoTurno Get_Turno()
        {

            TipoTurno tipoTurno = new TipoTurno();

            switch (Turno.SelectedValue)
            {
                case "Diurno":
                    tipoTurno = TipoTurno.Diurno;
                    break;

                case "Matutino":
                    tipoTurno = TipoTurno.Matutino;
                    break;

                case "Vespertino":
                    tipoTurno = TipoTurno.Vespertino;
                    break;

                case "Nocturno":
                    tipoTurno = TipoTurno.Nocturno;
                    break;
            }

            return tipoTurno;


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

        protected void AssignHorarios(Empleado empleado)
        {

            List<DayOfWeek> daysOfWeeks = Get_Days();
            MuchosAMuchos Hora_Emple = new MuchosAMuchos();

            foreach (DayOfWeek item in daysOfWeeks)
            {
                Horario horario = new Horario(TimeSpan.Parse(HoraInicio.Text), TimeSpan.Parse(HoraFin.Text), Get_Turno(), item);
                horario.Insertar();
                Hora_Emple.Insertar(empleado, horario);
            }


        }


        protected void AssignCargos(Empleado empleado, Cargo cargo) {

            MuchosAMuchos Cargo_Emple = new MuchosAMuchos();

            Cargo_Emple.Insertar(empleado, cargo, int.Parse(TextMonto.Text) );


        }

        protected void btnRegistrar_Click(object sender, EventArgs e) 
        {
            try
            {
                int CodLug1 = this.CodLugar(dplParroquia, dplMunicipio, dplEstado);

                CorreoElectronico correo = new CorreoElectronico(txtCorreo.Text);
                correo.Insertar();

                Departamento departamento = new Departamento();
                int CodDepartamento = departamento.Get_CodDepartamento(Departamentos.SelectedValue);

                Tienda tienda = new Tienda();
                int CodTienda = tienda.Get_CodTienda(Tiendas.SelectedValue);

                Cargo cargo = new Cargo();
                int CodCargo = cargo.Get_CodCargo(Cargos.SelectedValue);


                if (int.Parse(Jefe.Text) != 0) {
                    Empleado empleado = new Empleado(txtContraseña.Text, dplRif.SelectedValue + txtRif.Text, dplCedula.SelectedValue + txtCedula.Text, Nombre1.Text,
                    Nombre2.Text, Apellido1.Text, Apellido2.Text, new Departamento(CodDepartamento), new Tienda(CodTienda), new Lugar(CodLug1), correo, new Empleado(int.Parse(Jefe.Text)));
                    empleado.Insertar();

                    this.AssignHorarios(empleado);
                    this.AssignCargos(empleado, new Cargo(CodCargo));

                    Telefono telefono1 = new Telefono(int.Parse(CodigoPais1.SelectedValue), int.Parse(CodAre.Text), int.Parse(txtTelefono1.Text), TipoTelf.Text,empleado);
                    telefono1.Insertar();

                    Telefono telefono2 = new Telefono(int.Parse(CodigoPais2.SelectedValue), int.Parse(CodAre2.Text), int.Parse(txtTelefono2.Text), TipoTelf2.Text,empleado);
                    telefono2.Insertar();


                    Session["EmpleadoRif"] = empleado.Codigo;
                }
                else
                {
                    Empleado empleado = new Empleado(txtContraseña.Text, dplRif.SelectedValue + txtRif.Text, dplCedula.SelectedValue + txtCedula.Text, Nombre1.Text,
                    Nombre2.Text, Apellido1.Text, Apellido2.Text, new Departamento(CodDepartamento), new Tienda(CodTienda), new Lugar(CodLug1), correo, null);
                    empleado.Insertar();

                    this.AssignHorarios(empleado);
                    this.AssignCargos(empleado, new Cargo(CodCargo));

                    Telefono telefono1 = new Telefono(int.Parse(CodigoPais1.SelectedValue), int.Parse(CodAre.Text), int.Parse(txtTelefono1.Text), TipoTelf.Text,empleado);
                    telefono1.Insertar();

                    Telefono telefono2 = new Telefono(int.Parse(CodigoPais2.SelectedValue), int.Parse(CodAre2.Text), int.Parse(txtTelefono2.Text), TipoTelf2.Text,empleado);
                    telefono2.Insertar();

                    Session["EmpleadoRif"] = empleado.Codigo;
                }

   
                Response.Redirect("/Views/Employee/Beneficios.aspx", false);

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