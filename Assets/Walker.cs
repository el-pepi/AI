using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Walker : MonoBehaviour {

	public ToggleGroup algorithmToggles;
	List<Node>nodes;

	public void StartMoving(){
		PathFinder p = new PathFinder ();
		p.Init (Map.tiles,Map.weights);
		Node[] n = null;

		Toggle t = algorithmToggles.ActiveToggles ().FirstOrDefault ();
		n = p.GetPath (Map.startX, Map.startY, Map.endX, Map.endY,(PathFinder.Algorithm)System.Enum.Parse(typeof(PathFinder.Algorithm),t.name));
	

		if (n != null) {
			nodes = new List<Node> (n);
			StopAllCoroutines ();
			StartCoroutine ("move");
		}
	}

	IEnumerator move(){
		while (nodes.Count > 0) {
			yield return new WaitForSeconds(0.5f);
			Node n = nodes[nodes.Count-1];
			transform.position = new Vector3(n.x,n.y,0);
			nodes.Remove(n);
		}
	}
}
