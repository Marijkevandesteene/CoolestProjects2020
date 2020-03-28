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
        Vector3 ridderPosition = transform.position;
        Vector3 myPosition = ObjectToAttack.transform.position;
        float distance = Vector3.Distance(ridderPosition, myPosition);

        if (distance <= 10)
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
                // ridder animatie 1 : anim.SetInteger("condition", 1);
                anim.SetInteger("voorwaarde", 1);
                beweeg = new Vector3(0, 0, -1);
                beweeg *= snelheid;
            }
         }

       if (Input.GetKeyUp(KeyCode.G))
        {
            anim.SetBool("lopen", false);
            anim.SetInteger("voorwaarde", 0);
            beweeg = new Vector3(0, 0, 0);
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
    void Turn2Knight()
    {
        transform.LookAt(ObjectToAttack.transform);
    }

    void Turn2Knight_1()
    {
        
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
        

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
