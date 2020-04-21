using Unity.Entities;

[GenerateAuthoringComponent]
public struct PladdleMovementData : IComponentData
{
    public int direction;
    public float speed;
}
