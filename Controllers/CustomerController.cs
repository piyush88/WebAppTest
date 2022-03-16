using BAL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebHelper;

namespace WebAppTest.Controllers
{
    public class CustomerController : Controller
    {
        CustomerBAL balobj = new CustomerBAL(); 
        private readonly IGeekConfigManager _configuration;
        public CustomerController(IGeekConfigManager configuration)
        {
            this._configuration = configuration;
        }
        public IActionResult Index()
        {
            
            //string strEmail = this._configuration.EmailID;
            //string strAccountKey = this._configuration.AccountKey;
            //string connstr = this._configuration.NorthwindConnection;
            List<Customer> customers = new List<Customer>();
            customers = (List<Customer>)balobj.GetCustomerList();
            return View(customers);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind] Customer cust)
        {
            if (ModelState.IsValid)
            {
                balobj.AddCustomer(cust);
            }
            return RedirectToAction("Index");
        }
    }
}
