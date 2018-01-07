using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAccount.Controllers
{
    [Authorize] //sadece oturum açmış olanlar bu controller a girebilir.
    //oturum açmazsan seni logine yönlendirir.
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //HttpContext.User.Identity.Name; oturum açan kullanıcı ismini getir.
            //cookie ne yazdıysak name olarak o gelir. Bizim sistemimizde email adres gelecek.
            ViewBag.Email = HttpContext.User.Identity.Name;

            return View();
        }
    }
}