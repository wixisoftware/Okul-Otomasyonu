using Ninject.Modules;
using OKUL_OTOMASYON.Business.Abstract;
using OKUL_OTOMASYON.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKUL_OTOMASYON.Business.Dependency.Ninject
{
    public  class BusinessModel:NinjectModule
    {
        // Bizim Yönlendirme Kutumuz
        public override void Load()
        {

            Bind<ITeachersServices>().To<TeachersManager>();

        }
    }
}
