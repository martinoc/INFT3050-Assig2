using Better.Controllers;
using Better.Views;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Better.User
{
    public partial class TitanPage : Page
    {
        static string[,] usersTitansArray = new string[1, 12];
        Random rand = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["usersTitan"] == null)
            {

                Response.Redirect("UserProfile");
            }

            int titan = Convert.ToInt32(Request.QueryString["usersTitan"]);


            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            //DS Sample of how to implement database manager (remove for final website submission...)
            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");

            int count = 1;
            foreach (AspNetUserTitan tit in dbm.GetUserTitans(user.Id))
            {
                if (tit.Retired == false && tit.Deleted == false)
                {
                    if (count == titan)
                    {
                        var titInfo = dbm.Titaninfo(tit.TitanID);

                        // add date
                        usersTitansArray[0, 0] = "DATE";
                        // add lvl
                        usersTitansArray[0, 1] = GetLvl(Convert.ToInt32(titInfo.Exp));
                        // add stp
                        usersTitansArray[0, 2] = GetStp(Convert.ToInt32(usersTitansArray[0, 1]), Convert.ToInt32(titInfo.Exp));
                        // add remaining
                        usersTitansArray[0, 3] = GetRemaing(Convert.ToInt32(usersTitansArray[0, 1]), Convert.ToInt32(usersTitansArray[0, 2]), Convert.ToInt32(titInfo.Exp));
                        // add element
                        usersTitansArray[0, 4] = titInfo.Type;
                        // add name
                        usersTitansArray[0, 5] = titInfo.TitanName;
                        // add wins
                        usersTitansArray[0, 6] = titInfo.Wins;
                        // add losses
                        usersTitansArray[0, 7] = titInfo.Losses;
                        // add draws
                        usersTitansArray[0, 8] = titInfo.Draws;
                        // add epBalance
                        usersTitansArray[0, 9] = user.EPBalance.ToString();
                        // titans totalEp
                        usersTitansArray[0, 10] = titInfo.Exp;
                        //titans ID
                        usersTitansArray[0, 11] = tit.TitanID;
                    }
                    count++;
                }
            }

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
                Label titanName = (Label)panel.FindControl("TitanName");
                Label level = (Label)panel.FindControl("heroLevel1");
                Label exp = (Label)panel.FindControl("heroExpText1");
                Label epBalance = (Label)panel.FindControl("EPBalance");
                Panel expPanel = (Panel)FindControlRecursive(Page, "HeroExp1");



                string createdString = usersTitansArray[0, 0];
                level.Text = "LVL: " + usersTitansArray[0, 1] + " STP: " + usersTitansArray[0, 2];
                expPanel.Width = Unit.Percentage(Convert.ToInt32(usersTitansArray[0, 3]));
                exp.Text = usersTitansArray[0, 3] + "%";
                string element = usersTitansArray[0, 4];
                titanName.Text = usersTitansArray[0, 5];
                int wins = Convert.ToInt32(usersTitansArray[0, 6]);
                int losses = Convert.ToInt32(usersTitansArray[0, 7]);
                int draws = Convert.ToInt32(usersTitansArray[0, 8]);
                epBalance.Text = usersTitansArray[0, 9];

                
                int fights = draws+wins+losses;

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
                                    tCell.Text = draws.ToString();
                                    tCell.ForeColor = System.Drawing.Color.Blue;
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
                image.ImageUrl = TitanImage(Convert.ToInt32(element));
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

        protected String GetLvl(int i)
        {

            if (i < 1001)
            {
                return "1";
            }
            else if (i < 3001)
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

            if ((lvl == 1 && i < 201) || (lvl == 2 && i < 1401) || (lvl == 3 && i < 3701) || (lvl == 4 && i < 7501))
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
                            result = Convert.ToInt32(((totalExp - 0) / (200 - 0)) * 100).ToString();
                            break;
                        case 2:
                            result = Convert.ToInt32(((totalExp - 200) / (425 - 200)) * 100).ToString();
                            break;
                        case 3:
                            result = Convert.ToInt32(((totalExp - 425) / (675 - 425)) * 100).ToString();
                            break;
                        case 4:
                            result = Convert.ToInt32(((totalExp - 675) / (1000 - 675)) * 100).ToString();
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
                            result = Convert.ToInt32(((totalExp - 1000) / (1400 - 1000)) * 100).ToString();
                            break;
                        case 2:
                            result = Convert.ToInt32(((totalExp - 1400) / (1900 - 1400)) * 100).ToString();
                            break;
                        case 3:
                            result = Convert.ToInt32(((totalExp - 1900) / (2400 - 1900)) * 100).ToString();
                            break;
                        case 4:
                            result = Convert.ToInt32(((totalExp - 2400) / (3000 - 2400)) * 100).ToString();
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
                            result = Convert.ToInt32(((totalExp - 3000) / (3700 - 3000)) * 100).ToString();
                            break;
                        case 2:
                            result = Convert.ToInt32(((totalExp - 3700) / (4500 - 3700)) * 100).ToString();
                            break;
                        case 3:
                            result = Convert.ToInt32(((totalExp - 4500) / (5400 - 4500)) * 100).ToString();
                            break;
                        case 4:
                            result = Convert.ToInt32(((totalExp - 5400) / (6400 - 5400)) * 100).ToString();
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
                            result = Convert.ToInt32(((totalExp - 6400) / (7500 - 6400)) * 100).ToString();
                            break;
                        case 2:
                            result = Convert.ToInt32(((totalExp - 7500) / (8700 - 7500)) * 100).ToString();
                            break;
                        case 3:
                            result = Convert.ToInt32(((totalExp - 8700) / (10000 - 8700)) * 100).ToString();
                            break;
                        case 4:
                            result = Convert.ToInt32(((totalExp - 10000) / (11500 - 10000)) * 100).ToString();
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
                    return "Draws: ";
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

        protected void delete_Command(object sender, CommandEventArgs e)
        {

            Response.Redirect("UserProfile");

        }


        protected void EPButton_Command(object sender, CommandEventArgs e)
        {
            Panel panel = (Panel)FindControlRecursive(Page, "Panel1");
            TextBox input = (TextBox)panel.FindControl("EP");
            Label balance = (Label)panel.FindControl("EPBalance");
            

            if (panel != null)
            {
                if (input != null)
                {
                    int value = Convert.ToInt32(input.Text);
                    int bal = Convert.ToInt32(balance.Text);
                    int titanExp = Convert.ToInt32(usersTitansArray[0, 10]);

                    if (bal >= value && value > 0)
                    {
                        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        var user = manager.FindById(User.Identity.GetUserId());

                        //DS Sample of how to implement database manager (remove for final website submission...)
                        DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");

                        var titan = dbm.Titaninfo(usersTitansArray[0, 11]);

                        Label epBalance = (Label)panel.FindControl("EPBalance");
                        Panel expPanel = (Panel)FindControlRecursive(Page, "HeroExp1");
                        Label level = (Label)panel.FindControl("heroLevel1");
                        Label exp = (Label)panel.FindControl("heroExpText1");


                        if ((value + titanExp) > 15000)
                        {
                            //retire hero
                            int maxValue = 15001 - titanExp;
                            bal -= maxValue;
                            titanExp += maxValue;
                            
                            titan.Retired = true;
                        }
                        else
                        {                            
                            bal -= value;
                            titanExp += value;

                        }

                        titan.Exp = titanExp.ToString();
                        user.EPBalance = bal;
                        epBalance.Text = bal.ToString();

                        string lvl = GetLvl(Convert.ToInt32(titan.Exp));
                        string stp = GetStp(Convert.ToInt32(lvl), Convert.ToInt32(titan.Exp));
                        string remain = GetRemaing(Convert.ToInt32(lvl), Convert.ToInt32(stp), Convert.ToInt32(titan.Exp));

                        level.Text = "LVL: " + lvl + " STP: " + stp;
                        expPanel.Width = Unit.Percentage(Convert.ToInt32(remain));
                        exp.Text = remain + "%";

                        //update tables
                        dbm.BetterDataContext.SubmitChanges();
                        manager.Update(user);
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
}