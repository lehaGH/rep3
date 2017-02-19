using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6_2.Controllers
{
    public class ImagesController : Controller
    {

        //форма добавления картинки
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //список всех картинок юзера
        [Authorize]
        public ActionResult ImageList()
        {
            return View();
        }

        //приемник картинок юзера
        [Authorize]
        public RedirectToRouteResult ImageUpload()
        {
            return null;
        }

        //управление картинкой
        [Authorize]
        public ActionResult ImagePage()
        {
            return View();
        }

        //удаление картинки
        [Authorize]
        public ActionResult Imageremove()
        {
            return View();
        }

        //получение картинки
        public FileContentResult GetImage(string link)
        {
            return null;
        }

    }
}