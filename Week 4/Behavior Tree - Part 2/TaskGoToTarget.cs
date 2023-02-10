using System.Collections;
using System.Collections;
using UnityEngine;

using BehaviorTree;

public class TaskGoToTarget : Node
{
    // A reference to the Transform component of the game object that this node is attached to.
    private Transform _transform;

    public TaskGoToTarget(Transform transform)
    {
        // Store the reference to the Transform component.
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        // Get the target transform from the data dictionary.
        Transform target = (Transform)GetData("target");

        // Check if the distance to the target is greater than 0.01.
        if (Vector3.Distance(_transform.position, target.position) > 0.01f)
        {
            // Move the game object towards the target.
            _transform.position = Vector3.MoveTowards(
                _transform.position, target.position, GuardBT.speed * Time.deltaTime);
            // Rotate the game object to look at the target.
            _transform.LookAt(target.position);
        }

        // Return NodeState.RUNNING, because the task is still in progress.
        state = NodeState.RUNNING;
        return state;
    }
}