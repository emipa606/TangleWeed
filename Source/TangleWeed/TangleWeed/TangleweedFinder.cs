using Verse;
using Verse.AI;

namespace TangleWeed.AI
{
    // Modeled after the PawnPathUtility class which gives an extension method on PawnPath 
    public static class TangleweedFinder
    {
        public static Thing FirstTangleweed(this PawnPath path, out IntVec3 cellBefore, Pawn pawn = null)
        {
            if (!path.Found)
            {
                cellBefore = IntVec3.Invalid;
                return null;
            }

            var nodesReversed = path.NodesReversed;
            if (nodesReversed.Count == 1)
            {
                cellBefore = nodesReversed[0];
                return null;
            }

            var unused = IntVec3.Invalid;

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

                cellBefore = nodesReversed[i + 1];
                return plant;
            }

            cellBefore = nodesReversed[0];
            return null;
        }
    }
}