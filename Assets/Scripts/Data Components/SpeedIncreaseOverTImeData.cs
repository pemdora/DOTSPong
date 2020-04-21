using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpeedIncreaseOverTImeData : IComponentData
{
    public float increasePerSeconds;
}
