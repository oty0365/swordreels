using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveForward", story: "[Agent] MovesForward [WithSpeed]", category: "Action", id: "91a4cb4061e4b015c8acf081cbd4a447")]
public partial class MoveForwardAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Rigidbody2D> Rb2D;
    [SerializeReference] public BlackboardVariable<float> WithSpeed;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Rb2D.Value.linearVelocity = Agent.Value.transform.right*WithSpeed.Value;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

