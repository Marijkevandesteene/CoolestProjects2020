using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dwerg : MonoBehaviour
{

    public Canvas _dwergBoodschap = null;
    private bool _messageActive = true;

    public GameObject ObjectToLookAt;
    
    // Start is called before the first frame update
    void Start()
    {
        //_dwergBoodschap.enabled = true;
        showMessage(true);
        Invoke("DisableText", 20f);//invoke after 5 seconds

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ObjectToLookAt.transform);
    }
    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.F6))
        {
            showMessage(!_messageActive);
        }

    }
    private void showMessage(bool active)
    {
        this._messageActive = active;
        this._dwergBoodschap.enabled = _messageActive;

  
    }
    private void DisableText()
    {
        this._dwergBoodschap.enabled = false;
    }


}
