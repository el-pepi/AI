using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencerNode<T> : BTNodeWithChildren<T> where T : class{

	int lastIndex = 0;

	protected override State OnUpdate ()
	{
		for (int i = lastIndex; i < Children.Count; i++) {
			State s = Children [i].Update ();
			if (s == State.InProgress) {
				lastIndex = i;
			}
			if(Children[i].Update() != State.Success){
				return s;
			}
		}
		return State.Success;
	}

	protected override void Sleep ()
	{
		lastIndex = 0;
	}
}
