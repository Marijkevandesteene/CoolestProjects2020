using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeurBinnengaan : MonoBehaviour
{

    public string LoadScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("we raken iets" + other.tag);
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(LoadScene);
        }
        if (other.tag == "Start")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
