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
        string picked;
        int[] elementArray = new int[] { 1, 1, 1, 1 };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Argumenst of the event</param>
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


            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");

            int count = 0;
           
            foreach (AspNetUserTitan tit in dbm.GetUserTitans(user.Id))
            {
                if (tit.Retired == false && tit.Deleted == false)
                {
                    var titInfo = dbm.Titaninfo(tit.TitanID);

                    panel = (Panel)FindControlRecursive(Page, "overLay" + titInfo.Type);
                    if (panel != null)
                    {

                        Label label = (Label)panel.FindControl("Label" + titInfo.Type);
                        label.Text = "-Taken-";
                        elementArray[Convert.ToInt32(titInfo.Type)-1] = 0;
                        panel.Visible = true;
                        count++;
                        //if user has more than 4 Titans they will be redirected back to user profile
                        if (count == 4)
                        {
                            Response.Redirect("UserProfile");

                        }
                    }

                }
            }


            int num = 0;

            for (int i = 0; i < 4; i++)
            {
                if (elementArray[i] == 1)
                {
                    num = i + 1;
                    break;
                }
            }

            //show one Titan
            panel = (Panel)FindControlRecursive(Page, "overLay" + num);
            if (panel != null)
            {
                panel.Visible = true;
                Label label = (Label)panel.FindControl("Label"+ num);
                label.Text = "Current";
                picked = num.ToString();
                Image image = (Image)panel.FindControl("image1");
                image.ImageUrl = CustomGlobal.TitanImage(CustomGlobal.viewtype.Front, num.ToString());

            }
        }
        /// <summary>
        /// Chooses the selected Titan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">arguments of the event</param>
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
                dbm.CreateTitan(User.Identity.GetUserId(), picked, titanname);
            }

            Response.Redirect("UserProfile");
        }


        /// <summary>
        /// submits the Titan with name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">arguments of the events</param>
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

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());
            
            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");
            //checks to see if Titan is retired or deleted to make room for new titan
            foreach (AspNetUserTitan tit in dbm.GetUserTitans(user.Id))
            {
                if (tit.Retired == false && tit.Deleted == false)
                {
                    var titInfo = dbm.Titaninfo(tit.TitanID);

                    panel = (Panel)FindControlRecursive(Page, "overLay" + titInfo.Type);
                    if (panel != null)
                    {

                        Label label = (Label)panel.FindControl("Label" + titInfo.Type);
                        label.Text = "-Taken-";
                        elementArray[Convert.ToInt32(titInfo.Type) - 1] = 0;
                        panel.Visible = true;
                        
                    }

                }
            }

            

            //show a titan that has been picked
            panel = (Panel)FindControlRecursive(Page, "overLay" + s);

            if (panel != null)
            {
                panel.Visible = true;
                Label label = (Label)panel.FindControl("Label" + s);
                label.Text = "Current";
                picked = s;
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