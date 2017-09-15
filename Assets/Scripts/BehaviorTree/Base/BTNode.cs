using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTNode {

	public enum State
	{
		None,
		Success,
		InProgress,
		Fail
	}

    List<BTNode> children = new List<BTNode>();

	protected List<BTNode> Children
    {
        get
        {
            return children;
        }
    }

	protected virtual bool AddChild(BTNode node)
    {
        children.Add(node);
        return true;
    }

	protected abstract State OnUpdate ();

	public State Update(){
		return OnUpdate ();
	}
}
//TODO: terminar Update, llama awake y sleep cuando es necesario. Sacar children de node base. Hacer funcion Reset.