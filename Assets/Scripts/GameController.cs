using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public static float EndingSceneDelay =   30f;//ahorita esta como 30 seg// (60f * 10f); //10 minutos
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
    public static int enemiesKilled = 0;
    public static int recursos =0;
    void Start () 
    {
        enemiesKilled = 0;
        timeElapsed =0;
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
            if (recursos > 0)
            {
                Invoke("Create", 1.0f);
                sembrados += 1;
                recursos -=1;
                personaje.addPuntos(1);
            }
        }
        /* if ((SceneManager.GetActiveScene().name).Equals("demo")){
            ResourceSpawner.Create();
        }*/
        if (enemiesKilled >= 3){
            SceneManager.LoadScene(sceneName: "BossBosque");
        }
        OnGUI();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(50,0,100,50),"Recursos = " + recursos);
        GUI.Label(new Rect(Screen.width - 100, 0, 100, 50), "Arboles =" + sembrados);
        GUI.Label(new Rect(Screen.width/2 +50,0,100,50), "Salud =" + personaje.getHealth());
        GUI.Label(new Rect(Screen.width/2 -100,0,100,50), "Enemigos matados =" + enemiesKilled);
        GUI.Label(new Rect(Screen.width/2 -400,0,100,50), "Tiempo para oleada =" + (EndingSceneDelay - timeElapsed));
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
        SpawnPosition.y =0;
		SpawnPosition = new Vector3 (SpawnPosition.x, SpawnPosition.y, SpawnPosition.z);

		GameObject Recurso = Instantiate (recurso, SpawnPosition, Quaternion.identity);

    }
    public void Crear(){
        Vector3 SpawnPosition = personaje.transform.position;
        SpawnPosition.y = 0;
        this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
		GameObject Recurso = Instantiate (recurso, SpawnPosition, Quaternion.identity);

	}
    public int getArboles(){return sembrados;}
}
