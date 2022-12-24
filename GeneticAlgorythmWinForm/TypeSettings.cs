using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythmWinForm
{
    public enum CrossingType
    {
        Point,
        Flat,
        Simplest,
        Arithmetic,
        Geometry,
        Linear
    }

    public enum MutationType
    {
        BinaryRandom,
        RealRandom
    }

    public enum SelectionType
    {
        SimpleSelection,
        PanmixiaSelection,
        RankSelection,
        ToutnamentSelection,
        Inbreeding,
        Outbreeding
    }
}
