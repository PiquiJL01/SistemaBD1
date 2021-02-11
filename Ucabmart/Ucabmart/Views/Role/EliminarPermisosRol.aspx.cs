using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ucabmart.Engine;

namespace Ucabmart.Views.Role
{
    public partial class EliminarPermisos : System.Web.UI.Page
    {
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
            this.VisibleFields(false);

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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            Rol rol = new Rol(int.Parse(BuscarCod.Text));
            MuchosAMuchos ro_pe = new MuchosAMuchos();
            


            foreach (ListItem item in Permisos.Items)
            {
                if (item.Selected)
                {
                    ro_pe.Eliminar(new Permiso(int.Parse(item.Value)), rol );

                }
            }

              ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('los permisos han sido eliminados exitosamente');" + "window.location ='Role_Admin.aspx';", true);



        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Rol rol = new Rol(int.Parse(BuscarCod.Text));
            TxtNombre.Text = rol.Nombre;

            this.Agregar_Permisos();
            this.VisibleFields(true);
            this.EnableFields(false);

        }


        protected bool VerificatePermisos(Rol rol, ListItem permi)
        {

            List<Permiso> permisos = rol.Permisos();

            foreach (Permiso permiso in permisos)
            {
                if (int.Parse(permi.Value) == permiso.Codigo)
                {
                    return true;

                }
            }

            return false;
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
            Permisos.Visible = visible;

        }

        protected void Agregar_Permisos()
        {

            Permisos.Items.Clear();

            Rol rol = new Rol(int.Parse(BuscarCod.Text));

            List<Permiso> lista = rol.Permisos();
            

            foreach (Permiso item in lista)
            {
                ListItem listItem = new ListItem(item.Nombre, item.Codigo.ToString());

                if (!Permisos.Items.Contains(listItem))
                {
                    Permisos.Items.Insert(Permisos.Items.Count, listItem);
                }
            }

            this.VisibleFields(true);


        }
    }
}