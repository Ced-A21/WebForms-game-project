using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace IT111_MP
{
 
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Login();
            Application.Run(game.winLogin);
        }
    }
}