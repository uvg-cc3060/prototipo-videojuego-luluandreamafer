using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
	public float health;
	public float maxhealth;
	Transform player;
	public GameObject healthbarUI;
	public Slider slider;
	float speed = 3.0f;
	public levantarObjectos lift;
	private float EndingSceneDelay = 32f;
	private float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
		health = maxhealth;
		slider.value = CalculateHealth ();
		player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void Update()
    {


		timeElapsed += Time.deltaTime;

		if(timeElapsed>EndingSceneDelay)
		{
			lift.Switch = false;
		}

		if (timeElapsed > 10f) {
			speed = 4.5f;
		}

		if (timeElapsed > 20f) {
			speed = 6.5f;
		}

		if (timeElapsed >= 32f) {
			transform.rotation = Quaternion.Slerp (transform.rotation , Quaternion.LookRotation (player.position - transform.position) , 0.0f * Time.deltaTime);
			transform.position += transform.forward * 0.0f * Time.deltaTime;
		}
		transform.rotation = Quaternion.Slerp (transform.rotation , Quaternion.LookRotation (player.position - transform.position) , speed * Time.deltaTime);
		transform.position += transform.forward * speed * Time.deltaTime;


		slider.value = CalculateHealth ();
		if (health < maxhealth) {
			healthbarUI.SetActive (true);
		}

		if (health <= 0) {
			Destroy (gameObject);
		}
			

		if (health > maxhealth) {
			health = maxhealth;
		}
    }
	void OnTriggerEnter(Collider collision) {
		if (collision.tag=="Weapon") {
			health -= 10;
		}
		if (health == 0)
		{
			Destroy(this.gameObject);
		}

	}

	float CalculateHealth(){
		return health / maxhealth;
	}
}
