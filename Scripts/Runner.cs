using UnityEngine;

public class Runner : MonoBehaviour {

	private CharacterController controller;

	public float speed = 3.0f;

	// Intialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	// Update per frame
	void Update () {
		controller.Move((Vector3.forward * speed) * Time.deltaTime);

	}
}  