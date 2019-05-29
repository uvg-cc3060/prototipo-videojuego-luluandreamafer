using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levantarObjectos : MonoBehaviour
{
	public Transform DestinationSpot;
	public Transform OriginSpot;
	public float Speed;
	public bool Switch = true;

	void FixedUpdate()
	{
		

		// If Switch becomes true, it tells the platform to move to its Origin.
		if(Switch)
		{
			

			
		}
		else
		{
			// If Switch is false, it tells the platform to move to the destination.
			transform.position = Vector3.MoveTowards(transform.position, DestinationSpot.position, Speed);

		}
	}
}
