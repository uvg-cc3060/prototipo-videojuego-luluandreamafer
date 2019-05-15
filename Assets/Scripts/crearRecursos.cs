using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crearRecursos : MonoBehaviour {

	public GameObject Recursos;
    public GameObject Jugador;
	public float RangoCreacion = 20f;
    public int arbol = 0;
    private GUIStyle guiStyle = new GUIStyle();
    private int puntos = 0;

    // Use this for initialization
    void Start () {
		
	}

    private void OnGUI()
    {
        GUI.Label(new Rect(100,0,100,50),"Recursos = " + puntos);
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 50), "Arboles =" + arbol);
        if (arbol >= 60) //aca deberia calcular la cantidad de arboles
        {
            guiStyle.fontSize = 50;
            GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 25, 1000, 500), "GANASTE",guiStyle);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (puntos > 0)
            {
                Invoke("Crear", 1.0f);
                arbol += 1;
            }
        }
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Recurso")//Si toca el tag "Recurso"  que suba puntos
        {
            puntos += 1;
            Destroy(other.gameObject);

        }
    }

    public void Crear(){
		Vector3 SpawnPosition = new Vector3 (0,0,0);
		SpawnPosition = this.transform.position;
		SpawnPosition = new Vector3 (transform.position.x - 10.0f, transform.position.y - 2.0f, SpawnPosition.z);

		GameObject Recurso = Instantiate (Recursos, SpawnPosition, Quaternion.identity);

	}
}
