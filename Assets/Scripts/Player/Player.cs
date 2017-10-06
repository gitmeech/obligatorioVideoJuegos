using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float jumpForce = 200f;
	public float speed = 150f;
	public Vector2 maxVelocity = new Vector2 (60, 100);
	public bool standing;
	public bool grounded = false;
	public bool jump = false;
	public float standingThreshold = 4f;
	public float airSpeedMultiplier = .3f;

	private Rigidbody2D body2D;
	private SpriteRenderer renderer2D;
	private PlayerController controller;
	private Animator animator;


	void Start () {
		renderer2D = GetComponent<SpriteRenderer> ();
		body2D = GetComponent<Rigidbody2D> ();
		controller = GetComponent<PlayerController> ();
		animator = GetComponent<Animator> ();
	}
	

	void Update () {

		var absVelX = Mathf.Abs (body2D.velocity.x);
		var absVelY = Mathf.Abs (body2D.velocity.y);

		if (absVelY <= standingThreshold) {
			standing = true;
		} else {
			standing = false;
		}
			
		var forceX = 0f;
		var forceY = 0f;

		if (controller.moving.x != 0) {
			if (absVelX < maxVelocity.x) {

				var newSpeed = speed * controller.moving.x;

				forceX = standing ? newSpeed : (newSpeed * airSpeedMultiplier);
			    
				renderer2D.flipX = forceX < 0;
			}
			animator.SetInteger ("AnimState", 1);
		
		} else {
			animator.SetInteger ("AnimState", 0);
		}
			
		if (controller.moving.y > 0 && standing) {
			
			Vector2 jump = Vector2.up * jumpForce;
			body2D.AddForce (jump, ForceMode2D.Impulse);
				//animator.SetInteger ("AnimState", 2);

		} else if (absVelY > 0 && !standing) {
//			animator.SetInteger ("AnimState", 3);
		}

		body2D.AddForce (new Vector2 (forceX, forceY));
		if (body2D.velocity.y == 0) {
			grounded = true;
		}
	}

	void FixedUpdate()
	{


	}
}
