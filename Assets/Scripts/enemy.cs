using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public EnemyAmmo ammo;
    private NavMeshAgent enemigo = null;
    public Camera jugador = null;

    public float attackDistance = 10.0f;
    public float chaseDistance = 60.0f;
    public float movespeed = 1.0f;
    public float turnspeed = 45.0f;
    private float ammoSpeed = 0.5f;
    private float fireTime =0;

    
    //para mientras se hara con 1 de damage
    //public float damage = 2.0f;
    public float damage = 1.0f;

	// Use this for initialization
	void Start () {
        enemigo = this.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(enemigo.transform.position, jugador.transform.position);
        if ( distance < chaseDistance)
        {
            enemigo.SetDestination(jugador.transform.position);
            
            if(distance < attackDistance)
            {
                //Disparar y bajar health del personaje
                //para disparar municion
                Vector3 offset = new Vector3(0.1f, 0.3f,0.1f);
                fireTime += Time.deltaTime;
                if (fireTime > 0.2) // si se presiona a la derecha, disparara bolas cada 0.1 seg
                {
                    Instantiate(ammo, (Vector3)transform.position + offset, Quaternion.identity);
                    ammo.character = this.jugador;
                    fireTime = 0;
                }
            }
        }
	}

     void OnTriggerEnter(Collider collision) {
        if (collision.tag=="Weapon") {
            damage--;
        }
        if (damage == 0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
