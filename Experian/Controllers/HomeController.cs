using Experian.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Experian.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
           

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            CustomDate customDate = new CustomDate(collection["DateTxt"],int.Parse(collection["DayToaddTxt"]));

            var newDate = customDate.AddDays();

            ViewBag.NewDate = newDate;
            ViewBag.Days = collection["DayToaddTxt"];
            ViewBag.oldDate = collection["DateTxt"];
            return View();
        }


    }
}