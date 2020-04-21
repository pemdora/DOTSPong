using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class PaddleMovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;
        float ybound = GameManager.main.yBound;

        // Example of job
        /*
        JobHandle myJob = Entities.ForEach((ref Translation trans, in PladdleMovementData data) =>
        {
            trans.Value.y = math.clamp(trans.Value.y + (data.speed * data.direction * deltaTime), -ybound, ybound);
        }).Schedule(inputDeps);

        return myJob;*/

        Entities.ForEach((ref Translation trans, in PladdleMovementData data) =>
        {
            trans.Value.y = math.clamp(trans.Value.y + (data.speed * data.direction * deltaTime), -ybound, ybound);
        }).Run();

        return default;
    }
}
