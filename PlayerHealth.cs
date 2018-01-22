using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	public float health = 100f;
	public GameObject player;
	public Character character;
	public float repeatDamagePeriod = 0f; // how frequent can be damaged
	public float damageAmount = 30f;
	public SpriteRenderer healthBar;	
	private Vector3 healthScale;
	private float lastHitTime;
	
	// Use this for initialization
	void Start () {
		// Gain access to character script
		character = player.GetComponent<Character>();
	}
	
	void Awake()
	{
		//healthBar = GameObject.Find ("Health").GetComponent<SpriteRenderer> ();
		healthScale = healthBar.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		
		// If enemy is killed
		if (health < 10)
		{
			// Player gains experience points
			character.playerEXP += 10;
			// Enemy is destroyed
			Destroy (gameObject);
			//Destroy (healthBar);
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			print ("Detected Enemy Collision with Player");
			Destroy (col.transform.gameObject);
			if (Time.time > lastHitTime + repeatDamagePeriod) {
				if (health > 0f) {
					TakeDamage ();
					lastHitTime = Time.time;
				}
			}
		}
	}
	void TakeDamage ()
	{
		health -=damageAmount;
		UpdateHealthBar();
		//print (health);
	}
	
	void UpdateHealthBar()
	{
		healthBar.material.color = Color.Lerp (Color.green, Color.red, 1 - health * 0.01f);
		healthBar.transform.localScale = new Vector3 (healthScale.x * health * 0.01f, 1, 1);
	}
	
	
}
