using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSpaceCheckNode<T> : ConditionalNode<T> where T : MinnerBlackboard{
	public override bool Evaluate ()
	{
		return _blackBoard.carrying < _blackBoard.capacity;
	}
}
