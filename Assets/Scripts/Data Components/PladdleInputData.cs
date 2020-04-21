using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct PladdleInputData : IComponentData
{
    public KeyCode upKey;
    public KeyCode downKey;
}
