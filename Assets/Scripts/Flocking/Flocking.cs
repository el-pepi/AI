using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour {

	List<Boid> boids = new List<Boid> ();

	public int boidsToSpawn = 1;
	public GameObject boidPrefab;
	public float flockRange;

	Vector3 target;
	Transform targetT;

	public float separationPeso = 1f;
	public float cohesionPeso = 1f;
	public float targetPeso = 1f;

	void Start () {
		targetT = transform.GetChild (0);
		while (boidsToSpawn > 0) {
			boidsToSpawn--;
			boids.Add(Instantiate (boidPrefab,Random.insideUnitSphere * 10,Quaternion.identity ).GetComponent<Boid>());
		}
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			target = (Camera.main.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * Random.Range(2f,20f)));
			targetT.position = target;
		}

		for (int i = 0; i < boids.Count; i++) {
			for (int j = i+1; j < boids.Count; j++) {
				if (Vector3.Distance (boids [i].transform.position, boids [j].transform.position) <= flockRange) {
					boids [i].AddVecino (boids [j]);
					boids [j].AddVecino (boids [i]);
				}
			}
		}
			
		foreach (Boid b in boids) {
			Vector3 center = b.GetFlockCentre ();
			Vector3 separation = (b.transform.position - center);
			Vector3 cohesion = separation * -1f;
			float cohesionW = Mathf.Clamp01(separation.magnitude / flockRange);
			float separationW = 1f - cohesionW;
			Vector3 align = b.GetFlockAlign ();

			Vector3 targetdir = (target - b.transform.position).normalized * targetPeso;

			Debug.DrawLine (b.transform.position,b.transform.position + separation.normalized * separationW,Color.red);
			Debug.DrawLine (b.transform.position,b.transform.position + cohesion.normalized * cohesionW,Color.green);
			Debug.DrawLine (b.transform.position,b.transform.position + align,Color.blue);

			b.SetDirTarget (((((separation.normalized * separationW) * separationPeso + (cohesion.normalized * cohesionW) * cohesionPeso + align).normalized) + targetdir ).normalized );

			b.ResetVecinos ();
		}
	}
}
