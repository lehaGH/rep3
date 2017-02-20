using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6_2.Models
{
    public class ImageViewModel
    {
        [Display(Name = "ссылка на картинку")]
        public string link { get; set; }

        [Display(Name = "описание картинки")]
        public string text { get; set; }

        [Display(Name = "имя пользавателя загрузившего картинку")]
        public string user { get; set; }

        public byte[] data { get; set; }

        public string types = "image/jpeg";

        public List<IPViewModel> requests { get; set; }
    }

    public class IPViewModel
    {
        [Display(Name = "ip адрес клиента")]
        public string ip { get; set; }
        [Display(Name="Дата доступа")]
        public DateTime time { get; set; }
    }
}