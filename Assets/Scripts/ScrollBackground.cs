using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	//Attach this Script to an image you want to scroll such as a clouds background

	public float speed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (0, Time.deltaTime * speed);

		//renderer.material.mainTextureOffset = offset;
	}
}
