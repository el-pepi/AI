using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder {

	public enum Algorithm{
		BreathFirst,
		DepthFirst,
		Dijkstra,
		AStar
	}


	List<Node> nodes;

	List<Node> openNodes;
	List<Node> closedNodes;

	int endX,endY;

	public PathFinder(){
		nodes = new List<Node> ();
		openNodes = new List<Node> ();
		closedNodes = new List<Node> ();
	}

	public void Init(int[,] tiles, int[,] weights){
		for (int x = 0; x < tiles.GetLength(0); x++) {
			for (int y = 0; y < tiles.GetLength(1); y++) {
				if (tiles [x, y] == 0) {
					nodes.Add (new Node(x,y,weights[x,y]));
				}
			}
		}

		for (int x = 0; x < tiles.GetLength(0); x++) {
			for (int y = 0; y < tiles.GetLength(1); y++) {
				if (tiles [x, y] == 0) {
					Node node = GetNodeAt (x,y);
					AddAdjacentToNode (node, GetNodeAt (x-1, y));
					AddAdjacentToNode (node, GetNodeAt (x+1, y));
					AddAdjacentToNode (node, GetNodeAt (x, y-1));
					AddAdjacentToNode (node, GetNodeAt (x, y+1));
				}
			}
		}
	}

	void AddAdjacentToNode(Node node,Node adjacent){
		if (node!= null && adjacent != null) {
			node.AddAdjacent (adjacent);
		}
	}

	public Node GetNodeAt(int x, int y){
		foreach (Node n in nodes) {
			if (n.x == x && n.y == y) {
				return n;
			}
		}

		return null;
	}

	public Node[] GetPath(int startX,int startY,int endX,int endY, Algorithm algorithm){
		this.endX = endX;
		this.endY = endY;

		Node node = GetNodeAt (startX,startY);
		if (node != null) {
			openNodes.Add (node);

			while (openNodes.Count > 0) {

				node = GetOpenNode (algorithm);

				if (CheckNode (node, endX, endY)) {
					List<Node> path = new List<Node> ();
					while (node != null) {
						path.Add (node);
						node = node.Parent;
					}
					Debug.Log ("Nodos cerrados: " + closedNodes.Count);
					return path.ToArray ();
				} else {
					CloseNode (node);
					OpenAdjacents (node,algorithm);
				}
			}
		}
		return null;
	}

	Node GetOpenNode(Algorithm algorithm){
		Node node = null;

		switch (algorithm) {
		case Algorithm.BreathFirst:
			node = openNodes [0];
			break;
		case Algorithm.DepthFirst:
			node = openNodes[openNodes.Count-1];
			break;
		case Algorithm.Dijkstra:
			foreach (Node n in openNodes) {
				if (node == null || n.weight < node.weight) {
					node = n;
				}
			}
			break;
		case Algorithm.AStar:
			foreach (Node n in openNodes) {
				if (node == null || n.weight < node.weight) {
					node = n;
				}
			}
			break;
		}

		return node;
	}

	void OpenAdjacents(Node node, Algorithm algorithm){
		foreach (Node n in node.GetAdjacents()) {
			switch (algorithm) {
			case Algorithm.Dijkstra:
				if (closedNodes.Contains (n) == false && ((n.weight > node.weight && n.Parent != node) || openNodes.Contains(n) == false)) {
					n.Parent = node;
					n.weight = n.originalWeight + node.weight;
					if (openNodes.Contains (n) == false) {
						openNodes.Add (n);
					}
				}
				break;
			case Algorithm.AStar:
				if (closedNodes.Contains (n) == false && ((n.weight > node.weight && n.Parent != node) || openNodes.Contains(n) == false)) {
					n.Parent = node;
					n.weight = n.originalWeight + node.weight + Mathf.Abs(endX - n.x) + Mathf.Abs(endY - n.y);
					if (openNodes.Contains (n) == false) {
						openNodes.Add (n);
					}
				}
				break;
			default:
				if (openNodes.Contains (n) == false && closedNodes.Contains (n) == false) {
					n.Parent = node;
					openNodes.Add (n);
				}
				break;
			}

		}
	}

	void CloseNode(Node node){
		openNodes.Remove (node);
		closedNodes.Add (node);
	}

	bool CheckNode(Node node, int endX, int endY){
		return node.x == endX && node.y == endY ? true : false;
	}
}
