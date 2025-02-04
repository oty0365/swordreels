using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using System.Collections;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Dash", story: "[Agent] Dashes With [MinTime] to [MaxTime]", category: "Action", id: "6af51797317585256d0fadbd3c44d69f")]
public partial class DashAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Rigidbody2D> Rb2D;
    [SerializeReference] public BlackboardVariable<float> MinTime;
    [SerializeReference] public BlackboardVariable<float> MaxTime;
    [SerializeReference] public BlackboardVariable<float> Speed;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Rb2D.Value.linearVelocity = Agent.Value.transform.right * time;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

