using NewspaperSolution.DataAccessLayer.Repositories.Concrete.EfRepositories;
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
        public ActionResult HomePage()
        {
            return View();
        }
    }
}