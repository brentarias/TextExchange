using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextExchange.Initialization;
using TextExchange.Interaction;

namespace TextExchange
{
    class Program
    {

        static void Main(string[] args)
        {
            var dir = Path.Combine(Environment.CurrentDirectory, @"..\..");
            var gameInfo = new Startup(dir);
            var gameParts = gameInfo.Load();
            var game = new Game(gameParts);

            game.Run();
        }
    }
}
