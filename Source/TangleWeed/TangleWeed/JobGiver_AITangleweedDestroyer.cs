using System;
using System.Linq;
using Verse;
using Verse.AI;
using Verse.AI.Group;
using RimWorld;
using System.Collections.Generic;
using TangleWeed.AI;

namespace TangleWeed
{
    // Modeled after JobGiver_AISapper
    public class JobGiver_AITangleweedDestroyer : ThinkNode_JobGiver
    {
        protected override Job TryGiveJob(Pawn pawn)
        {
            IntVec3 vector = (IntVec3)pawn.mindState.duty.focus;
            if (vector.IsValid && (float)vector.DistanceToSquared(pawn.Position) < 100 && vector.GetRoom(pawn.Map, RegionType.Set_Passable) == pawn.GetRoom(RegionType.Set_Passable) && vector.WithinRegions(pawn.Position, pawn.Map, 9, TraverseMode.NoPassClosedDoors, RegionType.Set_Passable))
            {
                pawn.GetLord().Notify_ReachedDutyLocation(pawn);
                return null;
            }
            if (!vector.IsValid)
            {
                IAttackTarget attackTarget;
                if (!(from x in pawn.Map.attackTargetsCache.GetPotentialTargetsFor(pawn)
                      where !x.ThreatDisabled(pawn) && x.Thing.Faction == Faction.OfPlayer && pawn.CanReach(x.Thing, PathEndMode.OnCell, Danger.Deadly, false, TraverseMode.PassAllDestroyableThings)
                      select x).TryRandomElement(out attackTarget))
                {
                    return null;
                }
                vector = attackTarget.Thing.Position;
            }
            if (!pawn.CanReach(vector, PathEndMode.OnCell, Danger.Deadly, false, TraverseMode.PassAllDestroyableThings))
            {
                return null;
            }
            using (PawnPath pawnPath = pawn.Map.pathFinder.FindPath(pawn.Position, vector, TraverseParms.For(pawn, Danger.Deadly, TraverseMode.PassAllDestroyableThings, false), PathEndMode.OnCell))
            {
                IntVec3 cellBeforeBlocker;
                Thing thing = pawnPath.FirstTangleweed(out cellBeforeBlocker, pawn);

                if (thing != null)
                {
                    Job job = AttackPlantUtility.AttackPlant(pawn, thing);
                    if (job != null)
                    {
                        return job;
                    }
                }
            }
            return new Job(JobDefOf.Goto, vector, 500, true);
        }
    }
}
