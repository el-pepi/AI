using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrNode<T> : LogicNode<T> where T : class{

	protected override State OnUpdate ()
	{
		foreach (BTNode<T> n in Children) {
			if (n.Update () == State.Success) {
				return State.Success;
			}
		}
		return State.Fail;
	}
}
