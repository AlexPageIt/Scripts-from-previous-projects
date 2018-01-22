using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {
	
	public Transform[] backgrounds;
	private float[] parallaxScales;
	public float smoothing = 1f;
	
	private Transform cam;
	private Vector3 previousCamPos;
	
	void Awake () {
		cam = Camera.main.transform;
	}
	
	// Use this for initialization
	void Start () {
		// Store camera's last position
		previousCamPos = cam.position;
		// Store length of background images in the array
		parallaxScales = new float[backgrounds.Length];
		
		// Loop through backgrounds and store their z position
		for (int i = 0; i < backgrounds.Length; i++)
		{
			parallaxScales[i] = backgrounds[i].position.z * -1; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Loop through backgrounds
		for (int i = 0; i < backgrounds.Length; i++)
		{
			// Calculate parallax effect
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];	
			// Find the target x position for background	
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;
			// Find the target position for background
			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
			// Set new background position
			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		// Store camera's last position
		previousCamPos = cam.position;
	}
}
