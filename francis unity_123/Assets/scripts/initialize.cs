using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class initialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey("coinsInChest");
        PlayerPrefs.SetInt("coinsInChest", 0);
        //SceneManager.LoadScene("PaddenstoelenKamer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
