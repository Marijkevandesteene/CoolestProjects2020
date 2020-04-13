using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class CoinSystem : MonoBehaviour
{
    private int health = 0;
    private int lives = 10;
    private int chestContent = 0;
    private int collected = 0;
    public Text healthText;
    public Text livesText;
    public Text chestText;
    public Text collectedText;

    /// <summary>Static reference to the instance of our DataManager</summary>
    public static CoinSystem instance;

    /// <summary>Awake is called when the script instance is being loaded.</summary>
    void Awake()
    {
        //Debug.Log("Before Awaking Game");
        //logPlayerPrefs();
        // If the instance reference has not been set, yet, 
        if (instance == null)
        {
            // Set this instance as the instance reference.
            instance = this;
        }
        else if (instance != this)
        {
            // If the instance reference has already been set, and this is not the
            // the instance reference, destroy this game object.
            Destroy(gameObject);
        }

        // Do not destroy this object, when we load a new scene.
        //DontDestroyOnLoad(gameObject)
    }

    // Start is called before the first frame update
    void Start()
    {
        loadGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void logPlayerPrefs()
    {
        Debug.Log("Collected: " + this.collected + " - PlayerPref: " + PlayerPrefs.GetInt("Collected"));
        Debug.Log("chestContent: " + this.chestContent + " - PlayerPref: " + PlayerPrefs.GetInt("ChestContent"));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coins"))
        {
            other.gameObject.SetActive(false);
            this.collected = this.collected + 1;
            setCollected(this.collected);
       }
        else if (other.gameObject.CompareTag("chest"))
        {
            this.chestContent = this.chestContent + this.collected;
            this.collected = 0;
            setChestContent(chestContent);
            setCollected(collected);
       }
        else if (other.gameObject.CompareTag("smaragd"))
        {
            other.gameObject.SetActive(false);
            this.collected = this.collected + 100;
            setCollected(this.collected);
       }
       save();
    }


    public void save()
    {
        PlayerPrefs.SetInt("ChestContent", this.chestContent);
        PlayerPrefs.SetInt("Collected", this.collected);
        PlayerPrefs.Save();
        //Debug.Log("Save: ");
        //logPlayerPrefs();
    }

    public void loadGame()
    {
        setChestContent(PlayerPrefs.GetInt("ChestContent"));
        setCollected(PlayerPrefs.GetInt("Collected"));
        setLives(PlayerPrefs.GetInt("Lives"));

    }

    public void setHealth(int waarde)
    {
        this.health = waarde;
        this.healthText.text = "" + this.health;
    }

    public void setLives(int waarde)
    {
        this.lives = waarde;
        this.livesText.text = "Lives: " + this.lives;
    }


    public void setChestContent(int waarde)
    {
        this.chestContent = waarde;
        Debug.Log("this.chestContent : " + this.chestContent.ToString());
        Debug.Log("this.chestText.text : " + this.chestText.text);
        this.chestText.text = "Coins in Chest: " + this.chestContent.ToString();
        Debug.Log("this.chestContent : " + this.chestContent);
    }

    private void setCollected(int waarde)
    {
        this.collected = waarde;
        this.collectedText.text = "Collected coins: " + this.collected.ToString();
     }

    public void resetGame()
    {
        this.setChestContent(0);
        this.setCollected(0);
        this.setLives(10);
        this.save();
        Debug.Log("New Game: ");
        logPlayerPrefs();

   }
}
