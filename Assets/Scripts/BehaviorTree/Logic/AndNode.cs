using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndNode : LogicNode {

	protected override State OnUpdate ()
	{
		foreach (BTNode n in Children) {
			if (n.Update () == State.Fail) {
				return State.Fail;
			}
		}
		return State.Success;
	}

}
