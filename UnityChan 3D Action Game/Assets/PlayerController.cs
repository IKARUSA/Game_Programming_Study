using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	private PlayerMotor motor;


	private Vector3 moveVec = Vector3.zero;
	private Vector3 currentInputMove = Vector3.zero;

	void Start () {
		motor = GetComponent<PlayerMotor> ();
	}

	void Update () {

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		currentInputMove = new Vector3 (h, 0f, v).normalized;
		if (currentInputMove != Vector3.zero) {
			moveVec = currentInputMove;
		} else {
			moveVec = Vector3.Lerp (moveVec, currentInputMove, 0.1f);	//for little delay when abruptly stopped while walking or running
		}
		Debug.Log (moveVec);
		motor.Move (moveVec);

	}
}
