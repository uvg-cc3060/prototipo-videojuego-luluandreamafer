using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollision : MonoBehaviour
{
	void OnParticleCollision(GameObject other){
		Debug.Log ("Particle HIT");
	}
}
