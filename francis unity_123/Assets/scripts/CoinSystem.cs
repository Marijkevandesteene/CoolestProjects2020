using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class CoinSystem : MonoBehaviour
{
    private int health = 0;
    private int lives = 3;
    private int chestContent = 0;
    private int collected = 0;
    private int smaragd = 0;
    public Text healthText;
    public Text livesText;
    public Text chestText;
    public Text collectedText;
    public Text smaragdText;

    /// <summary>Static reference to the instance of our DataManager</summary>
    public static CoinSystem instance;

    /// <summary>Awake is called when the script instance is being loaded.</summary>
  /*  void Awake()
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
    */
    // Start is called before the first frame update
    void Initialize()
    {
        Debug.Log("Starting main gameloop");

        //resetGame();
        loadGame();
    }

  
    public void logPlayerPrefs()
    {
        Debug.Log("Collected: " + this.collected + " - PlayerPref: " + PlayerPrefs.GetInt("Collected"));
        Debug.Log("chestContent: " + this.chestContent + " - PlayerPref: " + PlayerPrefs.GetInt("ChestContent"));
        Debug.Log("lives: " + this.lives + " - PlayerPref: " + PlayerPrefs.GetInt("lives"));
        Debug.Log("smaragd: " + this.smaragd + " - PlayerPref: " + PlayerPrefs.GetInt("Smaragd"));
    }

  

    public void save()
    {
        PlayerPrefs.SetInt("ChestContent", this.chestContent);
        PlayerPrefs.SetInt("Collected", this.collected);
        PlayerPrefs.SetInt("Lives", this.lives);
        PlayerPrefs.SetInt("Smaragd", this.smaragd);
        PlayerPrefs.Save();
    }

    public void loadGame()
    {
        setChestContent(PlayerPrefs.GetInt("ChestContent"));
        setCollected(PlayerPrefs.GetInt("Collected"));
        setLives(PlayerPrefs.GetInt("Lives"));
        setSmaragd(PlayerPrefs.GetInt("Smaragd"));
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
        this.chestText.text = "Coins in Chest: " + this.chestContent.ToString();
    }

    public int getChestContent()
    {
        return this.chestContent;
    }

    public void increaseChestContent()
    {
        //
        this.chestContent = this.chestContent + this.collected;
        this.collected = 0;
        if (this.chestContent >= 10)
        {
            this.chestContent = this.chestContent - 10;
            this.lives = this.lives + 1;
        }
        setChestContent(this.chestContent);
        setLives(this.lives);
        setCollected(this.collected);
        /*  this.chestContent = this.chestContent + this.collected;
            if (this.chestContent >= 10)
            {
                this.chestContent = this.chestContent - 10;
                this.lives = this.lives + 1;
            }
            this.collected = 0;
            setChestContent(chestContent);
            setLives(lives);
            setCollected(collected);*/
        this.chestText.text = "Coins in Chest: " + this.chestContent.ToString();
    }

    public void setCollected(int waarde)
    {
        this.collected = waarde;
        this.collectedText.text = "Collected coins: " + this.collected.ToString();
     }

    public int getCollected()
    {
        return this.collected;
    }

    public void increaseCollected(int waarde)
    {
        this.collected = this.collected + waarde;
        this.collectedText.text = "Collected coins: " + this.collected.ToString();
    }

    public void setSmaragd(int waarde)
    {        
        this.smaragd = waarde;
        this.smaragdText.text = "Smaragd: " + this.smaragd.ToString();
    }

    public int getSmaragd ()
    {
        return this.smaragd;
    }
    public void resetGame()
    {
        Debug.Log("New Game: ");
        this.setChestContent(0);
        this.setCollected(0);
        this.setLives(3);
        this.setSmaragd(0);
        this.save();
        Debug.Log("New Game: ");
        //logPlayerPrefs();
   }
}
