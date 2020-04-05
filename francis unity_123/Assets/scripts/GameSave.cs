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

    // Start is called before the first frame update
    void Start()
    {
        loadGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void save()
    {
        PlayerPrefs.SetInt("Health", health);
        PlayerPrefs.SetInt("ChestContent", chestContent);
        PlayerPrefs.SetInt("Collected", collected);
        PlayerPrefs.SetInt("Lives", lives);

        PlayerPrefs.Save();
        Debug.Log("Saving Game");
    }

    public void loadGame()
    {
        setHealth(PlayerPrefs.GetInt("Health"));
        setChestContent(PlayerPrefs.GetInt("ChestContent"));
        setCollected(PlayerPrefs.GetInt("Collected"));
        setCollected(PlayerPrefs.GetInt("Lives"));
        Debug.Log("loading Game");
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
        //this.healthText.text = "" + this.health;
    }

    public void increase5()
    {
        setHealth(health + 5);
        Debug.Log("loggging increase5");

    }
}

