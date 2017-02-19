using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6_2.Models
{
    public class DataImg
    {
        [Key]
        public int id { get; set; }

        public DateTime time { get; set; }

        public string link { get; set; }

        public string text { get; set; }

        public byte[] data { get; set; }

        public List<DataIP> requests { get; set; }
    }

    public class DataIP
    {
        [Key]
        public int id { get; set; }

        public string ip { get; set; }

        public DateTime time { get; set; }
    }
}