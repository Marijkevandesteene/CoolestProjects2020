using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Boss_Controller : MonoBehaviour
{
    public GameObject ObjectToAttack;
    //public Transform target;

    Vector3 beweeg = Vector3.zero;

    Animator anim;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
        //target = ObjectToAttack.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        Vector3 myPosition = transform.position;
        Vector3 playerPosition = ObjectToAttack.transform.position;
        Vector3 targetPosition = new Vector3(ObjectToAttack.transform.position.x,
                                                this.transform.position.y,
                                                ObjectToAttack.transform.position.z);
    
        float distance = Vector3.Distance(playerPosition, myPosition);

        if (distance <= 10 && distance > 1)
        {
            transform.LookAt(ObjectToAttack.transform);
            //new Vector3(ObjectToAttack.transform.position.x, transform.position.y, ObjectToAttack.transform.position.z)
            // te checken met Reinhart??? - transform.lookAt(targetPosition);
        }
        if (distance <= 3)
        {
            anim.SetBool("Boss_Attack", true);
        }
        else if (distance > 3)
        {
            anim.SetBool("Boss_Attack", false);
        }
    }
}
