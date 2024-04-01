using MaratonApp.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPlakApp
{
    public class Sanatci:Entity
    {
        //public int Id { get; set; }
        public string SanatciAdi { get; set; }
        public string SanatciSoyadi { get; set; }


        List<Album> Albumler { get; set; }
        public override string ToString()
        {
            return SanatciAdi + " " + SanatciSoyadi;
        }
    }
}
