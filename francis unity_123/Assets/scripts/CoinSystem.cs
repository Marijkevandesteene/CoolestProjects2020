using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class CoinSystem : MonoBehaviour
{
    private int count;
    private int coinsInChest;
    public Text countText;
    public Text chestText;


    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("collectedCoins");
        coinsInChest = PlayerPrefs.GetInt("coinsInChest");
        SetCountText();
        PlayerPrefs.SetInt("collectedCoins", 0);
        //PlayerPrefs.SetInt("coinsInChest", 0);
        //SetChestText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coins"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            PlayerPrefs.SetInt("collectedCoins", count);
            //PlayerController.collectedCoins = count;

        }
        else if (other.gameObject.CompareTag("chest"))
        {
            coinsInChest = coinsInChest + count;
            //PlayerPrefs.GetInt("coinsInChest") + PlayerPrefs.GetInt("collectedCoins");
            PlayerPrefs.SetInt("coinsInChest", coinsInChest);
            PlayerPrefs.SetInt("collectedCoins", 0);
            count = 0;
            SetChestText();
            SetCountText();
        }
        else if (other.gameObject.CompareTag("smaragd"))
        {
            other.gameObject.SetActive(false);
            count = count + 100;
            SetCountText();
            PlayerPrefs.SetInt("collectedCoins", count);
            //PlayerController.collectedCoins = count;

        }
    }


    void SetCountText()
    {
        countText.text = "coins: " + count.ToString();
    }

    void SetChestText()
    {
        chestText.text = "coins In chest: " + coinsInChest.ToString();
    }
}
