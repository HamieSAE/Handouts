using System.Collections;
using System.Collections.Generic;

namespace BehaviorTree
{
	public enum NodeState
	{
		RUNNING, SUCCESS, FAILURE,
	}

	public class Node
	{
		protected NodeState state;

		public Node parent;
		protected List<Node> children = new List<Node>();

		private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

		public Node()
		{
			parent = null;
		}
		public Node(List<Node> children)
		{
			foreach (Node child in children)
			_Attach(child);
		}

		private void _Attach(Node node)
		{
			node.parent = this;
			children.Add(node);
		}

		public virtual NodeState Evaluate() => NodeState.FAILURE;

		public void SetData(string key, object value)
		{
			_dataContext[key] = value;
		}

		public bool ClearData(string key)
		{
			//object value = null;
			if(_dataContext.ContainKey(key))
			{
				_dataContext.Remove(key);
				return true;

			}
			
			Node node = parent;
			while(node != null)
			{
				bool cleared = node.ClearData(key);
				if (cleared)
					return true;
					node = node.parent;
			}
			return false;
		}
	}
}




