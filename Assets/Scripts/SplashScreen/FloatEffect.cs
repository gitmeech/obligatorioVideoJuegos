using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEffect : MonoBehaviour {

	public float variation;
	private float startY;
	private float duration = 1f;
	private Transform rectTransform;

	// Use this for initialization
	void Start () {
		rectTransform = GetComponent<RectTransform> ();
		startY = rectTransform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		var newY = startY + (startY + Mathf.Cos (Time.time / duration * 2)) / variation;
		rectTransform.position = new Vector2 (rectTransform.position.x, newY);
	}
}
