using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerNode : BTNode {
	protected override State OnUpdate ()
	{
		foreach (BTNode n in Children) {
			if (n.Update () != State.Success) {
				return State.Fail;
			}
		}
		return State.Success;
	}
}
