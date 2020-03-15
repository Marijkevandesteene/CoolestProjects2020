using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class ChestManipulator : MonoBehaviour
{
    public GameObject ObjectToClose;
    // Start is called before the first frame update
    private IEnumerator coroutine;
    private Boolean chestOpen;

    void Start()
    {
        //coinsInChest = 0;
        chestOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("de kist wordt geraakt" + other.tag);
        if (other.tag == "Player")
        {
            if (chestOpen == true)
            {
                ObjectToClose.transform.Rotate(-45.0f, 0.0f, 0.0f, Space.Self);
                chestOpen = false;
            }
            else
            {
                ObjectToClose.transform.Rotate(45.0f, 0.0f, 0.0f, Space.Self);
                chestOpen = true;
            }
                
            //countInChest = countInChest + other.GetComponent<>
            //coroutine = WaitAndPrint(2.0f);
            //StartCoroutine(coroutine);
            //ObjectToClose.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
            //;
        }
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
        }
    }

}
