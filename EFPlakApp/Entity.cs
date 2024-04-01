
using EFPlakApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonApp.DAL.Repositories.Abstract
{
    public abstract class Entity :IEntity
    {
        public int Id { get; set; }

    }
}
