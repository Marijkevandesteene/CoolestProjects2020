using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

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
    NavMeshAgent nmagent;
    GameSystem _gameSystem = null;
    CoinSystem _coinSystem = null;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        controller = this.GetComponent<CharacterController>();
        nmagent = this.GetComponent<NavMeshAgent>();
        target = ObjectToAttack.transform;
        anim.SetInteger("voorwaarde", 2);

        _gameSystem = GameObject.FindObjectOfType<GameSystem>();
        _coinSystem = _gameSystem.coinSystem;

        if (_gameSystem && _coinSystem)
            Debug.Log("...Init of gamesystem and coinsystem done: riddercontroller");

    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }

    void Animate()
    {
        Vector3 myPosition = transform.position;
        Vector3 FPSposition = ObjectToAttack.transform.position;
        float distance = Vector3.Distance(myPosition, FPSposition);
 
        if (distance >= 2 && distance <= 15)
        {
            transform.LookAt(ObjectToAttack.transform);
            anim.SetBool("lopen", true);
            anim.SetInteger("voorwaarde", 1);
        }

        //voorwaarde 2 : idle
        //voorwaarde 1 : walk
        //voorwaarde 0 : attack

        if (distance <= 2.5)
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
    void OnTriggerEnter(Collider other)
        {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameSystem.coinSystem.damage(1);
        }

    }




}
