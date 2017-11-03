using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Web;

namespace Better.Controllers
{
    public static class CustomGlobal
    {
        public static object Response { get; private set; }
        #region constants

        public enum viewtype
        {
            Front,
            Side,
            FrontZoomed
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Works out the level of the titan based on exp points
        /// </summary>
        /// <param name="exp">experiance points of titan</param>
        /// <returns>current level</returns>
        public static String GetLvl(int exp)
        {
            if (exp < 1001)
            {
                return "1";
            }
            else if (exp < 3001)
            {
                return "2";
            }
            else if (exp < 6401)
            {
                return "3";
            }
            else if (exp < 15001)
            {
                return "4";
            }
            else
            {
                return "Retired";
            }
        }

        /// <summary>
        /// Gets the step of the current titans exp and level
        /// </summary>
        /// <param name="lvl">current level of the titan</param>
        /// <param name="exp">experiance points of the titan</param>
        /// <returns>current step</returns>
        public static String GetStp(int lvl, int exp)
        {
            if ((lvl == 1 && exp < 201) || (lvl == 2 && exp < 1401) || (lvl == 3 && exp < 3701) || (lvl == 4 && exp < 7501))
            {
                return "1";
            }
            else if ((lvl == 1 && exp < 426) || (lvl == 2 && exp < 1901) || (lvl == 3 && exp < 4501) || (lvl == 4 && exp < 8701))
            {
                return "2";
            }
            else if ((lvl == 1 && exp < 676) || (lvl == 2 && exp < 2401) || (lvl == 3 && exp < 5401) || (lvl == 4 && exp < 10001))
            {
                return "3";
            }
            else if (exp < 15001)
            {
                return "4";
            }
            else
            {
                return "Retired";
            }
        }

        /// <summary>
        /// gets the completed percentaage of a step for display for the titans given information
        /// </summary>
        /// <param name="lvl">titans current level</param>
        /// <param name="stp">titans current step</param>
        /// <param name="exp">titans current experiance points</param>
        /// <returns>percentage completed of step</returns>
        public static String GetRemaing(int lvl, int stp, int exp)
        {
            string result;
            double totalExp = exp;

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

        /// <summary>
        /// Returns the relevant image location for the titans type
        /// </summary>
        /// <param name="view">which view of the titan you want</param>
        /// <param name="type">titan type in numerical form</param>
        /// <returns>image string for titan image</returns>
        public static String TitanImage(viewtype view, string type)
        {
            string result = "";

            switch (view)
            {
                case viewtype.Front:
                    switch (Convert.ToInt32(type))
                    {
                        case 1:
                            result = "../Images/Air_Elemental_titans_front.png";
                            break;
                        case 2:
                            result = "../Images/Earth_Elemental_titans_front.png";
                            break;
                        case 3:
                            result = "../Images/Fire_Elemental_titans_front.png";
                            break;
                        case 4:
                            result = "../Images/Water_Elemental_titans_front.png";
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
                case viewtype.Side:
                    switch (Convert.ToInt32(type))
                    {
                        case 1:
                            result = "../Images/Air_Elemental_titans_side.png";
                            break;
                        case 2:
                            result = "../Images/Earth_Elemental_titans_side.png";
                            break;
                        case 3:
                            result = "../Images/Fire_Elemental_titans_side.png";
                            break;
                        case 4:
                            result = "../Images/Water_Elemental_titans_side.png";
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
                case viewtype.FrontZoomed:
                    switch (Convert.ToInt32(type))
                    {
                        case 1:
                            result = "../Images/Air_Elemental_titans_front_half.png";
                            break;
                        case 2:
                            result = "../Images/Earth_Elemental_titans_front_half.png";
                            break;
                        case 3:
                            result = "../Images/Fire_Elemental_titans_front_half.png";
                            break;
                        case 4:
                            result = "../Images/Water_Elemental_titans_front_half.png";
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
            }

            return result;
        }

        /// <summary>
        /// gets the pre appending text or label for a Cell
        /// </summary>
        /// <param name="callername">calling object</param>
        /// <param name="cellid">id of the Cell to get</param>
        /// <returns>Cell Label</returns>
        public static String CellFill(string callername, int cellid)
        {
            string result = "";

            switch (callername)
            {
                case "UserProfile":
                    switch (cellid)
                    {
                        case 1:
                            result = "Created: ";
                            break;
                        case 2:
                            result = "Fights: ";
                            break;
                        case 3:
                            result = "Wins: ";
                            break;
                        case 4:
                            result = "Losses: ";
                            break;
                        case 5:
                            result = "Name: ";
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
                case "HallOfFame":
                    switch (cellid)
                    {
                        case 1:
                            result = "Created: ";
                            break;
                        case 2:
                            result = "Fights: ";
                            break;
                        case 3:
                            result = "Wins: ";
                            break;
                        case 4:
                            result = "Losses: ";
                            break;
                        case 5:
                            result = "Coach: ";
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
                case "TitanPage":
                    switch (cellid)
                    {
                        case 1:
                            result = "Created: ";
                            break;
                        case 2:
                            result = "Fights: ";
                            break;
                        case 3:
                            result = "Wins: ";
                            break;
                        case 4:
                            result = "Losses: ";
                            break;
                        case 5:
                            result = "Draws: ";
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
                case "Fight":
                    switch (cellid)
                    {
                        case 1:
                            result = "Created: ";
                            break;
                        case 2:
                            result = "Fights: ";
                            break;
                        case 3:
                            result = "Wins: ";
                            break;
                        case 4:
                            result = "Losses: ";
                            break;
                        case 5:
                            result = "Coach: ";
                            break;
                        default:
                            result = "";
                            break;
                    }
                    break;
            }

            return result;
        }

        /// <summary>
        /// name population method for autofilling
        /// </summary>
        /// <param name="nameNum"> an id to select from the names in the method list</param>
        /// <returns>name to use</returns>
        public static String setName(int nameNum)
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

        //Source: http://asp.net-tutorials.com/misc/sending-mails/
        /// <summary>
        /// Creates a Email and if the SmptClient is set sends it.
        /// </summary>
        /// <param name="EmailTo"></param>
        /// <param name="EmailFrom"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <returns> String to display </returns>
        public static String email(string EmailTo, string EmailFrom, string Subject, string Body)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(EmailTo);
                mailMessage.From = new MailAddress(EmailFrom);
                mailMessage.Subject = Subject;
                mailMessage.Body = Body;


                string SmptClient = "smtp.newcastle.edu.au";

                //If you are not recieving Emails Please change the following string to your ISP supplier e.g "smtp.telstra.com" or "smtp.newcastle.edu.au"
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    if (!string.IsNullOrEmpty(properties.DnsSuffix))
                    {
                        SmptClient = "smtp." + properties.DnsSuffix;
                        break;
                    }
                }

                if (SmptClient == null)
                {
                    return "SmptClient not set, Contact Techsuport@better.com";
                }

                SmtpClient smtpClient = new SmtpClient(SmptClient);
                smtpClient.Send(mailMessage);
                return "E-mail sent! Please check your email.";
            }
            catch (Exception ex)
            {
                return "Could not send the e-mail - Contact Techsuport@better.com and quote error: " + ex.Message;
            }
        }

        #endregion 

    }
}