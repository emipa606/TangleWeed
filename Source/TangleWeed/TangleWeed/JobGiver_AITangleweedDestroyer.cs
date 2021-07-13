using System.Linq;
using RimWorld;
using TangleWeed.AI;
using Verse;
using Verse.AI;
using Verse.AI.Group;

namespace TangleWeed
{
    // Modeled after JobGiver_AISapper
    public class JobGiver_AITangleweedDestroyer : ThinkNode_JobGiver
    {
        protected override Job TryGiveJob(Pawn pawn)
        {
            var vector = (IntVec3) pawn.mindState.duty.focus;
            if (vector.IsValid && (float) vector.DistanceToSquared(pawn.Position) < 100 &&
                vector.GetRoomOrAdjacent(pawn.Map) == pawn.GetRoom(RegionType.Set_Passable) &&
                vector.WithinRegions(pawn.Position, pawn.Map, 9, TraverseMode.NoPassClosedDoors))
            {
                pawn.GetLord().Notify_ReachedDutyLocation(pawn);
                return null;
            }

            if (!vector.IsValid)
            {
                if (!(from x in pawn.Map.attackTargetsCache.GetPotentialTargetsFor(pawn)
                    where !x.ThreatDisabled(pawn) && x.Thing.Faction == Faction.OfPlayer && pawn.CanReach(x.Thing,
                        PathEndMode.OnCell, Danger.Deadly, false, false, TraverseMode.PassAllDestroyableThings)
                    select x).TryRandomElement(out var attackTarget))
                {
                    return null;
                }

                vector = attackTarget.Thing.Position;
            }

            if (!pawn.CanReach(vector, PathEndMode.OnCell, Danger.Deadly, false, false,
                TraverseMode.PassAllDestroyableThings))
            {
                return null;
            }

            using (var pawnPath = pawn.Map.pathFinder.FindPath(pawn.Position, vector,
                TraverseParms.For(pawn, Danger.Deadly, TraverseMode.PassAllDestroyableThings)))
            {
                var thing = pawnPath.FirstTangleweed(out _, pawn);

                if (thing == null)
                {
                    return new Job(JobDefOf.Goto, vector, 500, true);
                }

                var job = AttackPlantUtility.AttackPlant(pawn, thing);
                if (job != null)
                {
                    return job;
                }
            }

            return new Job(JobDefOf.Goto, vector, 500, true);
        }
    }
}