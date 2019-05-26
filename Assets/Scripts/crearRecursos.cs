using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crearRecursos : MonoBehaviour {

    public Transform onHand;
    public GameObject Recursos;
    public GameObject Flecha;
    public GameObject Jugador;
	public float RangoCreacion = 20f;
    public int arbol = 0;
    private GUIStyle guiStyle = new GUIStyle();
    private GUIStyle guiLose = new GUIStyle();
    private int puntos = 0;
    private int ammo = 0;
    private int damage = 2;
    public static bool hasWeapon = false;

    // Use this for initialization
    void Start () {
		
	}


    private void OnGUI()
    {
        GUI.Label(new Rect(50,0,100,50),"Recursos = " + puntos);
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 50), "Arboles =" + arbol);
        if (arbol >= 60) //aca deberia calcular la cantidad de arboles
        {
            guiStyle.fontSize = 50;
            GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 25, 1000, 500), "GANASTE",guiStyle);
        }
        if (damage <= 0)
        {
            guiLose.fontSize = 50;
            guiLose.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 25, 1000, 500), "PERDISTE", guiLose);
            SceneManager.LoadScene(sceneName: "MainMenu");
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
            Destroy(other.gameObject);

        }
        if (other.tag == "Ammo")//Si toca el tag "Ammo" sube ammo
        {
            ammo += 1;
            Destroy(other.gameObject);
        }
        if (other.tag == "Weapon")//Indica que tiene arma, si esta en true no deberia dejar que agarrase otra (?)
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
        SpawnPosition.y = 0;
        this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
		GameObject Recurso = Instantiate (Recursos, SpawnPosition, Quaternion.identity);

	}

    public void Atacar()
    {
        

    }
}
