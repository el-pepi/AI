using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotNode : DecoratorNode {

	protected override State OnUpdate ()
	{
		if (Children.Count == 1) {
			State tempState = Children [0].Update ();
			if (tempState == State.Fail) {
				return State.Success;
			}
		}
		return State.Fail;
	}
}
