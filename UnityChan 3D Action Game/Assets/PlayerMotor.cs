using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	private Rigidbody rb;
	private PlayerInfo playerInfo = new PlayerInfo();

	[SerializeField]
	private Animator anim;
	[SerializeField]
	private float speed = 3f;

	private Vector3 moveVec = Vector3.zero;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	public void Move(Vector3 _moveVec){
		moveVec = _moveVec;
	}
	
	void FixedUpdate(){
		anim.SetFloat ("moveH", Mathf.Abs(moveVec.x));
		anim.SetFloat ("moveV", moveVec.z);
		moveVec = moveVec * speed * Time.fixedDeltaTime;
		if (moveVec != Vector3.zero) {
			rb.MovePosition (rb.position + moveVec);
		}
	}
}
