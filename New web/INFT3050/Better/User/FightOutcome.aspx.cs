using Better.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        int usertitan;
        int defendertitan;
        int result;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Arguments of the event</param>
        protected void Page_Load(object sender, EventArgs e)
        {

            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection"); 
            //Checks to see if user has Titans. If not, user is taken back to profile
            if (Request.QueryString["usersTitan"] == null)
            {
                Response.Redirect("UserProfile");
            }
            else if (Request.QueryString["defendersTitan"] == null)
            {
                int usersTitansCount = 0;
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindById(User.Identity.GetUserId());

                //checks Titans details whether they are retired or not after outcome
                foreach (AspNetUserTitan tit in dbm.GetUserTitans(user.Id))
                {
                    if (tit.Retired == false && tit.Deleted == false)
                    {
                        //Redirects to active Titan page
                        usersTitansCount++;
                        if (tit.Id == Convert.ToInt32(Request.QueryString["usersTitan"]))
                        {
                            Response.Redirect("TitanPage?usersTitan=" + usersTitansCount);
                        }
                    }
                }
            }else if(Request.QueryString["result"] == null)
            {
                //Takes to fight Titan
                Response.Redirect("Fight?usersTitan=" + usertitan + "&defendersTitan=" + defendertitan);

            }
            //declares Titans
            usertitan = Convert.ToInt32(Request.QueryString["usersTitan"]);
            defendertitan = Convert.ToInt32(Request.QueryString["defendersTitan"]);
            result = Convert.ToInt32(Request.QueryString["result"]);

            Panel panel = (Panel)FindControlRecursive(Page, "Panel3");
            Button button = (Button)panel.FindControl("Button2");


            var titInfo = dbm.Titaninfo(usertitan);


            button.Text = titInfo.TitanName+" Titan Page";



            whoWins();


            fillHall(2);
        }

        /// <summary>
        /// Outcome of the fight between two players
        /// </summary>
        /// <param name="numOfTitans">Number of available titans</param>
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

                    var titInfo = dbm.Titaninfo(titanID);
                    //Shows Titan details and adds post fight experience
                    element = Convert.ToInt32(titInfo.Type);
                    name = dbm.TitanUsersName(titanID, Context);
                    wins = Convert.ToInt32(titInfo.Wins);
                    losses = Convert.ToInt32(titInfo.Losses);
                    fights = wins + losses + Convert.ToInt32(titInfo.Draws);
                    createdString = titInfo.CreatedDate.Value.ToShortDateString();
                    titanName.Text = titInfo.TitanName;

                    Label titanLvl = (Label)panel.FindControl("heroLevel" + i);
                    Panel titanExp = (Panel)panel.FindControl("HeroExp" + i);
                    Label titanExpText = (Label)panel.FindControl("heroExpText" + i);

                    string lvl = CustomGlobal.GetLvl(Convert.ToInt32(titInfo.Exp));
                    string stp = CustomGlobal.GetStp(Convert.ToInt32(lvl), Convert.ToInt32(titInfo.Exp));
                    string remain = CustomGlobal.GetRemaing(Convert.ToInt32(lvl), Convert.ToInt32(stp), Convert.ToInt32(titInfo.Exp));

                    titanLvl.Text = "LVL: " + lvl + " STP: " + stp;

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

        /// <summary>
        /// Checks to see which Titan will win
        /// </summary>
        protected void whoWins()
        {
            Panel panel = (Panel)FindControlRecursive(Page, "vs");
            if (panel != null)
            {
                Label winName = (Label)panel.FindControl("winName");
                Label winnerDir = (Label)panel.FindControl("winner");
                Label outcome = (Label)panel.FindControl("Wins");

                DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");

                var utitInfo = dbm.Titaninfo(usertitan);
                var dtitInfo = dbm.Titaninfo(defendertitan);

                if (winName != null && winnerDir != null)
                {
                    if (result == 1)
                    {
                        //User Titan wins
                        winName.Text = utitInfo.TitanName;
                        winnerDir.Text = "<<<<<<<<";
                        outcome.Text = "Wins";
                    }
                    else if (result == 2)
                    {
                        //defender Titan wins
                        winName.Text = dtitInfo.TitanName;
                        winnerDir.Text = ">>>>>>>>";
                        outcome.Text = "Wins";
                    }
                    else
                    {
                        //Draw
                        winName.Text = "       ";
                        winnerDir.Text = "       ";
                        outcome.Text = "Draw";
                    }
                }
            }
        }
        /// <summary>
        /// Returns to Titan page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Arguments of the event</param>
        protected void leaveButton_Command(object sender, CommandEventArgs e)
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
                    if (tit.Id == Convert.ToInt32(Request.QueryString["usersTitan"]))
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