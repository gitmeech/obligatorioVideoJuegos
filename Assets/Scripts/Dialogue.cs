using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
	
	//nombre del NPC
	public string name;
	[TextArea(3,10)]
	public string[] sentences;


}
