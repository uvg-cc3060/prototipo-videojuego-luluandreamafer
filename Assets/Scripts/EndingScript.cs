using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este metodo se va a llamar como al minuto de que haya empezado el juego
public class EndingScript : MonoBehaviour
{

    public static int total = crearRecursos.totalarboles + crearRecursos.arbol;
    int casualties = 0;
    private bool winCondition = false;
    private GUIStyle guiStyle = new GUIStyle();

    // Start is called before the first frame update
    void Start()
    {
        casualties = Random.Range(1, total);
        if (crearRecursos.getFraccion())
        {
            winCondition = true;
        }
    }

    private void OnGUI()
    {
        string texto = "Una oleada de termitas arrasó con "+casualties+" árboles.\n";
        if (winCondition)
        {
            texto += "A pesar de esto, lograste sembrar al menos un tercio de árboles,\nasí que sobrevives (al menos otro día).";
        }
        else
        {
            texto += "Sin embargo, no lograste sembrar al menos un tercio de árboles, así que,\ncon recursos insuficientes para poder seguir, no sobrevivirás.";
        }
        guiStyle.fontSize = 20;
        guiStyle.alignment = TextAnchor.UpperCenter;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(-80, Screen.height / 2 - 25, 1000, 500), texto, guiStyle);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
