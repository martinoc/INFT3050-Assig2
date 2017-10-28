using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data;
using Better.Controllers;

namespace Better.User
{
    public partial class UserProfile : Page
    {
        Random rand = new Random();

        static string[,] hohArray = new string[20, 6];
        static string[,] usersTitansArray = new string[4, 5];
             
        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            var role = Context.GetOwinContext().Get<AspNetRoleManager>();
            var Roles = role.FindById(User.Identity.GetUserId());

            Panel panel = (Panel)FindControlRecursive(Page, "UserDetails");
            Label Name = (Label)panel.FindControl("Name");
            Label UserEmail = (Label)panel.FindControl("UserEmail");
            Label EPBalance = (Label)panel.FindControl("EPBalance");

            //DS Sample of how to implement database manager (remove for final website submission...)
            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");


            int hohCount = 0;
            foreach (AspNetUserTitan tit in dbm.GetUserTitans(user.Id))
            {
                if (tit.Retired == true)
                {
                    var titInfo = dbm.Titaninfo(tit.TitanID);
                    
                    // add date
                    hohArray[hohCount, 0] = "Date";
                    // add element
                    hohArray[hohCount, 1] = titInfo.Type.ToString();
                    // add total fights
                    hohArray[hohCount, 2] = (Convert.ToInt32(titInfo.Wins) + Convert.ToInt32(titInfo.Losses) + Convert.ToInt32(titInfo.Draws)).ToString();
                    // add wins
                    hohArray[hohCount, 3] = titInfo.Wins;
                    // add losses
                    hohArray[hohCount, 4] = titInfo.Losses;
                    // add name
                    hohArray[hohCount, 5] = titInfo.TitanName;
                    hohCount++;
                }
            }
            int usersTitansCount = 0;
            foreach (AspNetUserTitan tit in dbm.GetUserTitans(user.Id))
            {
                if (tit.Retired == false && tit.Deleted == false)
                {
                    var titInfo = dbm.Titaninfo(tit.TitanID);

                    // add lvl
                    usersTitansArray[usersTitansCount, 0] = CustomGlobal.GetLvl(Convert.ToInt32(titInfo.Exp));
                    // add stp
                    usersTitansArray[usersTitansCount, 1] = CustomGlobal.GetStp(Convert.ToInt32(usersTitansArray[usersTitansCount, 0]), Convert.ToInt32(titInfo.Exp));
                    // add remaining
                    usersTitansArray[usersTitansCount, 2] = CustomGlobal.GetRemaing(Convert.ToInt32(usersTitansArray[usersTitansCount, 0]), Convert.ToInt32(usersTitansArray[usersTitansCount, 1]), Convert.ToInt32(titInfo.Exp));
                    // add element
                    usersTitansArray[usersTitansCount, 3] = titInfo.Type.ToString();
                    // add name
                    usersTitansArray[usersTitansCount, 4] = titInfo.TitanName;
                    usersTitansCount++;

                }
            }


            Name.Text = user.FirstName + " " + user.LastName;

            UserEmail.Text = user.UserName;
            EPBalance.Text = user.EPBalance.ToString();
            

            fillTitans(usersTitansCount);
            fillHall(hohCount);
        }

