using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    private float EndingSceneDelay = (60f * 10f); //10 minutos
    public static int totalarboles = 0;
    public static int sembrados = 0; //arboles que lleva sembrados el jugador
    // Start is called before the first frame update
    public Character personaje;
    private GUIStyle guiStyle = new GUIStyle(); //esto se hara jalando texts, no guis
    private GUIStyle guiLose = new GUIStyle();
    private float timeElapsed = 0;
    /* lo siguiente esta aqui solo para mientras, luego se pasara a resource spawner */
    public GameObject recurso;
    public float RangoCreacion = 20f;
    void Start () 
    {
        totalarboles = GameObject.FindGameObjectsWithTag("Tree").Length;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed>EndingSceneDelay)
        {
            if ((SceneManager.GetActiveScene().name).Equals("demo")){
                SceneManager.LoadScene(sceneName: "Oleada");
            }
        }

        if (Input.GetKeyDown(KeyCode.Z)) //Z para plantar
        {
            if (personaje.getPuntos() > 0)
            {
                Invoke("Crear", 1.0f);
                sembrados += 1;
                personaje.addPuntos(1);
            }
        }
        /* if ((SceneManager.GetActiveScene().name).Equals("demo")){
            ResourceSpawner.Create();
        }*/
    }

    void OnGUI()
    {
        GUI.Label(new Rect(50,0,100,50),"Recursos = " + personaje.getPuntos());
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 50), "Arboles =" + sembrados);
        /*if (totalarboles/arbol<=3) //menor o igual porque si es igual, es un tercio, si es menor es porque es mas de un tercio
        {
            guiStyle.fontSize = 50;
            GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 25, 1000, 500), "GANASTE",guiStyle);
        }*/
        if (personaje.getHealth() <= 0)
        {
            guiLose.fontSize = 50;
            guiLose.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 120, Screen.height / 2 - 25, 1000, 500), "PERDISTE", guiLose);
            SceneManager.LoadScene(sceneName: "MainMenu");
        }
    }
    public static bool getFraccion()
    {
        if (sembrados != 0)
        {
            return totalarboles / sembrados <= 0;
        }
        else
        {
            return false;
        }
        
    }
    public void Create(){
        Vector3 SpawnPosition = new Vector3 (0,0,0);
		SpawnPosition = personaje.transform.position - Random.onUnitSphere * RangoCreacion;
		SpawnPosition = new Vector3 (SpawnPosition.x, SpawnPosition.y, SpawnPosition.z);

		GameObject Recurso = Instantiate (recurso, SpawnPosition, Quaternion.identity);

    }
    public int getArboles(){return sembrados;}
}
