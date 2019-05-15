using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour {
    private NavMeshAgent enemigo = null;
    public Camera jugador = null;

    public float attackDistance = 10.0f;
    public float chaseDistance = 60.0f;
    public float movespeed = 1.0f;
    public float turnspeed = 45.0f;

    public float damage = 2.0f;


	// Use this for initialization
	void Start () {
        enemigo = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(enemigo.transform.position, jugador.transform.position);
        if ( distance < chaseDistance)
        {
            Debug.Log(distance);
            enemigo.SetDestination(jugador.transform.position);
            if(distance < attackDistance)
            {
                //Disparar y bajar health del personaje
            }
        }
	}
}
