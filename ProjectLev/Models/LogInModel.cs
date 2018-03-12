using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLev.Models
{
    public class LogInModel
    {
        public string personID { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public Nullable<byte> privileges { get; set; }
        public string profilePic { get; set; }
        public string userAddress { get; set; }
        public string password { get; set; }



        internal static bool userLogIn(string personId, string password)
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {
                    var userLogIn = ctx.TblUser.SingleOrDefault(x => x.personID == personId); //returns a single item.

                    if (userLogIn != null)
                    {
                        if (userLogIn.password == password)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                return false;
            }

            return false;
        }



    }

}