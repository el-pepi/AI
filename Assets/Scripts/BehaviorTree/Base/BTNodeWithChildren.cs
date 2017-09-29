using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTNodeWithChildren<T> : BTNode<T> where T : class{

	List<BTNode<T>> children = new List<BTNode<T>>();

	public virtual bool AddChild(BTNode<T> node)
	{
		children.Add(node);
		return true;
	}

	protected List<BTNode<T>> Children
	{
		get
		{
			return children;
		}
	}
}
