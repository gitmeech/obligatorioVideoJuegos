using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;

	public float backgroundSize;
	public float parallaxSpeed;
	public bool parallax;
	public bool scroll;

	void Start () {
		
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
			layers [i] = transform.GetChild (i);

		leftIndex = 0;
		rightIndex = layers.Length - 1;
			
	}

	private void ScrollLeft()
	{
		int lastRight = rightIndex;
		layers [rightIndex].position = new Vector3(layers [leftIndex].position.x - backgroundSize, layers [leftIndex].position.y, 1);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0)
			rightIndex = layers.Length - 1;
		
	}

	private void ScrollRight()
	{
		int lastLeft = leftIndex;
		layers [leftIndex].position = new Vector3(layers [rightIndex].position.x + backgroundSize, layers [rightIndex].position.y, 1);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}

	void Update () {
		

		if (parallax) {
			float deltaX = cameraTransform.position.x - lastCameraX;
			transform.position += Vector3.right *(deltaX * parallaxSpeed/2);
		}
		if (scroll) {
			if (cameraTransform.position.x < (layers [leftIndex].transform.position.x))
				ScrollLeft ();
			if (cameraTransform.position.x > (layers [rightIndex].transform.position.x - viewZone))
				ScrollRight ();
		}

		lastCameraX = cameraTransform.position.x;
	}
}
