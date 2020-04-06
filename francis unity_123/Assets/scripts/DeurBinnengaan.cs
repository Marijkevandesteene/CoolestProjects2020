using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeurBinnengaan : MonoBehaviour
{

    public string LoadScene;
 //   public GameObject GameSaveObject;
    public GameSave gs;

    // Start is called before the first frame update
    void Start()
    {
        gs = new GameSave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gs.save();
            SceneManager.LoadScene(LoadScene);
        }
        if (other.tag == "Start")
        {
            gs.save();
            SceneManager.LoadScene("SampleScene");
        }
    }
}
