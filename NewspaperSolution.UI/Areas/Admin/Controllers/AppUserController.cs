using NewspaperSolution.DataAccessLayer.Repositories.Concrete.EfRepositories;
using NewspaperSolution.EntityLayer.Entites.Concrete;
using NewspaperSolution.EntityLayer.Enum;
using NewspaperSolution.UI.Areas.Admin.Data.DTOs;
using NewspaperSolution.Utility.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewspaperSolution.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        private EfAppUserRepository _repo;
        public AppUserController()
        {
            _repo = new EfAppUserRepository();
        }
        // GET: Admin/AppUser
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AppUser data, HttpPostedFileBase Image)
        {
            List<string> UploadImagePaths = new List<string>();
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadImagePaths[0];

            if (data.UserImage == "1" || data.UserImage == "2" || data.UserImage == "3")
            {
                data.UserImage = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImagePath;
                data.CruptedUserImage = ImageUploader.DefaultCruptedProfileImagePath;
            }
            else
            {
                data.XSmallUserImage = UploadImagePaths[1];
                data.CruptedUserImage = UploadImagePaths[2];
            }

            _repo.Add(data);
            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult List()
        {
            return View(_repo.GetActive());
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            AppUserDTO data = new AppUserDTO();
            AppUser appUser = _repo.GetById(id);
            data.Id = appUser.Id;
            data.FirstName = appUser.FirstName;
            data.LastName = appUser.LastName;
            data.UserName = appUser.UserName;
            data.Password = appUser.Password;
            data.Role = appUser.Role;
            data.UserImage = appUser.UserImage;
            data.XSmallUserImage = appUser.XSmallUserImage;
            data.CruptedUserImage = appUser.CruptedUserImage;
            return View(data);
        }

        // Delete çalışmıyor & Update de hep aynı ID geliyor.

        [HttpPost]
        public ActionResult Update(AppUserDTO data , HttpPostedFileBase Image)
        {
            AppUser appUser = _repo.GetById(data.Id);

            List<string> UploadImagePaths = new List<string>();
            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadImagePaths[0];

            if (data.UserImage == "1" || data.UserImage == "2" || data.UserImage == "3")
            {
                if (appUser.UserImage == null || appUser.UserImage == ImageUploader.DefaultProfileImagePath)
                {
                    appUser.UserImage = ImageUploader.DefaultProfileImagePath;
                    appUser.XSmallUserImage = ImageUploader.DefaultXSmallProfileImagePath;
                    appUser.CruptedUserImage = ImageUploader.DefaultCruptedProfileImagePath;
                }
            }
            else
            {
                appUser.UserImage = UploadImagePaths[0];
                appUser.XSmallUserImage = UploadImagePaths[1];
                appUser.CruptedUserImage = UploadImagePaths[2];
            }

            appUser.FirstName = data.FirstName;
            appUser.LastName = data.LastName;
            appUser.UserName = data.UserName;
            appUser.Password = data.Password;
            appUser.Role = data.Role;
            _repo.Update(appUser);
            return Redirect("/Admin/AppUser/List");
        }

        public JsonResult Delete(int id)
        {
            AppUser appUser = _repo.GetById(id);
            if (appUser != null)
            {
                _repo.Remove(id);
                return Json("");
            }
            else
            {
                return Json("");
            }
        }

    }
}