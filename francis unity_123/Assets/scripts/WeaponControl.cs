using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        if (Input.GetMouseButtonDown(0))
        {
            SwordAttack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            SecondAttack();
        }
    }
    public void SwordAttack()
    {
       Debug.Log(this.name + " is attacking");
        animator.SetTrigger("Base_Attack");
    }
    public void SecondAttack()
    {
       Debug.Log(this.name + " is attacking");
        animator.SetTrigger("Second_Attack");
    }
}
