using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSave : MonoBehaviour
{

    public int health = 0;
    public int lives = 10;
    public int chestContent = 0;
    public int collected = 0;
    public Text healthText;
    public Text livesText;
    public Text chestText;
    public Text collectedText;

    /// <summary>Static reference to the instance of our DataManager</summary>
    public static GameSave instance;

    public CoinSystem cs;
 
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
        DontDestroyOnLoad(gameObject);
   }
    
    // Start is called before the first frame update
    void Start()
    {
        cs = new CoinSystem();
        loadGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void logPlayerPrefs()
    {
       Debug.Log("Collected: " + this.collected + " - " + PlayerPrefs.GetInt("Collected"));
        Debug.Log("chestContent: " + this.chestContent + " - " + PlayerPrefs.GetInt("ChestContent"));
    }

    public void save()
    {
        Debug.Log("Save: ");
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.SetInt("ChestContent", chestContent);
  //      PlayerPrefs.SetInt("Collected", collected);
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.Save();
        logPlayerPrefs();
    }

    public void loadGame()
    {
        setHealth(PlayerPrefs.GetInt("Health"));
        setChestContent(PlayerPrefs.GetInt("ChestContent"));
        setCollected(PlayerPrefs.GetInt("Collected"));
        setLives(PlayerPrefs.GetInt("Lives"));
    //    Debug.Log("loading Game");
    //    logPlayerPrefs();
    }

    public void setHealth(int waarde)
    {
        this.health = waarde;
        this.healthText.text = "" + this.health;
    }

    public void setLives(int waarde)
    {
        this.lives = waarde;
        this.livesText.text = "" + this.lives;
    }


    public void setChestContent(int waarde)
    {
        this.chestContent = waarde;
        this.chestText.text = "" + this.chestContent;
    }

    public void setCollected(int waarde)
    {
        this.collected = waarde;
        this.collectedText.text = "" + this.collected;
    }

    public void increase5()
    {
        setHealth(health + 5);
        Debug.Log("logging increase5");

    }
}

