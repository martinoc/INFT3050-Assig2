using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data;
using Better.Views;
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
                    usersTitansArray[usersTitansCount, 0] = GetLvl(Convert.ToInt32(titInfo.Exp));
                    // add stp
                    usersTitansArray[usersTitansCount, 1] = GetStp(Convert.ToInt32(usersTitansArray[usersTitansCount, 0]), Convert.ToInt32(titInfo.Exp));
                    // add remaining
                    usersTitansArray[usersTitansCount, 2] = GetRemaing(Convert.ToInt32(usersTitansArray[usersTitansCount, 0]), Convert.ToInt32(usersTitansArray[usersTitansCount, 1]), Convert.ToInt32(titInfo.Exp));
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
            //show add panel if less the 10 personal titans
            Panel addPanel = (Panel)FindControlRecursive(Page, "addHero1");
            if (numOfTitans < 10)
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
                    image.ImageUrl = TitanImage(element.ToString());
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
                                tCell.Text = CellFill(rowCtr);
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
                    image.ImageUrl = TitanImage(element);
                }
            }
        }

        protected String GetLvl(int i)
        {

            if(i < 1001)
            {
                return "1";
            }else if (i < 3001)
            {
                return "2";
            }
            else if (i < 6401)
            {
                return "3";
            }
            else if (i < 15001)
            {
                return "4";
            }
            else
            {
                return "Retired";
            }
        }

        protected String GetStp(int lvl, int i)
        {        
           
            if ( (lvl == 1 && i < 201) || (lvl == 2 && i < 1401) || (lvl == 3 && i < 3701) || (lvl == 4 && i < 7501))
            {
                return "1";
            }
            else if ((lvl == 1 && i < 426) || (lvl == 2 && i < 1901) || (lvl == 3 && i < 4501) || (lvl == 4 && i < 8701))
            {
                return "2";
            }
            else if ((lvl == 1 && i < 676) || (lvl == 2 && i < 2401) || (lvl == 3 && i < 5401) || (lvl == 4 && i < 10001)) 
            {
                return "3";
            }
            else if (i < 15001)
            {
                return "4";
            }
            else
            {
                return "Retired";
            }
        }

        protected String GetRemaing(int lvl, int stp, int i)
        {
            string result;
            double totalExp = i;

            switch (lvl)
            {
                case 1:
                    switch (stp)
                    {
                        case 1:
                            result = Convert.ToInt32((( totalExp - 0 ) / (200 - 0)) * 100 ).ToString();
                            break;
                        case 2:
                            result = Convert.ToInt32((( totalExp - 200) / (425 - 200)) * 100 ).ToString();
                            break;
                        case 3:
                            result = Convert.ToInt32((( totalExp - 425) / (675 - 425)) * 100 ).ToString();
                            break;
                        case 4:
                            result = Convert.ToInt32((( totalExp - 675) / (1000 - 675)) * 100 ).ToString();
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
                case 2:
                    switch (stp)
                    {
                        case 1:
                            result = Convert.ToInt32((( totalExp - 1000) / (1400 - 1000)) * 100 ).ToString();
                            break;
                        case 2:
                            result = Convert.ToInt32((( totalExp - 1400) / (1900 - 1400)) * 100 ).ToString();
                            break;
                        case 3:
                            result = Convert.ToInt32((( totalExp - 1900) / (2400 - 1900)) * 100 ).ToString();
                            break;
                        case 4:
                            result = Convert.ToInt32((( totalExp - 2400) / (3000 - 2400)) * 100 ).ToString();
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
                case 3:
                    switch (stp)
                    {
                        case 1:
                            result = Convert.ToInt32((( totalExp - 3000) / (3700 - 3000)) * 100 ).ToString();
                            break;
                        case 2:
                            result = Convert.ToInt32((( totalExp - 3700) / (4500 - 3700)) * 100 ).ToString();
                            break;
                        case 3:
                            result = Convert.ToInt32((( totalExp - 4500) / (5400 - 4500)) * 100 ).ToString();
                            break;
                        case 4:
                            result = Convert.ToInt32((( totalExp - 5400) / (6400 - 5400)) * 100 ).ToString();
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
                case 4:
                    switch (stp)
                    {
                        case 1:
                            result = Convert.ToInt32((( totalExp - 6400) / (7500 - 6400)) * 100 ).ToString();
                            break;
                        case 2:
                            result = Convert.ToInt32((( totalExp - 7500) / (8700 - 7500)) * 100 ).ToString();
                            break;
                        case 3:
                            result = Convert.ToInt32((( totalExp - 8700) / (10000 - 8700)) * 100 ).ToString();
                            break;
                        case 4:
                            result = Convert.ToInt32((( totalExp - 10000) / (11500 - 10000)) * 100 ).ToString();
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }

        private String TitanImage(string i)
        {
            switch (Convert.ToInt32(i))
            {
                case 1:
                    return "../Images/Air_Elemental_titans_front.png";
                case 2:
                    return "../Images/Earth_Elemental_titans_front.png";
                case 3:
                    return "../Images/Fire_Elemental_titans_front.png";
                case 4:
                    return "../Images/Water_Elemental_titans_front.png";
                default:
                    return "";
            }
        }

        private String CellFill(int i)
        {
            switch (i)
            {
                case 1:
                    return "Created: ";
                case 2:
                    return "Fights: ";
                case 3:
                    return "Wins: ";
                case 4:
                    return "Losses: ";
                case 5:
                    return "Name: ";
                default:
                    return "";
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