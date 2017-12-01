using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MCEC_www.Models;

namespace MCEC_www.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("MonteCarloJobs");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Explication.";

            return View();
        }

        public async Task<IActionResult> MonteCarlo()
        {
            ViewData["Message"] = "This page will allow to initiate a new MonteCarlo job.";

            var mcOpt = new MCEC_Jobs.Interface.MonteCarloJobSetting()
            {
                Steps = 500,
                Simulations = 10000,
                Maturity = 1,
                Strike = 100,
                Spot = 100,
                Volatility = 0.30,
                InterestRate = 0.05
            };

            return View(mcOpt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitNewJob([Bind("Steps,Simulations,Maturity,Strike,Spot,Volatility,InterestRate")]
            MCEC_Jobs.Interface.MonteCarloJobSetting settings)
        {
            // TODO : call the Job service to create a new request

            // HACK : simulate a job insertion returned valure
            var job = new MCEC_Jobs.Interface.JobState()
            {
                Id = Guid.NewGuid(),
                Status = MCEC_Jobs.Interface.JobStatus.Submitted,
                LastUpdate = DateTime.UtcNow
            };

            return View("MonteCarloNewJob",job);
        }


        public IActionResult MonteCarloJobs()
        {
            ViewData["Message"] = "This page will monitor monte carlo jobs status and result.";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
