using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MovesSide", story: "[Agent] MovesSide [WithSpeed]", category: "Action", id: "db7e96895b4bbc263b338f1184379668")]
public partial class MovesSideAction : Action
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
        Rb2D.Value.linearVelocity = Agent.Value.transform.up*WithSpeed.Value;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

