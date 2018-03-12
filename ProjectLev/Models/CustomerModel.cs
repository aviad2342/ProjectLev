using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectLev.Models
{
    public class CustomerModel
    {

        public CustomerModel()
        {

        }

        public string ID { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public Nullable<int> houseNum { get; set; }
        public string zipCode { get; set; }
        public Nullable<byte> gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KEY_CustomersTherapists> KEY_CustomersTherapists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KEY_Purchases> KEY_Purchases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPhone> TblPhone { get; set; }


        internal static Boolean addNewCustomer(CustomerModel customerToAdd)
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {

                    TblCustomer newCustomer = ctx.TblCustomer.Create();

                    newCustomer.ID = customerToAdd.ID;
                    newCustomer.fullName = customerToAdd.fullName;
                    newCustomer.email = customerToAdd.email;
                    newCustomer.city = customerToAdd.city;
                    newCustomer.street = customerToAdd.street;
                    newCustomer.houseNum = customerToAdd.houseNum;
                    newCustomer.zipCode = customerToAdd.zipCode;
                    newCustomer.gender = customerToAdd.gender;

                    ctx.TblCustomer.Add(newCustomer);
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

        internal static bool removeCustomer(string ID)
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {
                    var itemToRemove = ctx.TblCustomer.SingleOrDefault(x => x.ID == ID); //returns a single item.

                    if (itemToRemove != null)
                    {
                        ctx.TblCustomer.Remove(itemToRemove);
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

        internal static bool updateCustomer(CustomerModel customerToUpdate)
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {

                    var updateCustomer = ctx.TblCustomer.SingleOrDefault(x => x.ID == customerToUpdate.ID); //returns a single item.

                    updateCustomer.fullName = customerToUpdate.fullName;
                    updateCustomer.email = customerToUpdate.email;
                    updateCustomer.city = customerToUpdate.city;
                    updateCustomer.street = customerToUpdate.street;
                    updateCustomer.houseNum = customerToUpdate.houseNum;
                    updateCustomer.zipCode = customerToUpdate.zipCode;
                    updateCustomer.gender = customerToUpdate.gender;              

                    ctx.Entry(updateCustomer).State = System.Data.Entity.EntityState.Modified;
                    //ctx.TblUser.Add(updateUser);
                    ctx.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
                return false;
                //return Json(ex.InnerException.InnerException.ToString());
            }
        }


    }
}