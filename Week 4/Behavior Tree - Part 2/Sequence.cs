using System.Collections.Generic;

namespace BehaviorTree  
{
	public class Sequence : Node
	{
		// This constructor creates a Sequence node with an empty list of children.
		public Sequence() : base() { }
		// This constructor creates a Sequence node with a list of children nodes.
			public Sequence(List<Node> children) : base(children){}

// The Evaluate method evaluates the children nodes in order.
		// If a child node returns NodeState.FAILURE, the sequence returns NodeState.FAILURE.
		// If a child node returns NodeState.SUCCESS, the sequence continues to evaluate the next child node.
		// If a child node returns NodeState.RUNNING, the sequence returns NodeState.RUNNING.
		// If all child nodes return NodeState.SUCCESS, the sequence returns NodeState.SUCCESS.
		public override NodeState Evaluate()
		{
			bool anyChildIsRunning = false;

			// Evaluate each child node in the list.
			foreach(Node node in children)
			{
				switch(node.Evaluate())
				{
					case NodeState.FAILURE:
						state = NodeState.FAILURE;
						return state;
					case NodeState.SUCCESS:
						continue;
					case NodeState.RUNNING:
						anyChildIsRunning = true;
						continue;
					default:
					state = NodeState.SUCCESS;
						return state;
				}
			}
			state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
			return state;
		}



	}
}