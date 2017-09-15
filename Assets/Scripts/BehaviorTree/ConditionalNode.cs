using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalNode : BTNodeNoChild {
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
