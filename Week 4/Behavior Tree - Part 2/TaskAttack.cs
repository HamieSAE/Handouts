using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskAttack : Node
{
	// Declaration of a private Animator component
	private Animator _animator;
	// Declaration of a private Transform component that will store the last target
	private Transform _lastTarget;
	// Declaration of a private EnemyManager component
	private EnemyManager _enemyManager;
	// Declaration of a private float to store the attack time
	private float _attackTime = 1f;
	// Declaration of a private float to store the attack counter
	private float _attackCounter = 0f;
	// Constructor for the class that takes a Transform as an argument
	public TaskAttack(Transform transform)
	{
		// Initializing the _animator component using 
			//the GetComponent method on the transform argument
		_animator = transform.GetComponent<Animator>();
	}
	// Override method for evaluating the node
	public override NodeState Evaluate()
	{
		// Getting the target Transform data from the Behavior Tree data
		Transform target = (Transform)GetData("target");
		
		// Checking if the target has changed
		if(target != _lastTarget)
		{
			// If the target has changed, getting the EnemyManager component from the target
			_enemyManager = target.GetComponent<EnemyManager>();
			// Storing the new target as the last target
			_lastTarget = target;
		}
		// Increasing the attack counter with the delta time
		_attackCounter += Time.deltaTime;
		// Checking if the attack counter is greater than or equal to the attack time
		if(_attackCounter >= _attackTime)
		{
			// If the attack counter is greater, calling the TakeHit method on the enemy manager and storing the result in a boolean variable
			bool enemyIsDead = _enemyManager.TakeHit();
			// Checking if the enemy is dead			
			if(enemyIsDead)
			{
				// If the enemy is dead, clearing the target data from the Behavior Tree data
				ClearData("target");
				// Setting the Attacking boolean parameter in the Animator component to false
				_animator.SetBool("Attacking", false);
				// Setting the Walking boolean parameter in the Animator component to true
				_animator.SetBool("Walking", true);
			}
			else
			{
				// If the enemy is not dead, resetting the attack counter to 0
				_attackCounter = 0f;
			}
		}
		// Setting the state of the node to RUNNING		
		state = NodeState.RUNNING;
		// Returning the node state
		return state;
	}
}