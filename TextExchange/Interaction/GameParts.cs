using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextExchange.Interaction
{
    public class GameParts
    {
        public Interpreter Interpreter;
        public Area[] Areas;

        public GameParts(Interpreter interpreter, Area[] areas)
        {
            Interpreter = interpreter;
            Areas = areas;
        }

    }
}
