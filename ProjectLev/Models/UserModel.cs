using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLev.Models
{
    public class UserModel
    {

        public UserModel()
        {

        }

        public string personID { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public Nullable<byte> privileges { get; set; }
        public string profilePic { get; set; }
        public string userAddress { get; set; }
        public string password { get; set; }

        internal static Boolean addNewUser(UserModel userToAdd)
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {

                    TblUser newUser = ctx.TblUser.Create();
                    newUser.personID = userToAdd.personID;
                    newUser.email = userToAdd.email;
                    newUser.fullName = userToAdd.fullName;
                    newUser.privileges = (byte)userToAdd.privileges;
                    newUser.password = userToAdd.password;

                    ctx.TblUser.Add(newUser);
                    ctx.SaveChanges();
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
                //return Json(ex.InnerException.InnerException.ToString());
            }
        }


        internal static bool removeUser(string personID)
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {
                    var itemToRemove = ctx.TblUser.SingleOrDefault(x => x.personID == personID); //returns a single item.

                    if (itemToRemove != null)
                    {
                        ctx.TblUser.Remove(itemToRemove);
                        ctx.SaveChanges();
                    }

                    return true;
                }

            }
            catch (Exception)
            {
                return false;
                //return Json(ex.InnerException.InnerException.ToString());
            }
        }

        internal static bool updateUser(UserModel userToUpdate)
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {

                    var updateUser = ctx.TblUser.SingleOrDefault(x => x.personID == userToUpdate.personID); //returns a single item.
                    
                    updateUser.email = userToUpdate.email;
                    updateUser.fullName = userToUpdate.fullName;
                    updateUser.privileges = (byte)userToUpdate.privileges;
                    updateUser.userAddress = userToUpdate.userAddress;

                    ctx.Entry(updateUser).State = System.Data.Entity.EntityState.Modified;
                    //ctx.TblUser.Add(updateUser);
                    ctx.SaveChanges();
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
                //return Json(ex.InnerException.InnerException.ToString());
            }
        }

        internal static UserModel userLogIn(string personId, string password)
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
                            UserModel logInUser = new UserModel();
                            logInUser.personID = userLogIn.personID;
                            logInUser.fullName = userLogIn.fullName;
                            logInUser.email = userLogIn.email;
                            logInUser.privileges = userLogIn.privileges;
                           
                            return logInUser;
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                return null;
            }

            return null;
        }

        internal static UserModel getUserById(string personId)
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {
                    var userLogIn = ctx.TblUser.SingleOrDefault(x => x.personID == personId); //returns a single item.

                    if (userLogIn != null)
                    {
                            UserModel logInUser = new UserModel();
                            logInUser.personID = userLogIn.personID;
                            logInUser.fullName = userLogIn.fullName;
                            logInUser.email = userLogIn.email;
                            logInUser.privileges = userLogIn.privileges;

                            return logInUser;
                      
                    }
                }
            }
            catch (System.Exception)
            {
                return null;
            }

            return null;
        }
    }
}