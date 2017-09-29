using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LogicNode<T> : BTNodeWithChildren<T> where T : class{

	public override bool AddChild (BTNode<T> node)
	{
		if (node is ConditionalNode<T> || node is DecoratorNode<T>) {
			if (Children.Count < 2) {
				return base.AddChild (node);
			}
		}
		return false;
	}
}
