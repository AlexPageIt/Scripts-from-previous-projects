using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	private int direction;
	private bool isJumping;
	private int jumpCount;
	public int playerEXP = 0;
	
	// Get the direction the player is moving
	public int Direction {
		get { return direction; }
	}

	void Start () {
		// Set jumping variables
		isJumping = false;
		jumpCount = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		// When W is pressed, and the player is not already in the air
		if (Input.GetKeyDown ("w") && isJumping == false)
		{
			// Launch character upwards
			rigidbody2D.velocity = new Vector2(0, 10);
			// Jump counter to enable double jump
			jumpCount++;
			
			// If the player has performed a double jump, disable another jump until player hits the ground
			if (jumpCount == 2)
				isJumping = true;
		}
		
		// Movement controls
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate(Vector2.right * 10f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
			direction = 1;
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate(Vector2.right * 10f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
			direction = -1;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// When player collides with world, the jumping is reset
		if (col.gameObject.tag == "World") 
		{
			isJumping = false;
			jumpCount = 0;
		}
	}
}
