using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Better.User
{
    public partial class FightOutcome : Page
    {
        Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            fillHall(2);
            
        }

        //sets up the two heros
        protected void fillHall(int numOfTitans)
        {
            for (int i = 1; i < 3; i++)
            {
                Panel panel = (Panel)FindControlRecursive(Page, "Panel" + i);
                if (panel != null)
                {
                    panel.Visible = true;

                    Table table = (Table)panel.FindControl("Table" + i);

                    int element = rand.Next(1, 4);
                    int fights = rand.Next(100, 1000);
                    int wins = rand.Next(50, fights);
                    int losses = fights - wins;
                    string createdString = "";
                    string name = "";

                    if (i == 1)
                    {
                        name = "Your Name";
                    }
                    else
                    {
                        switch (rand.Next(1, 6))
                        {
                            case 3:
                                name = "FirstName LastName";
                                break;
                            case 4:
                                name = "John Doe";
                                break;
                            case 5:
                                name = "Martin O'Connor";
                                break;
                            default:
                                name = "Unknown";
                                break;
                        }
                    }

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
                            //left col
                            if (cellCtr == 1)
                            {
                                tCell.Text = CellFill(rowCtr);
                                tCell.Font.Size = 15;
                            }
                            else//right col
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

                                tCell.Font.Size = 12;
                            }
                            tRow.Cells.Add(tCell);
                        }
                    }

                    Image image = (Image)panel.FindControl("image" + i);
                    if (image != null)
                    {
                        image.ImageUrl = TitanImage(element);
                    }
                }

            }

        }

       

        protected void whoWins()
        {
            Panel panel = (Panel)FindControlRecursive(Page, "vs");
            if (panel != null)
            {
                Label winName = (Label)panel.FindControl("winName");
                Label winnerDir = (Label)panel.FindControl("winner");
                Label outcome = (Label)panel.FindControl("Wins");


                if (winName != null && winnerDir != null)
                {
                    //if (winner == 1)
                    //{
                    //    winName.Text = "TitanName1";
                    //    winnerDir.Text = "<<<<<<";
                    //    outcome.Text = "Wins";
                    //}
                    //else if (winner == 2)
                    //{
                    //    winName.Text = "TitanName2";
                    //    winnerDir.Text = ">>>>>>";
                    //    outcome.Text = "Wins";
                    //}
                    //else
                    //{
                    winName.Text = "       ";
                    winnerDir.Text = "       ";
                    outcome.Text = "Draw";
                    //}
                }
            }
        }

        protected void leaveButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("TitanPage");
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
                    return "Coach: ";
                default:
                    return "";
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