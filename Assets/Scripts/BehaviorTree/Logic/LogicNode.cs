using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LogicNode : BTNode {

	protected override bool AddChild (BTNode node)
	{
		if (node is ConditionalNode || node is DecoratorNode) {
			if (Children.Count < 2) {
				return base.AddChild (node);
			}
		}
		return false;
	}
}
