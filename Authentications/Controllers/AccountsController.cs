using Authentications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Authentications.Models;

namespace Authentications.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Repository repository = new Repository();
                repository.Add(model);
                return RedirectToAction("LoginCheck");
            }
            return View();
        }
        public ActionResult LoginCheck()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCheck(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Repository repository = new Repository();
                if (repository.Check(model))
                {
                    ViewData["user"]=model.Email;
                    return RedirectToAction("Success");
                }
                else
                {
                    ViewBag.msg = "Login Failed";
                }
            }
            return View();
        }
        public ActionResult ForgetPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(ForgetModel model)
        {
            if (ModelState.IsValid)
            {
                Repository repository = new Repository();
                repository.Forget(model);
                return RedirectToAction("LoginCheck");
            }
            return View();
        }
        
        public ActionResult Success(RegisterModel obj)
        {
            if (ModelState.IsValid)
            {
                ViewData["user"] = obj.Email;

            }
            return View();
        }
        public ActionResult Get()
        {
                Repository s= new Repository(); 
            ModelState.Clear();
             var data=s.GetList();
            return View(data);
           
        }

        public ActionResult Verify(string email)
        {
            Repository s= new Repository();
            var data=s.GetList().Find(e=>e.Email==email);
            return View();

        }
        public ActionResult Verify(string email,ForgetModel obj)
        {
            Repository s=new Repository();
            if (ModelState.IsValid)
            {
                s.Forget(obj);
            }
            return View();
        }

    }
}