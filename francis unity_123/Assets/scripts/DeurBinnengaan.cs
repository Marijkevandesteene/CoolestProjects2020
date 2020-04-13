using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeurBinnengaan : MonoBehaviour
{

    public string LoadScene;
  //  public CoinSystem cs;

    // Start is called before the first frame update
    void Start()
    {
      //  cs = new CoinSystem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
          //  cs.save();
            SceneManager.LoadScene(LoadScene);
        }
        if (other.tag == "Start")
        {
           // cs.save();
            SceneManager.LoadScene("SampleScene");
        }
    }
}
