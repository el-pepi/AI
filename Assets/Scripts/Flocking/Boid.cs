using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

	Vector3 target;

	public Vector3 targetDir;
	public Vector3 dir;

	Transform tSprite;

	List<Boid> vecinos = new List<Boid>();

	float speed = 5;
	float rotSpeed = 3f;

	void Start () {
		tSprite = transform.GetChild (0);

		speed = Random.Range (3f,7f);
		rotSpeed = Random.Range (1.5f,4.5f);
	}

	void Update () {
		//targetDir = target - transform.position;

		dir = Vector3.Slerp (dir, targetDir, rotSpeed * Time.deltaTime);
		dir.Normalize ();


		transform.position += dir * speed * Time.deltaTime;

		tSprite.LookAt(transform.position+dir);
	}

	public void SetDirTarget(Vector3 v){
		//v.z = 0;
		//target = v;
		targetDir = v;
	}

	public void AddVecino(Boid b){
		vecinos.Add (b);
	}

	public void ResetVecinos(){
		vecinos.Clear ();
	}

	public Vector3 GetFlockCentre(){
		Vector3 v = transform.position;

		foreach (Boid b in vecinos) {
			v += b.transform.position;
		}

		v /= vecinos.Count + 1;
		return v;
	}

	public Vector3 Getdir(){
		return dir;
	}

	public Vector3 GetFlockAlign(){
		Vector3 v = dir;

		foreach (Boid b in vecinos) {
			v += b.Getdir();
		}

		v /= vecinos.Count + 1;
		return v;
	}
}
