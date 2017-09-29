using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionalNode<T> : BTNode<T> where T : class{
	protected override State OnUpdate ()
	{
		if (Evaluate ()) {
			return State.Success;
		} else {
			return State.Fail;
		}
	}

	public virtual bool Evaluate(){
		return false;
	}
}
