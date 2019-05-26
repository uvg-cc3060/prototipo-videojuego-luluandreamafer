using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este metodo se va a llamar como al minuto de que haya empezado el juego
public class EndingScript : MonoBehaviour
{

    public static int total = crearRecursos.totalarboles + crearRecursos.arbol;
    int casualties = 0;

    // Start is called before the first frame update
    void Start()
    {
        casualties = Random.Range(1, total);
    }

    private void OnGUI()
    {
        
        
        if (crearRecursos.getFraccion())
        {

        }
        else
        {

        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
