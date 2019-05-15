using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmo : MonoBehaviour {
	private float fireSpeed = 0.4f;
	public Camera character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 translate = new Vector3(character.transform.position.x, character.transform.position.y, character.transform.position.z);
		transform.Translate (translate * fireSpeed * Time.deltaTime);
	}
}
