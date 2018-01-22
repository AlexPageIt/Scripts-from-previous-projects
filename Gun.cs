using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	private Vector3 mouse_pos;
	private Vector3 object_pos;
	private float angle;
	private float maxAngleRight = 140f;
	private float maxAngleLeft = 260f;
	private float minAngle = 20f;
	private float bulletSpeed = 1600;
	public GameObject[] ammo;

	public GameObject player;
	private Character characterscript;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
	
		// Gain access to character script 
		characterscript = (Character)player.GetComponent (typeof(Character));

		// Bullets are launched at mouse position
		mouse_pos = Input.mousePosition;
		mouse_pos.z = 0.0f; 
		object_pos = Camera.main.WorldToScreenPoint(transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;
		angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg - 90;
		Vector3 rotationVector = new Vector3 (0, 0, angle);
		transform.rotation = Quaternion.Euler(rotationVector);

		//print (angle);
		
		// Fire a bullet.
		if(Input.GetMouseButtonDown(0)){
		
			// Setting up shooting direction depending on where the player is facing
			if (characterscript.Direction == 1)
			{
				// Check if the shooting angle is within range of the minimum and maximum shooting angles
				if (angle > - 105.0f && angle < -50.0f)
				{
					// Instantiate bullet
					int ammoIndex = 0; 
					GameObject bullet = (GameObject)Instantiate(ammo[ammoIndex], transform.position, transform.rotation);
					// Aim bullet at mouse position
					bullet.transform.LookAt(mouse_pos);
					// Add force to bullet to move it forward
					bullet.rigidbody2D.AddForce(bullet.transform.forward * bulletSpeed);
				}
			}				
			else if (characterscript.Direction == -1)
			{		
				if (angle > -269.0f && angle < -238.0f || angle < 90.0f && angle > 55.0f)
				{
					int ammoIndex = 0; 
					GameObject bullet = (GameObject)Instantiate(ammo[ammoIndex], transform.position, transform.rotation);
					bullet.transform.LookAt(mouse_pos);
					bullet.rigidbody2D.AddForce(bullet.transform.forward * bulletSpeed);
				}
			}
		}
	}
}