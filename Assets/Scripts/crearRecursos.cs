using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crearRecursos : MonoBehaviour {

    public Transform onHand;
    public GameObject Recursos;
    public GameObject Flecha;
    public GameObject Jugador;
	public float RangoCreacion = 20f;
    public int arbol = 0;
    private GUIStyle guiStyle = new GUIStyle();
    private int puntos = 0;
    private int ammo = 0;
    private int damage = 10;
    public static bool hasWeapon = false;

    // Use this for initialization
    void Start () {
		
	}


    private void OnGUI()
    {
        GUI.Label(new Rect(50,0,100,50),"Recursos = " + puntos);
        GUI.Label(new Rect(Screen.width/2, 0, 100, 50), "Flechas = " + ammo);
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 50), "Arboles =" + arbol);
        if (arbol >= 60) //aca deberia calcular la cantidad de arboles
        {
            guiStyle.fontSize = 50;
            GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 25, 1000, 500), "GANASTE",guiStyle);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Z)) //Z para plantar
        {
            if (puntos > 0)
            {
                Invoke("Crear", 1.0f);
                arbol += 1;
                puntos -= 1;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Recurso")//Si toca el tag "Recurso"  que suba puntos
        {
            puntos += 1;
            

        }
        if (other.tag == "Ammo")//Si toca el tag "Ammo" sube ammo
        {
            ammo += 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "Weapon")//Indica que tiene arma
        {
            hasWeapon = true;
        }
        if (other.tag=="Deadly")
        {
            damage--;
        }
    }

    public void Crear(){
        Vector3 SpawnPosition = onHand.transform.position;
        this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
		GameObject Recurso = Instantiate (Recursos, SpawnPosition, Quaternion.identity);

	}

    public void Atacar()
    {
        

    }
}
