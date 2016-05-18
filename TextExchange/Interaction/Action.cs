using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextExchange.Interaction
{
    public enum Action
    {
        Unknown, //The default when the user's command could not be understood.
        Take,
        TakeSword,
        AttackSword,
        AttackArrow,
        Look,
        LookNorth,
        LookSouth,
        LookEast,
        LookWest,
        North,
        South,
        East,
        West
    }
}
