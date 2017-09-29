using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorNode<T> : BTNodeWithChildren<T> where T : class{

	public override bool AddChild (BTNode<T> node)
	{
		if (Children.Count == 0) {
			return base.AddChild (node);
		} else {
			return false;
		}
	}
}
