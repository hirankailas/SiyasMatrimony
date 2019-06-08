using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiyasMatrimony.API.Helper
{
    public enum ProfileFor
    {
        MySelf = 0,
        Son = 1,
        Daughter = 2,
        Brother = 3,
        Syster = 4,
        Relative = 5,
        Friend = 6
    }

    public enum BodyTpes
    {
        Slim = 0,
        Average = 1,
        Athletic = 2,
        Heavy = 3
    }

    public enum Complexions
    {
        VeryFair = 0,
        Fair = 1,
        Wheatish = 2,
        WheatishBrown = 3
    }

    public enum PhysicalStatus
    {
        Normal = 0,
        PhysicallyChallenged = 1
    }
}