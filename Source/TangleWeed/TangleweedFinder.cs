using Verse;
using Verse.AI;

namespace TangleWeed.AI;

// Modeled after the PawnPathUtility class which gives an extension method on PawnPath 
public static class TangleweedFinder
{
    public static Thing FirstTangleweed(this PawnPath path, Pawn pawn = null)
    {
        if (!path.Found)
        {
            return null;
        }

        var nodesReversed = path.NodesReversed;
        if (nodesReversed.Count == 1)
        {
            return null;
        }

        _ = IntVec3.Invalid;

        for (var i = nodesReversed.Count - 2; i >= 1; i--)
        {
            if (pawn == null)
            {
                continue;
            }

            var plant = nodesReversed[i].GetPlant(pawn.Map);
            if (plant == null)
            {
                continue;
            }

            if (plant.Label != "tangleweed vine")
            {
                continue;
            }

            return plant;
        }

        return null;
    }
}