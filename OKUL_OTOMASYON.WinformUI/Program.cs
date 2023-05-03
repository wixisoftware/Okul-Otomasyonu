using Ninject;
using OKUL_OTOMASYON.Business.Dependency.Ninject;
using OKUL_OTOMASYON.WinformUI.UserOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKUL_OTOMASYON.WinformUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CompositionRoot.Initialize();


            Application.Run(CompositionRoot.Resolve<Login>());
        }

    }

    public class CompositionRoot {

        private static IKernel kernel;
        public static void Initialize(){ 

            kernel = new StandardKernel(new BusinessModel()); 

        }    


        public static T Resolve<T>() {

            return kernel.Get<T>();
        }

    }

}
