using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

	private Vector3 directionVector;
	private CharacterController controller;

	// Initial Values
	public float speed = 3.0f;
	public float verticalVelocity = 0.0f;
	public float gravity = 9.8f;

    private bool isDead = false;

	// Intialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	// Update per frame
	void Update () {

        if (isDead) {
            return;
        }
		//if player is grounded
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

    public void SetSpeed(float modifier){
        speed = 5.0f + modifier;
    }

    // Callback called whenever the collider box hits something
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag =="Enemy") {
            Death();
        }
    }

    private void Death() {
        print("so dead");
        isDead = true;
        GetComponent<Score>().onDeath();
    }
}
