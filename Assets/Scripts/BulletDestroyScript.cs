using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyScript : MonoBehaviour {

	void onEnable () {
		Invoke ("Destroy", 2f);
	}

	void Destroy () {
		gameObject.SetActive (false);
	}

	void onDisable(){
		CancelInvoke ();
	}
}
