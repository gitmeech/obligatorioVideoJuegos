using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public float speed = 5f;

	void Start () {

	}

	void Update () {
		transform.Translate (speed * Time.deltaTime, 0, 0);
	}
}
