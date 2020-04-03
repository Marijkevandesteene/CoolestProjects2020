using System.Collections;
using System.Collections.Generic;
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
        Vector3 ridderPosition = transform.position;
        Vector3 myPosition = ObjectToAttack.transform.position;
        float distance = Vector3.Distance(ridderPosition, myPosition);

        if (distance <= 10)
        {
            transform.LookAt(ObjectToAttack.transform);

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
