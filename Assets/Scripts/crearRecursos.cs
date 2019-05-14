using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crearRecursos : MonoBehaviour {

	public GameObject Recursos;
	public float tiempoCreacion =2f, RangoCreacion = 2f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Crear", 0.0f,tiempoCreacion);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Crear(){
		Vector3 SpawnPosition = new Vector3 (0,0,0);
		SpawnPosition = this.transform.position + Random.onUnitSphere * RangoCreacion;
		SpawnPosition = new Vector3 (SpawnPosition.x, SpawnPosition.y, SpawnPosition.z);

		GameObject Recurso = Instantiate (Recursos, SpawnPosition, Quaternion.identity);

	}
}
