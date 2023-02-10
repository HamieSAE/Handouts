using System.Collections.Generic;

namespace BehaviorTree  
{
	public class Selector : Node
	{
		// Constructor without arguments
		public Selector() : base() { }
		// Constructor with a list of child nodes
		public Selector(List<Node> children) : base(children){}

		// This method is used to evaluate the state of the selector node
		public override NodeState Evaluate()
		{
			// Loop through all child nodes
			foreach(node.Evaluate())
			{
				// Check the state of the current child node
				switch(node.Evaluate())
				{

					// If the state of the current child node is FAILURE, continue to the next child node
					case NodeState.FAILURE:
						continue;
					// If the state of the current child node is SUCCESS, set the state of the selector node to SUCCESS and return the state
					case NodeState.SUCCESS:
						state = NodeState.SUCCESS;
						return state;
					// If the state of the current child node is RUNNING, set the state of the selector node to RUNNING and return the state
					case NodeState.RUNNING:
						state = NodeState.RUNNING;
						return state;
					// If the state of the current child node is not any of the above, continue to the next child node
					default:
						continue;
				}
			}
			// If all child nodes have been evaluated and none of them returned SUCCESS or RUNNING, set the state of the selector node to FAILURE and return the state
			state = NodeState.FAILURE;
			return state;
		}



	}
}