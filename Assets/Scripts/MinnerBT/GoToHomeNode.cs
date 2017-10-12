using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHomeNode<T> : BTNode<T> where T : MinnerBlackboard {

	const float walkSpeed = 5f;

	protected override State OnUpdate ()
	{
		Vector3 dir = _blackBoard.house.position - _blackBoard.minner.transform.position;

		if (dir.magnitude <= (dir.normalized * walkSpeed * Time.deltaTime).magnitude) {
			_blackBoard.minner.position = _blackBoard.house.position;
			return State.Success;
		} else {
			_blackBoard.minner.transform.position += dir.normalized * walkSpeed * Time.deltaTime;
			return State.InProgress;
		}
	}
}
