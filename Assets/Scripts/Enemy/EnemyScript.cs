using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float speed = 14f;
	public float roamingSpeed = 14f;
	public float chasingSpeed = 24f;
	public float roamDistance = 100f;
	public float perceptionDistance = 100f;
	public float meleeAtackRange = 36f;
	public int meleeAtackPower = 35;
	public float atackRate = 1.5f;
	public float lastAtckTime;
	public int startingHealth = 100;



	private Transform player;
	private Rigidbody2D body;
	public Vector2 startingPosition;
	private Vector3 forward;
	private SpriteRenderer sprite;
	private cameraShake camShaker;
	private PlayerHealth playerHealth;
	private bool chasing = false;
	private bool targetIsClose = false;
	private bool facingRight = true;
	public int currentHealth;


	void Awake () {
		startingPosition = transform.position;
		body = GetComponent<Rigidbody2D> ();
		sprite = GetComponent<SpriteRenderer> ();
		camShaker = GetComponent<cameraShake> ();
		//playerHealth = GetComponent<cameraShake> ();
		forward = Vector3.right;
		lastAtckTime = atackRate;

	}

	void Start () {
		GameObject playerObj = GameObject.FindWithTag ("Player");
		player = playerObj.transform;
		playerHealth = playerObj.GetComponent<PlayerHealth> ();
	}

	void Update () {

		if (player) {
			float targetDistance = Mathf.Abs (Vector3.Distance (transform.position, player.position));
			targetIsClose = targetDistance <= perceptionDistance;
			bool targetWithinReach = targetDistance <= meleeAtackRange;
			if (targetIsClose) {
				if (targetWithinReach) Atack ();
				else Chase ();
			} else {
				if (chasing) {
					StopChasing ();
				}
				MoveAround ();
			}
		}
		lastAtckTime += Time.deltaTime;
	}

	void MoveAround(){
		float startingPositionDistance = Mathf.Abs (Vector3.Distance (transform.position, startingPosition));

		if (startingPositionDistance <= roamDistance) {
			transform.position += forward * speed * Time.deltaTime;
		} else {
			TurnAround ();
			transform.position += forward * speed * Time.deltaTime;
			}
	}

	void Chase(){
		if (!chasing) {
			FaceTarget ();
			chasing = true;
			speed = chasingSpeed;
		}
		camShaker.Shake (0.2f, 0.05f);
		transform.position += forward * speed * Time.deltaTime;
	}

	void Atack(){
		if (lastAtckTime >= atackRate && playerHealth.currentHealth > 0) {
			camShaker.Shake (0.7f, 1f);
			Debug.Log ("ataqueeee");
			playerHealth.takeDamage (meleeAtackPower);
			lastAtckTime = 0f;
		}
	}

	void StopChasing(){
		startingPosition = transform.position;
		chasing = false;
		TurnAround ();
		speed = roamingSpeed;	
	}

	void FaceTarget(){
		bool targetIsToMyRight = (player.position.x > transform.position.x);
		if (targetIsToMyRight && !facingRight) {
				TurnAround ();
		} else if(!targetIsToMyRight && facingRight) {
				TurnAround ();
		}
	}

	void TurnAround(){
		forward = forward * -1;
		facingRight = !facingRight;
		GetComponent<SpriteRenderer> ().flipX = !GetComponent<SpriteRenderer> ().flipX;
	}

	Vector3 ClosestTarget(){
		return GameObject.FindWithTag ("Player").transform.position;
	}
}
