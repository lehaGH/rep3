using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication6_2.Models
{
    public class ModelContext : DbContext
    {
        // Контекст настроен для использования строки подключения "ModelContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "WebApplication6_2.Models.ModelContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ModelContext" 
        // в файле конфигурации приложения.
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public virtual DbSet<DataImg> DataImg { get; set; }
        public virtual DbSet<DataIP> DataIP { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class DataImg
    {
        [Key]
        public int id { get; set; }

        public string UserName { get; set; }

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