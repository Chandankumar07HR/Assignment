using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseFirst_Customers_CodebaseTest.Models;

namespace DatabaseFirst_Customers_CodebaseTest.Controllers
{
    
    
    public class CodeController : Controller
    {
        NorthwindDBContext db = new NorthwindDBContext();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GermanyCustomers()
        {
            var Customers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(Customers);
        }

      
        public ActionResult CustomerDetailsinOrder()
        {
            
            var customer = from order in db.Orders
                                  where order.OrderID == 10248
                                  select order.Customer;
            return View(customer.ToList());
        }

    }
}