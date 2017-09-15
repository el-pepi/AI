using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : BTNode {
	protected override State OnUpdate ()
	{
		foreach (BTNode n in Children) {
			if (n.Update () == State.Success) {
				return State.Success;
			}
		}
		return State.Fail;
	}
}