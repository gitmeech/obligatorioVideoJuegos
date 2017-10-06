using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2 : MonoBehaviour {

	public Transform[] backgrounds;
	public float smoothing = 1;

	private float[] scales;
	private Transform cam;
	private Vector3 previousCamPos;

	void Awake(){
		
		cam = Camera.main.transform;
	}

	void Start () {
		
		previousCamPos = cam.position;
		scales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			scales [i] = backgrounds [i].position.z * -1;
		}
	}
	

	void Update () {

		for (int i = 0; i < backgrounds.Length; i++) {
			float parallax = (previousCamPos.x - cam.position.x) * scales [i];

			float backgroundTargetPositionX = backgrounds [i].position.x + parallax;

			//create a targets position to be assigned
			Vector3 backgroundsTargetPos = new Vector3(backgroundTargetPositionX, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds [i].position = Vector3.Lerp (backgrounds[i].position, backgroundsTargetPos, smoothing * Time.deltaTime);

		}
		previousCamPos = cam.position;
	}
}
