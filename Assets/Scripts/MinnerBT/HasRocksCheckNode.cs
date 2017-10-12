using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasRocksCheckNode<T> : ConditionalNode<T> where T : MinnerBlackboard{

	public override bool Evaluate ()
	{
		return _blackBoard.carrying > 0;
	}
}
