using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	
	//atach this script to the player and reference this script from 
	//the EnemyAtack script (whatever script who wants to 
	//inflict damage to the player)

	//Like this:
	//player = GameObject.FindObjectWithTag("Player");
	// playerHealth = player.GetComponent<PlayerHealth>();
	//

	public int currentHealth;
	public Image damageImage;
	public Slider healthSlider;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public int startingHealth = 100;
	public Color flashColour = new Color (1f, 0f, 0f,0.1f);

	Animator anim;
	AudioSource playerAudio;
	PlayerController playerMovement;
	bool isDead;
	bool damaged;

	void Start () {
		anim = GetComponent<Animator> ();
		//playerAudio = GetComponent<AudioSource> ();
		playerMovement = GetComponent<PlayerController> ();
	}
		
	void Update () {
		if (damaged) {
			damageImage.color = flashColour;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void takeDamage(int amount){
		damaged = true;
		currentHealth-= amount;
		healthSlider.value = currentHealth;
		//playerAudio.Play ();
		if (currentHealth <= 0 && !isDead) {
			death ();
		}
	}

	void death(){
		isDead = true;
		anim.SetTrigger ("Die");
		playerAudio.clip = deathClip;
		playerAudio.Play ();
		playerMovement.enabled = false;
		//playerShooting.enabled = false;
	}
}
