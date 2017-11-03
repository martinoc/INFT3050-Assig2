using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Better.Models;
using Better.Controllers;

namespace Better.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Validate the user's email address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
                
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindByName(Email.Text);
                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    FailureText.Text = "The user either does not exist or is not confirmed.";
                    ErrorMessage.Visible = true;
                    return;
                }
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send email with the code and the redirect to reset password page
                string code = manager.GeneratePasswordResetToken(user.Id);
                string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);

                string emailOutcome = CustomGlobal.email(user.Email, "NoReply@Better.com", "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                
                loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }
    }
}