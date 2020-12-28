using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Ajedrez {
    class Program {
        [STAThread]
        static void Main(string[] args) {
    

            Tablero tablero = new Tablero();
            tablero.inicializarTablero();

            Application.EnableVisualStyles();
            Application.Run(new AjedrezWindow(tablero));

        }
    }
}
