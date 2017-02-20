using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6_2.Models
{
    public class ImageRepository:IDisposable
    {
        ModelContext db;

        public ImageRepository()
        {
            db = new ModelContext();
        }

        public List<DataImg> GetAllItems(string username)
        {
            return db.DataImg.Where(x => x.UserName == username).ToList();
        }

        public DataImg GetItem(string link)
        {
            return db.DataImg.Include("requests").Where(x => x.link == link).FirstOrDefault();        
        }

        public void SetItem(DataImg image)
        {
            db.DataImg.Add(image);
            db.SaveChanges();
        }

        public bool RemoveItem(string link, string username)
        {
            var buff = db.DataImg.Include("requests").Where(x => x.link == link).FirstOrDefault();
            if (buff!=null && buff.UserName == username)
            {
                db.DataImg.Remove(buff);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void SaveItem()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}