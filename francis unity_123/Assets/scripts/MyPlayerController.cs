using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyPlayerController : MonoBehaviour
{

    private GameSystem _gameSystem = null;
    private CoinSystem _coinSystem = null;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initializing Game System : PlayerController");
        _gameSystem = GameObject.FindObjectOfType<GameSystem>();       /// kan eigenlijk properder door een echte GameSystem Script / class te schrijven. kan je dan ook mandatory maken.
        _coinSystem = _gameSystem.coinSystem;

        if (_gameSystem && _coinSystem)
            Debug.Log("...Init of gamesystem and coinsystem done");



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
            _coinSystem.setCollected(_coinSystem.getCollected() + 1);


           // this.collected = this.collected + 1;
           // setCollected(this.collected);
        }
        else if (other.gameObject.CompareTag("chest"))
        {
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
        }
        else if (other.gameObject.CompareTag("smaragd"))
        {


            other.gameObject.SetActive(false);

            _coinSystem.setSmaragd(_coinSystem.getSmaragd()+1);

            //this.smaragd = this.smaragd + 1;
            //setSmaragd(this.smaragd);
        }
        _coinSystem.save();
    }

}
