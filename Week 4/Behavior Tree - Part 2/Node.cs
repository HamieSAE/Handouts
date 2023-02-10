using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
	    // Enum to represent the state of a node in the Behavior Tree
	public enum NodeState
	{
		RUNNING, SUCCESS, FAILURE,
	}

    // Base class for all nodes in the Behavior Tree
	public class Node
	{
        // Current state of the node
		protected NodeState state;

        // Parent node of the current node
		public Node parent;
        // List of children nodes of the current node
		protected List<Node> children = new List<Node>();

        // Dictionary to store data context that can be passed between nodes
		private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

        // Constructor to set the parent node to null
		public Node()
		{
			parent = null;
		}
        // Constructor to add children nodes to the current node
		public Node(List<Node> children)
		{
			foreach (Node child in children)
			_Attach(child);
		}

	     // Method to attach a child node to the current node
		private void _Attach(Node node)
		{
			node.parent = this;
			children.Add(node);
		}
        // Abstract method to evaluate the state of the node
		public virtual NodeState Evaluate() => NodeState.FAILURE;
        // Method to set data in the data context
		public void SetData(string key, object value)
		{
			_dataContext[key] = value;
		}
        // Method to clear data from the data context
		public bool ClearData(string key)
		{
            // Check if the key is present in the current node's data context
			if(_dataContext.ContainKey(key))
			{
				// If present, remove it from the data context
				_dataContext.Remove(key);
				return true;

			}
            // If not present, traverse the parent nodes to look for the key
			Node node = parent;
			while(node != null)
			{
                // Call the ClearData method on the parent node
				bool cleared = node.ClearData(key);
                // If the key is found, return true
				if (cleared)
					return true;
                // If not found, set the node to its parent
					node = node.parent;
			}
            // If the key is not found in any node, return false
			return false;
		}
	}
}




