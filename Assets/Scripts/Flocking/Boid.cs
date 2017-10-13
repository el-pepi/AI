using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

	Vector3 target;

	public Vector3 targetDir;
	public Vector3 dir;

	Transform tSprite;

	void Start () {
		tSprite = transform.GetChild (0);
	}

	void Update () {
		targetDir = target - transform.position;
		dir = Vector3.Slerp (dir, targetDir, 3f * Time.deltaTime).normalized;
		transform.position += dir * 5 * Time.deltaTime;

		float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		tSprite.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}

	public void SetDirTarget(Vector3 v){
		v.z = 0;
		target = v;
	}
}
