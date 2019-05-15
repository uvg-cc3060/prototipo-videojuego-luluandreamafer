using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crearRecursos : MonoBehaviour {

	public GameObject Recursos;
	public float RangoCreacion = 20f;
    public int arbol = 0;

	// Use this for initialization
	void Start () {
		
	}

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 50), "Arboles =" + arbol);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Invoke("Crear", 1.0f);
            arbol += 1;
        }
		
	}

	public void Crear(){
		Vector3 SpawnPosition = new Vector3 (0,0,0);
		SpawnPosition = this.transform.position - Random.onUnitSphere * RangoCreacion;
		SpawnPosition = new Vector3 (SpawnPosition.x, SpawnPosition.y, SpawnPosition.z);

		GameObject Recurso = Instantiate (Recursos, SpawnPosition, Quaternion.identity);

	}
}
