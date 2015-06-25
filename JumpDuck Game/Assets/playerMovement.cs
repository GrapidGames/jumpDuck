using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour 
{

	Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 jumpVelocity;
	float forwardSpeed = 4f;

	bool jump = false;
	bool canJump = false;

    private SwipeDetector swipeDetector;

	// Use this for initialization
	void Start ()
    {
        swipeDetector = new SwipeDetector();
	}
	
	// Update is called once per frame
	void Update ()
    {
		//Jumping controls
		if (transform.position.y == 0)
        {
			if (Input.GetKeyDown (KeyCode.UpArrow) || swipeDetector.up)
				jump = true;
		}


	}
	
	void FixedUpdate()
    {
		velocity.x = forwardSpeed;
		velocity += gravity * Time.deltaTime;

		if (jump == true)
        {
			jump = false;
			velocity += jumpVelocity;
		}

		transform.position += velocity * Time.deltaTime;

		if (transform.position.y < 0f) 
        {
			velocity.y = 0;
			transform.position += new Vector3(0, -transform.position.y, 0);
		}
	}
}
