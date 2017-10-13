using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.UI;
using Microsoft.Owin;
using System.Web.UI.WebControls;

public partial class Account_Login : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
        
     protected void forgotLink_Click(object sender, EventArgs e)
    {
        // no Database so override
        bool aUser = false;

        TextBox email  = (TextBox)FindControlRecursive(Page, "Email");

        if (email.Text != null)
        {
            if(email.Text.Contains("@") && email.Text.Contains(".com"))
            {
                aUser = true;
            }
            
        }

        if (!aUser)
        {
        }

    }

    protected void LogIn(object sender, EventArgs e)
    {
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