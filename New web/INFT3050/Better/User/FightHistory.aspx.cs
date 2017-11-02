using Better.Controllers;
using Microsoft.AspNet.Identity.Owin;
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
        static string[,] hofArray = new string[30, 5];

        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks to see if user has Titans otherwise redirects to user profile
            if (Request.QueryString["usersTitan"] == null)
            {

                Response.Redirect("UserProfile");
            }

            DatabaseManager dbm = new DatabaseManager("Web", "DefaultConnection");
            Panel panel = (Panel)FindControlRecursive(Page, "PanelButton");
            Button button = (Button)panel.FindControl("Button1");


            var titname = dbm.Titaninfo(Convert.ToInt32(Request.QueryString["usersTitan"]));

            //Name of Titan 
            button.Text = titname.TitanName + " Titan Page";

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            //Shows the record of a Titan as both defender and attacker
            int hofCount = 0;
            foreach (AspNetUserTitanFight fight in dbm.GetTitansFightHistory(Convert.ToInt32(Request.QueryString["usersTitan"])))
            {
                int result=0;
                int nonusertitanID;
                if (fight.AttackerTitanID == Convert.ToInt32(Request.QueryString["usersTitan"]))
                {
                    //Shows record of the titan defending
                    nonusertitanID = fight.DefenderTitanID;
                    if (fight.Win.ToString()=="True") { result = 1; }
                    else if (fight.Loss.ToString() == "True") { result = 2; }
                    else if (fight.Draw.ToString() == "True") { result = 3; }

                }
                else
                {
                    //Shows record of the titan attacking
                    nonusertitanID = fight.AttackerTitanID;
                    if (fight.Win.ToString() == "True") { result = 2; }
                    else if (fight.Loss.ToString() == "True") { result = 1; }
                    else if (fight.Draw.ToString() == "True") { result = 3; }
                }
                var titInfo = dbm.Titaninfo(nonusertitanID);


                // add date
                hofArray[hofCount, 0] = fight.CreatedDate.Value.ToShortDateString();
                // add element
                hofArray[hofCount, 1] = titInfo.Type.ToString();
                // add name
                hofArray[hofCount, 2] = titInfo.TitanName;
                // add coach name
                hofArray[hofCount, 3] = dbm.TitanUsersName(nonusertitanID, Context);
                // add result
                hofArray[hofCount, 4] = result.ToString();

                hofCount++;
            }


            fillHall(hofCount);
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

                    string element = hofArray[i - 1, 1]; 
                    string name = hofArray[i - 1, 2];
                    string coach = hofArray[i - 1, 3];
                    string createdString = hofArray[i - 1, 0];


                    //match result
                    Label result = (Label)panel.FindControl("FightResult" + i);
                    if (result != null)
                    {
                        switch (Convert.ToInt32(hofArray[i - 1, 4]))
                        {
                            case 1:
                                result.Text = "W";
                                result.BackColor = System.Drawing.Color.Green;
                                break;
                            case 2:
                                result.Text = "L";
                                result.BackColor = System.Drawing.Color.Red;
                                break;
                            case 3:
                                result.Text = "D";
                                result.BackColor = System.Drawing.Color.Blue;
                                break;
                            default:
                                name = "";
                                break;
                        }
                    }                    

                    for (int rowCtr = 1; rowCtr <= 3; rowCtr++)
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
                                        tCell.Text = name;
                                        break;
                                    case 3:
                                        tCell.Text = coach;
                                        tCell.ForeColor = System.Drawing.Color.Green;
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
                    image.ImageUrl = CustomGlobal.TitanImage(CustomGlobal.viewtype.Front, element);
                }
            }
        }
        

        private String CellFill(int i)
        {
            switch (i)
            {
                case 1:
                    return "Date: ";
                case 2:
                    return "Name: ";
                case 3:
                    return "Coach: ";
                default:
                    return "";
            }
        }
        //redirects to Titan Page
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