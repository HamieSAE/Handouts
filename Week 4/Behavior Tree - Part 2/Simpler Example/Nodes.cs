using System;
using UnityEngine;

public enum NodeState
{
    SUCCESS,
    FAILURE,
    RUNNING
}

public abstract class Node
{
    public NodeState state;

    public virtual NodeState Evaluate()
    {
        return NodeState.SUCCESS;
    }
}

public class PatrolNode : Node
{
    public override NodeState Evaluate()
    {
        // Code to patrol around the area
        Debug.Log("Patrolling");

        state = NodeState.SUCCESS;
        return state;
    }
}

public class ChaseNode : Node
{
    public override NodeState Evaluate()
    {
        // Code to chase the player
        Debug.Log("Chasing");

        state = NodeState.SUCCESS;
        return state;
    }
}

public class AttackNode : Node
{
    public override NodeState Evaluate()
    {
        // Code to attack the player
        Debug.Log("Attacking");

        state = NodeState.SUCCESS;
        return state;
    }
}

