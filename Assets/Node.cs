using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {
	Node parent;

	public Node Parent {
		get {
			return parent;
		}
		set {
			parent = value;
		}
	}

	List<Node> adjacent;
	public int x;
	public int y;

	public int weight = 1;
	public int originalWeight = 1;

	public Node(int x, int y, int w){
		this.x = x;
		this.y = y;
		adjacent = new List<Node> ();
		originalWeight = weight = w;
	}

	public void AddAdjacent(Node node){
		adjacent.Add (node);
	}

	public Node[] GetAdjacents(){
		return adjacent.ToArray ();
	}
}
