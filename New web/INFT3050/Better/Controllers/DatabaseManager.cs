using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using Better.Controllers;

namespace Better.Controllers
{
    public class DatabaseManager
    {
        #region Private Variables

        System.Configuration.Configuration RootWebConfig;
        System.Configuration.ConnectionStringSettings ConnString;
        BetterDataClassesDataContext dc;

        #endregion

        #region Contstructors
       
        /// <summary>
        /// Constructor method, takes in the web config and connection incase a standard sql command is required
        /// </summary>
        /// <param name="webconfig"></param>
        /// <param name="connectionname"></param>
        public DatabaseManager(string webconfig, string connectionname)
        {
            RootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/" + webconfig);

            if (RootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                ConnString = RootWebConfig.ConnectionStrings.ConnectionStrings[connectionname];
            }

            dc = new BetterDataClassesDataContext();
            
        }

        #endregion

        #region Public Properties

        public BetterDataClassesDataContext BetterDataContext
        {
            get { return dc; }
            set { dc = value; }
        }

        #endregion

        #region Static Methods 

        /// <summary>
        /// Sample method for understanding sql command way of gathering data.
        /// </summary>
        /// <returns>a string of values</returns>
        public static string Sample()
        { 
            var test = string.Empty;

            System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Web");

            System.Configuration.ConnectionStringSettings connString;

                if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
                {
                    connString =
                        rootWebConfig.ConnectionStrings.ConnectionStrings["DefaultConnection"];
                    if (connString != null)
                    {
                        using (SqlConnection conn = new SqlConnection(connString.ToString()))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT TitanId, UserId FROM AspNetUserTitans", conn);
                            try
                            {
                                conn.Open();
                                test = (string)cmd.ExecuteScalar();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }

            return test;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a list of required titan records for which the titans are retired
        /// </summary>
        /// <returns>List of retired Titans</returns>
        public List<AspNetTitan> GetRetiredHeros()
        {
            List<AspNetTitan> result = new List<AspNetTitan>();
            

            result = dc.AspNetTitans.Where(t => t.Retired == true).ToList();

            return result;
        }

        /// <summary>
        /// Gets the Titans that are available to fight
        /// </summary>
        /// <param name="userid">User id to exclude</param>
        /// <returns>List of Titan Link Records</returns>
        public List<AspNetUserTitan> GetTitansToFight(string userid)
        {
            List<AspNetUserTitan> result = new List<AspNetUserTitan>();

            result = dc.AspNetUserTitans.Where(t => t.UserId != userid && t.Retired == false).ToList();

            return result;
        }

        /// <summary>
        /// Gets a list of fights the titan has been involved in, both defending and attacking
        /// </summary>
        /// <param name="titanid">Titan id to search for</param>
        /// <returns>list of fight records</returns>
        public List<AspNetUserTitanFight> GetTitansFightHistory(string titanid)
        {
            List<AspNetUserTitanFight> result = new List<AspNetUserTitanFight>();
            
            result = dc.AspNetUserTitanFights.Where(t => t.AttackerTitanID == titanid || t.DefenderTitanID == titanid).ToList();

            return result;
        }

        /// <summary>
        /// Gets the Titans Linked to the current user
        /// </summary>
        /// <param name="userid">User id to search for</param>
        /// <returns>List of Titan Link Records</returns>
        public List<AspNetUserTitan> GetUserTitans(string userid)
        {
            List<AspNetUserTitan> result = new List<AspNetUserTitan>();
            

            result = dc.AspNetUserTitans.Where(t => t.UserId == userid).ToList();

            return result;
        }

        /// <summary>
        /// Gets details of a single Titan
        /// </summary>
        /// <param name="titanid">Id of the Titan to find</param>
        /// <returns>Single Titan record</returns>
        public AspNetTitan Titaninfo(string titanid)
        {
            
            return dc.AspNetTitans.First(t => t.Id == titanid);
        }

        /// <summary>
        /// Gets the name of a Titans user
        /// </summary>
        /// <param name="titanid">Id of the Titan to find</param>
        /// <returns>Sring of titan username/returns>
        public string TitanUsersName(string titanid, HttpContext _context)
        {
            
            AspNetUserTitan aspUserTitan = dc.AspNetUserTitans.FirstOrDefault(apt => apt.TitanID == titanid);

            var manager = _context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(aspUserTitan.UserId);

            if (user.Showname)
            {
                return user.FirstName + " " + user.LastName;
            }
            else
            {
                return user.FirstName;
            }

        }

        /// <summary>
        /// Creates the data rows for a new Titan
        /// </summary>
        /// <param name="userid">id of the user</param>
        /// <param name="type">type of the titan</param>
        /// <param name="name">name of the titan</param>
        public void CreateTitan(string userid, string type, string name)
        {
            AspNetTitan tit = new AspNetTitan
            {
                Id = GetMaxTitanId(),
                TitanName = name,
                Exp = "0",
                Wins = "0",
                Losses = "0",
                Draws = "0",
                Retired = false,
                Type = type
            };
            
            // Add the new object to the Orders collection.
            BetterDataContext.AspNetTitans.InsertOnSubmit(tit);

            AspNetUserTitan usrtit = new AspNetUserTitan
            {
                Id = GetMaxUserTitanId(),
                UserId = userid,
                TitanID = tit.Id,
                Retired = false,
                Deleted = false
            };

            // Add the new object to the Orders collection.
            BetterDataContext.AspNetUserTitans.InsertOnSubmit(usrtit);

            BetterDataContext.SubmitChanges();
        }

        /// <summary>
        /// Creates the fight record
        /// </summary>
        /// <param name="attackuserid">attacking titan id</param>
        /// <param name="defenduserid">defening titan id</param>
        /// <param name="win">did the attacker win?</param>
        /// <param name="loss">did the attacker lose?</param>
        /// <param name="draw">did the attacker draw?</param>
        public void CreateFight(string attacktitanid, string defendtitanid, bool win = false, bool loss = false, bool draw = false)
        {
            AspNetUserTitanFight fght = new AspNetUserTitanFight
            {
                Id = GetMaxFightId(),
                AttackerTitanID = attacktitanid,
                DefenderTitanID = defendtitanid,
                Win = win,
                Loss = loss, 
                Draw = draw
            };

            // Add the new object to the Orders collection.
            BetterDataContext.AspNetUserTitanFights.InsertOnSubmit(fght);

            BetterDataContext.SubmitChanges();
        }

        /// <summary>
        /// gets the max id for the AspNetTitans table
        /// </summary>
        /// <returns>string of the id</returns>
        public string GetMaxTitanId()
        {
            string result = "";
            
            result = Convert.ToString(Convert.ToInt16(BetterDataContext.AspNetTitans.Max(u => u.Id)) + 1);

            return result;
        }

        /// <summary>
        ///  gets the max id for the AspNetUserTitans table
        /// </summary>
        /// <returns>string of the id</returns>
        public string GetMaxUserTitanId()
        {
            string result = "";

            result = Convert.ToString(Convert.ToInt16(BetterDataContext.AspNetUserTitans.Max(u => u.Id)) + 1);

            return result;
        }

        /// <summary>
        ///  gets the max id for the AspNetUserTitanFights table
        /// </summary>
        /// <returns>string of the id</returns>
        public string GetMaxFightId()
        {
            string result = "";

            result = Convert.ToString(Convert.ToInt16(BetterDataContext.AspNetUserTitanFights.Max(u => u.Id)) + 1);

            return result;
        }

        #endregion
    }
}