using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[AlwaysSynchronizeSystem] 
public class PlayerInputSystem : JobComponentSystem
{
    public int direction;
    public float speed;

    // Not the greatest syntax
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        inputDeps.Complete();
        // ref = write into, in reading from
        //all "ref param" are 1st in the argument list then come "in param"
        Entities.ForEach((ref PladdleMovementData moveData, in PladdleInputData inputData) =>
        {
            moveData.direction = 0;

            // Need to be on the main thread
            moveData.direction += Input.GetKey(inputData.upKey) ? 1 : 0;
            moveData.direction -= Input.GetKey(inputData.downKey) ? 1 : 0;
        }).Run(); // will run on the main thread

        return default; // we dont need inputDeps since we use AlwaysSynchronizeSystem (because we want to use main thread)
    }

    private void Start()
    {
        Debug.Log("Hello i'm here");
    }
}
