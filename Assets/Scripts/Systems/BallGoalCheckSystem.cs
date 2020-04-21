using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Physics;

[AlwaysSynchronizeSystem]
public class BallGoalCheckSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        EntityCommandBuffer ecb = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);

        Entities
            .WithAll<BallTag>()
            .WithoutBurst()
            //.WithStructuralChanges() // Allow to modify entities => here we have DestroyEntity
            // However it will make a specialised copy of the data so it can slow down if there is a lot of copies
            .ForEach((Entity entity, in Translation trans) =>
        {
            float3 pos = trans.Value;
            float bound = GameManager.main.xBound;

            if(pos.x >= bound)
            {
                GameManager.main.PlayerScored(0); // main Thread
                ecb.DestroyEntity(entity);
                // EntityManager.DestroyEntity(entity); // main Thread, with WithStructuralChanges syntax

            }
            else if(pos.x <= -bound)
            {
                GameManager.main.PlayerScored(1);
                ecb.DestroyEntity(entity);
                // EntityManager.DestroyEntity(entity); // main Thread, with WithStructuralChanges syntax
            }
        }).Run();

        ecb.Playback(EntityManager);
        ecb.Dispose();

        return default;
    }
}
