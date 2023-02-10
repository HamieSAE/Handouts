using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

// TaskPatrol is a subclass of Node that represents a task in the behavior tree
public class TaskPatrol : Node
{
	private Transform _transform;
	private Animator _animator;
	private Transform[] _waypoints;

	private int _currentWaypointIndex = 0;

	private float _waitTime = 1f;
	private float _waitCounter = 0f;
	private bool _waiting = false;

	// Constructor takes a transform, an array of transforms (representing waypoints), 
		//and an animator component.
	
	public TaskPatrol(Transform transform, Transform[] waypoints)
	{
		_transform = transform;
		_animator = transform.GetComponent<Animator>();
		_waypoints = waypoints;
	}

	// The Evaluate method is called to evaluate the state of the task.
	public override NodeState Evaluate()
	{
		// If the character is waiting at a waypoint
		if(_waiting)
		{
			// Check if the waiting time has passed
			_waitCounter += Time.deltaTime;
			if(_waitCounter >= _waitTime)
			{
				_waiting = false;
				_animator.SetBool("Walking", true);
			}
		}
		else
		{
			// Get the current waypoint
			Transform wp = _waypoints[_currentWaypointIndex];
			// If the character has reached the waypoint
			if(Vector3.Distance(_transform.position, wp.position) < 0.01f)
			{
				_transform.position = wp.position;
				_waitCounter = 0f;
				_waiting = true;

				_currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
				_animator.SetBool("Walking", false);
			}
			else
			{
				_transform.position = Vector3.MoveTowards(_transform.position, wp.position, speed * Time.deltaTime);
				_transform.LookAt(wp.position);
			}
		}

		state = NodeState.RUNNING;
		return state;
	}
}




