using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject recurso;
    public GameObject personaje;
    public int spawnAmount = 100; //cantidad de recursos que se crean al inicio. aun no implementado
    // Start is called before the first frame update
    public float RangoCreacion = 20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create(){
        Vector3 SpawnPosition = new Vector3 (0,0,0);
		SpawnPosition = personaje.transform.position - Random.onUnitSphere * RangoCreacion;
		SpawnPosition = new Vector3 (SpawnPosition.x, SpawnPosition.y, SpawnPosition.z);

		GameObject Recurso = Instantiate (recurso, SpawnPosition, Quaternion.identity);

    }
}
