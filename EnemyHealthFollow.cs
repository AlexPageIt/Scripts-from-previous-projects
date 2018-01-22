using UnityEngine;
using System.Collections;

public class EnemyHealthFollow : MonoBehaviour {
	
	public Vector3 offset;
	public Transform Enemy;

	void Awake ()
	{
		//Enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Enemy.position;
	
	}
}
