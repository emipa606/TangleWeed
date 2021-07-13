using RimWorld;
using Verse;
using Verse.AI;

namespace TangleWeed
{
    // Modeled after Rimworld's internal TrashUtility class
    internal static class AttackPlantUtility
    {
        //
        // Static Fields
        //
        private static readonly IntRange TrashJobCheckOverrideInterval = new IntRange(450, 500);

        //
        // Static Methods
        //

        private static void FinalizeTrashJob(Job job)
        {
            job.expiryInterval = TrashJobCheckOverrideInterval.RandomInRange;
            job.checkOverrideOnExpire = true;
            job.expireRequiresEnemiesNearby = true;
        }

        public static Job AttackPlant(Pawn pawn, Thing t)
        {
            var job = new Job(JobDefOf.Ignite, t);
            FinalizeTrashJob(job);
            return job;
        }
    }
}