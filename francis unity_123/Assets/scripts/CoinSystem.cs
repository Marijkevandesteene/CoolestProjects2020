using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class CoinSystem : MonoBehaviour
{
    private int count;
    private int ChestContent;
    public Text countText;
    public Text chestText;

    public GameSave gs;
    
    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("Collected");
        ChestContent = PlayerPrefs.GetInt("ChestContent");
        gs = new GameSave();
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getCollected()
    {
        return this.count;    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coins"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            PlayerPrefs.SetInt("Collected", count);
 //           gs.setCollected(count);
         }
        else if (other.gameObject.CompareTag("chest"))
        {
            ChestContent = ChestContent + count;
            PlayerPrefs.SetInt("ChestContent", ChestContent);
            PlayerPrefs.SetInt("collected", 0);
            count = 0;
            SetChestText();
            SetCountText();

 //           gs.setChestContent(ChestContent);
 //           gs.setCollected(count);
        }
        else if (other.gameObject.CompareTag("smaragd"))
        {
            other.gameObject.SetActive(false);
            count = count + 100;
            SetCountText();
            PlayerPrefs.SetInt("Collected", count);
 //           gs.setCollected(count);
        }
        PlayerPrefs.Save();
    }


    void SetCountText()
    {
        countText.text = "coins: " + count.ToString();
    }

    void SetChestText()
    {
        chestText.text = "coins In chest: " + ChestContent.ToString();
    }
}
