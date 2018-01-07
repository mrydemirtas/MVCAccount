using MVCAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCAccount.Controllers
{
    public class AccountController : Controller
    {
        //sistemdeki kullanıcıları çeker.
        public ICollection<UserModel> GetUsers
        {
            get
            {
                if (Session["MyUsers"]==null)
                {
                    return new HashSet<UserModel>();
                }

                return (ICollection<UserModel>)Session["MyUsers"];
            }

        }

        //Sessiona kullanıcı ekler
        public void AddUserToSession(UserModel model)
        {
            Session["MyUsers"] = GetUsers;
            GetUsers.Add(model);
        }


        //Get
        public ActionResult Login()
        {
            return View();
        }
        
        //Post
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            //session içinde modelden gelen özelliklere eşit bir kullanıcı var mıdır ?
            if (GetUsers.Any(x=> x.Email==model.Email && x.Password==model.Password))
            {
                //firiş işlemleri için cookie oluşturduk
                FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Kullanıcı adınız veya parolanızı tekrar giriniz";

            //Kullanıcı Kontrolü eğer var ise kullanıcıya cookie yani oturum aç
            return View();
        }

        //GET
        public ActionResult Register()
        {

            //Kullanıcıyı sisteme kaydet.
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            //validasyondan geçtik mi ?
            //serverside validation
            if (ModelState.IsValid)
            {
                UserModel m = new UserModel();
                m.Email = model.Email;
                m.Password = model.Password;

                AddUserToSession(m);

                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            //oturumu sil ve login yönlendir.
            return RedirectToAction("Login", "Account");
        }
    }
}