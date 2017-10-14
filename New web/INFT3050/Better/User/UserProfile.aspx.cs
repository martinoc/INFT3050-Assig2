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
    public partial class UserProfile : Page
    {
        Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            Panel panel = (Panel)FindControlRecursive(Page, "UserDetails");
            Label Name = (Label)panel.FindControl("Name");
            Label UserEmail = (Label)panel.FindControl("UserEmail");
            Label EPBalance = (Label)panel.FindControl("EPBalance");
            
            Name.Text = user.FirstName + " " + user.LastName;
            UserEmail.Text = user.UserName;
            EPBalance.Text = user.EPBalance.ToString();

            int NumOfTitans = rand.Next(1, 5);
            int NumOfHohs = rand.Next(1, 20);

            fillTitans(NumOfTitans);
            fillHall(NumOfHohs);
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

                    int element = rand.Next(1, 4);
                    int expValue = rand.Next(1, 100);

                    Label titanName = (Label)panel.FindControl("heroName" + i);
                    Label level = (Label)panel.FindControl("heroLevel" + i);
                    Label exp = (Label)panel.FindControl("heroExpText" + i);

                    if (titanName != null)
                    {
                        titanName.Text = setName(i);
                    }
                    if (level != null)
                    {
                        level.Text = "L:" + rand.Next(1, 3) + " S:" + rand.Next(1, 4); ;
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
                    image.ImageUrl = TitanImage(element);
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

                    int element = rand.Next(1, 4);
                    int fights = rand.Next(100, 1000);
                    int wins = rand.Next(50, fights);
                    int losses = fights - wins;
                    string name = setName(rand.Next(1, 11));
                    string createdString = "";


                    //set date
                    switch (element)
                    {
                        case 1:
                            createdString = "19/12/16";
                            break;
                        case 2:
                            createdString = "05/07/17";
                            break;
                        case 3:
                            createdString = "11/11/11";
                            break;
                        case 4:
                            createdString = "14/12/14";
                            break;
                        default:
                            createdString = "";
                            break;
                    }

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
                                        tCell.Text = fights.ToString();
                                        break;
                                    case 3:
                                        tCell.Text = wins.ToString();
                                        tCell.ForeColor = System.Drawing.Color.Green;
                                        break;
                                    case 4:
                                        tCell.Text = losses.ToString();
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



        protected String setName(int nameNum)
        {
            string name = "";

            switch (nameNum)
            {
                case 1:
                    name = "dude";
                    break;
                case 2:
                    name = "titan";
                    break;
                case 3:
                    name = "killer";
                    break;
                case 4:
                    name = "trump";
                    break;
                case 5:
                    name = "hillary";
                    break;
                case 6:
                    name = "gary";
                    break;
                case 7:
                    name = "steve";
                    break;
                case 8:
                    name = "forest";
                    break;
                case 9:
                    name = "lumpy";
                    break;
                case 10:
                    name = "bumpy";
                    break;
                default:
                    name = "";
                    break;
            }
            return name;
        }


        private String TitanImage(int i)
        {
            switch (i)
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

                Response.Redirect("TitanPage");
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