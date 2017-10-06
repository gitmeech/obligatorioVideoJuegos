using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public Animator boxAnimator;

	private Queue<string> sentences;

	void Start () {
		boxAnimator.SetBool ("isOpen", false);
		sentences = new Queue<string> ();
	}
	
	public void StartDialogue (Dialogue dialogue)
	{
		boxAnimator.SetBool ("isOpen", true);
		Debug.Log ("starting conversation with " + dialogue.name);
		nameText.text = dialogue.name;
		sentences.Clear ();
		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}
		DisplayNextSentence ();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines (); //por si no termino de animar la sentence anterior
		StartCoroutine (TypeSentence (sentence));
	}

	IEnumerator TypeSentence(string sentence){
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) 
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue(){
		boxAnimator.SetBool ("isOpen", false);
		Debug.Log ("end sentence");
	}

}
