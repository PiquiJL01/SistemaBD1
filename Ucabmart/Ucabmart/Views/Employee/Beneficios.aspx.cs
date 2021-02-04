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
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
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

        protected void AssignBeneficios(Empleado empleado)
        {

            MuchosAMuchos Bene_Emple = new MuchosAMuchos();

            List<String> elements = new List<string>();

            foreach (ListItem item in Options.Items)
            {
                if (item.Selected)
                {
                    elements.Add(item.Value);
                }
            }

            Beneficio beneficio = new Beneficio();
            List<int> CodigosBeneficios = beneficio.BeneficiosCod(elements);

            foreach (int codigo in CodigosBeneficios)
            {
                Bene_Emple.Insertar(empleado, new Beneficio(codigo));
            }

        }


        protected void btn_Click(object sender, EventArgs e)
        {
            int EmpleadoRif = int.Parse(Session["EmpleadoRif"].ToString());

            this.AssignBeneficios(new Empleado(EmpleadoRif));

            Response.Redirect("/Views/Nomina_Admin.aspx", false);

        }
    }
}