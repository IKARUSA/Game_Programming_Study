using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	[SerializeField]
	private Transform playerTransform;

	private float currentCamDistance = 5f;
	[SerializeField]
	private float maxCamDistance = 10f;
	[SerializeField]
	private float minCamDistance = 2f;

	[SerializeField]
	private Vector3 camOffsetNormal;

	[SerializeField]
	private float followSmooth = 0.2f; // 0~1

	// Use this for initialization
	void Start () {
		camOffsetNormal = camOffsetNormal.normalized;
	}

	void FixedUpdate () {
		Vector3 currentCamPos = transform.position;
		Vector3 desiredCamPos = playerTransform.position + camOffsetNormal * currentCamDistance;
		Vector3 CamPos = Vector3.Lerp (currentCamPos, desiredCamPos, followSmooth);
		transform.position = CamPos;
		transform.LookAt (playerTransform);
	}
}
