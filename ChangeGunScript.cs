using UnityEngine;
using System.Collections;

public class ChangeGunScript : MonoBehaviour {

	public GameObject machinegun;
	public GameObject shotgun;
	public Character character;
	public bool isShotgunAvailable = false;
	public bool shotgunSwap = false;

	// Gun damage
	public float activeGunDamage;
	public float machinegunDamage = 30.0f;
	public float shotgunDamage = 50.0f;

	// Use this for initialization
	void Start () {
		activeGunDamage = machinegunDamage;
		// Set the correct guns active at the start of the game
		machinegun.SetActive(true);
		shotgun.SetActive(false);
		// Gain access to the character script
		character = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
		// If the player has enough exp
		if (character.playerEXP >= 20)
		{
			// Set variable to true, which indicates the shotgun is now usable
			isShotgunAvailable = true;
			// Call function to switch to the shotgun as soon as enough experience is gained
			ShotgunAvailable();
		}
		
		// When 1 is pressed, change to machine gun
		if (Input.GetKey (KeyCode.Alpha1))
		{
			machinegun.SetActive(true);
			shotgun.SetActive(false);
			activeGunDamage = machinegunDamage;
		}
		// When 2 is pressed, change to shotgun, if available
		if (Input.GetKey (KeyCode.Alpha2) && isShotgunAvailable)
		{
			machinegun.SetActive(false);
			shotgun.SetActive(true);
			activeGunDamage = shotgunDamage;
		}
	}
	
	// Function to switch to shotgun as soon as enough experience is gained
	void ShotgunAvailable () {
		
		if (shotgunSwap == false)
		{
			machinegun.SetActive(false);
			shotgun.SetActive(true);
			shotgunSwap = true;
			activeGunDamage = shotgunDamage;
		}
	}
}
