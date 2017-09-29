using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTNode<T> where T : class{

	public enum State
	{
		None,
		Success,
		InProgress,
		Fail
	}

	protected T _blackBoard;

	public void SetBlackBoard(T blackBoard){
		_blackBoard = blackBoard;
	}

	protected abstract State OnUpdate ();
	protected virtual void Awake (){}
	protected virtual void Sleep (){}

	State actualState = State.None;

	public State Update(){
		if (actualState == State.None) {
			Awake ();
		}
		actualState = OnUpdate ();
		if (actualState != State.InProgress) {
			Sleep ();
		}
		return actualState;
	}
}