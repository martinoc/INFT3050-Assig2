﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Better.Controllers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Better.User
{
    public partial class Fight : Page
    {
        Random rand = new Random();
        int usertitan;
        int defendertitan;
        int result;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["usersTitan"] == null)
            {
                Response.Redirect("UserProfile");
            }
            else if (Request.QueryString["defendersTitan"] == null)
            {
                backToTitanPage();
            }

            usertitan = Convert.ToInt32(Request.QueryString["usersTitan"]);
            defendertitan = Convert.ToInt32(Request.QueryString["defendersTitan"]);

            

            fillHall(2);
        }

        //set two players up
        protected void fillHall(int numOfTitans)
        {
            for (int i = 1; i < 3; i++)
            {
                //find panel id
                Panel panel = (Panel)FindControlRecursive(Page, "Panel" + i);
                if (panel != null)
                {
                    panel.Visible = true;

                    Table table = (Table)panel.FindControl("Table" + i);
                    Label titanName = (Label)panel.FindControl("TitanName" + i); 

                    int element;
                    int fights;
                    int wins;
                    int losses;
                    string createdString;
                    string name;
                    int titanID;

                    if (i == 1)
                    {
                        titanID = usertitan;
                    }
                    else
                    {
                        titanID = defendertitan;
                    }
                    
                    DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");
                                       
                    var titInfo = dbm.Titaninfo(titanID.ToString());

                    element = Convert.ToInt32(titInfo.Type);
                    name = dbm.TitanUsersName(titanID.ToString(), Context);
                    wins = Convert.ToInt32(titInfo.Wins);
                    losses = Convert.ToInt32(titInfo.Losses);
                    fights = wins + losses + Convert.ToInt32(titInfo.Draws);
                    createdString = "Date";
                    titanName.Text = titInfo.TitanName;

                    Label titanLvl = (Label)panel.FindControl("heroLevel" + i);
                    Panel titanExp = (Panel)panel.FindControl("HeroExp" + i);
                    Label titanExpText = (Label)panel.FindControl("heroExpText" + i);

                    string lvl = CustomGlobal.GetLvl(Convert.ToInt32(titInfo.Exp));                    
                    string stp = CustomGlobal.GetStp(Convert.ToInt32(lvl), Convert.ToInt32(titInfo.Exp));                    
                    string remain = CustomGlobal.GetRemaing(Convert.ToInt32(lvl), Convert.ToInt32(stp), Convert.ToInt32(titInfo.Exp));

                    titanLvl.Text = "LVL: " + lvl +" STP: " + stp;

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
                                tCell.Text = CustomGlobal.CellFill("Fight", rowCtr);
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
                        image.ImageUrl = CustomGlobal.TitanImage(CustomGlobal.viewtype.Front, element.ToString());
                    }
                }
            }
        }

        protected void fightButton_Command(object sender, CommandEventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton != null)
            {
                if (Convert.ToInt32((clickedButton.ID).Remove(0, "Button".Length)) == 1)
                {
                    //insert fight creation here
                    whoWins();                
                    Response.Redirect("FightOutcome?usersTitan=" + usertitan + "&defendersTitan=" + defendertitan  + "&result=" +  result);
                }
                else
                {
                    backToTitanPage();
                }
            }
        }

        public void whoWins()
        {
            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");

            var utitInfo = dbm.Titaninfo(usertitan.ToString());
            var dtitInfo = dbm.Titaninfo(defendertitan.ToString());

            //player one temp stats
            double playerOneExp = Convert.ToInt32(utitInfo.Exp);
            int playerOneType = Convert.ToInt32(utitInfo.Type);
            //player two temp stats
            double playerTwoExp = Convert.ToInt32(dtitInfo.Exp);
            int playerTwoType = Convert.ToInt32(dtitInfo.Type);



            double playerOne = playerOneExp;
            double playerTwo = playerTwoExp;

            switch (ElementalBonus(playerOneType, playerTwoType))
            {
                case 1:
                    playerOne += playerOneExp * .15;
                    break;
                case 2:
                    playerTwo += playerTwoExp * .15;
                    break;
                default:
                    break;
            }

            //chalenger bonus
            playerOne += playerOneExp * .25;

            //random bonus
            switch (rand.Next(1, 3))
            {
                case 1:
                    playerOne += playerOneExp * .25;
                    break;
                case 2:
                    playerTwo += playerTwoExp * .25;
                    break;
                default:
                    break;
            }

            if (playerOne > playerTwo)
            {
                dbm.CreateFight(usertitan.ToString(), defendertitan.ToString(), true, false, false);
                result = 1;
                utitInfo.Wins = (Convert.ToInt32(utitInfo.Wins) + 1).ToString();
                dtitInfo.Wins = (Convert.ToInt32(dtitInfo.Losses) + 1).ToString();
            }
            else if (playerOne < playerTwo)
            {
                dbm.CreateFight(usertitan.ToString(), defendertitan.ToString(), false, true, false);
                result = 2;
                utitInfo.Wins = (Convert.ToInt32(utitInfo.Losses) + 1).ToString();
                dtitInfo.Wins = (Convert.ToInt32(dtitInfo.Wins) + 1).ToString();
            }
            else
            {
                dbm.CreateFight(usertitan.ToString(), defendertitan.ToString(), false, false, true);
                result = 3;
                utitInfo.Wins = (Convert.ToInt32(utitInfo.Draws) + 1).ToString();
                dtitInfo.Wins = (Convert.ToInt32(dtitInfo.Draws) + 1).ToString();
            }


            //update tables
            dbm.BetterDataContext.SubmitChanges();
        }

        protected int ElementalBonus(int playerOneElement, int playerTwoElement)
        {

            //returns who should get elemental bonus if possible
            //1 = air
            //2 = earth
            //3 = fire
            //4 = water

            if ((playerOneElement == 4 && playerTwoElement == 3) || (playerOneElement == 3 && playerTwoElement == 4))
            {
                if (playerOneElement == 4)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            if ((playerOneElement == 3 && playerTwoElement == 1) || (playerOneElement == 1 && playerTwoElement == 3))
            {
                if (playerOneElement == 3)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            if ((playerOneElement == 1 && playerTwoElement == 2) || (playerOneElement == 2 && playerTwoElement == 1))
            {
                if (playerOneElement == 1)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            if ((playerOneElement == 2 && playerTwoElement == 4) || (playerOneElement == 4 && playerTwoElement == 2))
            {
                if (playerOneElement == 2)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            return 3;
        }

        public void backToTitanPage()
        {
            int usersTitansCount = 0;
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(User.Identity.GetUserId());
            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");
            foreach (AspNetUserTitan tit in dbm.GetUserTitans(user.Id))
            {
                if (tit.Retired == false && tit.Deleted == false)
                {

                    usersTitansCount++;
                    if (tit.Id == Request.QueryString["usersTitan"])
                    {
                        Response.Redirect("TitanPage?usersTitan=" + usersTitansCount);
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