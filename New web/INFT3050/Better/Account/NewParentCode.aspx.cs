using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Better.Models;
using Better.Controllers;
using System.Web.UI.WebControls;

namespace Better.Account
{
    public partial class NewParentCode : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user's email address

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(User.Identity.GetUserId());

                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    FailureText.Text = "The user either does not exist or is not confirmed.";
                    ErrorMessage.Visible = true;
                    return;
                }

                Random rand = new Random();
                int newCode = rand.Next(0,10000);
                string completeCode;

                if(newCode < 10)
                {
                    completeCode = "000" + newCode.ToString();
                }
                else if(newCode < 100)
                {
                    completeCode = "00" + newCode.ToString();

                }else if (newCode < 1000)
                {
                    completeCode = "0" + newCode.ToString();
                }
                else
                {
                    completeCode = newCode.ToString();
                }

                user.ParentCode = completeCode;
                manager.Update(user);


                string emailOutcome = CustomGlobal.email(user.ParentEmail, "NoReply@Better.com","New ParentCode","Your New ParentCode is "+completeCode+".");
                

                loginForm.Visible = false;
                DisplayEmail.Visible = true;
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