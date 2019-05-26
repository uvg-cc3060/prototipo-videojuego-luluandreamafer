using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    

    public void nuevoJuego()
    {
        SceneManager.LoadScene("demo");
    }

    public void salir()
    {
        Application.Quit();
    }
}
