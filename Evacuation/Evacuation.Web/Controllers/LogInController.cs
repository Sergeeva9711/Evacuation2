using AutoMapper;
using Evacuation.Bll.Services;
using Evacuation.Dal.Entities;
using Evacuation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evacuation.Web.Controllers
{
    public class LogInController : Controller
    {
        UserService userSevice;

        MapperConfiguration con = new MapperConfiguration(cf =>
        {
            cf.CreateMap<User, UserModel>();
            cf.CreateMap<UserModel, User>();
        });

        public LogInController(UserService us)
        {
            userSevice = us;
        }

        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var map = con.CreateMapper();
                userSevice.GetUserEmailAndPassvord(map.Map<User>(user));
                if (user != null)
                {
                    var userlogin = userSevice.Get(userSevice.GetUserId(user.Email));
                    Session["LogedUserId"] = userlogin.UserID.ToString();
                    Session["LogedUserName"] = userlogin.UserName;
                    return RedirectToAction("AfterLogIn");
                }
            }
            return View();
        }

        public ActionResult AfterLogIn()
        {
            //if(Session["LogedUserId"] != null)
            //{
            //    RedirectToAction("UserPage");
            //}          
            return View();          
        }

        
    }
}