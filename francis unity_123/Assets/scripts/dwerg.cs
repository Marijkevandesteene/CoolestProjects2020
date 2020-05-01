using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dwerg : MonoBehaviour
{

    public Canvas _dwergBoodschap = null;
    public Canvas _smaragdBoodschap = null;

    private bool _dwergBoodschapActive = true;
    private bool _smaragdBoodschapActive = true;

     public GameObject _objectToLookAt;
    private int _smaragd = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        this._smaragd = PlayerPrefs.GetInt("Smaragd");
        if (this._smaragd == 0)
        {
            showSmaragdBoodschap(false);
            showDwergBoodschap(true);
            Invoke("disableDwergBoodschap", 20f);//invoke after 5 seconds
        }
        else{
            Debug.Log("....Smaragdboodschap => smaragd = ?" + this._smaragd);
            showSmaragdBoodschap(true);
            showDwergBoodschap(false);
            Invoke("disableSmaragdBoodschap", 20f);//invoke after 5 seconds

        }

       
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_objectToLookAt.transform);
    }
    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.F6))
        {
            showDwergBoodschap(!_dwergBoodschapActive);
        }

    }
    private void showDwergBoodschap(bool active)
    {
        this._dwergBoodschapActive = active;
        this._dwergBoodschap.enabled = _dwergBoodschapActive;
    }

    private void showSmaragdBoodschap(bool active)
    {
        this._smaragdBoodschapActive = active;
        this._smaragdBoodschap.enabled = _smaragdBoodschapActive;
    }

    private void disableDwergBoodschap()
    {
        this._dwergBoodschap.enabled = false;
    }
    private void disableSmaragdBoodschap()
    {
        this._smaragdBoodschap.enabled = false;
    }


}
