using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //variables 
    public static bool hasWeapon = false;
    private int puntos = 0; //en realidad esto se llama con PlayerPrefs

    private int health = 100; // "cantidad de vida del personaje"
    private int ammo =0; //cantidad de municiones que tiene. se modificara mas adelante para que dependa del arma.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            health -= 3;
        }
    }
    public int getHealth(){return this.health;}
    public int getPuntos(){return this.puntos;}
    public void addPuntos(int puntos) {this.puntos += puntos;} //temporal 
}
