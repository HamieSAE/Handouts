using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree  
{
	public class Tree : MonoBehaviour
	{
		private Node _root = null;
		// The Start function is called when the component is first enabled
		// It sets up the tree by calling the abstract method SetupTree and assigning the returned 
			//Node object to the `_root` variable
		protected void Start()
		{
			_root = SetupTree();
		}
		// The Update function is called once per frame. It evaluates the tree 
			//by calling the Evaluate method of the `_root` node if it's not null
		private void Update()
		{
			if(_root != null)
				_root.Evaluate();
		}
		
		// The SetupTree method is abstract and must be implemented by a subclass.
		// It's used to set up the tree and return the root node.
		protected abstract Node SetupTree();
	}
}




