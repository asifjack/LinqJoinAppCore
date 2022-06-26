using LinqJoinAppCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LinqJoinAppCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ModelViewForInvoice> list = new List<ModelViewForInvoice>();
            var result = (from emp in dbContext.Employees
                          join dep in dbContext.Departments on emp.Department_Id equals dep.DepartmentId
                          join inc in dbContext.Incentives on dep.DepartmentId equals inc.IncentiveId
                          select new
                          {

                              Name = emp.Name,
                              IncentiveAmount = inc.IncentiveAmount,
                              DepartmentName = dep.DepartmentName
                          }
                         ).ToList();
            foreach (var invoice in result) 
            {
                ModelViewForInvoice e = new ModelViewForInvoice();
                e.DepartmentName = invoice.DepartmentName;
                e.IncentiveAmount = invoice.IncentiveAmount;
                e.Name = invoice.Name;
                list.Add(e);

            }

            //var result = (from emp in dbContext.Employees join 
            //              dep in dbContext.Departments on emp.Department_Id equals dep.DepartmentId 
            //              join inc in dbContext.Incentives on dep.DepartmentId equals inc.
            //              select new ViewModel { 
            //              employee=emp,
            //              department=dep,
            //              incentive = inc
            //              }
            //              ).ToList();
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
