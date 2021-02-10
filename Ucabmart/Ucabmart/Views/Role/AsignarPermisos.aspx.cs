using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Role
{
    public partial class AsignarPermisos : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
            this.VisibleFields(false);



        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            //Empleado empleado = new Empleado(int.Parse(BuscarCod.Text));
            //MuchosAMuchos em_ca = new MuchosAMuchos();
            //em_ca.Insertar(empleado, new Rol(int.Parse(Roles.SelectedValue)));

            //Response.Redirect("/Views/Role/Role_Admin.aspx", false);

        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol(int.Parse(BuscarCod.Text));

            TxtNombre.Text =  rol.Nombre;

            this.VisibleFields(true);
            this.EnableFields(false);

        }


        protected void EnableFields(bool enable)
        {

            TxtNombre.Enabled = enable;
            TxtNombre.CssClass = "form-control";

        }

        protected void VisibleFields(bool visible)
        {
            Nombre.Visible = visible;
            EmplHead.Visible = visible;
            TxtNombre.Visible = visible;
            Asignar.Visible = visible;

        }

        protected void Agregar_Roles()
        {

        }

        protected void Agregar_Permisos(object sender, EventArgs e)
        {

            //Permisos.Items.Clear();

            //if (int.Parse(Roles.SelectedValue) != 0) {
            //    Rol rol = new Rol(int.Parse(Roles.SelectedValue));

            //    List<Permiso> lista = new List<Permiso>();
            //    lista = rol.Permisos();

            //    foreach (Permiso item in lista)
            //    {
            //        ListItem listItem = new ListItem(item.Nombre, item.Codigo.ToString());

            //        if (!Permisos.Items.Contains(listItem))
            //        {
            //            Permisos.Items.Insert(Permisos.Items.Count, listItem);
            //        }
            //    }

            //}

            this.VisibleFields(true);


        }
    }
}