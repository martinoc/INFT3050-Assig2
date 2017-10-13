using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;

public partial class ExerciseForm : System.Web.UI.Page
{
    //userManager manager = new UserManager();


    protected void Page_Load()
    {
        //var user = manager.FindById(User.Identity.GetUserId());

        Panel panel = (Panel)FindControlRecursive(Page, "UserDetails");
        Label Name = (Label)panel.FindControl("Name");
        Label EPBalance = (Label)panel.FindControl("EPBalance");

        //Name.Text = user.FirstName + " " + user.LastName;
        //EPBalance.Text = user.EPBalance.ToString();
        
        Panel epAdded = (Panel)FindControlRecursive(Page, "epAdded");
        epAdded.Visible = false;
    }

    protected void Enter_Click(object sender, EventArgs e)
    {
        Panel panel = (Panel)FindControlRecursive(Page, "Panel1");
        TextBox distanceWalked = (TextBox)panel.FindControl("distanceWalked");
        TextBox distanceRan = (TextBox)panel.FindControl("distanceRan");
        TextBox pushUps = (TextBox)panel.FindControl("pushUps");
        TextBox sitUps = (TextBox)panel.FindControl("sitUps");
        TextBox ParentPin = (TextBox)panel.FindControl("ParentPin");

        //var user = manager.FindById(User.Identity.GetUserId());


        String errmsg = "";

        //check if all boxs have vaild inputs 
        if (distanceWalked.Text.All(Char.IsDigit) && distanceRan.Text.All(Char.IsDigit) && pushUps.Text.All(Char.IsDigit) && sitUps.Text.All(Char.IsDigit) && ParentPin.Text.All(Char.IsDigit))
        {
            if (ParentPin.Text.Equals("1234"))
            {
                Show();
            }
            else
            {
                errmsg = errmsg + "ParentPin is wrong";
            }
        }
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

    protected void Show()
    {
        Panel panel = (Panel)FindControlRecursive(Page, "Panel1");
        Panel epAdded = (Panel)FindControlRecursive(Page, "epAdded");

        TextBox ParentPin = (TextBox)panel.FindControl("ParentPin");
        Label newEP = (Label)FindControlRecursive(Page, "newEP");
        Label EPBalance = (Label)FindControlRecursive(Page, "EPBalance");

        //var user = manager.FindById(User.Identity.GetUserId());
        
        Random rand = new Random();

        int add = rand.Next(200, 800);
        //int oldInt = Convert.ToInt32(user.EPBalance);
        //int newInt = oldInt + add;
        
        //user.EPBalance = newInt;
        //manager.UpdateAsync(user);

        //EPBalance.Text = user.EPBalance.ToString();
        newEP.Text = add.ToString();
        epAdded.Visible = true;
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