using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerArma : MonoBehaviour
{
    public Transform onHand;
    private bool hitSomething = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Character.hasWeapon==true)
        {
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
            
            this.transform.position = onHand.transform.position;
            this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
            

            if (Input.GetMouseButtonDown(0) & !hitSomething)
            {
                
                this.transform.parent = null;

                this.transform.position += Camera.main.transform.forward*2;
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 20;
                Character.hasWeapon = false;


            }
            
        }
        /*if (this.transform.position.y <= 0.42)
        {
            Vector3 SpawnPosition = this.transform.position;
            SpawnPosition.y = 0.42f;
            this.transform.SetPositionAndRotation(SpawnPosition, Quaternion.identity);
        }*/
    }

    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.tag != "Player" & collision.tag!="Enemy") & !Character.hasWeapon)
        {
            hitSomething = true;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            hitSomething = false;
        }
        
        
    }


}
