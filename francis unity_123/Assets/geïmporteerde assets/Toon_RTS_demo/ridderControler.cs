using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ridderControler : MonoBehaviour
{
    float snelheid = 1;
    float draaisnelheid = 80;
    float gravity = 8;
    float draai = 0f;
    public GameObject ObjectToAttack;


    Vector3 beweeg = Vector3.zero;


    Animator anim;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.G))
        {
            if (anim.GetBool("aanvallen") == true)
            {
                return;
            }
            if (anim.GetBool("aanvallen") == false)
            {
                anim.SetBool("lopen", true);
                // ridder animatie 1 : anim.SetInteger("condition", 1);
                anim.SetInteger("voorwaarde", 1);
                beweeg = new Vector3(0, 0, -1);
                beweeg *= snelheid;
            }
         }

        /*if (Input.GetKey(KeyCode.G))
        {
            if (anim.GetBool("aanvallen") == true)
            {
                return;
            }
            if (anim.GetBool("aanvallen") == false)
            {
                anim.SetBool("lopen", true);
                // ridder animatie 1 : anim.SetInteger("condition", 1);
                anim.SetInteger("voorwaarde", 1);
                beweeg = new Vector3(0, 0, -1);
                beweeg *= snelheid;
            }
        }
        */

        if (Input.GetKeyUp(KeyCode.G))
        {
            anim.SetBool("lopen", false);
            anim.SetInteger("voorwaarde", 0);
            beweeg = new Vector3(0, 0, 0);
        }
        controller.Move(beweeg * Time.deltaTime);

    }
    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetBool("lopen")==true)
            {
                anim.SetBool("lopen", false);
                anim.SetInteger("voorwaarde", 0);
            }
            else if (anim.GetBool("lopen") == false)
            {
                Attacking();
            }
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
