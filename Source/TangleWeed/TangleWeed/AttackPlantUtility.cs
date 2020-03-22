using System;
using Verse;
using Verse.AI;
using RimWorld;

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
            job.expiryInterval = AttackPlantUtility.TrashJobCheckOverrideInterval.RandomInRange;
            job.checkOverrideOnExpire = true;
            job.expireRequiresEnemiesNearby = true;
        }

        public static Job AttackPlant(Pawn pawn, Thing t)
        {
            Job job = new Job(JobDefOf.Ignite, t);
            AttackPlantUtility.FinalizeTrashJob(job);
            return job;
        }
    }
}
