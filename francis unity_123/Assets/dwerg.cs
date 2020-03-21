using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dwerg : MonoBehaviour
{
    public GameObject ObjectToLookAt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ObjectToLookAt.transform);
    }
}
