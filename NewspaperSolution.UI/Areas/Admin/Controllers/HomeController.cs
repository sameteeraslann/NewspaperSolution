using NewspaperSolution.DataAccessLayer.Repositories.Concrete.EfRepositories;
using NewspaperSolution.EntityLayer.Entites.Concrete;
using NewspaperSolution.UI.Areas.Admin.Data.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewspaperSolution.UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        EfPostRepository _postRepository;
        public HomeController() => _postRepository = new EfPostRepository();
       
        // GET: Admin/Home
        public ActionResult HomePage(int id)
        {
            var getir = _postRepository.GetById(id);
            if (getir!= null)
            {
                return View("HomePage", getir);
            }
            else
            {
                return View("/Home/HomePage");
            }
            
        }
    }
}