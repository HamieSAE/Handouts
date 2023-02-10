using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class CheckEnemyInAttackRange : Node
{
	private static int _enemyLayerMask = 1 << 6;
    // layer mask to represent enemy layer, it is a bit shift operation to select 6th layer

	private Transform _transform;
	private Animator _animator;

	public CheckEnemyInAttackRange(Transform transform)
	{
		_transform = transform; // store the transform component of the object
		_animator = transform.GetComponent<Animator>(); // store the animator component of the object
	}

	public override NodeState Evaluate()
	{
		object t = GetData("target"); // get the data "target" stored in the parent node
		if(t == null) // if the data is not stored
		{
			state = NodeState.FAILURE; // set the state to failure
			return state;
		}

		Transform target = (Transform)t; // cast the data to Transform type
		if(Vector3.Distance(_transform.position, target.position) <= GuardBT.attackRange)
        // if the distance between the position of the object and the target is less than or equal to the attack range
		{
			_animator.SetBool("Attacking", true); // set the "Attacking" bool in the animator to true
			_animator.SetBool("Walking", false); // set the "Walking" bool in the animator to false

			state = NodeState.SUCCESSFUL; // set the state to successful
			return state;
		}

		state = NodeState.FAILURE; // if the condition is not met, set the state to failure
		return state;
	}
}