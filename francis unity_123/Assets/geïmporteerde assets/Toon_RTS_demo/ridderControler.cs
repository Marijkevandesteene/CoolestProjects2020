using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ridderControler : MonoBehaviour
{
    float snelheid = 1000f;
    //float draaisnelheid = 80;
    //float gravity = 8;
    //float draai = 0f;
    public GameObject ObjectToAttack;
    public Transform target;

    // Angular speed in radians per sec.
    public float speed = 1.0f;

    Vector3 beweeg = Vector3.zero;

    Animator anim;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
        target = ObjectToAttack.transform;
        anim.SetInteger("voorwaarde", 2);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 myPosition = transform.position;
        Vector3 FPSposition = ObjectToAttack.transform.position;
        float distance = Vector3.Distance(myPosition, FPSposition);
        float step = snelheid * Time.deltaTime; // calculate distance to move


        if (distance >= 1 && distance <= 15)
        {
            transform.LookAt(ObjectToAttack.transform);
        }
        if (distance <= 2)
        {
            anim.SetBool("aanvallen", true);
            anim.SetBool("lopen", false);
            anim.SetInteger("voorwaarde", 0);
        }
        else
        {
            anim.SetBool("aanvallen", false);
            if (anim.GetBool("lopen") != true)
            {
                anim.SetInteger("voorwaarde", 2);
            }
        }
        if (Input.GetKey(KeyCode.G))
        {
            if (anim.GetBool("aanvallen") == true)
            {
                return;
            } else
            {
                anim.SetBool("lopen", true);
                anim.SetInteger("voorwaarde", 1);
                beweeg = new Vector3(0, 0, -1);

                controller.Move(beweeg * Time.deltaTime);
            }
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            anim.SetBool("lopen", false);
            anim.SetInteger("voorwaarde", 2);
        }        
    }

    void Attacking() => StartCoroutine(AttackRoutine());
    IEnumerator AttackRoutine()
    {
        anim.SetBool("aanvallen", true);
        anim.SetInteger("voorwaarde", 2);
        yield return new WaitForSeconds(1);
        anim.SetInteger("voorwaarde", 0);
        anim.SetBool("aanvallen", false);
    }

}
