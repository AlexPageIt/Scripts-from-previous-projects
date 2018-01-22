using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Transform target;
	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;
	
	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;
	
	// Use this for initialization
	void Start () {
		// Save the player's last position
		lastTargetPosition = target.position;
		// Calculate the difference in z between player and camera
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		// Find distance player has moved
		float xMoveDelta = (target.position - lastTargetPosition).x;
		// Check if the player has moved further than the threshold. If not, the camera will not move.
		bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;
		
		// Only update lookahead pos if accelerating or changed direction
		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
		}
		
		// Find end position for camera
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		// Gradually move camera to new position
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);
		// Set new camera position
		transform.position = newPos;
		// Store player's last position
		lastTargetPosition = target.position;		
	}
}
