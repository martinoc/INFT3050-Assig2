using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Better.App_Code;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;

namespace Better.Views
{
    public class DatabaseManager
    {
        #region Private Variables

        System.Configuration.Configuration RootWebConfig;
        System.Configuration.ConnectionStringSettings ConnString;
        App_Code.BetterDataClassesDataContext dc;

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

            dc = new App_Code.BetterDataClassesDataContext();

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
        public static string sample()
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

        #endregion
    }
}