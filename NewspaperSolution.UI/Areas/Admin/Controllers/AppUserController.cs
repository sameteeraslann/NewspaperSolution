﻿using NewspaperSolution.DataAccessLayer.Repositories.Concrete.EfRepositories;
using NewspaperSolution.EntityLayer.Entites.Concrete;
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

    }
}