using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Account_Manage : System.Web.UI.Page
{
    protected string SuccessMessage
    {
        get;
        private set;
    }


   
    protected void Page_Load()
    {
        if (!IsPostBack)
        {
            // Determine the sections to render
          
            

            // Render success message
            var message = Request.QueryString["m"];
            if (message != null)
            {
                // Strip the query string from action
                Form.Action = ResolveUrl("~/User/Account/Manage");

                SuccessMessage =
                    message == "ChangePwdSuccess" ? "Your password has been changed."
                    : message == "SetPwdSuccess" ? "Your password has been set."
                    : String.Empty;
                //successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
            }
        }
    }

    
    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error);
        }
    }
}