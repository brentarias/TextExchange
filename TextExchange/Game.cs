using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextExchange.Interaction;

namespace TextExchange
{
    public class Game
    {
        private GameParts parts;
        private Area currentArea;
        private readonly string startPoint = "The Valley Garden";

        public Game(GameParts gameParts)
        {
            parts = gameParts;

            foreach(var area in parts.Areas)
            {
                if (area.Name == startPoint)
                {
                    currentArea = area;
                }
            }

            if (currentArea == null)
            {
                throw new InvalidOperationException($"The start point called '{startPoint}' could not be found.");
            }
        }

        public void Run()
        {
            Console.WriteLine();
            string lastView = null;
            while (true)
            {
                string description = currentArea.Describe();
                if (lastView != description)
                {
                    Console.WriteLine(description);
                    lastView = description;
                }
                Console.WriteLine();
                Console.WriteLine("What now?");
                var verbage = Console.ReadLine();
                var command = parts.Interpreter.InterpretCommand(verbage);

                //Now somebody's code must use the command
                //to make things happen, such as...
                // * Move from one room to another.
                // * Interacting with objects.
                Console.WriteLine($"Subject '{command.Subject}' and action '{command.Action}'");
            }
        }
    }
}
