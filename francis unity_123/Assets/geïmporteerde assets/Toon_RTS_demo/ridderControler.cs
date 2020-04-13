using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ridderControler : MonoBehaviour
{
    float snelheid = 0.000001f;
    float draaisnelheid = 80;
    float gravity = 8;
    float draai = 0f;
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
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //AttackMe();
        //Turn2Knight();

    }

    void Movement()
    {
        Vector3 myPosition = transform.position;
        Vector3 FPSposition = ObjectToAttack.transform.position;
        float distance = Vector3.Distance(myPosition, FPSposition);

        //if (distance <= 10)
        if (distance >= 1 && distance <= 10)
            {
            transform.LookAt(ObjectToAttack.transform);
        }
        if (Input.GetKey(KeyCode.G))
        {
            if (anim.GetBool("aanvallen") == true)
            {
                return;
            }
            if (anim.GetBool("aanvallen") == false)
            {
                anim.SetBool("lopen", true);
                anim.SetInteger("voorwaarde", 1);
               beweeg = Vector3.MoveTowards(myPosition, FPSposition, snelheid);                
            }
         }

       if (Input.GetKeyUp(KeyCode.G))
        {
            anim.SetBool("lopen", false);
            anim.SetInteger("voorwaarde", 0);
            beweeg = Vector3.MoveTowards(myPosition, FPSposition, snelheid);
        }
        controller.Move(beweeg * Time.deltaTime);

    }

    void AttackMe()
    {
        Vector3 ridderPosition = transform.position;
        Vector3 myPosition = ObjectToAttack.transform.position;
        float distance = Vector3.Distance(ridderPosition, myPosition);
 
        if (distance >= 2000000)
        {
            Vector3 offset = myPosition - ridderPosition;
            transform.rotation = Quaternion.LookRotation(
                 Vector3.forward, // Keep z+ pointing straight into the screen.
                offset           // Point y+ toward the target.
            );

            if (anim.GetBool("aanvallen") == true)
            {
                return;
            }
            if (anim.GetBool("aanvallen") == false)
            {
                anim.SetBool("lopen", true);
                anim.SetInteger("voorwaarde", 1);
                beweeg = new Vector3(0, 0, -1);
                beweeg *= snelheid;
            }
        }
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
