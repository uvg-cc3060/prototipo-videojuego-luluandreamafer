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
	public Transform[] plant;
	public bool[] isOnPlant;
	public GameObject sporePlant1;
	private Animator animator;




    // Start is called before the first frame update
    void Start()
    {
			timeElapsed =0;
			health = maxhealth;
			slider.value = CalculateHealth ();
			player = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void Update()
    {
		isOnPlant[0] = true;

		if (animator == null)
		{
			animator = plant[0].gameObject.GetComponentInChildren<Animator>();
			//animator = plant [1].gameObject.GetComponentInChildren<Animator> ();
		}

		timeElapsed += Time.deltaTime;

		if(timeElapsed>EndingSceneDelay)
		{
			lift.Switch = false;
		}

		if (timeElapsed >= 10f) {
			PlaySpell ();
			speed = 4.5f;
		} else {
			DisableSpores ();
		}

		if (timeElapsed > 20f) {
			PlaySpell ();
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
	public void DisableSpores()
	{
		sporePlant1.SetActive(false);

	}

	//Animations


	public void PlaySpell()
	{
		animator.SetTrigger("Spell");
		if (isOnPlant[0])
		{
			sporePlant1.SetActive(true);

		}




	}
	float CalculateHealth(){
		return health / maxhealth;
	}
}
