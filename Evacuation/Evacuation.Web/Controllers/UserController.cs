using AutoMapper;
using Evacuation.Bll.Services;
using Evacuation.Dal.Entities;
using Evacuation.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Evacuation.Web.Controllers
{
    public class UserController : Controller
    {
        UserService userSevice;

        MapperConfiguration con = new MapperConfiguration(cf =>
        {
            cf.CreateMap<User, UserModel>();
            cf.CreateMap<UserModel, User>();            
        });
        
        public UserController(UserService us)
        {
            userSevice = us;
        }
       
        public ActionResult Users()
        {
            var map = con.CreateMapper();
            IEnumerable<User> us = userSevice.GetAll();
            IEnumerable<UserModel> um = map.Map<IEnumerable<UserModel>>(us);
            return View(um.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UserModel());
        }

        [HttpPost]
        public ActionResult Create(UserModel userM)
        {
            if (ModelState.IsValid)
            {
                var map = con.CreateMapper();
                var user = map.Map<User>(userM);
                userSevice.Create(user);
                return RedirectToAction("Users", "User");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var map = con.CreateMapper();
            var userEdit = userSevice.Get(id);
            var userM = map.Map<UserModel>(userEdit);
            return View(userM);
        }

        [HttpPost]
        public ActionResult Edit(UserModel userM)
        {
            if (ModelState.IsValid)
            {
                var map = con.CreateMapper();
                var userEdit = userSevice.Get(userM.UserID);
                userEdit = map.Map<User>(userM);
                userSevice.Edit(userEdit);
                return RedirectToAction("Users", "User");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var map = con.CreateMapper();
            var userDelete = userSevice.Get(id);
            var userM = map.Map<UserModel>(userDelete);
            return View(userM);

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (ModelState.IsValid)
            {
                var userDelete = userSevice.Get(id);
                userSevice.Delete(userDelete);
                return RedirectToAction("Users", "User");
            }
            return View();
        }
       
    }
}