using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Better.User
{
    public partial class FightHistory : Page
    {
        Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            int NumOfHeros = rand.Next(1, 30);

            fillHall(NumOfHeros);
        }

        //setup last matches
        protected void fillHall(int numOfTitans)
        {
            for (int i = 1; i <= numOfTitans; i++)
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
                    int nameNum = rand.Next(1, 6);
                    int wl = rand.Next(1, 3);
                    string name = "";
                    string createdString = "";

                    //match result
                    Label result = (Label)panel.FindControl("FightResult" + i);
                    if (result != null)
                    {
                        if (wl == 1)
                        {
                            result.Text = "W";
                            result.BackColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            result.Text = "L";
                            result.BackColor = System.Drawing.Color.Red;
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
                            name = "";
                            break;
                    }

                    switch (nameNum)
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

                    for (int rowCtr = 1; rowCtr <= 5; rowCtr++)
                    {
                        // Create new row and add it to the table.
                        TableRow tRow = new TableRow();
                        table.Rows.Add(tRow);
                        for (int cellCtr = 1; cellCtr <= 2; cellCtr++)
                        {
                            // Create a new cell and add it to the row.
                            TableCell tCell = new TableCell();
                            //right col
                            if (cellCtr == 1)
                            {
                                tCell.Text = CellFill(rowCtr);
                            }
                            else//left col
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
                                        name = "";
                                        break;
                                }
                            }
                            tRow.Cells.Add(tCell);
                        }
                    }
                    Image image = (Image)panel.FindControl("image" + i);
                    image.ImageUrl = TitanImage(element);
                }
            }
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

        protected void fsButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("TitanPage");
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