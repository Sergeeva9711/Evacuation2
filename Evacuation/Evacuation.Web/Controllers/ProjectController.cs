using AutoMapper;
using Evacuation.Bll.Services;
using Evacuation.Dal.Entities;
using Evacuation.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evacuation.Web.Controllers
{
    public class ProjectController : Controller
    {
        ProjectService projectService;
        UserService userSevice;

        MapperConfiguration con = new MapperConfiguration(cf =>
        {           
            cf.CreateMap<Project, ProjectModel>();
            cf.CreateMap<ProjectModel, Project>();
        });

        public ProjectController(ProjectService ps, UserService us)
        {
            projectService = ps;
            userSevice = us;
        }
       
        public ActionResult Projects()
        {
            var map = con.CreateMapper();
            IEnumerable<Project> pr = projectService.GetAll();
            IEnumerable<ProjectModel> pm = map.Map<IEnumerable<ProjectModel>>(pr);
            return View(pm.ToList());
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
                return RedirectToAction("Projects", "Project");
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
                return RedirectToAction("Projects", "Project");
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
                return RedirectToAction("Projects", "Project");
            }
            return View();
        }
    }
}