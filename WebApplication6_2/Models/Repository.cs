using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6_2.Models
{
    public class ImageRepository
    {
        ModelContext db;

        public ImageRepository()
        {
            db = new ModelContext();
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
    }
}