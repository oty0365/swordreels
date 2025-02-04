using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.VisualScripting;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "LookAtPlayer", story: "[Agent] Looks [Target]", category: "Action", id: "0cd1428125d0b9f78688f6e0f53cfe3c")]
public partial class LookAtPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        var dir = Mathf.Atan2(Target.Value.transform.position.y-Agent.Value.transform.position.y, Target.Value.transform.position.x - Agent.Value.transform.position.x)*Mathf.Rad2Deg;
        Agent.Value.transform.rotation = Quaternion.Euler(0, 0, dir);
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

