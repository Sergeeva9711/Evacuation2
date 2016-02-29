using AutoMapper;
using Evacuation.Bll.Interfaces;
using Evacuation.Bll.Services;
using Evacuation.Dal.Entities;
using Evacuation.Dal.Repositories;
using Evacuation.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Evacuation.Web.Controllers
{
    public class HomeController : Controller
    {
        UserService userSevice;
        ProjectService projectService;     
        
        MapperConfiguration con = new MapperConfiguration(cf =>
        {
            cf.CreateMap<User, UserModel>();
            cf.CreateMap<UserModel, User>();
            cf.CreateMap<Project, ProjectModel>();
            cf.CreateMap<ProjectModel, Project>();
        });
        
        public HomeController(UserService service, ProjectService serv)
        {
            userSevice = service;
            projectService = serv;          
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var map = con.CreateMapper();
            IEnumerable<User> us = userSevice.GetAll();
            IEnumerable<UserModel> um = map.Map<IEnumerable<UserModel>>(us);
            return View(um.ToList());
        }

        public ActionResult Projects()
        {
            var map = con.CreateMapper();
            IEnumerable<Project> pr = projectService.GetAll();
            IEnumerable<ProjectModel> pm = map.Map<IEnumerable<ProjectModel>>(pr);
            return View(pm.ToList());
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
                return RedirectToAction("Users", "Home");              
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            SelectList users = new SelectList(userSevice.GetAll().ToList(), "UserID", "UserName");
            ViewBag.Users = users;                    
            return View(new ProjectModel());
        }

        [HttpPost]
        public ActionResult CreateProject(ProjectModel projectM, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid && uploadImage != null)
            {
                var map = con.CreateMapper();
                var project = map.Map<Project>(projectM);
                byte[] imageData = null;               
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                }               
                project.Image = imageData;
                projectService.Create(project);
                return RedirectToAction("Projects", "Home");
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
                return RedirectToAction("Users", "Home");               
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditProject(int id)
        {
            var map = con.CreateMapper();
            var projectEdit = projectService.Get(id);
            var projectM = map.Map<ProjectModel>(projectEdit);
            SelectList users = new SelectList(userSevice.GetAll().ToList(), "UserID", "UserName");
            ViewBag.Users = users;
            return View(projectM);
        }

        [HttpPost]
        public ActionResult EditProject(ProjectModel projectM)
        {
            if (ModelState.IsValid)
            {
                var map = con.CreateMapper();
                var projectEdit = projectService.Get(projectM.ProjectID);
                projectEdit = map.Map<Project>(projectM);
                projectService.Edit(projectEdit);
                return RedirectToAction("Projects", "Home");
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
                return RedirectToAction("Users", "Home");                             
            }
                return View();
        }

        [HttpGet]
        public ActionResult DeleteProject(int id)
        {
            var map = con.CreateMapper();
            var projectDelete = projectService.Get(id);
            var projectM = map.Map<ProjectModel>(projectDelete);
            return View(projectM);
        }

        [HttpPost, ActionName("DeleteProject")]
        public ActionResult DeleteP(int id)
        {
            if (ModelState.IsValid)
            {
                var projectDelete = projectService.Get(id);
                projectService.Delete(projectDelete);
                return RedirectToAction("Projects", "Home");
            }
            return View();
        }

       
    }
}