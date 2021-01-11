using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ucabmart.Views
{
    public partial class Check_Products : System.Web.UI.Page
    {
        public string Check;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Items(object sender, EventArgs e)
        {
            List<String> items = new List<String>();
            items.Add("Limon");
            items.Add("Pera");
            items.Add("Manzana");
            items.Add("Coco");
            items.Add("Frambuesa");

            //Options.Items.Add(new ListItem("Limon", "Limon"));
            foreach (String item in items)
            {
                if (Options.Items.Count == 0 | Options.Items.Count % 2 == 0)
                {

                   ListItem ChckItem = new ListItem(item);
                   ChckItem.Attributes.Add("class", "ColorChangeBlue");
                   Options.Items.Insert(Options.Items.Count,ChckItem);

                }
                else
                {
                    ListItem ChckItem = new ListItem(item);
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
        }

     }
}