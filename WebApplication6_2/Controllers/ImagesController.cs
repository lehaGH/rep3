using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6_2.Controllers
{
    public class ImagesController : Controller
    {
        Random rnd = new Random();

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
            var rep = new Models.ImageRepository();
            var buff=rep.GetAllItems(User.Identity.Name);
            ViewBag.listImage = buff;
            return View();
        }

        //приемник картинок юзера
        [Authorize]
        public RedirectToRouteResult ImageUpload(string text, HttpPostedFileBase uploadImage)
        {
            var buff = new Models.DataImg();

            buff.link = DateTime.Today.ToString().Replace(' ', '_').Replace('.', '_').Replace(':', '_') + rnd.Next(111111, 999999);
            buff.text = text;
            buff.UserName = User.Identity.Name;

            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(uploadImage.InputStream))
            {
                imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
            }

            buff.data = imageData;

            var rep = new Models.ImageRepository();
            rep.SetItem(buff);

            return RedirectToRoute(new { controller = "Images", action = "ImagePage", link = buff.link });
        }

        //управление картинкой
        [Authorize]
        public ActionResult ImagePage(string link)
        {
            var rep = new Models.ImageRepository();
            var buff = rep.GetItem(link);

            var buff2 = new Models.ImageViewModel() { link = buff.link, text = buff.text, user = buff.UserName, data=buff.data};

            return View(buff2);
        }

        //удаление картинки
        [Authorize]
        public ActionResult ImageRemove(string link)
        {
            var rep = new Models.ImageRepository();
            if (rep.RemoveItem(link, User.Identity.Name))
            {
                return PartialView();
            }
            else
            {
                return View("Error");
            }
            
        }

        //получение картинки
        public FileContentResult GetImage(string link)
        {
            var rep = new Models.ImageRepository();
            var buff = rep.GetItem(link);
            return File(buff.data, "image/jpeg");
        }

    }
}