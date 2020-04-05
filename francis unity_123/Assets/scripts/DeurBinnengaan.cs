using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using GameSave;

public class DeurBinnengaan : MonoBehaviour
{

    public string LoadScene;
    public GameObject GameSaveObject;

    // Start is called before the first frame update
    void Start()
    {
        GameSaveObject = GameObject.Find("GameSave");
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
            GameSaveObject.GetComponent<GameSave>().save();
            SceneManager.LoadScene(LoadScene);
        }
        if (other.tag == "Start")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
