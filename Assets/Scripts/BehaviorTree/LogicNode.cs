using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicNode : BTNode {

	public override bool AddChild (BTNode node)
	{
		if (Children.Count < 2) {
			return base.AddChild (node);
		} else {
			return false;
		}
	}
}
