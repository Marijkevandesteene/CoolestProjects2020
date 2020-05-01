using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(CoinSystem))]
public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update

    

    private GameSystem _gameSystem = null;


    // coin system variables

    private CoinSystem _coinSystem = null;
    public Canvas _menuPanel = null;

    public Button _resetButton;
    public Button _cancelButton;

    // Menu system Variables

    private bool _menuActive = false;

    public GameObject _playerObject = null;
    private FirstPersonController _playerController = null;

    public CoinSystem coinSystem
    {
        get{

            if (!_coinSystem)
                this.GameInit();
            return this._coinSystem;
        
        }
        
    }

    public bool menuActive
    {
        get { return this._menuActive; }
    }


    public void GameInit()
    {
        Debug.Log("Initializing Game System : PlayerController");
        if (!_gameSystem)
            _gameSystem = new GameSystem();

        _coinSystem = this.GetComponent<CoinSystem>();
        _playerController = _playerObject.GetComponent<FirstPersonController>();

        this._menuPanel.enabled = false;

        if (_gameSystem && _coinSystem)
            Debug.Log("...Init of gamesystem and coinsystem done");

    }


    /*
     * Implementatie als singleton zodat er altijd maar 1 gamesystem is.
     */

    private GameSystem()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

        GameInit();
        _coinSystem.loadGame();

        //add listener button.onClick : script reference unity3D documentation
        Button resetbtn = _resetButton.GetComponent<Button>();
        resetbtn.onClick.AddListener(_coinSystem.resetGame);

        Button cancelbtn = _cancelButton.GetComponent<Button>();
        cancelbtn.onClick.AddListener(cancelMenu);

        if (cancelbtn && resetbtn)
            Debug.Log("...Init of _cancelButton and _resetButton done");

    }


    private void setMenuActive(bool active)
    {
        this._menuActive = active;
        this._menuPanel.enabled = _menuActive;

        if (_menuActive)
            this._playerController.enabled = false;
        else
            this._playerController.enabled = true;

    }

    public void cancelMenu()
    {
        this.setMenuActive(false);
    }

    private void FixedUpdate()
    {
        

        if (Input.GetKeyDown(KeyCode.F10) && _coinSystem.getLives() >= 1)
        {
            setMenuActive(!_menuActive);
        }
        if (_coinSystem.getLives() <= 0)
        {
            setMenuActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            _coinSystem.resetGame();
            _coinSystem.loadGame();
            setMenuActive(false);
        }

    }
}
