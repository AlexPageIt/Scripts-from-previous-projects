using UnityEngine;
using System.Collections;

public class DestroyBullets : MonoBehaviour {

	// Set bullet lifetime
	public float lifetime = 5f;
	
	void Start () {
		// Rotate bullet to correct position
		transform.Rotate(0, 90f, 0);
		// Destroy bullet after its lifetime runs out 
		Destroy (gameObject, lifetime);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// If bullet collides with the world, destroy it
		if (col.gameObject.tag == "World")
			Destroy (gameObject);
		// If bullet collides with the barrier, destroy it
		if (col.gameObject.tag == "Barrier")
			Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
}
