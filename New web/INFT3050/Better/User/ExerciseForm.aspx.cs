using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace Better.User
{
    public partial class ExerciseForm : Page
    {
        /// <summary>
        /// 
        /// </summary>
        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());
            //checks if user is locked out from exercise
            if (user.ExersiseLockoutEnabled)
            {
                if (user.ExersiseLastEntered.Value.Date.CompareTo(DateTime.Today.Date) != -1)
                {
                    Response.Redirect("UserProfile");

                }
                else
                {
                    user.ExersiseLockoutEnabled = false;
                }
            }
            //Shows details of user
            Panel panel = (Panel)FindControlRecursive(Page, "UserDetails");
            Label Name = (Label)panel.FindControl("Name");
            Label EPBalance = (Label)panel.FindControl("EPBalance");

            Name.Text = user.FirstName + " " + user.LastName;
            EPBalance.Text = user.EPBalance.ToString();

            Panel epAdded = (Panel)FindControlRecursive(Page, "epAdded");
            epAdded.Visible = false;
        }
        /// <summary>
        /// user exercise input is taken 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">arguments of the event</param>
        protected void Enter_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)FindControlRecursive(Page, "Panel1");
            TextBox distanceWalked = (TextBox)panel.FindControl("distanceWalked");
            TextBox distanceRan = (TextBox)panel.FindControl("distanceRan");
            TextBox pushUps = (TextBox)panel.FindControl("pushUps");
            TextBox sitUps = (TextBox)panel.FindControl("sitUps");
            TextBox ParentPin = (TextBox)panel.FindControl("ParentPin");

            
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());


            String errmsg = "";

            //check if all boxs have vaild inputs 
            if (distanceWalked.Text.All(Char.IsDigit) && distanceRan.Text.All(Char.IsDigit) && pushUps.Text.All(Char.IsDigit) && sitUps.Text.All(Char.IsDigit) && ParentPin.Text.All(Char.IsDigit))
            {
                //checks if parent pin is correct
                if (ParentPin.Text.Equals(user.ParentCode))
                {
                    if (!user.ExersiseLockoutEnabled)
                    {
                        Show();
                    }
                }
                else
                {
                    errmsg = errmsg + "ParentPin is wrong";
                }
            }
            //If a field is wrong a message will be returned
            else
            {


                if (!distanceWalked.Text.All(Char.IsDigit))
                {
                    errmsg = errmsg + "Distance walked field has the wrong input<br>";
                }
                if (!distanceRan.Text.All(Char.IsDigit))
                {
                    errmsg = errmsg + "Distance run field has the wrong input<br>";
                }
                if (!pushUps.Text.All(Char.IsDigit))
                {
                    errmsg = errmsg + "Push up field has the wrong input<br>";
                }
                if (!sitUps.Text.All(Char.IsDigit))
                {
                    errmsg = errmsg + "Sit up field has the wrong input<br>";
                }
                if (!ParentPin.Text.All(Char.IsDigit))
                {
                    errmsg = errmsg + "ParentPin field has the wrong input";
                }
            }
            Label error = (Label)FindControlRecursive(Page, "Error");

            error.Visible = true;
            error.Text = errmsg;
        }
        /// <summary>
        /// shows experience points added and the new experience points gained
        /// </summary>
        protected void Show()
        {
            Panel panel = (Panel)FindControlRecursive(Page, "Panel1");
            Panel epAdded = (Panel)FindControlRecursive(Page, "epAdded");

            TextBox ParentPin = (TextBox)panel.FindControl("ParentPin");
            Label newEP = (Label)FindControlRecursive(Page, "newEP");
            Label EPBalance = (Label)FindControlRecursive(Page, "EPBalance");


            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());
            
            TextBox distanceWalked = (TextBox)panel.FindControl("distanceWalked");
            TextBox distanceRan = (TextBox)panel.FindControl("distanceRan");
            TextBox pushUps = (TextBox)panel.FindControl("pushUps");
            TextBox sitUps = (TextBox)panel.FindControl("sitUps");

            float walk = Convert.ToInt32(distanceWalked.Text);
            float ran = Convert.ToInt32(distanceRan.Text);
            float push = Convert.ToInt32(pushUps.Text);
            float sit = Convert.ToInt32(sitUps.Text);
            float total = (walk / 25) * 10 + (ran / 25) * 10 + (push / 25) * 10 + (sit / 25) * 10;

            int add = Convert.ToInt32(total);
            int oldInt = Convert.ToInt32(user.EPBalance);
            int newInt = oldInt + add;


            user.ExersiseLastEntered = DateTime.Today;
            user.ExersiseLockoutEnabled = true;
            user.EPBalance = newInt;
            manager.Update(user);

            EPBalance.Text = user.EPBalance.ToString();
            newEP.Text = add.ToString();
            epAdded.Visible = true;

            Response.Redirect("UserProfile");
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