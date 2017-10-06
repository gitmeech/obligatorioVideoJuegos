using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour {
	
	//Script que shakea la camara, para utilzar en ataques, daño, animaciones, etc
	//crear un empty meterle la camara adentro y el script camera follow
	//referenciar a este script con GetComponent<cameraShake> donde 
	//desees utilizar el camera shake

	public Camera cam;
	public float shakeAmount = 0;

	void Awake() 
	{
		if (cam == null)
			cam = Camera.main;
	}

	public void Shake(float amount, float length)
	{
		shakeAmount = amount;
		InvokeRepeating ("BeginShake", 0, 0.01f);
		Invoke ("StopShake", length);
	}

	void BeginShake()
	{
		Vector3 newCamPosition = cam.transform.position;

		if (shakeAmount > 0) {
			float deltaX = Random.value * shakeAmount * 2 - shakeAmount;
			float deltaY = Random.value * shakeAmount * 2 - shakeAmount;
			newCamPosition.x += deltaX;
			newCamPosition.y += deltaY;

			cam.transform.position = newCamPosition;
		}
	}

	void StopShake()
	{
		CancelInvoke ("BeginShake");

		//para que no haya lio entre el cameraFollow y este script, poner
		//la camara en un empty, y al empty ponerle el camaraFollow.
		//cam.transform.localPosition = Vector3.zero; 

	}
		
}
