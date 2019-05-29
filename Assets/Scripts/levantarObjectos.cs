using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levantarObjectos : MonoBehaviour
{
	public Transform DestinationSpot;
	public Transform OriginSpot;
	public float Speed;
	public bool Switch = true;

	void FixedUpdate()
	{
		


		if(Switch)
		{
			

			
		}
		else
		{
			
			transform.position = Vector3.MoveTowards(transform.position, DestinationSpot.position, Speed);
			//SceneManager.LoadScene ("MainMenu");

		}
	}
}
