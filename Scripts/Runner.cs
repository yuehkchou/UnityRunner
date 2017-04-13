using UnityEngine;

public class Runner : MonoBehaviour {

	private Vector3 directionVector;
	private CharacterController controller;

	public float speed = 3.0f;

	// Intialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	// Update per frame
	void Update () {
		directionVector = Vector3.zero;

		// X - Left or Right
		directionVector.x = Input.GetAxis("Horizontal");

		// Y - Up and Down
		// Z - Forward and Backward
		controller.Move((directionVector * speed) * Time.deltaTime);
	}
}
