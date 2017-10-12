using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRocksNode<T> : BTNode<T> where T : MinnerBlackboard {

	float timer = 1f;

	protected override State OnUpdate ()
	{
		timer = Mathf.Clamp (timer-Time.deltaTime,0,timer);
		if (timer == 0) {
			timer = 1f;
			if (_blackBoard.carrying > 0) {
				_blackBoard.carrying--;
			} else {
				return State.Success;
			}
		}
		return State.InProgress;
	}
}
