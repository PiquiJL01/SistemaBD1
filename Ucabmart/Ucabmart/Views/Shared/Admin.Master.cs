using System;

namespace Ucabmart.Views.Shared
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string nombreUsuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.nombreUsuario = Session["NombreLogin"].ToString();
        }
    }
}