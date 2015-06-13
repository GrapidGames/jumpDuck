using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 jumpVelocity;
	float forwardSpeed = 1f;

	bool jump = false;
	bool canJump = false;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

	
		if (transform.position.y == 0) {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))
				jump = true;
		}
	}
	
	void FixedUpdate() {
		velocity.x = forwardSpeed;
		velocity += gravity * Time.deltaTime;

		if (jump == true) {
			jump = false;
			velocity += jumpVelocity;
		}

		transform.position += velocity * Time.deltaTime;

		if (transform.position.y < 0f) {
			velocity.y = 0;
			transform.position += new Vector3(0, -transform.position.y, 0);
		}
	}
}
