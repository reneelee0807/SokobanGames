using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FilerNS;
using System.Windows.Forms;
using GameNS;

namespace SokobanExampleSolution
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IView View = new WinFormView();
            IFiler Filer = new Filer();
            // GameController gameController = new GameController(new Game(null), View);
            GameController gameController = new GameController(new GameNS.Game(Filer), View);
            //FilerController ex = new FilerController(new Filer(), View);
            GameForm gameBoard = new GameForm(View, gameController);

            Application.Run(gameBoard);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //IView view = new WinFormView();
            
            //FilerForm f = new FilerForm(view, ex);

            //Application.Run(f);
        }
    }
}