        //Setup The personal Titans
        protected void fillTitans(int numOfTitans)
        {
            //show add panel if less the 4 personal titans
            Panel addPanel = (Panel)FindControlRecursive(Page, "addHero1");
            if (numOfTitans < 4)
            {
                if (addPanel != null)
                {
                    addPanel.Visible = true;
                }
            }
            else
            {
                if (addPanel != null)
                {
                    addPanel.Visible = false;
                }
            }

            //hide all
            for (int i = 1; i <= 10; i++)
            {
                Panel panel = (Panel)FindControlRecursive(Page, "hero" + i);
                if (panel != null)
                {
                    panel.Visible = false;
                }
            }

            //show
            for (int i = 1; i <= numOfTitans; i++)
            {
                Panel panel = (Panel)FindControlRecursive(Page, "hero" + i);
                if (panel != null)
                {
                    panel.Visible = true;

                    Table table = (Table)panel.FindControl("Table" + i);

                    int element = Convert.ToInt32(usersTitansArray[i - 1, 3]);
                    int expValue = Convert.ToInt32(usersTitansArray[i - 1, 2]);

                    Label titanName = (Label)panel.FindControl("heroName" + i);
                    Label level = (Label)panel.FindControl("heroLevel" + i);
                    Label exp = (Label)panel.FindControl("heroExpText" + i);

                    if (titanName != null)
                    {
                        titanName.Text = usersTitansArray[i-1, 4];
                    }
                    if (level != null)
                    {
                        level.Text = "L:" + usersTitansArray[i - 1, 0] + " S:" + usersTitansArray[i - 1, 1];
                    }
                    if (exp != null)
                    {
                        exp.Text = expValue + "%";
                    }


                    Panel expPanel = (Panel)FindControlRecursive(Page, "HeroExp" + i);
                    if (expPanel != null)
                    {
                        expPanel.Width = Unit.Percentage(expValue);
                    }


                    Image image = (Image)panel.FindControl("ImageButton" + i);
                    image.ImageUrl = CustomGlobal.TitanImage(CustomGlobal.viewtype.Front, element.ToString());
                }


            }

        }


        //Setup The personal Hall of Heros
        protected void fillHall(int numOfTitans)
        {
            for (int i = 1; i <= numOfTitans; i++)
            {
                //find panel id
                Panel panel = (Panel)FindControlRecursive(Page, "Panel" + i);
                if (panel != null)
                {
                    panel.Visible = true;

                    Table table = (Table)panel.FindControl("Table" + i);

                    string createdString = hohArray[i-1, 0];
                    string element = hohArray[i-1, 1];
                    string fights = hohArray[i-1, 3];
                    string wins = hohArray[i-1, 3];
                    string losses = hohArray[i-1, 4];
                    string name = hohArray[i-1, 5];
                    


                    for (int rowCtr = 1; rowCtr <= 5; rowCtr++)
                    {
                        // Create new row and add it to the table.
                        TableRow tRow = new TableRow();
                        table.Rows.Add(tRow);
                        for (int cellCtr = 1; cellCtr <= 2; cellCtr++)
                        {
                            // Create a new cell and add it to the row.
                            TableCell tCell = new TableCell();

                            if (cellCtr == 1)//left column
                            {
                                tCell.Text = CustomGlobal.CellFill("UserProfile", rowCtr);
                            }
                            else//right column
                            {
                                switch (rowCtr)
                                {
                                    case 1:
                                        tCell.Text = createdString;
                                        break;
                                    case 2:
                                        tCell.Text = fights;
                                        break;
                                    case 3:
                                        tCell.Text = wins;
                                        tCell.ForeColor = System.Drawing.Color.Green;
                                        break;
                                    case 4:
                                        tCell.Text = losses;
                                        tCell.ForeColor = System.Drawing.Color.Red;
                                        break;
                                    case 5:
                                        tCell.Text = name;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            tRow.Cells.Add(tCell);
                        }
                    }
                    //titan image
                    Image image = (Image)panel.FindControl("image" + i);
                    image.ImageUrl = CustomGlobal.TitanImage(CustomGlobal.viewtype.Front, element);
                }
            }
        }

        

        protected void Button_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ExerciseForm");
        }

        protected void ImageButton_Command(object sender, EventArgs e)
        {
            String s = ((ImageButton)sender).ID;
            string str = "ImageButton";
            string add = "AddButton";

            if (s.Contains(str))
            {
                s = s.Remove(0, str.Length);

                Response.Redirect("TitanPage?usersTitan="+s);
            }
            else
            {
                s = s.Remove(0, add.Length);

                Response.Redirect("CharacterCreation");
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