using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TitanPage : System.Web.UI.Page
{
    Random rand = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        fillTitans();
        fillHall(1);
    }


    //setup the Titan
    protected void fillHall(int numOfTitans)
    {
        //find panel id
        Panel panel = (Panel)FindControlRecursive(Page, "Panel1");
        if (panel != null)
        {
            panel.Visible = true;

            Table table = (Table)panel.FindControl("Table1");

            int element = rand.Next(1, 4);
            int fights = rand.Next(100, 1000);
            int expLeft = rand.Next(900, 10000);
            int wins = rand.Next(50, fights);
            int losses = fights - wins;
            string createdString = "";

            //set elementString
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

            //fill all rows and columns
            for (int rowCtr = 1; rowCtr <= 5; rowCtr++)
            {
                // Create new row and add it to the table.
                TableRow tRow = new TableRow();
                table.Rows.Add(tRow);

                for (int cellCtr = 1; cellCtr <= 2; cellCtr++)
                {
                    // Create a new cell and add it to the row.
                    TableCell tCell = new TableCell();

                    //if it is left column
                    if (cellCtr == 1)
                    {
                        tCell.Text = CellFill(rowCtr);
                        tCell.Font.Size = 15;
                    }
                    else//it is right column
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
                                tCell.Text = expLeft.ToString();
                                tCell.ForeColor = System.Drawing.Color.Blue;
                                tCell.ID = "EPleft";
                                break;
                            default:
                                break;
                        }

                        tCell.Font.Size = 12;
                    }
                    tRow.Cells.Add(tCell);
                }
            }
            // set titan image
            Image image = (Image)panel.FindControl("image1");
            image.ImageUrl = TitanImage(element);
        }
    }

    //setup of chalangers
    protected void fillTitans()
    {

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
        for (int i = 1; i <= 10; i++)
        {
            //find panel id
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

                //set name lvl exp 
                if (titanName != null)
                {
                    titanName.Text = setName(i);
                }
                if (level != null)
                {
                    level.Text = "LVL: " + rand.Next(1, 3);
                }
                if (exp != null)
                {
                    exp.Text = expValue + "%";
                }

                //set the exp bar width
                Panel expPanel = (Panel)FindControlRecursive(Page, "HeroExp" + i);
                if (expPanel != null)
                {
                    expPanel.Width = Unit.Percentage(expValue);
                }
                //set the titans image
                Image image = (Image)panel.FindControl("ImageButton" + i);
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
                return "Ep Till LvlUp: ";
            default:
                return "";
        }
    }

    protected void ImageButton_Command(object sender, EventArgs e)
    {
        //get image number
        String s = ((ImageButton)sender).ID;
        string str = "ImageButton";

        if (s.Contains(str))
        {
            s = s.Remove(0, str.Length);

            Response.Redirect("Fight");
        }
    }

    protected void fsButton_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("FightHistory");
    }

    protected void EPButton_Command(object sender, CommandEventArgs e)
    {
        Panel panel = (Panel)FindControlRecursive(Page, "Panel1");
        TextBox input = (TextBox)panel.FindControl("EP");
        Label balance = (Label)panel.FindControl("EPBalance");
        TableCell tCell = (TableCell)panel.FindControl("EPleft");

        if (panel != null)
        {
            if (input != null)
            {
                int value = Convert.ToInt32(input.Text);
                int bal = Convert.ToInt32(balance.Text);

                if (bal > value)
                {
                    if (tCell != null)
                    {
                        int newLeft = Convert.ToInt32(tCell.Text) - value;
                        if (newLeft < 0)
                        {
                            Label level = (Label)panel.FindControl("heroLevel1");
                            string s = level.Text;
                            s = s.Remove(0, "LVL: ".Length);
                            //update level
                            level.Text = (Convert.ToInt32(s) + 1).ToString();

                            newLeft = rand.Next(10000, 1000000) - newLeft;

                        }
                        //update left till level up
                        tCell.Text = (newLeft).ToString();
                    }
                    // update balance
                    balance.Text = (bal - value).ToString(); ;
                }
            }
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