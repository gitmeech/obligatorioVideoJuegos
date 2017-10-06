using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFireScript : MonoBehaviour {

	public float firetime = 0.5f;
		
	void Start () {
		InvokeRepeating ("Fire", firetime, firetime);
	}

	void Fire () {

		GameObject obj = ObjectPoolerScript.current.getPooledObject ();
		if (obj == null)
			return;
		obj.transform.position = transform.position;
		obj.transform.rotation = transform.rotation;
		obj.SetActive (true);


	}
}
