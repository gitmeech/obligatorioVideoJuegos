using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//para accederla desde cualquier lado del juego
	public static GameManager instance = null;

	public int level = 3;
	public LevelManager levelManager;

	void Start () {
		
	}

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
		levelManager = GetComponent<LevelManager> ();
		initGame();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void initGame(){
		levelManager.setUpScene (level);
	}
}
