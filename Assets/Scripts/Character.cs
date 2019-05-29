using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    //variables 
    public static bool hasWeapon = false;
    private int puntos = 0; //en realidad esto se llama con PlayerPrefs
	private float EndingSceneDelay = 32f;
	private float timeElapsed = 0; 
	//private GUIStyle guiLose = new GUIStyle();
    private int health = 200; // "cantidad de vida del personaje"
    private int ammo =0; //cantidad de municiones que tiene. se modificara mas adelante para que dependa del arma.


    // Start is called before the first frame update
    void Start()
    {
		health = 200;
    }

    // Update is called once per frame
    void Update()
    {
		if (timeElapsed >= 10f) {
			health -= 1;
		}
		if (health <= 0) {
			SceneManager.LoadScene ("MainMenu");

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
		if (other.tag == "Fire") {
			health -= 10;
		}
        if (other.tag=="Deadly")
        {
            health -= 3;
        }
    }
    public int getHealth(){return this.health;}
    public int getPuntos(){return this.puntos;}
    public void addPuntos(int puntos) {this.puntos += puntos;} //temporal 
}
