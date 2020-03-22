using RimWorld;
using System;
using System.Collections.Generic;
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
            List<IntVec3> nodesReversed = path.NodesReversed;
            if (nodesReversed.Count == 1)
            {
                cellBefore = nodesReversed[0];
                return null;
            }
            IntVec3 vector = IntVec3.Invalid;

            for (int i = nodesReversed.Count - 2; i >= 1; i--)
            {
                Plant plant = nodesReversed[i].GetPlant(pawn.Map);
                if (plant != null)
                {
                    if (plant.Label == "tangleweed vine")
                    {
                        cellBefore = nodesReversed[i + 1]; ;
                        return plant;
                    }
                }
            }
            cellBefore = nodesReversed[0];
            return null;
        }
    }
}

