using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorNode : BTNode {

	public override bool AddChild (BTNode node)
	{
		if (Children.Count == 0) {
			return base.AddChild (node);
		} else {
			return false;
		}
	}
}
