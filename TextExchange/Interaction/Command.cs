using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextExchange.Interaction
{
    public class Command
    {
        public Subject Subject;
        public Action Action = Action.Unknown;
    }
}
