using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Employee
{
    public partial class ModificarEmpleado : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }

        Lugar nombreLugar = new Lugar(0);
        int codigoEstado = -1, codigoMunicipio = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();

            try
            {
                cargarPagina(true);
                this.Agregar_Cargos();
                this.Agregar_Departamentos();
                this.Agregar_Tiendas();
                this.Add_Items();
                this.EnableFields(false);
            }
            catch (Exception ex)
            {
                Session["mensajeError"] = "Ha ocurrido un error con la base de datos. " + ex;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No hay conexión con la base de datos');", true);
            }


        }

        protected void btnGuardarCambios(object sender, EventArgs e) { 
        
        
        
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.EnableFields(true);

            Empleado empleado = new Empleado(int.Parse(BuscarCod.Text));

            Nombre1.Text = empleado.Nombre1;
            Nombre2.Text = empleado.Nombre2;

            Apellido1.Text = empleado.Apellido1;
            Apellido2.Text = empleado.Apellido2;

            //RIF
            char[] a = new char[1];
            empleado.RIF.CopyTo(0, a, 0, 1);
            char[] NumRif = new char[15];
            empleado.RIF.CopyTo(1, NumRif, 0, empleado.RIF.Length - 1);

            dplrif.SelectedValue = new String(a).Replace("\0", "");
            txtRif.Text = new String(NumRif).Replace("\0", "");

            //CEDULA
            char[] c = new char[1];
            empleado.Cedula.CopyTo(0, c, 0, 1);
            char[] NumCed = new char[15];
            empleado.Cedula.CopyTo(1, NumCed, 0, empleado.Cedula.Length - 1);

            dplCedula.SelectedValue = new String(c).Replace("\0", "");
            txtCedula.Text = new String(NumCed).Replace("\0", "");

            //CORREO
            CorreoElectronico correo = new CorreoElectronico(empleado.CodigoCorreoElectronico);
            txtCorreo.Text = correo.Direccion;


            //TELEFONOS

            Telefono telefono1 = new Telefono();
            List<Telefono> telefonos = telefono1.Leer(empleado);


            foreach (ListItem item in CodigoPais1.Items)
            {
                if (item.Value == telefonos[0].Numero[NumeroTelefono.Pais].ToString())
                {

                    CodigoPais1.SelectedValue = item.Value;

                }
            }

            TipoTelf.SelectedValue = telefonos[0].Tipo;
            CodAre.Text = telefonos[0].Numero[NumeroTelefono.Area].ToString();
            txtTelefono1.Text = telefonos[0].Numero[NumeroTelefono.Numero].ToString();

            if (telefonos.Count > 1)
            {

                foreach (ListItem item in CodigoPais2.Items)
                {
                    if (item.Value == telefonos[1].Numero[NumeroTelefono.Pais].ToString())
                    {

                        CodigoPais2.SelectedValue = item.Value;

                    }
                }




            }


            //LUGAR Y CONTRASEÑA
            Lugar parroquia = new Lugar(empleado.CodigoDireccion);
            Lugar Municipio = new Lugar(parroquia.CodigoUbicacion);
            Lugar Estado = new Lugar(Municipio.CodigoUbicacion);

            dplEstado.SelectedValue = Estado.Nombre;
            this.dplEstado_SelectedIndexChanged(sender, e);
            dplMunicipio.SelectedValue = Municipio.Nombre;
            this.dplMunicipio_SelectedIndexChanged(sender, e);
            dplParroquia.SelectedValue = parroquia.Nombre;


            txtContraseña.Text = empleado.Password;
            txtRepetirContraseña.Text = empleado.Password;


            //DEPARTAMENTO

            Departamento departamento = new Departamento(empleado.CodigoDepartamento);
            Departamentos.Items.Clear();
            this.Agregar_Departamentos();
            Departamentos.SelectedValue = departamento.Nombre;

            //TIENDA

            Tienda tienda = new Tienda(empleado.CodigoTienda);
            Tiendas.Items.Clear();
            this.Agregar_Tiendas();
            Tiendas.SelectedValue = tienda.Nombre;

            //JEFE

            Empleado jefe = new Empleado(empleado.CodigoJefe);
            Jefe.Text = jefe.Codigo.ToString();


        }


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

        protected void Add_Items()
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

        protected void EnableFields(bool enable)
        {

            Nombre1.Enabled = enable;
            Nombre2.Enabled = enable;
            Apellido1.Enabled = enable;
            Apellido2.Enabled = enable;

            dplrif.Enabled = enable;
            txtRif.Enabled = enable;
            dplCedula.Enabled = enable;
            txtCedula.Enabled = enable;

            txtCorreo.Enabled = enable;
            CodigoPais1.Enabled = enable;
            CodAre.Enabled = enable;
            TipoTelf.Enabled = enable;
            txtTelefono1.Enabled = enable;
            CodigoPais2.Enabled = enable;
            CodAre2.Enabled = enable;
            TipoTelf2.Enabled = enable;
            txtTelefono2.Enabled = enable;

            dplEstado.Enabled = enable;
            dplMunicipio.Enabled = enable;
            dplParroquia.Enabled = enable;
            txtContraseña.Enabled = enable;
            txtRepetirContraseña.Enabled = enable;

            Cargos.Enabled = enable;
            Departamentos.Enabled = enable;
            Tiendas.Enabled = enable;
            Jefe.Enabled = enable;

            HoraInicio.Enabled = enable;
            HoraFin.Enabled = enable;
            Dias.Enabled = enable;
            Turno.Enabled = enable;
            btnModificar.Enabled = enable;
            Options.Enabled = enable;
  

            Nombre1.CssClass = "form-control";
            Nombre2.CssClass = "form-control";
            Apellido1.CssClass = "form-control";
            Apellido2.CssClass = "form-control";
            dplrif.CssClass = "input-group-prepend be-addon";
            txtRif.CssClass = "form-control";
            dplCedula.CssClass = "input-group-prepend be-addon";
            txtCedula.CssClass = "form-control";
            txtCorreo.CssClass = "form-control";

            CodigoPais1.CssClass = "input-group-prepend be-addon";
            TipoTelf.CssClass = "input-group-prepend be-addon";
            CodAre.CssClass = "form-control";
            txtTelefono1.CssClass = "form-control";

            CodigoPais2.CssClass = "input-group-prepend be-addon";
            TipoTelf2.CssClass = "input-group-prepend be-addon";
            CodAre2.CssClass = "form-control";
            txtTelefono2.CssClass = "form-control";

            dplEstado.CssClass = "input-group-prepend be-addon";
            dplMunicipio.CssClass = "input-group-prepend be-addon";
            dplParroquia.CssClass = "input-group-prepend be-addon";

            Cargos.CssClass = "input-group-prepend be-addon";
            Departamentos.CssClass = "input-group-prepend be-addon";
            Tiendas.CssClass = "input-group-prepend be-addon";
            Jefe.CssClass = "form-control";

            HoraInicio.CssClass = "form-control";
            HoraFin.CssClass = "form-control";
            Turno.CssClass = "input-group-prepend be-addon";
            Dias.CssClass = "input-group-prepend be-addon";

            Options.CssClass = "input-group-prepend be-addon";
            txtContraseña.CssClass = "form-control";
            txtRepetirContraseña.CssClass = "form-control";

            btnModificar.CssClass = "btn btn-primary btn-user btn-block";



        }




    }
}