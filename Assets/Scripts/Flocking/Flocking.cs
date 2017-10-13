using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour {

	List<Boid> boids = new List<Boid> ();

	public int boidsToSpawn = 1;
	public GameObject boidPrefab;

	// Use this for initialization
	void Start () {
		while (boidsToSpawn > 0) {
			boidsToSpawn--;
			boids.Add(Instantiate (boidPrefab).GetComponent<Boid>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			foreach (Boid b in boids) {
				b.SetDirTarget(Camera.main.ScreenToWorldPoint (Input.mousePosition));
			}
		}
	}
}
