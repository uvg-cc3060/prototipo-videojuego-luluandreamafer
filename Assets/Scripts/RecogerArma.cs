using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerArma : MonoBehaviour
{
    public Transform onHand;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (crearRecursos.hasWeapon==true)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
            this.transform.position = onHand.transform.position;
            this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
        }
    }
}
