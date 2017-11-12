using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResCodeCalculator.Models;

namespace ResCodeCalculator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [ActionName("Index")]
        public ActionResult Index()
        {
            Resistor resistor = new Resistor();
            return View(resistor);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult CalculateRes(string BandA, string BandB, string BandC, string BandD)
        {
            Resistor resistor = new Resistor();
            double total = resistor.CalculateOhmValue(BandA, BandB, BandC, BandD);
            ViewBag.Message = MakeValReadable(total) + " Ohms" + " +/-" + resistor.CalculateTolerance(BandD) + "%";
            return View();
        }

        // prints out MOhm, KOhm for larger values 
        [NonAction]
        private string MakeValReadable(double total)
        {
            string betterVal = string.Empty;
            if (total  >= 1e6)
            {
                betterVal = total / 1e6 + "M";
            }
            else if (total >= 1e3)
            {
                betterVal = total / 1e3 + "K";
            }
            else
            {
                betterVal = total.ToString();
            }
            return betterVal;
        }
    }
}