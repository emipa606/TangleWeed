using RimWorld;
using Verse;
using Verse.AI;

namespace TangleWeed;

// Modeled after Rimworld's internal TrashUtility class
internal static class AttackPlantUtility
{
    //
    // Static Fields
    //
    private static readonly IntRange trashJobCheckOverrideInterval = new(450, 500);

    //
    // Static Methods
    //

    private static void finalizeTrashJob(Job job)
    {
        job.expiryInterval = trashJobCheckOverrideInterval.RandomInRange;
        job.checkOverrideOnExpire = true;
        job.expireRequiresEnemiesNearby = true;
    }

    public static Job AttackPlant(Thing t)
    {
        var job = new Job(JobDefOf.Ignite, t);
        finalizeTrashJob(job);
        return job;
    }
}