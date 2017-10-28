using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Better.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;



namespace Better.User
{
    public partial class CharacterCreation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            Panel panel;

            //hide all
            for (int i = 1; i < 5; i++)
            {
                panel = (Panel)FindControlRecursive(Page, "overLay" + i);

                if (panel != null)
                {
                    panel.Visible = false;
                }
            }

            //show one
            int num = rand.Next(1, 5);
            panel = (Panel)FindControlRecursive(Page, "overLay" + num);
            if (panel != null)
            {
                panel.Visible = true;
                Image image = (Image)panel.FindControl("image1");
                image.ImageUrl = CustomGlobal.TitanImage(CustomGlobal.viewtype.Front, num.ToString());

            }
        }

        protected void Enter_Click(object sender, EventArgs e)
        {
            Panel panel;
            string titanname = "";
            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");

            panel = (Panel)FindControlRecursive(Page, "PanelTitanInfo");

            if (panel != null)
            {
                panel.Visible = true;
                TextBox name = (TextBox)panel.FindControl("TitanName");
                titanname = name.Text;
            }

            if (!string.IsNullOrEmpty(titanname))
            {
                dbm.CreateTitan(User.Identity.GetUserId(), "1", titanname);
            }

            Response.Redirect("UserProfile");
        }



        protected void ImageButton_Command(object sender, EventArgs e)
        {
            Panel panel;

            //hide all
            for (int i = 1; i < 5; i++)
            {
                panel = (Panel)FindControlRecursive(Page, "overLay" + i);

                if (panel != null)
                {
                    panel.Visible = false;
                }
            }
            String s = ((ImageButton)sender).ID;
            string str = "btnSubmit";
            s = s.Remove(0, str.Length);
            //show one
            panel = (Panel)FindControlRecursive(Page, "overLay" + s);

            if (panel != null)
            {
                panel.Visible = true;
                Image image = (Image)panel.FindControl("image1");
                image.ImageUrl = CustomGlobal.TitanImage(CustomGlobal.viewtype.Front, s);
            }
        }

        /*
         * source: https://stackoverflow.com/questions/28327229/asp-net-find-control-by-id
         * 
         * Recursivly finds the ControlId needed to dynamicaly display titans on page depending on how many titans are in the hall
         * 
         */
        private Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn = FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null) return controlToReturn;
            }
            return null;
        }
    }
}