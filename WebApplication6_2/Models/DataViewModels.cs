using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6_2.Models
{
    public class ImageViewModel
    {
        public int id { get; set; }
        public string link { get; set; }
        public string text { get; set; }
        public string user { get; set; }
        public byte[] data { get; set; }

        static const string type = "image/jpeg";
    }
}