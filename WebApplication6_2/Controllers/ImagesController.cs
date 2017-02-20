using System;
using System.Collections.Generic;
using System.Drawing;
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
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult ImageList()
        {
            var rep = new Models.ImageRepository();
            var buff=rep.GetAllItems(User.Identity.Name);
            ViewBag.listImage = buff;
            return View();
        }

        //приемник картинок юзера
        [Authorize]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public RedirectToRouteResult ImageUpload(string text, HttpPostedFileBase uploadImage)
        {
            var buff = new Models.DataImg();

            try
            {
                var img = new Bitmap(uploadImage.InputStream);
                var str = new MemoryStream();
                img.Save(str, System.Drawing.Imaging.ImageFormat.Jpeg);
                buff.data = str.ToArray();
            }
            catch (Exception e) { return RedirectToRoute("Error"); }
            
            buff.link = DateTime.Today.ToString().Replace(' ', '_').Replace('.', '_').Replace(':', '_') + rnd.Next(111111, 999999);
            buff.text = text;
            buff.UserName = User.Identity.Name;
            var rep = new Models.ImageRepository();
            rep.SetItem(buff);

            return RedirectToRoute(new { controller = "Images", action = "ImagePage", link = buff.link });
        }

        //управление картинкой
        [Authorize]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult ImagePage(string link)
        {
            var rep = new Models.ImageRepository();

            var buff = (link != null) ? rep.GetItem(link) : null ;

            if (buff != null && buff.UserName == User.Identity.Name)
            {
                var buff2 = new Models.ImageViewModel() { link = buff.link, text = buff.text, user = buff.UserName, data=buff.data};
                buff2.requests = new List<Models.IPViewModel>(buff.requests.Count);
                foreach (var t in buff.requests) buff2.requests.Add(new Models.IPViewModel() { ip = t.ip, time = t.time });
                return View(buff2);
            }
            else 
                return View("Error");      
        }

        //удаление картинки
        [Authorize]
        [HandleError(ExceptionType = typeof(Exception), View = "Error")]
        public ActionResult ImageRemove(string link)
        {
            var rep = new Models.ImageRepository();
            if (link!=null && rep.RemoveItem(link, User.Identity.Name))
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

            if (buff == null)
            {
                return File(new byte[] { 0 }, "image/jpeg");
            }
            else
            {
                buff.requests.Add(new Models.DataIP() { time = DateTime.Now, ip = Request.UserHostAddress });
                rep.SaveItem();
                return File(buff.data, "image/jpeg");
            }
            
        }

    }
}