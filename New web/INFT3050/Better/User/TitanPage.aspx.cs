using Better.Controllers;
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
        static string[,] defendersTitansArray = new string[10, 7];

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
                        usersTitansArray[0, 1] = CustomGlobal.GetLvl(Convert.ToInt32(titInfo.Exp));
                        // add stp
                        usersTitansArray[0, 2] = CustomGlobal.GetStp(Convert.ToInt32(usersTitansArray[0, 1]), Convert.ToInt32(titInfo.Exp));
                        // add remaining
                        usersTitansArray[0, 3] = CustomGlobal.GetRemaing(Convert.ToInt32(usersTitansArray[0, 1]), Convert.ToInt32(usersTitansArray[0, 2]), Convert.ToInt32(titInfo.Exp));
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
                        usersTitansArray[0, 11] = titInfo.Id.ToString();
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
                Label level = (Label)panel.FindControl("usersheroLevel1");
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
                            tCell.Text = CustomGlobal.CellFill("TitanPage", rowCtr);
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
                image.ImageUrl = CustomGlobal.TitanImage(CustomGlobal.viewtype.Front, element);
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
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());
            
            //DS Sample of how to implement database manager (remove for final website submission...)
            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");
            
            int titanCount = 0;
            //here
           
            foreach (AspNetUserTitan usrtitan in dbm.GetTitansToFight(user.Id))
            {
               
                if (titanCount < 10)
                {
                    AspNetTitan titaninfo = usrtitan.AspNetTitan;

                    int dLvl = Convert.ToInt32(CustomGlobal.GetLvl(Convert.ToInt32(titaninfo.Exp)));
                    int dStp = Convert.ToInt32(CustomGlobal.GetLvl(Convert.ToInt32(titaninfo.Exp)));

                    int aLvl = Convert.ToInt32(usersTitansArray[0, 1]);
                    int aStp = Convert.ToInt32(usersTitansArray[0, 2]);

                    bool add = false;

                    switch (aLvl)
                    {
                        case 1:
                            switch (aStp)
                            {
                                case 1:
                                    if(dLvl == 1 && dStp < 4)
                                    {
                                        add = true;
                                    }
                                    break;
                                case 2:
                                    if (dLvl == 1 && dStp < 5)
                                    {
                                        add = true;
                                    }
                                    break;
                                case 3:
                                    if ((dLvl == 1 && dStp > 1 )||(dLvl == 2 && dStp < 2))
                                    {
                                        add = true;
                                    }
                                    break;
                                case 4:
                                    if ((dLvl == 1 && dStp > 2) || (dLvl == 2 && dStp < 3))
                                    {
                                        add = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            switch (aStp)
                            {
                                case 1:
                                    if ((dLvl == 1 && dStp > 3) || (dLvl == 2 && dStp < 4))
                                    {
                                        add = true;
                                    }
                                    break;
                                case 2:
                                    if (dLvl == 2 && dStp < 5)
                                    {
                                        add = true;
                                    }
                                    break;
                                case 3:
                                    if ((dLvl == 2 && dStp > 1) || (dLvl == 3 && dStp < 2))
                                    {
                                        add = true;
                                    }
                                    break;
                                case 4:
                                    if ((dLvl == 2 && dStp > 2) || (dLvl == 3 && dStp < 3))
                                    {
                                        add = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 3:
                            switch (aStp)
                            {
                                case 1:
                                    if ((dLvl == 2 && dStp > 3) || (dLvl == 3 && dStp < 4))
                                    {
                                        add = true;
                                    }
                                    break;
                                case 2:
                                    if (dLvl == 3 && dStp < 5)
                                    {
                                        add = true;
                                    }
                                    break;
                                case 3:
                                    if ((dLvl == 3 && dStp > 1) || (dLvl == 4 && dStp < 2))
                                    {
                                        add = true;
                                    }
                                    break;
                                case 4:
                                    if ((dLvl == 3 && dStp > 2) || (dLvl == 4 && dStp < 3))
                                    {
                                        add = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case 4:
                            switch (aStp)
                            {
                                case 1:
                                    if ((dLvl == 3 && dStp > 3) || (dLvl == 4 && dStp < 4))
                                    {
                                        add = true;
                                    }
                                    break;
                                case 2:
                                    if (dLvl == 4 && dStp < 5)
                                    {
                                        add = true;
                                    }
                                    break;
                                case 3:
                                    if (dLvl == 4 && dStp > 1)
                                    {
                                        add = true;
                                    }
                                    break;
                                case 4:
                                    if (dLvl == 4 && dStp > 2)
                                    {
                                        add = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }

                    if (add)
                    {
                        // add element
                        defendersTitansArray[titanCount, 0] = titaninfo.Type;
                        // add name
                        defendersTitansArray[titanCount, 1] = titaninfo.TitanName;
                        //titans ID
                        defendersTitansArray[titanCount, 2] = titaninfo.Id.ToString();
                        // add total exp
                        defendersTitansArray[titanCount, 3] = titaninfo.Exp;
                        // add lvl
                        defendersTitansArray[titanCount, 4] = CustomGlobal.GetLvl(Convert.ToInt32(defendersTitansArray[titanCount, 3]));
                        // add stp
                        defendersTitansArray[titanCount, 5] = CustomGlobal.GetStp(Convert.ToInt32(defendersTitansArray[titanCount, 4]), Convert.ToInt32(defendersTitansArray[titanCount, 3]));
                        // add remaining
                        defendersTitansArray[titanCount, 6] = CustomGlobal.GetRemaing(Convert.ToInt32(defendersTitansArray[titanCount, 4]), Convert.ToInt32(defendersTitansArray[titanCount, 5]), Convert.ToInt32(defendersTitansArray[titanCount, 3]));
                        

                        titanCount++;
                    }

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

                    int element = Convert.ToInt32(defendersTitansArray[i - 1, 0]);
                    int expValue = Convert.ToInt32(defendersTitansArray[i - 1, 3]);

                    Label titanName = (Label)panel.FindControl("heroName" + i);
                    Label level = (Label)panel.FindControl("heroLevel" + i);
                    Label exp = (Label)panel.FindControl("heroExpText" + i);

                    //set name lvl exp 
                    if (titanName != null)
                    {
                        titanName.Text = defendersTitansArray[i-1, 1];
                    }
                    if (level != null)
                    {
                        level.Text = "LVL: " + defendersTitansArray[i - 1, 4] + " STP: " + Convert.ToInt32(defendersTitansArray[i - 1, 5]);
                    }
                    if (exp != null)
                    {
                        exp.Text = defendersTitansArray[i - 1, 6] + "%";
                    }

                    //set the exp bar width
                    Panel expPanel = (Panel)FindControlRecursive(Page, "HeroExp" + i);
                    if (expPanel != null)
                    {
                        expPanel.Width = Unit.Percentage(expValue);
                    }
                    //set the titans image
                    Image image = (Image)panel.FindControl("ImageButton" + i);
                    image.ImageUrl = CustomGlobal.TitanImage(CustomGlobal.viewtype.Front, element.ToString());
                }
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

                Response.Redirect("Fight?usersTitan="+ usersTitansArray[0, 11] + "&defendersTitan="+ defendersTitansArray[Convert.ToInt32(s)-1, 2]);
            }
        }

        protected void fsButton_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("FightHistory?usersTitan=" + usersTitansArray[0, 11]);
        }

        protected void delete_Command(object sender, CommandEventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());

            //DS Sample of how to implement database manager (remove for final website submission...)
            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");
            
            foreach (AspNetUserTitan tit in dbm.GetUserTitans(user.Id))
            {
                if (tit.Retired == false && tit.Deleted == false)
                {
                    if (tit.Id.ToString() == usersTitansArray[0, 11])
                    {
                        tit.Deleted = true;
                    }
                }
            }


            //update tables
            dbm.BetterDataContext.SubmitChanges();

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

                        var titan = dbm.Titaninfo(Convert.ToInt32(usersTitansArray[0, 11]));

                        Label epBalance = (Label)panel.FindControl("EPBalance");
                        Panel expPanel = (Panel)FindControlRecursive(Page, "HeroExp1");
                        Label level = (Label)panel.FindControl("usersheroLevel1");
                        Label exp = (Label)panel.FindControl("heroExpText1");


                        if ((value + titanExp) > 15000)
                        {
                            //retire hero
                            int maxValue = 15001 - titanExp;
                            bal -= maxValue;
                            titanExp += maxValue;
                            
                            titan.Retired = true;

                            foreach (AspNetUserTitan tit in dbm.GetUserTitans(user.Id))
                            {
                                if (tit.Retired == false && tit.Deleted == false)
                                {
                                    if (tit.Id == Convert.ToInt32(usersTitansArray[0, 11]))
                                    {
                                        tit.Retired = true;
                                    }
                                }
                            }
                        }
                        else
                        {                            
                            bal -= value;
                            titanExp += value;

                        }

                        titan.Exp = titanExp.ToString();
                        user.EPBalance = bal;
                        epBalance.Text = bal.ToString();

                        string lvl = CustomGlobal.GetLvl(Convert.ToInt32(titan.Exp));
                        string stp = CustomGlobal.GetStp(Convert.ToInt32(lvl), Convert.ToInt32(titan.Exp));
                        string remain = CustomGlobal.GetRemaing(Convert.ToInt32(lvl), Convert.ToInt32(stp), Convert.ToInt32(titan.Exp));

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