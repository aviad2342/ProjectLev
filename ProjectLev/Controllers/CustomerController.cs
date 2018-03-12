using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectLev.Models;

namespace ProjectLev.Controllers
{
    public class CustomerController : Controller
    {
        
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCustomers()
        {
            try
            {
                using (var ctx = new arivanLevEntities())
                {


                    List<TblCustomer> customer = ctx.TblCustomer.ToList();

                    var dataset = customer
                                .Select(x => new CustomerModel
                                {
                                    ID = x.ID,
                                    fullName = x.fullName,
                                    email = x.email,
                                    city = x.city,
                                    street = x.street,
                                    houseNum = x.houseNum,
                                    zipCode = x.zipCode,
                                    gender = x.gender                      
                                }).ToList();

                    return Json(dataset, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.InnerException.InnerException.ToString());
            }

        }


        [HttpPost]
        public ActionResult addCustomer(string ID, string customerFullname, string customerEmail, string customerCity, string customerStreet, int customerHouseNum, string customerZipCode, byte customerGender)
        {
            CustomerModel newCustomer = new CustomerModel();

            newCustomer.ID = ID;
            newCustomer.fullName = customerFullname;
            newCustomer.email = customerEmail;
            newCustomer.city = customerCity;
            newCustomer.street = customerStreet;
            newCustomer.houseNum = customerHouseNum;
            newCustomer.zipCode = customerZipCode;
            newCustomer.gender = customerGender;

            if (CustomerModel.addNewCustomer(newCustomer))
            {
                return Json(newCustomer);
            }
            else
            {
                return Json("error");
            }

        }


        [HttpPost]
        public ActionResult updateCustomer(string ID, string customerFullname, string customerEmail, string customerCity, string customerStreet, int customerHouseNum, string customerZipCode, byte customerGender)
        {
            CustomerModel updateCustomer = new CustomerModel();

            updateCustomer.ID = ID;
            updateCustomer.fullName = customerFullname;
            updateCustomer.email = customerEmail;
            updateCustomer.city = customerCity;
            updateCustomer.street = customerStreet;
            updateCustomer.houseNum = customerHouseNum;
            updateCustomer.zipCode = customerZipCode;
            updateCustomer.gender = customerGender;

            if (CustomerModel.updateCustomer(updateCustomer))
            {
                return Json(updateCustomer);
            }
            else
            {
                return Json("error");
            }

        }


        [HttpPost]
        public ActionResult removeCustomer(string ID)
        {
            if (CustomerModel.removeCustomer(ID))
            {
                return Json("success");
            }
            else
            {
                return Json("error");
            }

        }
    }
}
