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
        PlayerPrefs.SetInt("Health", 0);
        PlayerPrefs.SetInt("Lives", 0);

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
        Debug.Log("Collected: " + this.collected + " - " + PlayerPrefs.GetInt("Collected"));
        Debug.Log("chestContent: " + this.chestContent + " - " + PlayerPrefs.GetInt("ChestContent"));
    }

    public void save()
    {
        PlayerPrefs.SetInt("ChestContent", this.chestContent);
        PlayerPrefs.SetInt("Collected", this.collected);
         //PlayerPrefs.SetInt("Health", health);
        //PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.Save();
        //Debug.Log("Save: ");
        //logPlayerPrefs();
    }

    public void loadGame()
    {
        setChestContent(PlayerPrefs.GetInt("ChestContent"));
        setCollected(PlayerPrefs.GetInt("Collected"));
        //setHealth(PlayerPrefs.GetInt("Health"));
        //setLives(PlayerPrefs.GetInt("Lives"));
        //Debug.Log("loading Game");
        //logPlayerPrefs();
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
        Debug.Log("waarde: " + waarde);
        Debug.Log("collected: " + this.collected);

        this.collected = waarde;
        this.collectedText.text = "" + this.collected;
        Debug.Log("waarde: " + waarde);
        Debug.Log("collected: " + this.collected);
    }

    public void increase5()
    {
        setHealth(health + 5);
        Debug.Log("logging increase5");

    }
}

