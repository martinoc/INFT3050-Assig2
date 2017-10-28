using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Better.Views;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Better.Controllers;

namespace Better
{
    public partial class HallOfFame : Page
    {
        Random rand = new Random();
        static string[,] hofArray = new string[30, 6];

        protected void Page_Load(object sender, EventArgs e)
        {

            //DS Sample of how to implement database manager (remove for final website submission...)
            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            

            int hofCount = 0;
            foreach (AspNetTitan tit in dbm.GetRetiredHeros())
            {
                var titInfo = dbm.Titaninfo(tit.Id);


                // add date
                hofArray[hofCount, 0] = "Date";
                // add element
                hofArray[hofCount, 1] = titInfo.Type.ToString();
                // add total fights
                hofArray[hofCount, 2] = (Convert.ToInt32(titInfo.Wins) + Convert.ToInt32(titInfo.Losses) + Convert.ToInt32(titInfo.Draws)).ToString();
                // add wins
                hofArray[hofCount, 3] = titInfo.Wins;
                // add losses
                hofArray[hofCount, 4] = titInfo.Losses;
                // add name
                hofArray[hofCount, 5] = dbm.TitanUsersName(tit.Id, Context);
                hofCount++;
            }
            

            fillHall(hofCount);
        }

        //fill the Hall of Fame
        protected void fillHall(int numOfTitans)
        {
            for (int i = 1; i <= numOfTitans; i++)
            {
                Panel panel = (Panel)FindControlRecursive(Page, "Panel" + i);
                if (panel != null)
                {
                    panel.Visible = true;

                    Table table = (Table)panel.FindControl("Table" + i);

                    string createdString = hofArray[i - 1, 0];
                    string element = hofArray[i - 1, 1];
                    string fights = hofArray[i - 1, 3];
                    string wins = hofArray[i - 1, 3];
                    string losses = hofArray[i - 1, 4];
                    string name = hofArray[i - 1, 5];
                    
                    for (int rowCtr = 1; rowCtr <= 5; rowCtr++)
                    {
                        // Create new row and add it to the table.
                        TableRow tRow = new TableRow();
                        table.Rows.Add(tRow);
                        for (int cellCtr = 1; cellCtr <= 2; cellCtr++)
                        {
                            // Create a new cell and add it to the row.
                            TableCell tCell = new TableCell();
                            //left column
                            if (cellCtr == 1)
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
                    image.ImageUrl = TitanImage(Convert.ToInt32(element));
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