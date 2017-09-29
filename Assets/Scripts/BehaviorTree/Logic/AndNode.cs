using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndNode<T> : LogicNode<T> where T : class{

	protected override State OnUpdate ()
	{
		foreach (BTNode<T> n in Children) {
			if (n.Update () == State.Fail) {
				return State.Fail;
			}
		}
		return State.Success;
	}
}
