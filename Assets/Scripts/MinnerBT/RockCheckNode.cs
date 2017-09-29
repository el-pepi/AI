using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCheckNode<T> : ConditionalNode<T> where T : MinnerBlackboard{

	public override bool Evaluate ()
	{
		return _blackBoard.rocksLeft > 0;
	}
}
