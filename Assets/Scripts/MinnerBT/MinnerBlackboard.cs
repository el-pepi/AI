using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinnerBlackboard : MonoBehaviour {

	public int rocksLeft = 10;
	public int capacity = 5;
	public int carrying = 0;

	public Transform minner;
	public Transform mine;
	public Transform house;

	public Text uiText;

	SequencerNode<MinnerBlackboard> root;

	void Start () {
		root = MinnerBTBuilder.Build (this);
	}

	void Update () {
		root.Update ();
		uiText.text = "Left: " + rocksLeft + "\nCarying: " + carrying + " / " + capacity ;
	}
}
