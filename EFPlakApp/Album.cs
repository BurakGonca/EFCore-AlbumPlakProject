using MaratonApp.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPlakApp
{
    public class Album:Entity
    {
        //public int Id { get; set; }
        public string AlbumAdi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public double Fiyat { get; set; }
        public double? IndirimOrani { get; set; }

        public Status Status { get; set; }
        public int? SanatciId { get; set; }
        public Sanatci Sanatci { get; set; }


    }
}
