using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	private Vector3 directionVector;
	private CharacterController controller;

	// Initial Values
	public float speed = 3.0f;
	public float verticalVelocity = 0.0f;
	public float gravity = 9.8f;

	// Intialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	// Update per frame
	void Update () {
		directionVector = Vector3.zero;

		//
		if (controller.isGrounded) {
			verticalVelocity = -0.5f;
		} else {
			verticalVelocity -= gravity * Time.deltaTime;
		}
		// X - Left or Right
		directionVector.x = Input.GetAxis("Horizontal") * speed;

		// Y - Up and Down
		directionVector.y = verticalVelocity;

		// Z - Forward and Backward
		directionVector.z = speed;
		controller.Move((directionVector * speed) * Time.deltaTime);
	}
}
