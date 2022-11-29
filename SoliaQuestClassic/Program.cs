using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoliaQuestClassic
{
    static class Program
    {
        // RUN WINFORMS

#if true
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
#else
        static void Main(string[] args)
        {
            using (SQGameWindow systemsWindow = new SQGameWindow(960, 540, "Solia Quest Classic"))
            {
                systemsWindow.Run(60.0);
                systemsWindow.Dispose();
            }
        }
#endif


    }
}
