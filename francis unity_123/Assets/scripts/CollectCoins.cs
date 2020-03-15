using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoins : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

     void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }
 }
