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
            return db.DataImg.Where(x => x.link == link).FirstOrDefault();        
        }

        public void SetItem(DataImg image)
        {
            db.DataImg.Add(image);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}